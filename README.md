
! Heroku deplyed app: https://app-helloworld-naghi.herokuapp.com/
      
# HelloWorldWeb
## How to deploy to Heroku:

-build container (where the dockerfile is):
```
docker build -t imageName(ex:'app-helloworld-naghi') .
```

-create docker container and run it
```
docker run -d -p 8081:80 --name app-helloworld-naghi_container app-helloworld-naghi
```

-login to Heroku:
```
heroku login
heroku container:login
```

-build the Dockerfile in the current directory and push the container
```
heroku container:push -a app-helloworld-naghi web
```

-release the container.
```
heroku container:release -a app-helloworld-naghi web

```