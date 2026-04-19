# Traza - Project Context

## Overview

Traza is a web application for managing:

- incidents
- improvement actions
- projects

The project is inspired by a real internal legacy system used in an industrial/factory environment.

Traza is intended to be a modern, web-based alternative to that legacy system.

## Why this project exists

The current internal system is a legacy desktop application built with old Windows technologies.

Current pain points include:

- outdated visual design
- poor responsiveness
- limited usability
- difficult evolution and maintenance
- desktop-oriented experience instead of a modern web workflow

Traza exists to explore a cleaner, more maintainable and more usable replacement.

## Product vision

Traza should become a serious internal business application with a modern web experience.

The goal is not to build a flashy product.
The goal is to build a tool that feels:

- clear
- fast
- intuitive
- maintainable
- professional

The application should work well on:

- desktop
- tablet

The user experience should be especially careful in the incident creation flow, which should be simple, guided and easy to complete.

## Real-world inspiration

The real legacy system currently manages:

- incidents
- projects
- improvement actions

That existing system and its database may be used as a source of domain knowledge.

However, Traza should not blindly replicate the current solution.
The legacy system should be treated as:

- a source of information
- a source of business terminology
- a source of current workflows and constraints

but not as a perfect model to copy.

## Functional direction

Traza is expected to evolve around these main areas:

### 1. Incident management
The system should allow users to:

- create incidents
- classify incidents
- assign priority/severity
- track status
- add comments
- attach files or evidence
- view history and follow-up

### 2. Improvement actions
The system should support actions derived from incidents or identified needs for improvement.

These actions may include:

- responsible person
- status
- due dates
- follow-up
- related comments or evidence

### 3. Project management
The system should also support projects as a separate but related concept.

Projects may be:

- created independently
- related to one or more incidents
- related to improvement actions
- tracked over time with their own states and ownership

## Long-term direction

Traza should be designed with this principle in mind:

**Build it as if it will live in AWS first, without closing the door to on-premise deployment later.**

This means the project should be:

- cloud-ready
- not cloud-dependent
- portable
- environment-aware

The application should be able to evolve toward:

- deployment in AWS
- deployment in a company on-premise environment
- integration with corporate infrastructure if needed later

## Hosting and infrastructure direction

The current vision is to build Traza as a web application that can live in modern hosting environments.

Important technical principles:

- do not hardcode machine-specific paths
- do not assume a single hosting model
- do not tightly couple the app to IIS, AWS or local machine conventions
- keep configuration environment-based
- keep file storage abstract enough to evolve later
- keep the app portable between cloud and on-premise environments

## Authentication and authorization direction

For the first versions of Traza:

- authentication should be application-managed
- authorization should be application-owned

Important rule:

**Identity may come from different sources, but Traza decides permissions.**

This means:

- do not design business permissions directly around Windows users or Active Directory groups
- define internal roles and permissions as part of the application domain
- if Active Directory is integrated in the future, external groups should be mapped to Traza roles and permissions

The goal is to keep identity flexible while keeping business authorization under application control.

## Current technology direction

The current chosen stack is:

- ASP.NET Core
- Blazor Web App
- .NET 10
- Entity Framework Core
- SQL Server
- Radzen
- Bootstrap / admin-style UI approach

This direction was chosen because it:

- fits the developer's current experience
- fits the possible future enterprise/on-premise context
- supports a modern web application model
- allows focus on architecture, cloud readiness and AI-assisted development

## Architecture direction

At this stage, the project should remain intentionally simple.

Current architecture direction:

- one main web project: `Traza.Web`
- EF Core DbContext inside the web project
- UI components and pages inside the same project
- documentation at repository level
- avoid creating extra projects before real complexity appears

The goal right now is not to build a multi-layer enterprise template.
The goal is to create a clean, understandable and extensible foundation.

## UI and UX direction

Traza should look like a modern internal tool, not like a legacy industrial application.

The UI should aim for:

- responsive behavior
- clear layouts
- business-oriented dashboards and pages
- readable forms
- clean tables and detail screens
- intuitive navigation
- low visual noise

The visual direction should be:

- admin/dashboard style
- Bootstrap-friendly
- compatible with Radzen components
- clean and practical rather than decorative

The incident creation flow is especially important and should be:

- short
- guided
- easy to understand
- comfortable on tablet
- visually clean

## Expected domain concepts

The system is expected to use concepts such as:

- Incident
- ImprovementAction
- Project
- User
- Role
- Permission
- Comment
- Attachment
- AuditTrail
- Status
- Priority
- Severity

These concepts should be used consistently across code, UI and documentation.

## Current development priorities

Near-term priorities include:

1. establish a clean technical foundation
2. keep documentation useful for both humans and Codex
3. connect EF Core to SQL Server
4. create initial migrations
5. define the first domain entities
6. shape the first useful incident workflow
7. keep the architecture simple while learning the domain

## Documentation strategy

This file is expected to evolve as the project evolves.

As Traza grows, additional documentation may be added for:

- architecture decisions
- domain model details
- authentication and authorization rules
- deployment strategy
- Active Directory integration
- AWS/on-premise portability
- UI conventions

## Summary

Traza is a modern web-based internal business application concept focused on:

- incidents
- improvement actions
- projects

It is inspired by a real legacy industrial system, but it should not be a blind rewrite.

It should be:

- modern
- responsive
- maintainable
- cloud-ready
- portable
- simple at first
- extensible later