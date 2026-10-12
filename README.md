# unite-identity-data-migrations

Shared architecture, development workflows, and agent instructions:
[UNITE project documentation](https://github.com/dkfz-unite/.github/blob/main/README.md).

Code-first EF Core migrations for the PostgreSQL `unite_identity` database.
The model/context package lives in
[unite-identity-data](https://github.com/dkfz-unite/unite-identity-data); this
repository contains the migration history, model snapshot, design-time factory,
and console runner. Biomedical domain data uses a separate database and
[migration repository](https://github.com/dkfz-unite/unite-data-migrations).

## Project and configuration

`Unite.Identity.Data.Migrations` targets .NET 8 and references
`Unite.Identity.Data`. Its project file also contains a commented sibling
`ProjectReference` for local model development. Alternatively, publish a new
model package through `main` and update the package version here.

`IdentityDbContextFactory` provides the context for EF commands. SQL options use
`UNITE_SQL_HOST`, `UNITE_SQL_PORT`, `UNITE_SQL_USER`, and `UNITE_SQL_PASSWORD`.
Configure the local target; keep actual credentials out of committed docs.

## Local development

Settle the entity and explicit mapper changes in `unite-identity-data`, then
run EF commands from `Unite.Identity.Data.Migrations/`:

```sh
dotnet ef migrations add <name>
```

Prefer a short, single-word name. Review `Up()` and `Down()` and edit generated
operations when necessary to preserve/update existing data. Apply locally:

```sh
dotnet ef database update
```

Start the affected services and verify behavior before pushing this repository.
To revise the last unpublished local migration, return the local database to
the previous migration and remove the latest migration from the project:

```sh
dotnet ef database update <previous-migration>
dotnet ef migrations remove
```

Adjust the model/dependency, generate again, and repeat verification. This
records the owner's local development loop, not a procedure for rewriting
already shared/deployed migration history. See the
[EF Core CLI reference](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
for command syntax.

## Container execution

The Docker entry point runs `Unite.Identity.Data.Migrations.dll`. `Program.cs`
creates `IdentityDbContext` and calls `Database.Migrate()` to apply pending
migrations, then exits. There is no HTTP API or continuous worker.

[unite-env](https://github.com/dkfz-unite/unite-env) deploys this application
before its main service deployments. Current scripts launch containers in
detached mode without explicitly waiting for migration completion. The runner
logs caught migration errors without rethrowing or setting a failing exit code,
so container completion alone does not establish success. No runtime behavior
was changed while documenting this workflow.
