# Test Software Developer - Menu
![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=%20Finalizado&color=GREEN&style=for-the-badge)

<p align="center">
<a href="#sobre">Tecnologias</a> •
<a href="#sobre">Pré Requisitos</a> • 
<a href="#sobre">End Points</a> 

## Tecnologias

- C#
- Asp .Net Core 6.0
- Dapper
- SQL Server
- Swagger

## Pré Requisitos

Visual Studio 2022 ou Visual Studio Code
dotnet SDK 6.0.301
Software para realizar requisições HTTP (Insomnia, Postman...)

## End Points
### Products
- /api/Products/GetProducts : Retorna os produtos ativos 
- /api/Products/GetChoices : Retorna os produtos ativos do tipo Choice
- api/Products/GetValueMeal : Retorna os produtos ativos do tipo Value Meal

### Status
 - /api/Status/GetAllProducts : Retorna todos os produtos do banco
 - /api/Status/GetProductStatus : Retorna a tabela status
 - /api/Status/EnableProduct : Troca o status de um produto inativo para ativo
 - /api/Status/DisableProducts : Troca o status de um produto ativo para inativo
