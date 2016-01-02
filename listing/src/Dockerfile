FROM stephanvs/dnx-docker:1.0.0-rc1

EXPOSE 5001
ENTRYPOINT ["dnx", "-p", "project.json", "web"]

COPY project.json /app/
WORKDIR /app
RUN ["dnu", "restore"]
COPY . /app
