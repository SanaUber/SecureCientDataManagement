# SecureCientDataManagement
SecureCientDataManagement
# Secure Client Data Management Assignment

## Project Overview
This project is a secure client data management system with encryption of Emirates ID. It has two parts:
- **Backend**: ASP.NET Core Web API (.NET 8) – handles data, encryption, and API endpoints
- **Frontend**: Blazor Server (.NET 8) – user interface to add clients and view list with reveal feature
- **Docker**: docker-compose to run both frontend and backend in containers which executed partially

Features:
- Add new client (First Name, Last Name, Emirates ID)
- List of clients with masked Emirates ID (784-XXXX-XXXXXXX-X)
- Reveal button to decrypt and show original Emirates ID
- AES-256 encryption using environment variable key a strong encryption method data is locked 256-bit key and also unlocked with same key
- In-memory data storage (can be extended to SQLite)data in RAM
- Swagger UI for API testing
- Docker support for easy deployment

## Technologies Used
- Backend: ASP.NET Core Web API (.NET 8)
- Frontend: Blazor Server (.NET 8)
- Encryption: AES-256 (System.Security.Cryptography)
- Dependency Injection & Interfaces (SOLID principles)
- Docker & docker-compose
- Swagger (Swashbuckle.AspNetCore)

## Folder Structure
SecureCientDataManagement (root folder)
├── SecureCientDataManagement.sln              ← Main solution file (contains both projects)
├── docker-compose.yml                         ← Docker configuration to run both API and frontend
├── README.md                                  ← This file
│
├── SecureCientDataManagementAPI (Backend project)
│   ├── Controllers
│   │   └── ClientsController.cs               ← API endpoints (Add, GetAll, Decrypt)
│   ├── Interfaces
│   │   ├── IClientService.cs
│   │   ├── IEncryptionService.cs
│   │   └── IClientRepository.cs
│   ├── Models
│   │   ├── Client.cs
│   │   └── ClientDto.cs
│   ├── Repositories
│   │   └── InMemoryClientRepository.cs
│   ├── Services
│   │   ├── ClientService.cs
│   │   └── EncryptionService.cs
│   ├── Program.cs                             ← Registers services, Swagger, controllers
│   └── Dockerfile                             ← For building backend container
│
└── SecureCientDataManagementFrontend (Frontend project)
├── Components
│   ├── Pages
│   │   └── Home.razor                     ← Main page (form + list + reveal logic)
│   └── Shared
├── Interfaces
│   └── IClientApiService.cs
├── Models
│   └── ClientDto.cs
├── Services
│   └── ClientApiService.cs                ← Calls backend API
├── Program.cs                             ← Registers HttpClient, services
└── Dockerfile                             ← For building frontend container
text##
