cd wwwsrc
npm run build
cd ..
dotnet publish -c Release
docker build -t keepr ./
docker tag keepr registry.heroku.com/keepr7/web
docker push registry.heroku.com/keepr7/web
heroku container:release web -a keepr7
echo press any key 
read end