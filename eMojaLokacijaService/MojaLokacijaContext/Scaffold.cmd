@echo off

cd ..\..

dotnet build .\eMojaLokacijaApi\eMojaLokacijaApi.csproj

rmdir /Q /S .\eMojaLokacijaService\MojaLokacijaContext\Models
del .\eMojaLokacijaService\MojaLokacijaContext\MojaLokacijaContext.cs

dotnet ef dbcontext scaffold Name=Default Microsoft.EntityFrameworkCore.SqlServer ^
-s .\eMojaLokacijaApi ^
-p .\eMojaLokacijaService ^
--schema Locations ^
--context MojaLokacijaContext ^
--context-dir .\MojaLokacijaContext ^
--output-dir .\MojaLokacijaContext\Models ^
--no-pluralize ^
--force ^
--no-build ^
--no-onconfiguring


rmdir /Q /S .\eMojaLokacijaService\MojaLokacijaContext\Compiled
dotnet build .\eMojaLokacijaApi\eMojaLokacijaApi.csproj

dotnet ef dbcontext optimize ^
-s .\eMojaLokacijaApi ^
-p .\eMojaLokacijaService ^
--context MojaLokacijaContext ^
--output-dir .\MojaLokacijaContext\Compiled ^
--namespace eMojaLokacijaService.MojaLokacijaContext ^
--no-build

pause
