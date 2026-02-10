# POSTO DESKTOP
Aplicação desktop (Windows) desenvolvida em C# / WinForms, responsável pelo controle local de bombas de combustível e registros de consumo, com sincronização automática para uma API online.

O projeto foi pensado com abordagem offline-first, permitindo operação normal mesmo sem internet, com sincronização posterior.

# Execute Packages
 - dotnet add package Polly
 - dotnet add package Polly.Extensions.Http
 - dotnet add package Microsoft.Data.SqlClient
 - dotnet add package Microsoft.Extensions.Hosting


# Banco de Dados Local (SQL Server)

O banco roda em Docker.

Subir o SQL Server
- docker compose up -d

# Dados de Acesso ao banco de daso SQL SERVER
 - Servidor	localhost,1433
 - Usuário	sa
 - Senha	StrongPass!123
 - Banco	FuelLocalDb

 # Tecnologias

 | Camada         | Tecnologia         |
| -------------- | ------------------ |
| UI             | WinForms (.NET)    |
| Linguagem      | C#                 |
| Banco Local    | SQL Server         |
| Acesso a Dados | ADO.NET            |
| Resiliência    | Polly              |
| API Online     | Java + Spring Boot |
| Banco Online   | PostgreSQL         |
| Infra          | Docker             |



# 🚀 Funcionalidades
✔️ Operação Local (Offline)

Cadastro de Bombas de Combustível

Controle de estoque em litros

Registro de consumos

Persistência local em SQL Server

# 🔁 Sincronização Online

Envio de consumos não sincronizados para API REST

Retry automático com Polly

Backoff exponencial

Controle de status de sincronização

Base preparada para Dead Letter
