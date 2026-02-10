# POSTO DESKTOP
Aplicação desktop (Windows) desenvolvida em C# / WinForms, responsável pelo controle local de bombas de combustível e registros de consumo, com sincronização automática para uma API online.

O projeto foi pensado com abordagem offline-first, permitindo operação normal mesmo sem internet, com sincronização posterior.

# Execute Packages
 - dotnet add package Polly
 - dotnet add package Polly.Extensions.Http
 - dotnet add package Microsoft.Data.SqlClient

# Banco de Dados Local (SQL Server)

O banco roda em Docker.

Subir o SQL Server
docker compose up -d

# Dados de Acesso ao banco de daso SQL SERVER
Servidor	localhost,1433
Usuário	sa
Senha	StrongPass!123
Banco	FuelLocalDb
