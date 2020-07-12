docker-compose -f .\docker-compose.mirror.yml down

docker-compose -f docker-compose.mirror.yml up -d judge0db judge0redis db
Start-Sleep -Seconds 10
docker-compose -f docker-compose.mirror.yml up -d
Start-Sleep -Seconds 5