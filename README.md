# StackOverflow Viewer Application aka SOVA

SOVA is the project made during the RAWDATA Autumn 2017 course at RUC (Roskilde University Center).  
It is a StackOverflow Viewer with a given fixed sample of data. The requests are made in SQL, the back-end in C# and the front-end will be coded in HTML/CSS/JQuery.

Members of the group :
  * Baptiste JOUAN
  * Jean-Alexandre PECONTAL
  * Søren Ulrik Johansen
  * Thomas Halberg
  * Frederik Nordam Rosenvilde Jakobsen

### How to connect to the database

The secret to the connection to the database is the `db.conf` file at the root of the `API` folder.  
  
The file will look like this:  
```
    choice=nlocal
    connection=localhost
    dbname=sova
    uid=**
    pwd=**
    connection=wt-220.ruc.dk
    dbname=raw4
    uid=raw4
    pwd=raw4
```

The `choice` parameter will represent wich type of connection you want, either on the remote database (with `nlocal`) or with your local one (with `local`). If you selected your local database, you'll just need to fill the `uid` & `pwd` parameters with your actual uid and password to your local connection.  

The only thing you need to start the project then, is to open it in Visual Studio and press Ctrl+F5. You'll be instantly transported on the Home page of our project.
