using System.Configuration;

namespace Workshop16DbCsharp
{
    internal class PostgresDataAccess
    {
        // variable to store the connection string
        private static string connectionString = LoadConnectionString();

        private static string LoadConnectionString(string id = "Default")
        {
            // Return the connection string stored in the configuration file
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        // ###### Here starts CRUD operations ( Create, Read-retrieve, Update, and Delete) ######

        //TODO: Create user
        //TODO: Retrieve user
        //TODO: Update user
        //TODO: Delete user

        //TODO: Create course
        //TODO: Retrieve course
        //TODO: Update course
        //TODO: Delete course

    }
}
