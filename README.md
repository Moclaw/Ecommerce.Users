# Ecommerce Users Service

A microservice for managing user authentication, authorization, and user management in an ecommerce platform built with .NET 9.0 and Clean Architecture principles.

## 🏗️ Architecture

This solution follows Clean Architecture patterns with the following layers:

- **API Layer** (`Ecom.Users.API`) - Web API endpoints and HTTP concerns
- **Application Layer** (`Ecom.Users.Application`) - Business logic and use cases
- **Domain Layer** (`Ecom.Users.Domain`) - Core business entities and domain logic
- **Infrastructure Layer** (`Ecom.Users.Infrastructure`) - Data access and external services
- **Shared Layer** (`Ecom.Users.Shared`) - Common utilities and shared kernel

## 🚀 Technologies

- **.NET 9.0** - Latest .NET framework
- **Entity Framework Core 9.0** - Data access and ORM with PostgreSQL
- **PostgreSQL** - Primary database
- **JWT Authentication** - Secure token-based authentication
- **Serilog** - Structured logging
- **Docker** - Containerization support
- **Moclawr Framework** - Custom framework components
- **xUnit** - Unit testing framework

## 📁 Project Structure

```
src/
├── Ecom.Users.API/           # Web API layer
│   ├── Endpoints/            # API endpoints
│   │   ├── Auth/            # Authentication endpoints
│   │   ├── Permissions/     # Permission management
│   │   └── Users/           # User management
│   ├── Filters/             # Request/response filters
│   ├── Middleware/          # Custom middleware
│   └── Logs/               # Application logs
├── Ecom.Users.Application/   # Application services layer
│   ├── Features/            # Feature-based organization
│   ├── Services/            # Application services
│   └── Validators/          # Input validation
├── Ecom.Users.Domain/        # Domain layer
│   ├── Aggregates/          # Domain aggregates
│   ├── Entities/            # Domain entities
│   ├── ValueObjects/        # Value objects
│   ├── DTOs/               # Data transfer objects
│   ├── DomainEvents/        # Domain events
│   ├── Interfaces/          # Domain interfaces
│   ├── Repositories/        # Repository contracts
│   └── Specifications/      # Domain specifications
├── Ecom.Users.Infrastructure/ # Infrastructure layer
│   ├── Persistence/         # Database context and configuration
│   ├── Repositories/        # Repository implementations
│   ├── ExternalServices/    # External service integrations
│   └── Migrations/          # Database migrations
└── Ecom.Users.Shared/        # Shared components
    └── SharedKernel/        # Common utilities

test/
├── Ecom.Users.Application.UnitTests/
├── Ecom.Users.Domain.UnitTests/
└── Ecom.Users.Infrastructure.UnitTests/
```

## 🛠️ Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker](https://www.docker.com/get-started) (optional)
- [PostgreSQL](https://www.postgresql.org/download/) 12 or later

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Ecommerce.Users
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update database connection string**
   
   Update the connection string in `src/Ecom.Users.API/appsettings.Development.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=EcommerceUsers;Username=postgres;Password=your_password"
     }
   }
   ```

4. **Run database migrations**
   ```bash
   cd src/Ecom.Users.API
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run --project src/Ecom.Users.API
   ```

The API will be available at:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`
- Swagger UI: `https://localhost:5001/swagger`

### Docker Support

1. **Build Docker image**
   ```bash
   docker build -t ecommerce-users .
   ```

2. **Run with Docker Compose**
   ```bash
   docker-compose up
   ```

## 🧪 Testing

Run all tests:
```bash
dotnet test
```

Run tests for a specific project:
```bash
dotnet test test/Ecom.Users.Domain.UnitTests
```

Run tests with coverage:
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## 📊 API Documentation

Once running, visit the Swagger UI at `https://localhost:5001/swagger` for interactive API documentation.

### Key Endpoints

- **Authentication**
  - `POST /auth/login` - User login
  - `POST /auth/register` - User registration
  - `POST /auth/refresh` - Refresh token

- **User Management**
  - `GET /users` - Get all users
  - `GET /users/{id}` - Get user by ID
  - `PUT /users/{id}` - Update user
  - `DELETE /users/{id}` - Delete user

- **Permissions**
  - `GET /permissions` - Get user permissions
  - `POST /permissions` - Assign permissions

## 🔧 Configuration

Key configuration settings in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "..."
  },
  "JwtSettings": {
    "SecretKey": "...",
    "Issuer": "...",
    "Audience": "...",
    "ExpirationMinutes": 60
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

## 🚀 Deployment

### Environment Variables

Set the following environment variables for production:

- `ASPNETCORE_ENVIRONMENT=Production`
- `ConnectionStrings__DefaultConnection=<postgresql-connection-string>`
- `JwtSettings__SecretKey=<jwt-secret-key>`

### Docker Deployment

```bash
docker run -d \
  --name ecommerce-users \
  -p 80:8080 \
  -e ASPNETCORE_ENVIRONMENT=Production \
  -e ConnectionStrings__DefaultConnection="Host=your-host;Database=EcommerceUsers;Username=your-user;Password=your-password" \
  ecommerce-users
```

## 📝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🤝 Support

For support and questions:
- Create an issue in the repository
- Contact the development team

## 📚 Additional Resources

- [.NET 9.0 Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/)
- [Clean Architecture Principles](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
