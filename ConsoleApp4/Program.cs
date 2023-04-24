using MongoDB.Driver;

var client = new MongoClient();
var database = client.GetDatabase("testDb");


var collections = database.ListCollections();


Console.WriteLine(database.DatabaseNamespace.DatabaseName);
Console.WriteLine(collections.ToList().Count);

Console.ReadLine();
