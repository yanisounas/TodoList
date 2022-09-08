using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DatabaseManager.Database
{
    public class DatabaseManager
    {
        private string _host;
        private string _username;
        private string _password;
        private string _name;
        private string _query;
        private string _whereStatement;
        private QueryType _qt;
        private MySqlConnection _connection;
        
        private static DatabaseManager _instance;
        
        public static DatabaseManager GetInstance(string host, string dbUsername, string dbPassword, string dbName)
        {
            return _instance ?? (_instance = new DatabaseManager(host, dbUsername, dbPassword, dbName));
        }
        
        public static DatabaseManager GetInstance()
        {
            return _instance;
        }

        private DatabaseManager(string host, string dbUsername, string dbPassword, string dbName)
        {
            _host = host;
            _username = dbUsername;
            _password = dbPassword;
            _name = dbName;
            _query = null;
            _whereStatement = null;
            _qt = QueryType.NONE;
            _connection = new MySqlConnection("server="+ _host +";username="+ _username +";password="+ _password +";database="+ _name);
            
        }
        
        private bool OpenConnection()
        {
            // TODO: Gérer les erreurs
            _connection.Open();
            return true;
        }

        private bool CloseConnection()
        {
            // TODO: Gérer les erreurs
            _connection.Close();
            return true;
        }
        
        private MySqlCommand ExecuteCommand()
        {
            if (!OpenConnection()) throw new Exception("Can't open connection");
            if (_qt == QueryType.NONE) throw new Exception("You have to build a query before");
            if (String.IsNullOrEmpty(_query)) throw new Exception("Can't execute empty query");
            if (
                (_qt == QueryType.DELETE || _qt == QueryType.UPDATE)
                && string.IsNullOrEmpty(_whereStatement)
            ) 
                throw new Exception("Selected method need a where statement");
            
            return new MySqlCommand(_query + _whereStatement, _connection);
        }

        public void ExecuteQuery()
        {

            MySqlCommand cmd = ExecuteCommand();
            cmd.ExecuteNonQuery();
            CloseConnection();
            
            _query = null;
            _whereStatement = null;
            _qt = QueryType.NONE;
        }

        public MySqlDataReader FetchAll()
        {
            MySqlCommand cmd = ExecuteCommand();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            return dataReader;
        }

        // WHERE
        public DatabaseManager Where(Dictionary<string, string> whereStatements, string separator = "AND")
        {
            _whereStatement = " WHERE ";

            foreach (KeyValuePair<string, string> entry in whereStatements)
            {
                _whereStatement += "`" + entry.Key + "`='"+ entry.Value + "'" + ( entry.Equals(whereStatements.Last()) ? "" : " " + separator + " " );
            }
            return this;
        }

        public DatabaseManager Where(List<string> columns, List<string> values, string separator = "AND")
        {
            Dictionary<string, string> columnsValues = new Dictionary<string, string>();
            foreach (var i in Enumerable.Range(0, columns.Count)) columnsValues.Add(columns[i], values[i]);
            return Where(columnsValues);
        }
        
        // INSERT
        public DatabaseManager BuildInsert(string table, List<string> columns, List<string> values)
        {
            _qt = QueryType.INSERT;
            _query = "INSERT INTO " + table + "(`" + String.Join("`, `", columns) + "`) VALUES('" + String.Join("', '", values) + "')";
            Console.WriteLine(_query);
            
            return this;
        }

        public DatabaseManager BuildInsert(string table, Dictionary<string, string> columnsValues)
        {
            List<string> columns = new List<string>();
            List<string> values = new List<string>();


            foreach (KeyValuePair<string, string> entry in columnsValues)
            {
                columns.Add(entry.Key);
                values.Add(entry.Value);
            }
            
            return BuildInsert(table, columns, values);
        }

        public DatabaseManager BuildInsert(string table, Dictionary<string, string> columnsValues, Dictionary<string, string> whereStatement)
        {
            return BuildInsert(table, columnsValues).Where(whereStatement);
        }

        public DatabaseManager BuildInsert(string table, List<string> columns, List<string> values, Dictionary<string, string> whereStatement)
        {
            return BuildInsert(table, columns, values).Where(whereStatement);
        }
        
        // UPDATE
        public DatabaseManager BuildUpdate(string table, Dictionary<string, string> columnsValues)
        {
            _qt = QueryType.UPDATE;
            _query = "UPDATE `"+ table +"` SET ";

            foreach (KeyValuePair<string, string> entry in columnsValues)
            {
                _query += "`" + entry.Key + "`='" + entry.Value + "'" + ( entry.Equals(columnsValues.Last()) ? "" : ", " );
            }
            
            return this;
        }
        
        public DatabaseManager BuildUpdate(string table, List<string> columns, List<string> values)
        {
            Dictionary<string, string> columnsValues = new Dictionary<string, string>();
            foreach (var i in Enumerable.Range(0, columns.Count)) columnsValues.Add(columns[i], values[i]);
            return BuildUpdate(table, columnsValues);
        }

        public DatabaseManager BuildUpdate(string table, Dictionary<string, string> columnsValues, Dictionary<string, string> whereStatement)
        {
            return BuildUpdate(table, columnsValues).Where(whereStatement);
        }

        public DatabaseManager BuildUpdate(string table, List<string> columns, List<string> values, Dictionary<string, string> whereStatement)
        {
            return BuildUpdate(table, columns, values).Where(whereStatement);
        }

        // DELETE
        public DatabaseManager BuildDelete(string table)
        {
            _qt = QueryType.DELETE;
            _query = "DELETE FROM " + table;
            return this;
        }
        
        public DatabaseManager BuildDelete(string table, Dictionary<string, string> whereStatement)
        {
            return BuildDelete(table).Where(whereStatement);
        }
        
        // SELECT
        public DatabaseManager BuildSelect(string table, List<string> columns)
        {
            _qt = QueryType.SELECT;
            _query = "SELECT `" + String.Join("`, `", columns) + "` FROM " + table;
            return this;
        }
        
        public DatabaseManager BuildSelect(string table, List<string> columns, Dictionary<string, string> whereStatement)
        {
            return BuildSelect(table, columns).Where(whereStatement);
        }
        
        public DatabaseManager BuildSelect(string table)
        {
            _qt = QueryType.SELECT;
            _query = "SELECT * FROM " + table;
            return this;
        }

        public DatabaseManager BuildSelect(string table, Dictionary<string, string> whereStatement)
        {
            return BuildSelect(table).Where(whereStatement);
        }

        public MySqlDataReader this[string table] => BuildSelect(table).FetchAll();
        public MySqlDataReader this[string table, List<string> columns] => BuildSelect(table, columns).FetchAll();
        public MySqlDataReader this[string table, Dictionary<string, string> whereStatement] => BuildSelect(table, whereStatement).FetchAll();
        public MySqlDataReader this[string table, List<string> columns, Dictionary<string, string> whereStatement] => BuildSelect(table, columns, whereStatement).FetchAll();

    }
}