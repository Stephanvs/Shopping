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

The below is the preferred approach to take to build this project:

- **identity** &rarr; user identity and authorization (&hellip;)
- **search** &rarr; search for products (ElasticSearch)
- [**listing**](/listing) &rarr; view product details (MongoDB)
- **review** &rarr; product reviews (&hellip;)
- **cart** &rarr; shopping cart (&hellip;)
- **order** &rarr; (&hellip;)
- **xsell** &rarr; related items (Machine Learning)

# Cross-cutting concerns:

- Analytics (AppInsights)
- Logging (ELK-stack)

# Running the solution

This application consists of several little, targeted services and in order to be able to run the entire solution in a cohesive way in your local machine, it leverages [Docker Compose](https://docs.docker.com/compose/). You should be able to get everything up and running by running `docker-compose up` command under the root directory of this repository.
