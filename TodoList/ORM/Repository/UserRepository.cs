using System;
using System.Collections.Generic;
using TodoList.ORM.Entity;

namespace TodoList.ORM.Repository
{
    public abstract class UserRepository : Abstract.Repository
    {
        public static UserEntity GetEntityBy(string field, string value)
        {
            return GetEntityBy<UserEntity>(field, value);
        }

        public static bool UserExist(string username, string password)
        {
            try
            {
                UserEntity user = GetEntityBy("username", username);

                return user.Equals(new UserEntity(new Dictionary<string, string>()
                    { { "id", user.Id }, { "username", username }, { "password", password } }));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}