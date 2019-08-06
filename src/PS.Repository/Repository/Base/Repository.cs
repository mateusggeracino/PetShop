using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PS.Domain.Models;
using PS.Repository.Factory;
using PS.Repository.Interfaces.Base;

namespace PS.Repository.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly IMongoCollection<T> Collection;
        public Repository(IConfiguration config, string databaseName)
        {
            var connectionFactory = new ConnFactory(config);
            Collection = connectionFactory.GetDataBase(databaseName).GetCollection<T>(typeof(T).Name.ToLower());
        }

        public T Insert(T obj)
        {
            Collection.InsertOne(obj);
            return obj;
        }

        public T Update(T obj)
        {
            var filter = Builders<T>.Filter.Eq("Id", obj.Id);
            Collection.FindOneAndReplace(filter, obj);
            return obj;
        }

        public bool Remove(int id)
        {
            Collection.DeleteOne(Builders<T>.Filter.Eq("Id", id));
            return true;
        }

        public T Read(int id)
        {
            var filters = Builders<T>.Filter.Eq("Id", id);
            return Collection.Find(filters).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return Collection.AsQueryable().ToList();
        }
    }
}