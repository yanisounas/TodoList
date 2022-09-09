using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TodoList.ORM.Entity
{
    public class UserEntity : Abstract.Entity
    {
        public override string TableName => "users";

        public string Id { get; private set; }
        public string Username { get; private set; }
        private string Password { get; set; }
        
        public UserEntity()
        {}
        
        public UserEntity(MySqlDataReader reader) : base(reader)
        {
            Set(reader);
        }

        public UserEntity(Dictionary<string, string> values) : base(values)
        {
            Set(values);
        }
        
        public UserEntity(Dictionary<string, object> values) : base(values)
        {
            Set(values);
        }
        
        public sealed override void Set(MySqlDataReader reader)
        {
            while (reader.Read())
            {
                Id = reader["id"] + "";
                Username = reader["username"] + "";
                Password = reader["password"]+ "";
            }
        }

        public sealed override void Set(Dictionary<string, string> values)
        {
            Id = values["id"];
            Username = values["username"];
            Password = values["password"];
        }
        
        public sealed override void Set(Dictionary<string, object> values)
        {
            Id = values["id"] + "";
            Username = values["username"] + "";
            Password = values["password"] + "";
        }
        
        public override bool Equals(object obj)
        {
            return obj is Abstract.Entity && obj.GetType() == typeof(UserEntity) && ((UserEntity)obj).Equals(this);
        }
        
        private bool Equals(UserEntity other)
        {
            return Id == other.Id && Username == other.Username && Password == other.Password;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Username != null ? Username.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Password != null ? Password.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override void Persist()
        {
            throw new System.NotImplementedException();
        }
    }
}