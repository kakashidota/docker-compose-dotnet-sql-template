# 🐳 Docker Compose: .NET API + SQL Server Starter

A complete beginner-friendly template to run a containerized `.NET Web API` and `SQL Server` using **Docker Compose**.

🎓 This project is designed as a learning resource for students, educators, and developers who want to:
- Understand how Docker works with .NET and SQL Server
- Set up a local dev environment with containerized services
- Explore how APIs communicate with databases in a real-world dev setup

💡 If you run into any issues, please refer to the YouTube tutorial — it walks through everything step-by-step and may cover details not mentioned in this README.

📺 **Watch the full tutorial on YouTube:**  
[▶️ Getting Started with Docker Compose: .NET API + SQL Server](https://youtu.be/ocMwNAt3-G0)

---

## 📦 Project Overview

This repo includes:
- A minimal `.NET 8 Web API` with one controller
- A `docker-compose.yml` file to run SQL Server in a container
- A `Dockerfile` to containerize the API
- Sample database connection setup
- Instructions for running and testing locally

---

## 🧱 Tech Stack

| Layer          | Tech                 |
|----------------|----------------------|
| Backend API    | ASP.NET Core (.NET 8)|
| Database       | SQL Server (Linux image) |
| Containerization | Docker, Docker Compose |
| Environment    | Localhost (dev-ready) |

---

## 🚀 Getting Started

### 1. Clone the repo

```bash
git clone https://github.com/<your-username>/<repo-name>.git
cd <repo-name>
```

### 2. Build & Run with Docker Compose

```bash
docker-compose up --build
```

This will:
- Build the .NET API container
- Pull the official SQL Server image
- Set up networking between containers

### 3. Test the API

Visit:  
`http://localhost:5000/products`

> This will return a prepopulated list of products from the SQL Server database.

The database is automatically migrated and seeded on startup using the following logic:

```csharp
using (var scope = app.Services.CreateScope()) 
{ 
    var context = scope.ServiceProvider.GetRequiredService<ProductContext>();
    context.Database.Migrate();

    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new Product { Name = "Coca-Cola", Price = 10 },
            new Product { Name = "Fanta", Price = 10 },
            new Product { Name = "Bebsi", Price = 5 }
        );

        context.SaveChanges();
    }
}
```

The API route is defined as:

```csharp
app.MapGet("/products", async (ProductContext db) => await db.Products.ToListAsync());
```

Database connection is configured in `appsettings.Development.json`.


---

## ⚙️ Configuration

### 🔑 SQL Server Settings

Environment variables for SQL Server are defined in `docker-compose.yml`:

```yaml
SA_PASSWORD: "Your_password123"
ACCEPT_EULA: "Y"
```

Update the connection string in the `.NET API` accordingly:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=sqlserver,1433;Database=MyAppDb;User=sa;Password=Your_password123;"
}
```

---

## 🧠 What You'll Learn

✅ Containerizing a .NET API  
✅ Setting up SQL Server with Docker  
✅ Using Docker Compose to manage multi-container apps  
✅ Connecting services via internal Docker networking  
✅ Basics of `appsettings.json` and environment configs

---

## 📚 For Students & Educators

This project is ideal for:
- Teaching Docker fundamentals
- Demonstrating local dev environments
- Practicing database + API integration
- Assignments or classroom demos


---

## 🔗 Resources

- [Official Docker Compose Docs](https://docs.docker.com/compose/)
- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [SQL Server on Linux with Docker](https://learn.microsoft.com/en-us/sql/linux/)

---

## 📺 Related Content

📹 **YouTube Tutorial**:  
[Getting Started with Docker Compose: .NET API + SQL Server](https://youtu.be/ocMwNAt3-G0)

---

## 🧑‍💻 About the Author

👋 I'm Robin Kamo — Senior DevOps Engineer, YH Instructor, developer, and cloud educator.  
This repo is part of my effort to support students and early-career developers in learning practical, modern cloud development skills.

Follow along for more at [linkedin.com/in/robin-kamo](https://www.linkedin.com/in/robin-kamo)

---

## 🪪 License

MIT License. Use it freely for learning or teaching!
