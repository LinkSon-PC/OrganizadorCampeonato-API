# AGENTS.md

## Build & Run

```
dotnet build
dotnet run --project OrganizadorCampeonato
dotnet test
```

## EF Core Migrations

The startup project is the API (`OrganizadorCampeonato`), the migrations project is `OrganizadorCampeonato.Persistencia`:

```
dotnet ef migrations add <Name> --project OrganizadorCampeonato.Persistencia --startup-project OrganizadorCampeonato
dotnet ef database update --project OrganizadorCampeonato.Persistencia --startup-project OrganizadorCampeonato
```

## Architecture

.NET 9 ASP.NET Core Web API. Clean Architecture with four projects:

| Project | Role |
|---|---|
| `OrganizadorCampeonato/` | API layer — controllers, `Program.cs`, `appsettings` |
| `OrganizadorCampeonato.Aplicacion/` | Application — CQRS use cases, custom mediator, DI registration |
| `OrganizadorCampeonato.Dominio/` | Domain — entities, enums, exceptions, `EntidadAuditable<T>` |
| `OrganizadorCampeonato.Persistencia/` | Infrastructure — EF Core + SQL Server, repositories, migrations |

Dependency flow: API → Aplicacion + Persistencia; Persistencia → Aplicacion + Dominio; Aplicacion → Dominio.

## Key Patterns

- **Custom mediator** (NOT MediatR): `IMediator`, `IRequest`, `IRequestHandler` in `Aplicacion/Comunes/Mediator/`. Do not add the MediatR NuGet package.
- **CQRS structure**: each entity has `CasosDeUso/<Entity>/Comandos/` and `CasosDeUso/<Entity>/Consultas/`. Each use case is a folder containing a `Comando*`/`Consulta*` (the request) and a `CasoDeUso*` (the handler implementing `IRequestHandler`).
- **Handler auto-registration**: Scrutor scans the Aplicacion assembly for `IRequestHandler<>` and `IRequestHandler<,>` implementations. New handlers are picked up automatically.
- **Entity configuration**: Fluent API in `Persistencia/Configuraciones/`, applied via `ApplyConfigurationsFromAssembly`.
- **Audit fields**: all entities inherit `EntidadAuditable<Guid>`. `FechaCreacion` and `UltimaFechaModificacion` are auto-set in `ApplicationDbContext.SaveChangesAsync`.

## Conventions

- All domain/application code uses **Spanish naming**: Comandos, Consultas, CasoDeUso, Repositorio, UnidadDeTrabajo, etc. Follow this convention.
- Controllers inject `IMediator` and delegate to use cases via `mediator.Send()`.
- Repository interfaces live in `Aplicacion/Contratos/Repositorios/`; implementations in `Persistencia/Repositorios/`.
- New repositories must be registered manually in `RegistroDeServiciosDePersitencia.cs` (note: typo in filename is intentional, do not rename).

## Testing

- Framework: **MSTest** + **NSubstitute** for mocking.
- Test project: `OrganizadorCampeonato.Tests/` (the `OrganizadorCampeonato.Test/` directory is empty and unused).
- Run a single test: `dotnet test --filter "FullyQualifiedName~<TestClassName>"`

## Database

- SQL Server (LocalDB/Express). Connection string `DefaultConnection` is in `appsettings.Development.json`.
- The connection string targets `TONY\SQLEXPRESS` — update for your local instance.
