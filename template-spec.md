# 🤖 GitHub Copilot Agent Instructions

The GitHub Copilot Agent should follow the structure and conventions outlined below when generating or modifying code.

---

## 📁 Project Structure & Responsibilities

### `Application.Core`
Use this project for:

- All **DTOs** (Data Transfer Objects)
- All **mappings** (e.g., AutoMapper profiles)
- All **entities**, enums, and value objects

### `Application.Services`
Use this project for:

- All **business services**
- All **service interfaces and implementations**
- All **application workflows and feature logic**

---

## ❌ What to Avoid

- Do **not** create folders or classes named `UseCases`, `Features`, `Commands`, or `QueryHandlers`.
- Do **not** use **MediatR**, **CQRS**, or feature-based architecture.
- Avoid placing custom logic inside the UI or Infrastructure projects.

---

## ✅ Design Guidelines

- Follow a **service-oriented**, **modular**, and **clean architecture** approach.
- Use **dependency injection** to wire services into the UI layer.
- Organize code into folders by domain (e.g., `Policies`, `Claims`) under both `Core` and `Services`.

---

## Example

For a feature like “Start Claim”:
- Define `ClaimDto.cs` in `Application.Core/Claims`
- Create `ClaimService.cs` in `Application.Services/Claims`
- Add interface `IClaimService.cs` in the same folder

---

By adhering to these guidelines, the Copilot Agent ensures all generated functionality is aligned with the project’s architectural standards and remains easily maintainable.
