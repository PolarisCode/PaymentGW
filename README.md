# Payment Gateway
Example application that shows communication between PaymentGW API and Bank

Solution consists of 3 projects:
- Payment.Gateway -  Central place for communication with API for external mechants
- Payments.API - Application that makes actual business logic 
- Banking.Simulator - fake implementation of Acquiring Bank


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


In running state there should be 4 containers runnings:

3 for each project and one for sql server
It can be checked by command 
 
 ```
 docker ps
 ```
 
 ## Dev Guide
 
 Application was implemented on Visual Studio 2017 Community Edition with .NET Code SDK 2.2 installed
 
 
 ## Technology Stack
 
 * .NET Core SDK 2.2 - runtime
 * SQL.SErver 2017 Express - database engine
 * EF Core - ORM Library
 * Ocelot - API Gateway
 * Log4net - logging library
 * MSTest - test library
 * docker - containarization technology
 * docker-compose - orchestrator 
 
 
 
 
 
 
