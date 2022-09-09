using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TodoList.ORM.Abstract
{
    public abstract class Entity
    {
        public abstract string TableName { get; }

        protected Entity()
        {}
        
        protected Entity(MySqlDataReader reader)
        {}
        
        protected Entity(Dictionary<string, string> values)
        {}

        protected Entity(Dictionary<string, object> values)
        {}

        public abstract override bool Equals(object obj);

        public abstract void Persist();
        public abstract void Set(MySqlDataReader reader);
        public abstract void Set(Dictionary<string, string> values);
        public abstract void Set(Dictionary<string, object> values);
    }
}