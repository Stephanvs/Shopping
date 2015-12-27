# Shopping

Sample project to try out some ideas.

# Architectural Objectives

This sample is build with the following architectural objectives in mind:

- HTTP interface first approach
- Microservices approach
- Polyglot persistence
- Centralized logging
- Event Sourcing + CQRS on Akka.NET
- Top notch deployment, release and versioning story
- Multiple clients (web, app, etc)

# μServices

The below is the prefered approach to take to build this project:

- **identity** -> user identity and authorization (PostgreSQL)
- **search**: search for products (ElasticSearch)
- **listing**: view product details (MongoDB)
- **review**: product reviews (&hellip;)
- **cart**: shopping cart (&hellip;)
- **order**: (&hellip;)
- **xsell**: related items (Machine Learning)

# Cross-cutting concerns:

- Analytics (AppInsights)
- Logging (ELK-stack)