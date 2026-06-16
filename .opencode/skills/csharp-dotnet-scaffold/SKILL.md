---
name: csharp-dotnet-scaffold
description: Scaffolds Domain entities, repository interfaces/implementations, Fluent API configurations, and DI registrations for the OrganizadorCampeonato project. Use when the user says "create entity", "scaffold entity", "add repository", "generate persistence layer", or provides a structured entity definition with properties and relations.
---

# C# .NET Entity Scaffolding Skill

Scaffolds Domain entities, repository interfaces/implementations, Fluent API configurations, and DI registrations following the OrganizadorCampeonato project conventions. Works alongside the existing Clean Architecture layers.

## When to Use

Use this skill when the user says:
- "Create entity X with properties A, B, C"
- "Scaffold a new domain entity"
- "Add repository for X"
- "Generate the persistence layer for X"
- Any variant of creating a new entity + its supporting layers

## Input Format

The user provides a structured entity definition. Parse these fields:

```
Entity: <Name>
Type: simple | tph-persona | join-table
Properties:
  - <Name>(<Type>, required|optional, max:<N>|none)
Relations:
  - <Entity> has many|<one> <RelatedEntity> (FK: <FKProperty>, required|optional, onDelete: NoAction|Cascade)
CustomRepositoryMethods:
  - <ReturnType> <MethodName>(<params>)
```

### Entity Types

| Type | Detection | Pattern |
|------|-----------|---------|
| `simple` | Regular entity with own properties | Like `Categoria`, `Equipo` |
| `tph-persona` | Shares PK with Persona (FK is PK) | Like `Jugador`, `Entrenador`, `Arbitro` |
| `join-table` | Only 2 FKs, no intrinsic properties | Like `TorneoEquipo` |

### Supported Property Types

| Type | C# Type | DB Type |
|------|---------|---------|
| `string` | `string` | `nvarchar(max)` or `nvarchar(N)` if maxLength set |
| `int` | `int` | `int` |
| `decimal` | `decimal` | `decimal(18,2)` |
| `Guid` | `Guid` | `uniqueidentifier` |
| `DateTime` | `DateTime` | `datetime2` |
| `bool` | `bool` | `bit` |
| `enum:EnumName` | `EnumName` (enum type) | `int` |

## Workflow

### Step 1: Parse Entity Definition

Extract:
- `entityName` — PascalCase, singular
- `entityType` — `simple`, `tph-persona`, or `join-table`
- `properties` — name, type, required, maxLength
- `relations` — navigation property, related entity, cardinality, FK, required, onDelete
- `customRepositoryMethods` — method signatures to add to interface + implementation

### Step 2: Generate Domain Entity

**File:** `OrganizadorCampeonato.Dominio\Entidades\<EntityName>.cs`

Rules:
- Namespace: `OrganizadorCampeonato.Dominio.Entidades`
- Inherit: `EntidadAuditable<Guid>`
- Private parameterless constructor: `private <EntityName>() { }`
- Factory constructor: all scalar properties as parameters
- All scalar properties: `public <Type> <Name> { get; private set; }`
- Collections: `public List<<Related>> <Name> { get; private set; } = new();`
- Navigation to parent: `public <Related> <Name> { get; private set; } = null!;`
- ID assignment: `Guid id` as first parameter, passed to `base(id)`
- Validation: private `Validar<Property>` methods throwing `ExcepcionReglaDeNegocio`
- For required string properties: validate `string.IsNullOrWhiteSpace`
- For required Guid properties: validate `== Guid.Empty`
- Enums: use directly, no converter needed
- Collections initialized with `= new()`
- Navigation properties initialized with `= null!`

### Step 3: Generate Repository Interface

**File:** `OrganizadorCampeonato.Aplicacion\Contratos\Repositorios\IRepositorio<EntityName>.cs`

Rules:
- Namespace: `OrganizadorCampeonato.Aplicacion.Contratos.Repositorios`
- Interface: `public interface IRepositorio<EntityName> : IGenericRepository<EntityName, Guid>`
- Add custom methods from user input
- For `tph-persona` entities, add: `Task AsignarComo<EntityName>(Guid Id)` and `Task<IEnumerable<EntityName>> ObtenerTodos<EntityName>s()`
- Use `Task` for void-async, `Task<T>` for queries

### Step 4: Generate Repository Implementation

**File:** `OrganizadorCampeonato.Persistencia\Repositorios\Repositorio<EntityName>.cs`

Rules:
- Namespace: `OrganizadorCampeonato.Persistencia.Repositorios`
- Class: `public class Repositorio<EntityName> : Repositorio<EntityName, Guid>, IRepositorio<EntityName>`
- Constructor: `public Repositorio<EntityName>(ApplicationDbContext context) : base(context) { this.context = context; }`
- For custom methods, use `context.Set<EntityName>()` + EF Core
- For queries with includes, use `.Include(x => x.NavProp).ThenInclude(...)`
- Return `Task.FromResult(entity)` for sync operations in `Agregar`
- Do NOT call `SaveChanges()` in repository — use `IUnidadDeTrabajo.Persistir()` in handlers

### Step 5: Generate Entity Configuration

**File:** `OrganizadorCampeonato.Persistencia\Configuraciones\<EntityName>Configuration.cs`

Rules:
- Namespace: `OrganizadorCampeonato.Persistencia.Configuraciones`
- Class: `public class <EntityName>Configuration : IEntityTypeConfiguration<EntityName>`
- In `Configure(EntityTypeBuilder<EntityName> builder)`:
  - Scalar properties: `builder.Property(x => x.<Prop>).IsRequired().HasMaxLength(N)` (if string)
  - String without maxLength: `HasMaxLength(150)` default
  - Enum properties: no converter needed (stored as int)
  - Relationships: use `HasOne`, `HasMany`, `WithOne`, `WithMany`
  - All relationships: `.OnDelete(DeleteBehavior.NoAction)`
  - Required FK: `.IsRequired()` on the FK property in the relationship
  - Optional FK: no `.IsRequired()`
  - For `tph-persona`: configure the one-to-one on `PersonaConfiguration` side (see Step 6)
  - For join-table: two `HasOne().HasForeignKey()` relationships

### Step 6: Update PersonaConfiguration (tph-persona only)

**File:** `OrganizadorCampeonato.Persistencia\Configuraciones\PersonaConfiguration.cs`

If entity is `tph-persona` and a `HasOne().WithOne()` relationship is not already configured:

**ADD** to `PersonaConfiguration.Configure()`:
```csharp
builder.HasOne(p => p.<EntityName>)
       .WithOne(e => e.Persona)
       .HasForeignKey<<EntityName>>(p => p.Id)
       .OnDelete(DeleteBehavior.NoAction);
```

Also add navigation property to `Persona.cs`:
```csharp
public <EntityName>? <EntityName> { get; private set; } = null!;
```

And update `PersonaConfiguration.cs` to include the relationship.

### Step 7: Register DI

**File:** `OrganizadorCampeonato.Persistencia\RegistroDeServiciosDePersitencia.cs`

**ADD** after existing registrations:
```csharp
services.AddScoped<IRepositorio<EntityName>, Repositorio<EntityName>>();
```

Note: the filename has an intentional typo `Persitencia` — do NOT rename it.

### Step 8: Create Migration

Tell the user to run manually:
```bash
dotnet ef migrations add <MigrationName> --project OrganizadorCampeonato.Persistencia --startup-project OrganizadorCampeonato
```

Name format: `Add<EntityName>Entity` or `Add<EntityName>AndRelations` if it includes related entities.

### Step 9: Build Verification

```bash
dotnet build
```

If build fails, fix compilation errors before proceeding.

### Step 10: Undo/Revert

If the user wants to undo (remove entity + migration):

1. Remove the entity file: `OrganizadorCampeonato.Dominio\Entidades\<EntityName>.cs`
2. Remove the repository interface: `OrganizadorCampeonato.Aplicacion\Contratos\Repositorios\IRepositorio<EntityName>.cs`
3. Remove the repository implementation: `OrganizadorCampeonato.Persistencia\Repositorios\Repositorio<EntityName>.cs`
4. Remove the configuration: `OrganizadorCampeonato.Persistencia\Configuraciones\<EntityName>Configuration.cs`
5. Remove the DI registration from `RegistroDeServiciosDePersitencia.cs`
6. Revert `PersonaConfiguration.cs` if it was modified for tph-persona
7. Run: `dotnet ef migrations remove --project OrganizadorCampeonato.Persistencia --startup-project OrganizadorCampeonato --force`

## Property Validation Rules

| Type | Required Check | Optional Check |
|------|---------------|----------------|
| `string` | `string.IsNullOrWhiteSpace(value)` → error | allow `null`/`""` |
| `Guid` | `value == Guid.Empty` → error | allow `Guid?` |
| `int/decimal` | check `<= 0` if positive required | allow nullable |
| `DateTime` | check `default` / `DateTime.MinValue` | allow nullable |
| `enum` | check `!Enum.IsDefined(typeof(EnumType), value)` | allow nullable enum |

## Conventions Summary

| Aspect | Rule |
|--------|------|
| Entity ID | Always `Guid`, received as first parameter and passed to `base(id)` |
| Property setters | Always `private set` |
| Collection inits | `= new()` |
| Nav property inits | `= null!` |
| Constructor | Private parameterless + public factory |
| Relationships | All `DeleteBehavior.NoAction` |
| FK naming | `<RelatedEntity>Id` (e.g., `CategoriaId`) |
| Repository naming | `IRepositorio<EntityName>`, `Repositorio<EntityName>` |
| Namespace | `OrganizadorCampeonato.Dominio.Entidades`, `OrganizadorCampeonato.Aplicacion.Contratos.Repositorios`, `OrganizadorCampeonato.Persistencia.Repositorios` |

## Example Prompts

**Simple entity:**
```
Entity: Partido
Type: simple
Properties:
  - Nombre(string, required, max: 150)
  - Fecha(DateTime, required)
  - Estado(EstadoPartido enum, required)
  - Division(string, optional, max: 50)
Relations:
  - Partido has one Arbitro (FK: ArbitroId, optional, onDelete: NoAction)
  - Partido has many PartidoEquipo (one-to-many via PartidoEquipo)
```

**Join table:**
```
Entity: PartidoEquipo
Type: join-table
Properties: none beyond audit
Relations:
  - PartidoEquipo belongs to Partido (FK: PartidoId, required)
  - PartidoEquipo belongs to Equipo (FK: EquipoId, required)
```

**TPH with Persona:**
```
Entity: Arbitro
Type: tph-persona
Properties: none beyond audit
Relations:
  - Arbitro belongs to Persona (one-to-one, PK shared with Persona)
```

**Complex entity with custom repo methods:**
```
Entity: Equipo
Type: simple
Properties:
  - Nombre(string, required, max: 150)
  - Ciudad(string, optional, max: 100)
Relations:
  - Equipo has one Entrenador (FK: EntrenadorId, optional, onDelete: NoAction)
  - Equipo has many PartidoEquipo
CustomRepositoryMethods:
  - Task<IEnumerable<Equipo>> ObtenerTodosConEntrenador()
  - Task<bool> ExistePorNombre(string nombre)
```

## Template Files

Reference templates in `templates/` folder:
- `entity-template.txt` — Domain entity boilerplate
- `repository-interface-template.txt` — IRepositorio interface
- `repository-impl-template.txt` — Repository implementation
- `configuration-template.txt` — Fluent API configuration
- `di-registration-template.txt` — DI registration snippet
