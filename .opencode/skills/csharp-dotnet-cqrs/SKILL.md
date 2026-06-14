# CQRS Use Case Generator Skill

This skill generates complete CQRS use cases (commands, queries, handlers, DTOs, and mappers) for the OrganizadorCampeonato project following Clean Architecture and CQRS patterns.

## When to Use

Use this skill when the user requests:
- "Generate CQRS for entity X"
- "Create use cases for entity X"
- "Add CRUD operations for entity X"
- "Generate commands and queries for entity X"

## Input Format

The user provides an entity name and specifies which use cases to generate:

```
Generate CQRS for entity: <EntityName>
Use cases: create, update, delete, get-all, get-by-id, get-paginated, assign
Properties:
  - PropertyName(Type, required|optional, max:N)
  - RelatedId(Guid?, optional)
  - Estado(EnumType enum, required)
Relations:
  - NavigationProperty -> RelatedEntity
```

## Supported Use Case Types

| Type | Description | Handler Interface | Returns |
|------|-------------|-------------------|---------|
| `create` | Create new entity | `IRequestHandler<Comando*, Guid>` | `Task<Guid>` |
| `update` | Update existing entity | `IRequestHandler<Comando*>` | `Task` |
| `delete` | Delete entity | `IRequestHandler<Comando*>` | `Task` |
| `get-by-id` | Get single entity by ID | `IRequestHandler<Consulta*, EntityDTO>` | `Task<EntityDTO>` |
| `get-all` | Get all entities | `IRequestHandler<Consulta*, List<Listado*DTO>>` | `Task<List<DTO>>` |
| `get-paginated` | Get paginated results | `IRequestHandler<Consulta*, PaginadoDTO<Listado*DTO>>` | `Task<PaginadoDTO<T>>` |
| `assign` | Assign relationship (e.g., assign player to team) | `IRequestHandler<Comando*>` | `Task` |

## File Structure Generated

```
OrganizadorCampeonato.Aplicacion\CasosDeUso\<EntityName>\
├── Comandos\
│   ├── Agregar<EntityName>\
│   │   ├── ComandoAgregar<EntityName>.cs
│   │   └── CasoDeUsoAgregar<EntityName>.cs
│   ├── Actualizar<EntityName>\
│   │   ├── ComandoActualizar<EntityName>.cs
│   │   └── CasoDeUsoActualizar<EntityName>.cs
│   └── Eliminar<EntityName>\
│       ├── ComandoEliminar<EntityName>.cs
│       └── CasoDeUsoEliminar<EntityName>.cs
└── Consultas\
    ├── ObtenerTodos<EntityName>s\
    │   ├── ConsultaObtenerTodos<EntityName>s.cs
    │   ├── CasoDeUsoObtenerTodos<EntityName>s.cs
    │   ├── Listado<EntityName>DTO.cs
    │   └── Mapeador<Listado<EntityName>.cs
    └── Obtener<EntityName>PorId\
        ├── ConsultaObtener<EntityName>PorId.cs
        ├── CasoDeUsoObtener<EntityName>PorId.cs
        ├── <EntityName>DTO.cs
        └── Mapeador<EntityName>.cs
```

## Workflow

### Step 1: Parse User Input

Extract from user request:
- `entityName` - PascalCase, singular (e.g., "Partido")
- `useCases` - list of operations to generate
- `properties` - entity properties with types and constraints
- `relations` - navigation properties to related entities

### Step 2: Generate Command Files (for write operations)

For each command (create, update, delete, assign):

**Command file** (`Comando<Operation><EntityName>.cs`):
- Use `record` syntax with positional parameters
- Implement `IRequest<Guid>` for create, `IRequest` for others
- Include all required properties

**Handler file** (`CasoDeUso<Operation><EntityName>.cs`):
- Implement `IRequestHandler<Comando*, TResponse>`
- Inject `IRepositorio<EntityName>` and `IUnidadDeTrabajo`
- Follow pattern: Validate → Create/Update → try { Persistir } catch { Reversar }
- For update: use domain entity's `Set*` or `Actualizar*` methods
- Throw `ExcepcionDeValidacion` for validation errors

### Step 3: Generate Query Files (for read operations)

For each query (get-by-id, get-all, get-paginated):

**Query file** (`Consulta<Operation><EntityName>.cs`):
- Use `record` syntax
- Implement `IRequest<TResponse>` where TResponse is DTO or List<DTO>

**Handler file** (`CasoDeUso<Operation><EntityName>.cs`):
- Implement `IRequestHandler<Consulta*, TResponse>`
- Inject only `IRepositorio<EntityName>` (no IUnidadDeTrabajo)
- Call repository method and map to DTO using `.ADto()` extension

**DTO file** (`<EntityName>DTO.cs` or `Listado<EntityName>DTO.cs`):
- Use `record` syntax
- Include all properties needed for display
- Use `required` keyword for non-nullable strings

**Mapper file** (`Mapeador<EntityName>.cs`):
- Static class with static extension method `ADto()`
- Map entity properties to DTO properties
- Handle navigation properties safely with `?.` operator

### Step 4: Build and Verify

Run `dotnet build` to verify all generated code compiles correctly.

## Code Patterns

### Command Pattern (Create)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Comandos.Agregar<EntityName>;

public record ComandoAgregar<EntityName>(
    required string Nombre,
    Guid? RelatedId,
    EstadoEnum Estado
) : IRequest<Guid>;
```

### Command Pattern (Update)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Comandos.Actualizar<EntityName>;

public record ComandoActualizar<EntityName>(
    Guid Id,
    required string Nombre,
    Guid? RelatedId
) : IRequest;
```

### Command Pattern (Delete)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Comandos.Eliminar<EntityName>;

public record ComandoEliminar<EntityName>(Guid Id) : IRequest;
```

### Query Pattern (Get All)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Consultas.ObtenerTodos<EntityName>s;

public record ConsultaObtenerTodos<EntityName>s : IRequest<List<Listado<EntityName>DTO>>;
```

### Query Pattern (Get By ID)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Consultas.Obtener<EntityName>PorId;

public record ConsultaObtener<EntityName>PorId(Guid Id) : IRequest<<EntityName>DTO>;
```

### Query Pattern (Get Paginated)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Comunes.Dtos;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Consultas.ObtenerTodosPaginados<EntityName>s;

public record ConsultaObtenerTodosPaginados<EntityName>s(
    int PageNumber = 1,
    int PageSize = 10
) : IRequest<PaginadoDTO<Listado<EntityName>DTO>>;
```

### Handler Pattern (Create Command)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Comandos.Agregar<EntityName>;

public class CasoDeUsoAgregar<EntityName> : IRequestHandler<ComandoAgregar<EntityName>, Guid>
{
    private readonly IRepositorio<EntityName> repositorio;
    private readonly IUnidadDeTrabajo unidadDeTrabajo;

    public CasoDeUsoAgregar<EntityName>(
        IRepositorio<EntityName> repositorio,
        IUnidadDeTrabajo unidadDeTrabajo)
    {
        this.repositorio = repositorio;
        this.unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task<Guid> Handle(ComandoAgregar<EntityName> request, CancellationToken cancellationToken)
    {
        // 1. Validate uniqueness or business rules
        if (await repositorio.ExistePorNombre(request.Nombre))
            throw new ExcepcionDeValidacion("Ya existe un registro con ese nombre");

        // 2. Create entity via domain constructor
        var entity = new <EntityName>(request.Nombre, request.RelatedId);

        // 3. Persist with transaction pattern
        try
        {
            await repositorio.Agregar(entity);
            await unidadDeTrabajo.Persistir();
            return entity.Id;
        }
        catch (Exception)
        {
            await unidadDeTrabajo.Reversar();
            throw;
        }
    }
}
```

### Handler Pattern (Update Command)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Excepciones;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Comandos.Actualizar<EntityName>;

public class CasoDeUsoActualizar<EntityName> : IRequestHandler<ComandoActualizar<EntityName>>
{
    private readonly IRepositorio<EntityName> repositorio;
    private readonly IUnidadDeTrabajo unidadDeTrabajo;

    public CasoDeUsoActualizar<EntityName>(
        IRepositorio<EntityName> repositorio,
        IUnidadDeTrabajo unidadDeTrabajo)
    {
        this.repositorio = repositorio;
        this.unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task Handle(ComandoActualizar<EntityName> request, CancellationToken cancellationToken)
    {
        // 1. Fetch entity
        var entity = await repositorio.ObtenerPorId(request.Id);
        if (entity is null)
            throw new ExcepcionDeValidacion("No se encontró el registro");

        // 2. Update using domain model methods (Set* or Actualizar*)
        entity.ActualizarNombre(request.Nombre);
        entity.ActualizarRelatedId(request.RelatedId);

        // 3. Persist with transaction pattern
        try
        {
            await repositorio.Actualizar(entity);
            await unidadDeTrabajo.Persistir();
        }
        catch (Exception)
        {
            await unidadDeTrabajo.Reversar();
            throw;
        }
    }
}
```

### Handler Pattern (Delete Command)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Excepciones;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Comandos.Eliminar<EntityName>;

public class CasoDeUsoEliminar<EntityName> : IRequestHandler<ComandoEliminar<EntityName>>
{
    private readonly IRepositorio<EntityName> repositorio;
    private readonly IUnidadDeTrabajo unidadDeTrabajo;

    public CasoDeUsoEliminar<EntityName>(
        IRepositorio<EntityName> repositorio,
        IUnidadDeTrabajo unidadDeTrabajo)
    {
        this.repositorio = repositorio;
        this.unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task Handle(ComandoEliminar<EntityName> request, CancellationToken cancellationToken)
    {
        // 1. Fetch entity
        var entity = await repositorio.ObtenerPorId(request.Id);
        if (entity is null)
            throw new ExcepcionDeValidacion("No se encontró el registro");

        // 2. Delete with transaction pattern
        try
        {
            await repositorio.Eliminar(entity);
            await unidadDeTrabajo.Persistir();
        }
        catch (Exception)
        {
            await unidadDeTrabajo.Reversar();
            throw;
        }
    }
}
```

### Handler Pattern (Get All Query)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Consultas.ObtenerTodos<EntityName>s;

public class CasoDeUsoObtenerTodos<EntityName>s : IRequestHandler<ConsultaObtenerTodos<EntityName>s, List<Listado<EntityName>DTO>>
{
    private readonly IRepositorio<EntityName> repositorio;

    public CasoDeUsoObtenerTodos<EntityName>s(IRepositorio<EntityName> repositorio)
    {
        this.repositorio = repositorio;
    }

    public async Task<List<Listado<EntityName>DTO>> Handle(
        ConsultaObtenerTodos<EntityName>s request,
        CancellationToken cancellationToken)
    {
        var entities = await repositorio.ObtenerTodos();
        return entities.Select(x => x.ADto()).ToList();
    }
}
```

### Handler Pattern (Get By ID Query)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Consultas.Obtener<EntityName>PorId;

public class CasoDeUsoObtener<EntityName>PorId : IRequestHandler<ConsultaObtener<EntityName>PorId, <EntityName>DTO>
{
    private readonly IRepositorio<EntityName> repositorio;

    public CasoDeUsoObtener<EntityName>PorId(IRepositorio<EntityName> repositorio)
    {
        this.repositorio = repositorio;
    }

    public async Task<<EntityName>DTO> Handle(
        ConsultaObtener<EntityName>PorId request,
        CancellationToken cancellationToken)
    {
        var entity = await repositorio.ObtenerPorId(request.Id);
        if (entity is null)
            throw new ExcepcionDeValidacion("No se encontró el registro");

        return entity.ADto();
    }
}
```

### Handler Pattern (Get Paginated Query)

```csharp
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Comunes.Dtos;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Consultas.ObtenerTodosPaginados<EntityName>s;

public class CasoDeUsoObtenerTodosPaginados<EntityName>s : IRequestHandler<ConsultaObtenerTodosPaginados<EntityName>s, PaginadoDTO<Listado<EntityName>DTO>>
{
    private readonly IRepositorio<EntityName> repositorio;

    public CasoDeUsoObtenerTodosPaginados<EntityName>s(IRepositorio<EntityName> repositorio)
    {
        this.repositorio = repositorio;
    }

    public async Task<PaginadoDTO<Listado<EntityName>DTO>> Handle(
        ConsultaObtenerTodosPaginados<EntityName>s request,
        CancellationToken cancellationToken)
    {
        var (entities, total) = await repositorio.ObtenerPaginado(request.PageNumber, request.PageSize);
        
        return new PaginadoDTO<Listado<EntityName>DTO>
        {
            Items = entities.Select(x => x.ADto()).ToList(),
            TotalCount = total,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
```

### DTO Pattern (List DTO)

```csharp
namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Consultas.ObtenerTodos<EntityName>s;

public record Listado<EntityName>DTO
{
    public Guid Id { get; init; }
    public required string Nombre { get; init; }
    public string? RelatedNombre { get; init; }
    public EstadoEnum Estado { get; init; }
    public DateTime FechaCreacion { get; init; }
}
```

### DTO Pattern (Single Entity DTO)

```csharp
namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Consultas.Obtener<EntityName>PorId;

public record <EntityName>DTO
{
    public Guid Id { get; init; }
    public required string Nombre { get; init; }
    public Guid? RelatedId { get; init; }
    public string? RelatedNombre { get; init; }
    public EstadoEnum Estado { get; init; }
    public DateTime FechaCreacion { get; init; }
    public DateTime? FechaModificacion { get; init; }
}
```

### Mapper Pattern (Extension Methods)

```csharp
using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Consultas.ObtenerTodos<EntityName>s;

public static class Mapeador<Listado<EntityName>
{
    public static Listado<EntityName>DTO ADto(this <EntityName> entity) => new()
    {
        Id = entity.Id,
        Nombre = entity.Nombre,
        RelatedNombre = entity.Related?.Nombre,
        Estado = entity.Estado,
        FechaCreacion = entity.FechaCreacion
    };
}
```

### Mapper Pattern (Single Entity)

```csharp
using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.<EntityName>.Consultas.Obtener<EntityName>PorId;

public static class Mapeador<EntityName>
{
    public static <EntityName>DTO ADto(this <EntityName> entity) => new()
    {
        Id = entity.Id,
        Nombre = entity.Nombre,
        RelatedId = entity.RelatedId,
        RelatedNombre = entity.Related?.Nombre,
        Estado = entity.Estado,
        FechaCreacion = entity.FechaCreacion,
        FechaModificacion = entity.FechaModificacion
    };
}
```

## Key Conventions

| Aspect | Rule |
|--------|------|
| Command syntax | `record Comando*(...) : IRequest<Guid>` or `: IRequest` |
| Query syntax | `record Consulta* : IRequest<List<DTO>>` or `: IRequest<DTO>` |
| Handler DI | `IRepositorio<EntityName>` + `IUnidadDeTrabajo` (write) or only `IRepositorio` (read) |
| Write pattern | Validate → Create → try { Persistir } catch { Reversar } |
| Read pattern | `repositorio.ObtenerTodos()` or `ObtenerPorId()` → Select `.ADto()` |
| Update pattern | Domain entity `Set*` / `Actualizar*` methods, no direct property assignment |
| Mapper | `Mapeador<EntityName>` static class with `ADto()` extension method |
| Null check | `throw new ExcepcionDeValidacion("No se encontró...")` |
| Namespace | `OrganizadorCampeonato.Aplicacion.CasosDeUso.<Entity>.Comandos.*` or `Consultas.*` |

## Example Prompts

### Simple Entity (All CRUD)

```
Generate CQRS for entity: Partido
Use cases: create, update, delete, get-all, get-by-id
Properties:
  - Nombre(string, required, max: 150)
  - Fecha(DateTime, required)
  - Estado(EstadoPartido enum, required)
  - Division(string, optional, max: 50)
Relations:
  - Arbitro -> Arbitro
  - PartidoEquipos -> List<PartidoEquipo>
```

### Read-Only Entity

```
Generate CQRS for entity: Categoria
Use cases: get-all, get-by-id
Properties:
  - Nombre(string, required, max: 100)
  - Descripcion(string, optional)
Relations:
  - Torneos -> List<Torneo>
```

### Write-Only Entity

```
Generate CQRS for entity: Inscripcion
Use cases: create, delete
Properties:
  - JugadorId(Guid, required)
  - TorneoId(Guid, required)
  - FechaInscripcion(DateTime, required)
Relations:
  - Jugador -> Jugador
  - Torneo -> Torneo
```

## Template Files

- `templates/command-template.txt` - Command record boilerplate
- `templates/query-template.txt` - Query record boilerplate
- `templates/handler-command-template.txt` - Command handler pattern
- `templates/handler-query-template.txt` - Query handler pattern
- `templates/dto-template.txt` - DTO record pattern
- `templates/mapper-template.txt` - Mapper extension method pattern

## Validation Rules

When generating use cases:

1. **Create commands** should validate:
   - Uniqueness constraints (e.g., name already exists)
   - Required relationships exist (e.g., RelatedId is valid)
   - Business rules from domain entity constructor

2. **Update commands** should:
   - Verify entity exists before updating
   - Use domain entity's `Set*` or `Actualizar*` methods
   - Never directly assign properties

3. **Delete commands** should:
   - Verify entity exists before deleting
   - Check for dependent records if needed

4. **Query handlers** should:
   - Never inject `IUnidadDeTrabajo`
   - Always use mapper extension methods
   - Throw `ExcepcionDeValidacion` if entity not found (for get-by-id)

## Common Mistakes to Avoid

1. ❌ Don't use `class` for commands/queries - use `record`
2. ❌ Don't inject `IUnidadDeTrabajo` in query handlers
3. ❌ Don't directly assign entity properties in update handlers
4. ❌ Don't forget to call `Reversar()` in catch blocks
5. ❌ Don't forget to use `.ADto()` extension method for mapping
6. ❌ Don't use `required` keyword on Guid properties (they have defaults)
7. ❌ Don't forget to add `CancellationToken` parameter to handler methods

## Integration with Other Skills

This skill works with:
- `csharp-dotnet-scaffold` - Generate domain entities and repositories first
- Then use this skill to generate use cases for those entities

## Undo/Revert

To remove generated use cases:

1. Delete the entire `CasosDeUso/<EntityName>/` folder
2. Run `dotnet build` to verify no broken references
3. Remove any controller endpoints that reference the deleted use cases
