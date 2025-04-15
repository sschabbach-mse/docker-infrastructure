// See https://aka.ms/new-console-template for more information

using MongoDB.Bson;
using MongoDB.Driver;

Console.WriteLine("Hello, World!");

try
{
    MongoClientSettings mongoClientSettings = new MongoClientSettings()
    {
        Servers = new[]
        {
            new MongoServerAddress("mongo"),
        },
        DirectConnection = false,
        Credential = MongoCredential.CreateCredential("admin", "admin", "basic"),
    };

    var client = new MongoClient(mongoClientSettings);

    var mongoDatabase = client.GetDatabase("TimerTest");

    await mongoDatabase.CreateCollectionAsync("messages");

    var collection = mongoDatabase.GetCollection<BsonDocument>("messages");

    var now = DateTime.UtcNow;
    var document = new BsonDocument
    {
        { "ticks", now.Ticks },
        { "date", now.ToLongDateString() },
        { "time", now.ToLongTimeString() },
    };

    await collection.InsertOneAsync(document);

    Console.WriteLine("Databases found: " + String.Join(",", await client.ListDatabaseNamesAsync()));
    Console.WriteLine("Collections found: " + String.Join(",", await mongoDatabase.ListCollectionsAsync()));

}
catch (Exception e)
{
    Console.WriteLine(e);
}