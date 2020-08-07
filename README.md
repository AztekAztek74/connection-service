# `connection-service`

## For what

The application represents the operator's interface for handling calls for communication connection. Tariffs are in TariffDB, successful connection requests are saved in UsersDataDB, interrupted requests are saved in EarlyCompletionDB.

## Running the application

1. Download zip or git clone
2. Restore database `./UsersDataDB`, `./TariffDB`, `./EarlyCompletionDB`
3. Install dependencies in `./frontend`

```sh
npm install
```

4. .NET Core build then restore in `./backend`

```sh
dotnet build
dotnet restore
```

5. Start the server in `./backend`

```sh
ctrl + f5
```

6. Start application in `./frontend`

```sh
npm run watch
```

The angular app will be served at `http://localhost:4000`
While the c# server will be served at `http://localhost:50383`
