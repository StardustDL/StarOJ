from invoke import task
import platform
import subprocess

DB_NAME = 'staroj-db'

@task
def db(c, op = 'up'):
    match op:
        case 'up':
            c.run(f"docker start {DB_NAME}")
        case 'down':
            c.run(f"docker stop {DB_NAME}")
        case 'create':
            c.run(f"docker run --name {DB_NAME} -d -p 3306:3306 -e MYSQL_ROOT_PASSWORD=213546 mysql")
        case 'rm':
            c.run(f"docker rm {DB_NAME}")
        case 'exec':
            subprocess.run(f'docker exec -it {DB_NAME} /bin/bash -c "mysql -uroot -p213546"')