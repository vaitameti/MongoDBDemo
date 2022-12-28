using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDBDemo;
using MongoDataAccess.Models;
using MongoDataAccess.DataAccess;
using System.Linq;

namespace MongoDBDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //string connectionString = "mongodb://127.0.0.1:27017";
            //string databaseName = "simple_db";
            //string collectionName = "people";

            //var client = new MongoClient(connectionString); //connect to mongoDB
            //var db = client.GetDatabase(databaseName); //connect to databse
            //var collection = db.GetCollection<PersonModel>(collectionName); //it is like a table in SQL db

            //var person = new PersonModel
            //{
            //    FirstName = "Vait",
            //    LastName = "Ameti"
            //};

            //await collection.InsertOneAsync(person);

            //var results = await collection.FindAsync(_ => true); //returns every record

            //foreach(var result in results.ToList())
            //{
            //    Console.WriteLine($"{result.Id}: {result.FirstName} {result.LastName}");
            //}
            //Console.ReadLine();

            ChoreDataAccess db = new ChoreDataAccess();

            await db.CreateUser(new UserModels() { FirstName = "Vaita", LastName = "Ameti" });

            var users = await db.GetAllUsers();
            var chore = new ChoreModel()
            {
                AssignedTo = users.First(),
                ChoreText = "Mow the lawn",
                FrequencyInDays = 7
            };

            await db.CreateChore(chore);

            var chores = await db.GetAllChores();

            var newChore = chores.First();
            newChore.LastCompleted = DateTime.UtcNow;

            await db.CompleteChore(newChore);

            Console.ReadKey();
        }
    }
}
