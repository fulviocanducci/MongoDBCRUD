using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDBCRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MongoDBCRUD
{
    class Program
    {
        static void Main(string[] args)
        {

            IMongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("example");            
            IMongoCollection<News> colNews = database.GetCollection<News>("news");

            #region NewDocument
            Nova coleção
            News doc = new News();
            doc.Title = "Titulo";
            doc.Body = "Texto";
            doc.Created = DateTime.Now;
            doc.Active = true;

            colNews.InsertOne(doc);
            #endregion NewDocument

            #region EditDocument
            //Expression<Func<News, bool>> filter = x => x.Id.Equals(ObjectId.Parse("594b093325841c1b6cac28ea"));

            //News news = colNews.Find(filter).FirstOrDefault();
            //if (news != null)
            //{
            //    news.Value = 200d;                
            //    ReplaceOneResult result = colNews.ReplaceOne(filter, news);                
            //    //result.MatchedCount;
            //    //result.ModifiedCount;
            //}
            #endregion EditDocument

            #region FindDocument                     

            //IMongoQueryable<News> queryAbleNews = colNews.AsQueryable()
            //    .OrderBy(x => x.Created)
            //    .Take(2)
            //    .Skip(0)
            //    .Where(x => x.Title.Contains("s"));

            //IList<News> items = queryAbleNews.ToList();
            #endregion FindDocument

            #region DeleteDocument
            Expression<Func<News, bool>> filter = x => x.Id.Equals(ObjectId.Parse("594b1ff26ae823f4a7722cdc"));
            DeleteResult delresult = colNews.DeleteOne(filter);   
            
            #endregion DeleteDocument
            



            //UpdateDefinition<News> updateNews = Builders<News>.Update.Set(a => a.Position, 0);
            //var result = colNews.UpdateMany(up => up.Title.Contains("t"), updateNews);

            //var result = colNews.UpdateMany(ca => ca.Position == 0, Builders<News>.Update.Inc(x => x.Position, 1));
            var result = colNews.UpdateMany(ca => ca.Position == 1, Builders<News>.Update.Set(x => x.Created, DateTime.Now.Date));

            //Builders<News>.Sort.Ascending(c => c.Active)
            //    .Ascending(c => c.Id);
            //var a = colNews.Find(Builders<News>.Filter.Empty)
            //    .Sort(Builders<News>.Sort.Ascending(c => c.Active)
            //    .Ascending(c => c.Id))
            //    .ToList();
            //News c = colNews                
            //    .Find(x => x.Id.Equals(ObjectId.Parse("594ac1257127cd2a447c5d25")))
            //    .FirstOrDefault();


            //DeleteResult resultDelete = colNews.DeleteOne(Builders<News>.Filter.Eq(c => c.Id, ObjectId.Parse("594b14396ae823f4a7722afc")));
            

            Console.WriteLine("Item inserido com êxito");
        }
    }
}