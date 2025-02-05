# Payment Gateway
Example application that shows communication between Merchant, PaymentGW API and Bank

Solution consists of 4 projects:

- Payment.Gateway -  Gawateway for communication with downstream APIs (for now it is only Payments.API)
- Payments.API - Restful API for handling Payments related requests 
- Banking.Simulator - fake implementation of Acquiring Bank
- Payments.API.Tests - sample project for showing testing techniques


## Requirements 

* Windows 10 (Build 18362)/ Ubuntu Linux
* Docker 2.1.0.5 
  - Docker must run in "Linux containers mode"
  - Minimum Docker engine configuration: CPUs 2, Memory 2 GB, Swap: 1 GB, Disk image size: 15 GB
  - Disk "C" must be shared in Docker preferences cause it is required for mounting folder for application logs in host machine (preferably mounting device can be changed in docker-compose file)

## Troubleshooting

* TCP ports 5000, 5001, 5002 are used by application. If these ports will be busy then application will fail to start. 
* Standard port 1433 is used for SqlServer. Sql container can have port conflicts if other instance of sql server is already running on host machine on the same port.
* ATTENTION: Volume path in docker-compose file was indicated in Windows style, it means this mount command can fail in Linux based host system, then path should be changed to linux style


## Application Installation Guide

After having all required components, application can be easily run by using next command in cmd:

```
docker-compose up
```

Above command should be run in directory where docker-compose.yml file resides

Take into consideration during running "docker-compose" docker should download .net core runtime , sdk (for building app on the fly) and sql server. Overall process can take 3-4 minutes on normal internet connection.

4 containers will be started: 
- 1 for each project (simulator, api, gateway)
- 1 for sql server (sql server 2017 express edition)

It can be checked by command 
 
 ```
 docker ps
 ```
 
Sample database will be generated automatically in sql server instance which running in container. Database will exist while sql instance container is alive (not removed by docker rm commamnd)

Database can be accessed via SSMS on localhost, port 1433 with next credentials: username: sa, password: Pass@word

If Disk "C" is shared (see Requirements section) then C:\PaymentGW\Logs folder will be generated on first run on host machine (Windows 10)
 
 ## Usage
 
 Requests can be send by any REST client (POSTMAN or Insomnia):
 
 ### Payment Request
 
 - HTTP Method: POST
 - Content-Type: application/json
 - Accept: \*/\*
 
 > http://localhost:5000/api/payments/ 
 
 * ExternalID - must be unique for each request
 * CardNumber - string with length 16
 * CurrencyCode: USD, EUR, CHF for any other code appropriate error text should be returned
 
 
 ```json
{
	"ExternalID": "250",
	"CardNumber":"3243423445543456",
	"Amount":"100",
	"CurrencyCode":"EUR",
	"ExpiryMonth": "10",
	"ExpiryYear":"2020",
	"CVV":123	
}
 ```
 
 ### Retrieve Payment Details
 
 - HTTP Method: GET
 - Accept: \*/\*
 
 > http://localhost:5000/api/payments/250

 
 ## Dev Guide
 
 Application was implemented on Visual Studio 2017 Community Edition with .NET Core SDK 2.2 installed
 
 
 ## Technology Stack
 
 * .NET Core SDK 2.2 - runtime
 * SQL.Server 2017 Express - database engine
 * EF Core - ORM Library
 * Ocelot - open source API Gateway (https://threemammals.com/ocelot/)
 * Log4net - logging library
 * MSTest - test library
 * Moq - for mocking interfaces in unit test project
 * docker - containarization technology
 * docker-compose - orchestrator 
