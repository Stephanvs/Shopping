FROM stephanvs/dnx-docker:1.0.0-rc1

EXPOSE 5001/tcp
ENTRYPOINT ["dnx", "-p", "project.json", "web"]

COPY project.json /app/
COPY NuGet.Config /
WORKDIR /app
RUN ["dnu", "restore"]
COPY . /app
