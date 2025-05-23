﻿// See https://aka.ms/new-console-template for more information

using MongoDB.Bson;
using MongoDB.Driver;

Console.WriteLine("Hello, World!");

try
{
    MongoClientSettings mongoClientSettings = new MongoClientSettings()
    {
        Servers = new[]
        {
            new MongoServerAddress("s1.mongo.infrastructure.docker"),
        },
        DirectConnection = false,
        Credential = MongoCredential.CreateCredential("admin", "admin", "basic"),
         ReplicaSetName = "Workflow"
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

      Console.WriteLine("Databases found: " + String.Join(",", (await client.ListDatabaseNamesAsync()).ToList()));
    Console.WriteLine("Collections found: " + String.Join(",", (await mongoDatabase.ListCollectionsAsync()).ToList()));
}
catch (Exception e)
{
    Console.WriteLine(e);
}
