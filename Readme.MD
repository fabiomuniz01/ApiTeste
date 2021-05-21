﻿# ntitsolutions01@gmail.com; fabio.muniz01@gmail.com - OpahIT TEste

Este é um modelo de solução para o teste de uma API da Web ASP.NET Core seguindo os princípios da Arquitetura Limpa. 

## Tecnologias
* .NET 5.0
* ASP .NET 5.0
* Entity Framework Core 5.0
* MediatR
* Mapster
* FluentValidation
* NUnit, FluentAssertions, Moq & Respawn
* Elasticsearch, Serilog, Kibana

## Para Rodar

Alterar a connection string no arquivo appsettings.json com as configuraçoes de acesso 
do banco de dados sqlexpress da maquina local onde irá rodar a api.

Setar como StartUp project o project WebApi e rodar a api o banco de dados será criado automaticamente.

Caso haja haja necessidade de verificar os scripts de criação do banco, os arquivos de Migrations estao em 
\src\Common\Infrastructure\Persistence\Migrations\

## Visão geral da estrutura do projeto

### Domain

Aqui tem todas as entidades, enums, exceções, interfaces, tipos e lógicas específicas da camada de domínio.

### Application

Esta camada contém toda a lógica do aplicativo. Depende da camada de domínio, mas não depende de nenhuma outra camada ou projeto. Esta camada define interfaces que são implementadas por camadas externas. Por exemplo, se o aplicativo precisar acessar um serviço de notificação, 
uma nova interface seria adicionada ao aplicativo e uma implementação seria criada dentro da infraestrutura.

### Infrastructure

Essa camada contém classes para acessar recursos externos, como sistemas de arquivos, serviços da Web, 
 e assim por diante. Essas classes devem ser baseadas em interfaces definidas na camada de aplicativo.

### WebApi

Esta camada é um aplicativo de API da Web baseado em ASP.NET 5.0.x. Essa camada depende das camadas de aplicativo e de infraestrutura; no entanto, a dependência da infraestrutura é apenas para oferecer suporte à injeção de dependência. 
Portanto, apenas * Startup.cs * deve fazer referência a Infraestrutura.

### Logs

Logging Elasticsearch usando Serilog e visualização de logs em Kibana.





