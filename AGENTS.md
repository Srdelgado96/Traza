# AGENTS.md

## Project overview

Traza is a web application for managing incidents, improvement actions, and projects in an industrial environment.

The project is inspired by a real internal legacy system currently used in a factory environment. The current system is a desktop application built with old Windows technologies and poor responsiveness. Traza aims to explore a modern web-based replacement.

## Current stack

- ASP.NET Core
- Blazor Web App
- .NET 10
- Entity Framework Core
- SQL Server
- Radzen
- Bootstrap / admin-style UI approach

## Current implementation scope

At this stage, the project is intentionally kept simple and lives in a single web project:

- `Traza.Web`

Do not introduce extra solution projects unless there is a clear and justified need.

## Core principles

- Keep the project cloud-ready but not cloud-dependent
- Start with app-managed authentication
- Keep authorization decisions inside Traza
- Prepare the system for future Active Directory integration
- Prefer simple and maintainable architecture over premature layering
- Do not hardcode secrets
- Use User Secrets for local development
- Use environment variables for production
- Avoid coupling the application to IIS, AWS, Windows login, or local file system paths

## Product direction

Traza is expected to manage:

- incidents
- improvement actions
- projects

The application should work well on:

- desktop
- tablet

The incident creation flow should be:

- fast
- simple
- intuitive
- visually clear

## Current technical decisions

- Blazor Web App uses interactive server render mode
- SQL Server is used for local development
- EF Core is the ORM
- Radzen is used for business-oriented UI components
- Bootstrap/admin-like visual direction is preferred
- The application should remain portable to both AWS and on-premise environments

## Authentication and authorization direction

Current direction:

- authentication is application-managed
- authorization is application-owned

Important architectural rule:

> Identity may come from different sources in the future, but Traza decides permissions.

This means:

- do not tightly couple business permissions to Windows or Active Directory groups
- design roles and permissions as part of the application domain
- future AD integration should map external groups to internal roles/permissions

## Repository structure

Current structure:

- `Traza.Web/` → main web application
- `Traza.Web/Data/` → EF Core DbContext and related data setup
- `Traza.Web/Components/` → Blazor components, pages and layout
- `Traza.Web/wwwroot/` → static assets
- `docs/` → project and architecture documentation

## Commands

### Run application
```bash
dotnet run --project .\Traza.Web\Traza.Web.csproj