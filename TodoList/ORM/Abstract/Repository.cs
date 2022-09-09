using System;
using System.Collections.Generic;
using TodoList.ORM.DatabaseManager;

namespace TodoList.ORM.Abstract
{
    public abstract class Repository
    {
        public static TEntity GetEntityBy<TEntity>(string column, string value) where TEntity : Entity, new()
        {
            TEntity entity = new TEntity();
            Dictionary<string, object> user = Database.GetInstance().BuildSelect(entity.TableName).SingleWhere(column, value).Fetch();
            
            if (user.Count == 0) throw new Exception();
            entity.Set(user);

            return entity;
        }

        public static bool AlreadyExist<TEntity>(TEntity entity) where TEntity : Entity, new()
        {
            return false;
        }
    }
}