## `ApiCleanArchitecture`

## Arquitetura

Este projeto segue os princípios da **Clean Architecture**, onde cada camada é responsável por uma parte específica da lógica e se comunica apenas com a camada adjacente, mantendo um baixo acoplamento e alta coesão.

As camadas principais são:

1. **Apresentação (Api)**: Contém os controllers e expõe a API para os clientes externos.
2. **Aplicação (Application)**: Lida com a lógica de negócios específica dos casos de uso, chamando repositórios e serviços conforme necessário.
3. **Domínio (Domain)**: Define o núcleo da aplicação, incluindo entidades e interfaces fundamentais.
4. **Infraestrutura (Infrastructure)**: Implementa os detalhes de infraestrutura, como persistência de dados e serviços externos.
5. **Testes (Tests)**: Contém testes unitários e, possivelmente, testes de integração para validar o comportamento do código.

## Estrutura de Pastas e Responsabilidades

### 1. `ApiCleanArchitecture.Api`

- **Descrição**: Esta é a camada de Apresentação. Aqui ficam os controllers, responsáveis por receber as requisições HTTP e direcioná-las aos casos de uso apropriados.
- **Subpastas**:
    - **Module/Swagger**: Configurações e extensões para o Swagger, que facilita a documentação da API.
    - **Versioning**: Configurações de versionamento para lidar com múltiplas versões da API.
    - **V1/Controllers** e **V2/Controllers**: Contêm os controllers de diferentes versões da API. Cada controller manipula um endpoint específico e mapeia as requisições para os casos de uso.
- **Principais Arquivos**:
    - `Program.cs`: Configuração e inicialização da aplicação.
    - `appsettings.json`: Arquivo de configuração da API.

### 2. `ApiCleanArchitecture.Application`

- **Descrição**: Esta camada contém a lógica de aplicação e orquestra os casos de uso. É responsável pela execução de operações específicas, chamadas de repositórios e mapeamento de dados.
- **Subpastas**:
    - **Dtos**: Definições dos DTOs (Data Transfer Objects) usados para transferência de dados entre camadas.
    - **Interfaces**: Interfaces para serviços de aplicação.
    - **Mappings**: Contém configurações para mapeamento de entidades para DTOs e vice-versa.
    - **UseCases**: Implementação de casos de uso específicos, cada um responsável por uma operação de negócio.

### 3. `ApiCleanArchitecture.Domain`

- **Descrição**: Essa camada representa o núcleo do sistema. Define as entidades e interfaces fundamentais, sem depender de infraestrutura ou lógica de aplicação.
- **Subpastas**:
    - **Entities**: Contém as entidades principais do sistema que representam os objetos de negócio.
    - **Interfaces**: Interfaces para repositórios, garantindo que a camada de domínio esteja desacoplada da implementação da persistência de dados.

### 4. `ApiCleanArchitecture.Infrastructure`

- **Descrição**: Esta camada contém as implementações de repositórios e serviços externos. Fornece os detalhes concretos para acesso a dados e integração com APIs externas.
- **Subpastas**:
    - **ExternalServices**: Implementações de serviços externos que o sistema consome.
    - **IoC**: Configuração de Inversão de Controle e Injeção de Dependência.
    - **Persistence**: Implementações dos repositórios que acessam o banco de dados, usando ORMs como Entity Framework.

### 5. `ApiCleanArchitecture.Tests`

- **Descrição**: Camada de testes, onde estão os testes unitários e de integração para garantir a confiabilidade do sistema.
- **Subpastas e Arquivos**:
    - Arquivo de teste exemplo: `UnitTest1.cs`

## Estrutura de Código (Skeleton)

Aqui está uma estrutura de código básica para representar essa organização de pastas:

```
ApiCleanArchitecture/
│
├── ApiCleanArchitecture.Api/
│   ├── Module/
│   │   └── Swagger/
│   │       ├── ConfigureSwaggerOptions.cs
│   │       └── SwaggerExtensions.cs
│   ├── Versioning/
│   ├── V1/
│   │   └── Controllers/
│   │       └── PessoaFisicaController.cs
│   ├── V2/
│   │   └── Controllers/
│   │       └── PessoaFisicaController.cs
│   ├── ApiCleanArchitecture.Api.http
│   ├── appsettings.json
│   └── Program.cs
│
├── ApiCleanArchitecture.Application/
│   ├── Dtos/
│   │   └── PessoaFisicaDto.cs
│   ├── Interfaces/
│   │   └── IPessoaFisicaService.cs
│   ├── Mappings/
│   │   └── PessoaFisicaMappingProfile.cs
│   └── UseCases/
│       └── GetPessoaFisicaListUseCase.cs
│
├── ApiCleanArchitecture.Domain/
│   ├── Entities/
│   │   └── PessoaFisica.cs
│   └── Interfaces/
│       └── IPessoaFisicaRepository.cs
│
├── ApiCleanArchitecture.Infrastructure/
│   ├── ExternalServices/
│   │   └── SomeExternalService.cs
│   ├── IoC/
│   │   └── DependencyContainer.cs
│   └── Persistence/
│       └── PessoaFisicaRepository.cs
│
└── ApiCleanArchitecture.Tests/
    └── UnitTest1.cs

```
