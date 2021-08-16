# HelloWorld
## How to deploy to Heroku

Steps:
1. Create heroku account
2. Create application
3. Choose container registry as deployment method
4. Make sure application works locally

Commands:
Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a app-helloworld-naghi web
```

Release the container
```
heroku container:release -a app-helloworld-naghi web
```