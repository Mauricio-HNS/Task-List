# Task Management — ASP.NET Core + Angular

Task management application with an ASP.NET Core backend and Angular frontend.

## Why this repository matters

This project is one of the transition points in my development history: it started from a straightforward task-management application and evolved into a more structured web solution with authentication, SQL Server persistence and Microsoft identity integration.

I keep the repository because it shows the progression from CRUD applications toward authenticated, production-oriented web systems.

## Architecture

```text
Angular UI
    │
    ▼
ASP.NET Core
    ├── Authentication / Authorization
    ├── Task management
    └── Entity Framework Core
            │
            ▼
        SQL Server
```

## Current stack

- .NET 8 / ASP.NET Core
- Entity Framework Core
- SQL Server
- Microsoft Identity Web
- OpenID Connect
- Angular
- TypeScript

## Running the backend

From the backend directory:

```bash
dotnet restore
dotnet run
```

Configure the connection string and identity settings through local configuration/user secrets. Do not commit credentials.

## Running the frontend

From the Angular application directory:

```bash
npm install
ng serve
```

The Angular application should point to the running ASP.NET Core API.

## Engineering evolution

```text
CRUD
 ↓
Layered application
 ↓
Authentication
 ↓
Identity integration
 ↓
Persistence and migrations
 ↓
Cloud-ready application architecture
```

## Status

Maintained as a portfolio and evolution project. The codebase is intentionally preserved instead of being rewritten into a completely different architecture.

## Next evolution

- API integration tests
- stronger application/service boundaries
- centralized validation
- structured logging and observability
- containerized local development
- CI build/test pipeline
