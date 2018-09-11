FROM 		redis:latest
MAINTAINER 	Vina

COPY        ./.docker/config/redis.production.conf /cache/redis.conf
RUN apt-get update && apt-get install -y net-tools iputils-ping

EXPOSE      6379

ENTRYPOINT  ["redis-server", "/cache/redis.conf"]