# QuizMaster

## Goal

QuizMaster is a project to assist in learning C#.
Topics to be discussed:

- .NET Core API
- MVC With Angular and .NET Core
- Middleware
- Unit tests
- Dependency Injection 

### Specifics of C#

- Building a RESTfull API in .NET Core
- Database access with SQLite
- Use SignalR to allow messaging between client and server 


## Setup

Clone the application and run it

### Configure database

If you want to use a database, change the appsettings.json setting of the API to the following:

```javascript{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "Connections": {
    "useSqlite":  true,
    "sqliteFile": "quiz.db"
  }
}
```

Set the `useSqlite` to `false` if you don't want to use the sqlite implementation