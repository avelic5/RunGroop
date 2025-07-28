# RunGroopWebApp

## Overview

RunGroopWebApp is an ASP.NET Core web application designed to help users manage and discover running clubs and races. It provides a platform for sports enthusiasts to connect with local running communities, view upcoming events, and track their participation. The application emphasizes a seamless user experience with robust authentication and authorization features.

## Key Features

* **User Authentication & Authorization:** Secure user registration, login, and logout functionalities powered by ASP.NET Core Identity. The application is configured to require authentication for most of its features, ensuring data privacy and controlled access.
* **Club Management:** Users can browse through various running clubs, view their details, and potentially join them.
* **Race Discovery:** Explore a list of upcoming running races, view detailed information about each event, including start times, entry fees, and locations.
* **Detailed Views:** Dedicated pages for in-depth information on individual clubs and races.
* **Data Persistence:** All application data (clubs, races, user accounts) is stored in a SQL Server database, managed efficiently with Entity Framework Core.

## Technologies Used

* **Backend:** ASP.NET Core 7.0 (or newer)
* **Language:** C#
* **Database:** SQL Server
* **ORM:** Entity Framework Core
* **Authentication:** ASP.NET Core Identity
* **Architecture:** Model-View-Controller (MVC)
* **Frontend:** Razor Pages for Identity UI, HTML, CSS (potentially Bootstrap or custom styles)

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

Before you begin, ensure you have the following installed:

* [.NET SDK 7.0 (or newer)](https://dotnet.microsoft.com/download/dotnet/7.0)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (SQL Server Express is sufficient for local development)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/community/) (recommended IDE)

### Installation and Setup

1.  **Clone the Repository:**
    Start by cloning the project from GitHub to your local machine:
    ```bash
    git clone [https://github.com/YourUsername/RunGroopWebApp.git](https://github.com/YourUsername/RunGroopWebApp.git)
    cd RunGroopWebApp
    ```
    *(Replace `YourUsername` with your actual GitHub username and `RunGroopWebApp` if your repository name differs.)*

2.  **Configure Database Connection:**
    * Open the `RunGroopWebApp.sln` solution file in Visual Studio.
    * Navigate to `appsettings.json` (or `appsettings.Development.json`) in the project's root directory.
    * Update the `DefaultConnection` string within the `ConnectionStrings` section to point to your SQL Server instance.
        Example:
        ```json
        "ConnectionStrings": {
          "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=RunGroopDb;Trusted_Connection=True;MultipleActiveResultSets=true"
        }
        ```
        Adjust `Server` and `Database` as per your SQL Server setup.

3.  **Apply Database Migrations:**
    * Open the **Package Manager Console** in Visual Studio (Go to `Tools` -> `NuGet Package Manager` -> `Package Manager Console`).
    * Execute the following commands, one after another, to create and update your database schema, including tables required by ASP.NET Core Identity:
        ```powershell
        Add-Migration InitialCreate // Or Add-Migration AddIdentityTables if specifically for Identity setup
        Update-Database
        ```

4.  **Seed Initial Data (Optional):**
    If you have implemented initial data seeding (e.g., for sample clubs or races), you can run it:
    * You might have a command-line argument setup. In Visual Studio, go to `Debug` -> `Run without debugging` (Ctrl+F5) and in the "Command Line Arguments" field, type `seeddata`.
    * Alternatively, you could temporarily modify `Program.cs` to call `Seed.SeedData(app);` directly for a single run, then revert the change.

5.  **Run the Application:**
    * Press **F5** (Start Debugging) or **Ctrl + F5** (Start Without Debugging) in Visual Studio.
    * The application will launch in your default web browser. Due to the global authorization policy, you will be redirected to the login page first.

## Screenshots

**Please insert your application screenshots here.**

You can embed images using Markdown syntax. For example:


<img width="1889" height="897" alt="Screenshot 2025-07-28 152302" src="https://github.com/user-attachments/assets/80d8d066-2a68-494f-be73-b406b97d846b" />
<img width="1886" height="881" alt="Screenshot 2025-07-28 152315" src="https://github.com/user-attachments/assets/3217003b-5329-4e7e-99b9-4ee55037e1d9" />
<img width="1891" height="902" alt="Screenshot 2025-07-28 152333" src="https://github.com/user-attachments/assets/f9f1d6e4-8fb2-4212-b333-f252fae975a4" />
<img width="1891" height="903" alt="Screenshot 2025-07-28 152347" src="https://github.com/user-attachments/assets/6481776e-6f49-4f74-bb4b-46102a414fe0" />
<img width="1882" height="889" alt="Screenshot 2025-07-28 152411" src="https://github.com/user-attachments/assets/ed4da267-070c-45e7-8b27-c9045381f13b" />
<img width="1871" height="895" alt="Screenshot 2025-07-28 152426" src="https://github.com/user-attachments/assets/2a17c39c-96e0-49f3-a4a6-f5f2488538a0" />
<img width="1892" height="906" alt="Screenshot 2025-07-28 152453" src="https://github.com/user-attachments/assets/340a7e28-f656-474b-9975-dba4691ed218" />
<img width="1873" height="890" alt="Screenshot 2025-07-28 152513" src="https://github.com/user-attachments/assets/90a6c78a-0826-4ae9-8b9b-71948f03613a" />
