"# Simple WebAPI by Gio Lavilla" 

Simple REST API demo. ( Programmed using Visual Studio 2015)

To Install, Clone or download the file 

git clone https://github.com/gwaping/webapi.git

In the project directory open :

WebApi.sln  

- Set Database Path.

        Database used is sqlite.

        Database File path is declared in the constructor of SqliteConnection Class. 

        public SqliteConnection()
        {

            string sqliteDatabase = "C:\\Users\\admin\\Desktop\\Ombori\\WebApi\\DataAccess\\bin\\Release\\OmboriDB.db";
            strConnection = String.Format("Data Source={0}", sqliteDatabase);
        }
  
  
Headers :
        Content-Type application/json
        Authorization Basic b21ib3JpOm9tYm9yaQ==  // set this on post and delete to allow access 
        
Sample JSON Post
 {
        "ExpirationDate": "2020-02-24",
        "ProductName": "Sample Product Name",
        "UsesLeft": 1,
        "Description": "Description Description",
        "IsActive": false,
        "PatientId": "7"
  }

Please also check Screenshot folder.

