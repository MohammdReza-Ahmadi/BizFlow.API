# BizFlow.API

A clean, modular Web API project built using **.NET 8**, applying **Clean Architecture + Vertical Slice Architecture** principles to manage **customers**, **orders**, **invoices**, and **wallet-based payments** in a secure and scalable way.

🧪 **Note:** This is a sample/test project designed for evaluation purposes. Some implementations, shortcuts, or simplifications (such as hardcoded users or lack of tests) are intentional to meet time constraints or to keep the scope focused during review."

## ✅ Features

- 🔐 JWT-based authentication (Admin / Customer roles)
- 👤 View and manage customer account info
- 📦 Create and query orders
- 🧾 Generate and pay invoices
- 💰 Manage wallet balances
- 🧠 Business logic validations (e.g., invoice ownership, sufficient wallet funds)
- 📄 Vertical slice structure per feature (no controller bloat)

## 🏗 Architecture Overview

This project combines the **Clean Architecture** layered separation with **Vertical Slice** feature-based organization. Each feature is independently implemented with clear boundaries:

```
/Features
  /Invoices
    /CreateInvoice
    /PayInvoice
  /Orders
    /CreateOrder
    /GetOrder
  /Customers
    /GetCustomer
    /UpdateCustomer
```

**Layers:**

| Layer | Responsibility |
|-------|----------------|
| **Domain** | Entities, Enums, Business rules |
| **Application** | Use cases, Commands/Queries, Interfaces |
| **Infrastructure** | EF Core, JWT, Repositories |
| **API** | HTTP endpoints, request routing |
| **Shared** | Common utilities, result wrappers |

## ⚙️ Tech Stack

| Technology | Usage |
|------------|-------|
| ASP.NET Core 8 | Web API |
| MediatR | Command/Query separation |
| EF Core | Database access |
| SQL Server / InMemory | Database |
| JWT | Auth & authorization |
| FluentValidation | (Optional) Input validation |
| Swagger | API testing & docs |

## 🛡 Authentication

- JWT-based authentication
- Role-based authorization:
  - `Admin` can access and manage all entities
  - `Customer` can only access their own data
- Hardcoded test accounts:

| Role | Email | Password |
|------|-------|----------|
| Admin | `admin@test.com` | `123456` |
| Customer | `customer1@test.com` | `123456` |

## 🔄 Sample API Flow

1. **Login → Get JWT**
2. **Get my customer info (`GET /me`)**
3. **Create Order (`POST /orders`)**
4. **Create Invoice (`POST /invoices`)**
5. **Pay Invoice (`POST /invoices/pay`)**

## 🧪 How to Run

```bash
git clone https://github.com/your-org/BizFlow.API.git
cd BizFlow.API

# Update DB
dotnet ef database update

# Run
dotnet run
```

📍 Visit `https://localhost:5001/swagger` for interactive API docs.

## 📁 Sample Folder Structure

```
/BizFlow.API
  /Api
  /Application
    /Customers
    /Invoices
  /Domain
  /Infrastructure
  /Shared
```

## 📌 Business Rules Implemented

- ❗ Only one invoice allowed per order
- ❗ Invoice must belong to requesting customer
- ❗ Invoice cannot be paid if status is already `Paid`
- ❗ Payment fails if wallet balance is insufficient
- ✅ Upon payment:
  - Invoice status updated to `Paid`
  - Wallet balance decreased
  - Wallet transaction logged

## ⚠️ Known Limitations

| Feature | Status |
|---------|--------|
| Wallet transaction history | ✅ (logged in DB) |
| Role-based access control | ✅ implemented |
| Unit tests | ❌ not implemented (time constraint) |
| Refresh token | ❌ not implemented |

## 👨‍💻 Developer Info

- **Name:** Mohammd Reza Ahmadi
- **GitHub:** (https://github.com/MohammdReza-Ahmadi)
- **Email:** mohammadre3aahmadi@gmail.com
- **LinkedIn:** (https://www.linkedin.com/in/mohammadre3a-ahmadi/)

## 🧠 Design Notes

- Clean Architecture enables long-term scalability
- Vertical Slice keeps features isolated and testable
- Minimal external dependencies used for clarity and control
- Project designed to be extendable for multi-tenant or SaaS scenarios

## 📚 Future Enhancements (Optional Ideas)

- Add unit/integration tests
- Wallet transaction filtering and reporting
- Admin dashboard endpoints
- Refresh token and logout support
