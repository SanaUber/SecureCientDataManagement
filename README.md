# Secure Client Data Management (Interview Assignment)

A simple full-stack app to **store client records securely**.

- **Backend:** ASP.NET Core Web API (.NET 8)
- **Frontend:** Blazor Server (.NET 8)
- **Security:** Emirates ID is encrypted with AES-256 before storage
- **Storage:** In-memory (data resets on app restart)

---

## What this project does

You can:
1. Add a client (First Name, Last Name, Emirates ID)
2. View client list with masked Emirates ID
3. Click **Reveal** to decrypt and see original Emirates ID

---

## Why `http://localhost:28052/` was showing 404

### Reason (simple)
In the API project, controllers are mapped under `/api/...` and Swagger UI is under `/swagger`.
There was **no route defined for root path `/`**, so opening only the base URL returned **HTTP 404**.

### What was changed
A root endpoint was added to redirect `/` to Swagger:

- `GET /` → redirects to `/swagger`

Now these both work:
- `http://localhost:28052/`
- `http://localhost:28052/swagger`

---

## Project structure

```text
SecureCientDataManagement/
├── SecureClientDataManagement/
│   ├── SecureClientDataManagementAPI/
│   │   ├── Controllers/
│   │   ├── Interfaces/
│   │   ├── Models/
│   │   ├── Repository/
│   │   ├── Services/
│   │   └── Program.cs
│   ├── SecureClientDataManagementFrontend/
│   │   ├── Components/
│   │   ├── Interfaces/
│   │   ├── Models/
│   │   ├── Services/
│   │   └── Program.cs
│   ├── docker-compose.yml
│   └── SecureClientDataManagement.sln
└── README.md
```

---

## API endpoints (quick)

Base URL example: `http://localhost:28052`

- `GET /swagger` → API documentation UI
- `POST /api/clients` → add new client
- `GET /api/clients` → get all clients (masked Emirates ID)
- `GET /api/clients/{id}/decrypt` → reveal original Emirates ID

---
