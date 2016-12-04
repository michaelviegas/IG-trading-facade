# IG-trading-facade
.NET facade for IG REST trading API

[![Build Status](https://travis-ci.org/michaelviegas/IG-trading-facade.svg?branch=master)](https://travis-ci.org/michaelviegas/IG-trading-facade) [![NuGet](https://img.shields.io/nuget/v/IG.TradingFacade.svg)](https://www.nuget.org/packages/IG.TradingFacade/)

API documentation
https://labs.ig.com/

Project management board
https://tree.taiga.io/project/michaelviegas-trading/kanban

## Session

```csharp
IGEnvironment environment = IGEnvironment.Demo;
ISessionFacade sessionFacade = new SessionFacade(environment);
```

### Login

Creates a trading session, obtaining session tokens for subsequent API access. 

```csharp
string apiKey = "API_KEY";
IUserCredentials userCredentials = new UserCredentials 
{
	Username = "USERNAME",
	Password = "PASSWORD",
	EncryptedPassword = false
};

IAuthenticationResult authResult = await sessionFacade.Login(apiKey, userCredentials);

// Summary of client account information returned on successful client login
IUserAccount userAccount = authResult.UserAccount;

// Two security access tokens are returned in the response, and are required to be submitted in future API requests 
ISession session = authResult.Session;
```