cd /var/www/Zuleny-NutritionalAdvice/
git pull
dotnet restore
dotnet-ef database update --project NutritionalAdvice.Infrastructure --startup-project NutritionalAdvice.WebApi --context StoredDbContext
dotnet build
dotnet publish --configuration Release