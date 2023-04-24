using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Diagnostics;

namespace ClassLibrary3
{
    public class MongoTest
    {
        public MongoTest()
        {
            Run();
        }


        public void Run()
        {
            Debug.WriteLine("Start");

            var client = new MongoClient();
            var database = client.GetDatabase("testDb");

            var collection = database.GetCollection<BsonDocument>("name");
            //Console.WriteLine(collection.Count(new BsonDocument()));

            var document = new BsonDocument
{
    { "name", "MongoDB" },
    { "type", "Database" },
    { "count", 1 },
    { "info", new BsonDocument
        {
            { "x", 203 },
            { "y", 102 }
        }}
};
            collection.InsertOne(document);

            Console.WriteLine(database.DatabaseNamespace.DatabaseName);
            //Console.WriteLine(collection.Count(new BsonDocument()));

            Console.ReadLine();
        }
    }
}
