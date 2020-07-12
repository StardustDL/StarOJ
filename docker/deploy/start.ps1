docker-compose down

docker-compose up -d judge0db judge0redis db
Start-Sleep -Seconds 10
docker-compose up -d
Start-Sleep -Seconds 5