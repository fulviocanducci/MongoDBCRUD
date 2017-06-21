using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBCRUD.Entities;
using System;

namespace MongoDBCRUD
{
    class Program
    {
        static void Main(string[] args)
        {

            IMongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("example");            
            IMongoCollection<News> colNews = database.GetCollection<News>("news");

            //News doc = new News();
            //doc.Title = "Titulo 2";
            //doc.Body = "Texto 2";
            //doc.Created = DateTime.Now;
            //doc.Active = true;




            //colNews.InsertOne(doc);

            UpdateDefinition<News> updateNews = Builders<News>.Update.Set(a => a.Active, false);
            var result = colNews.UpdateMany(up => up.Title.Contains("t"), updateNews);

            News c = colNews                
                .Find(x => x.Id.Equals(ObjectId.Parse("594ac1257127cd2a447c5d25")))
                .FirstOrDefault();


            Console.WriteLine("Item inserido com êxito");
        }
    }
}