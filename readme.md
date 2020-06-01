https://zablo.net/blog/post/setup-apache-kafka-in-docker-on-windows/

# Apache Kafka in Docker


## Start docker containers

    docker-compose up

Launches Kafka
- Kafka server / 9092
- Kafka manager (dashboard) / localhost:9000

*Kafka manager is a tool from Yahoo Inc. for managing Apache Kafka.*

## Update hosts file
Append 127.0.0.1 kafkaserver *(c:\windows\system32\etc\hosts)

## Hack - jvm.dll
Added /server path, and copy jvm.dll from /client to /server/jvm.dll

## Start consumer script - listen to _topic topic

    .\kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic kafka_test_topic

## Start producer script - publish to _topic topic

    .\kafka-console-producer.bat --broker-list localhost:9092 --topic kafka_test_topic

## Stop docker

    docker-compose down
    docker ps 