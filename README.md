# ModularMonolith

# Migrations

dotnet ef migrations add Users_Module_Init --context UsersDbContext --startup-project ..\..\..\Bootstrapper\Confab.Bootstrapper\ -o ./DAL/Migrations