# shopping-listing

## Description

This μService is responsible for providing listings. In theory this could be any type of listing, however in this sample we'll focus on listing products.

## How to run

There's a `Dockerfile` which you can run individually to just launch the listing service.

### Building the docker image

`$ docker build --no-cache -t stephanvs/shopping-listing .`

### Starting the container

`$ docker run -t -d -p 5001:5001 stephanvs/shopping-listing`

## Running tests

...
