\# SpecimenCheckInBackend



\## How to Run Locally

1\. Clone the repo:

&#x20;  ```bash

&#x20;  git clone git@github.com:shyamsundertejpaldev/SpecimenCheckInBackend.git

&#x20;  cd SpecimenCheckInBackend



2\. Restore dependencies and apply migrations:

&#x20;  dotnet restore

&#x20;  dotnet ef database update

&#x20;  dotnet run



Endpoints

List manifests for the current lab → GET /manifests

Manifest detail + specimens (404 if not in tenant) → GET /manifests/?ManifestId=

Actions Mark received (idempotent), Flag missing → raises a discrepancy  and Close (reject unless reconciled) 

/Manifests



payload -> for MarkReceived 

{

&#x20; "manifestId": 1,

&#x20; "specimenId": 1,

&#x20; "action": 2

}



for Flag Missing -> Raises a discrepancy

{

&#x20; "manifestId": 1,

&#x20; "specimenId": 1,

&#x20; "action": 2,

}



for Close Manifest unless reconciled

{

&#x20; "manifestId": 1,

&#x20; "closeManifest": true

}





Azure Topology

I would deploy the backend as an Azure App Service running ASP.NET Core, connected to Azure SQL. Each request flows through the App Service → EF Core → Azure SQL, scoped by tenant. For scalability, I’d add Azure Storage Queues for background reconciliation tasks and Blob Storage for audit logs or manifests. The request path is: client (Vue.js) → App Service API → EF Core → Azure SQL.



and I am using Azure sql 

Server=tcp:specimenserver.database.windows.net,1433;Database=SpecimenDb;User Id=sqlserveradmin;Password=Azure@sql123;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

this is my connectionstring for limited time use



2\. Tenant Isolation

Every entity row carries a LabId. During login, the current lab context is established and passed in the request header for each API call. All queries are filtered by this LabId before hitting the database, ensuring Lab A cannot read or mutate Lab B’s data. Enforcement happens at the repository/service layer, and automated tests attempt cross‑lab access to validate isolation. As the codebase grows, I would add middleware checks and integration tests to guarantee tenant scoping remains consistent.



HIPAA‑Aware Handling
With More Time I Would…



Implement CI/CD pipeline with GitHub Actions.

Harden security with secrets vault integration.

Improve UI polish and error handling.













