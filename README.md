# Specification Pattern In .NET With Projection.

This demo project showcases an extended specification pattern with projection capability, specifically tailored for Entity Framework in .NET. It showcases how the specification pattern can be effectively utilized with projection or selecting during SQL query execution rather than mapping after data retrieval, this pattern is designed to handle selection/projection directly within the SQL query when implementing the repository pattern with specifications.

## Setup

### Prerequisite

1. .NET 8 installed on your computer. You can download .NET 8 from the official website (<https://dotnet.microsoft.com/download/dotnet/8.0>).
2. An integrated development environment (IDE) to write your code
3. Git installed on your computer.

### Initial setup

1. Clone the project.

```shell
git clone https://github.com/haritha99ch/ExtendedSpecificationPattern-Example.git
cd ExtendedSpecificationPattern-Example
```

2. Set Environment variables.

```shell
dotnet user-secrets set "SqlServerOptions:ConnectionString" CONNECTIONSTRINGS_DEFAULTCONNECTION --project ./src/ApplicationSettings/
```

3. Install all the dependencies.

   ```shell
   dotnet restore
   ```

4. Build the project.

```shell
dotnet build
```

5. Add migrations and update database.

```shell
dotnet ef migrations add InitialMigration --project ./src/Infrastructure/
dotnet ef database update --project ./src/Infrastructure/
```

> Make sure, dotnet-ef tool is installed with `dotnet tool install --global dotnet-ef`

5. Run the project.

```shell
dotnet run --project ./src/Presentation/
```
