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
  - Disk "C" must be shared for logging purposes in Docker configuration
  - Minimum Docker engine configuration: CPUs 2, Memory 2 GB, Swap: 1 GB, Disk image size: 15 GB


## Application Running Guide

After having all required components, application can be run easily run by using next command in cmd:

```
docker-compose up
```

Above command should be run in directory where docker-compose.yml file resides


In running state 4 containers must be started: 
- 3 for each project (simulator, api, gateway)
- 1 for sql server (sql server 2017 express edition)

It can be checked by command 
 
 ```
 docker ps
 ```
 
 ## Dev Guide
 
 Application was implemented on Visual Studio 2017 Community Edition with .NET Core SDK 2.2 installed
 
 
 ## Technology Stack
 
 * .NET Core SDK 2.2 - runtime
 * SQL.SErver 2017 Express - database engine
 * EF Core - ORM Library
 * Ocelot - API Gateway
 * Log4net - logging library
 * MSTest - test library
 * Moq - for mocking interfaces in unit test project
 * docker - containarization technology
 * docker-compose - orchestrator 
 
 
 
 
 
 
