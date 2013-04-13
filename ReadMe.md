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


