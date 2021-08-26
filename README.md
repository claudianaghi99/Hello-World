# HelloWorldApp
## How to deploy to Heroku
1.Login to heroku
```
heroku login
heroku container:login
```
2. Build container

Build docker image:
```
docker build -t app-helloworld-naghi
```

3. Create and run docker container
```
docker run -d -p 8081:80 --name app-helloworld-naghi_container app-helloworld-naghi
```

4. Push container
```
heroku container:push -a app-helloworld-naghi web
```

5. Release the container
```
heroku container:release -a app-helloworld-naghi web
```