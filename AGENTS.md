# AGENTS.md

## Project overview

Traza is a web application for managing incidents, improvement actions, and projects in an industrial environment.

Initial stack:
- ASP.NET Core
- Blazor Web App (.NET 10)
- Entity Framework Core
- SQL Server
- Bootstrap
- Radzen

## Core principles

- Cloud-ready but not cloud-dependent
- Start with app-managed authentication
- Keep authorization inside Traza
- Prepare for future Active Directory integration
- Never hardcode secrets
- Use User Secrets for local development
- Use environment variables for production

## Coding guidelines

- Prefer clear and simple code
- Avoid premature abstractions
- Use consistent domain language
- Keep changes small and reviewable

## Domain language

Core concepts:
- Incident
- ImprovementAction
- Project
- User
- Role
- Permission
- Comment
- Attachment
- AuditTrail