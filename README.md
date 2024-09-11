<h1>TODO LIST ANGULAR & ASP.NET CORE</h1>
Para instalar e rodar um projeto com um backend em **ASP.NET Core** e um frontend em **Angular** em diferentes máquinas, você pode seguir os passos abaixo. Isso envolve a preparação do ambiente em cada máquina, a instalação das dependências necessárias e a execução do projeto.

### Pré-requisitos
1. **Backend - ASP.NET Core:**
   - **.NET SDK**: Certifique-se de que o SDK do .NET está instalado. [Baixe e instale aqui](https://dotnet.microsoft.com/en-us/download).
   - **SQL Server** (ou outro banco de dados configurado).

2. **Frontend - Angular:**
   - **Node.js**: Baixe e instale a versão LTS do Node.js [aqui](https://nodejs.org/).
   - **Angular CLI**: Instale o Angular CLI globalmente.
     ```bash
     npm install -g @angular/cli
     ```

### Passo a Passo: Instalação e Execução

#### 1. Clonar o Projeto

Em cada máquina, o projeto precisará ser clonado do repositório (GitHub ou outro local):

```bash
git clone https://github.com/usuario/projeto.git
```

#### 2. Configurar o **Backend** (ASP.NET Core)

##### a. Instalar Dependências do Backend

Navegue até a pasta do backend (onde o arquivo `.csproj` está localizado) e execute:

```bash
cd path/to/backend
dotnet restore
```

##### b. Configurar a Connection String

Edite o arquivo `appsettings.json` (ou `appsettings.Development.json`) para configurar a connection string do banco de dados, por exemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TaskManagementDb;Trusted_Connection=True;"
}
```

Se o banco de dados ainda não foi criado, você pode rodar as migrações do **Entity Framework**:

```bash
dotnet ef database update
```

##### c. Rodar o Backend

Agora, você pode rodar o backend:

```bash
dotnet run
```

Isso irá iniciar o servidor backend (provavelmente na URL `http://localhost:5000`).

#### 3. Configurar o **Frontend** (Angular)

##### a. Instalar Dependências do Frontend

Navegue até a pasta do frontend (onde o `package.json` está localizado) e instale as dependências do projeto:

```bash
cd path/to/frontend
npm install
```

##### b. Configurar as Variáveis de Ambiente

Certifique-se de que o frontend está configurado para se comunicar com o backend. No Angular, edite o arquivo `src/environments/environment.ts`:

```typescript
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api'
};
```

Essa URL deve apontar para o backend em execução.

##### c. Rodar o Frontend

Agora, execute o frontend:

```bash
ng serve
```

O servidor do frontend estará rodando na URL `http://localhost:4200`.

### 4. Acessar a Aplicação

- Acesse o frontend via `http://localhost:4200`.
- O frontend se comunicará com o backend via API.

### Resumo dos Comandos

**Para o backend:**
1. Clonar o projeto.
   ```bash
   git clone https://github.com/usuario/projeto.git
   ```
2. Navegar até a pasta do backend e instalar dependências:
   ```bash
   cd path/to/backend
   dotnet restore
   ```
3. Configurar a connection string e rodar as migrações:
   ```bash
   dotnet ef database update
   ```
4. Executar o backend:
   ```bash
   dotnet run
   ```

**Para o frontend:**
1. Navegar até a pasta do frontend e instalar dependências:
   ```bash
   cd path/to/frontend
   npm install
   ```
2. Configurar a URL da API no `environment.ts`.
3. Executar o frontend:
   ```bash
   ng serve
   ```

### Implantação em Produção

Se quiser rodar em produção, você pode compilar ambos os projetos e colocá-los em um servidor, ou utilizar Docker para empacotar tudo e facilitar a implantação em diferentes máquinas.

Caso tenha dúvidas sobre qualquer uma dessas etapas, posso detalhar mais!
