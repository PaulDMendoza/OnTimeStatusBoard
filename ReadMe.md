#OnTime Status Board

## Requirements

* IIS 7
* .NET 4.5
* ASP.NET MVC 4
* SQL Server 2008 and above

## Setup
You will only need these steps if you want to install this application behind a firewall. Otherwise you can just use the public website.

1. Edit the Web.Config connection string so that it is the database you want to use. The site will auto generate the database for you.
1. Edit the Web.Config appsetting called "OnTimeClientID" to be the ClientID you configure.
1. Deploy the site to the server you want to run it on.
1. On the web server an Environment variable called "OnTimeClientSecret" that is the secret that OnTime provides.
1. Open the website.
1. It should automatically create a database for you on the local SQL Server or the one you specify in the connection string. 
1. You need to set some defaults on the UserProfile table or creating a new user won't work. Add a default to the following columns. ShowDefects = 1, ShowFeatures = 1, RefreshRate = 180. If you don't like these defaults you can change them and all new users will get different defaults.




