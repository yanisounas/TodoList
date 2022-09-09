using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TodoList.ORM.DatabaseManager
{
    public class Database
    {
        private string _query;
        private string _whereStatement;
        private QueryType _qt;
        private MySqlConnection _connection;
        
        private static Database _instance;

        public static Database GetInstance(string host, string dbUsername, string dbPassword, string dbName)
        {
            return _instance ?? (_instance = new Database(host, dbUsername, dbPassword, dbName));
        }
        
        public static Database GetInstance()
        {
            return _instance;
        }

        private Database(string host, string dbUsername, string dbPassword, string dbName)
        {
            _query = null;
            _whereStatement = null;
            _qt = QueryType.None;
            _connection = new MySqlConnection("server="+ host +";username="+ dbUsername +";password="+ dbPassword +";database="+ dbName);
            
        }
        
        private bool OpenConnection()
        {
            // TODO: Gérer les erreurs
            _connection.Open();
            return true;
        }

        private void CloseConnection()
        {
            // TODO: Gérer les erreurs
            _connection.Close();
            _query = null;
            _whereStatement = null;
            _qt = QueryType.None;
        }
        
        private MySqlCommand ExecuteCommand()
        {
            if (!OpenConnection()) throw new Exception("Can't open connection");
            if (_qt == QueryType.None) throw new Exception("You have to build a query before");
            if (String.IsNullOrEmpty(_query)) throw new Exception("Can't execute empty query");
            if (
                (_qt == QueryType.Delete || _qt == QueryType.Update)
                && string.IsNullOrEmpty(_whereStatement)
            ) 
                throw new Exception("Selected method need a where statement");
            _query += _whereStatement;
            return new MySqlCommand(_query, _connection);
        }

        public void ExecuteQuery()
        {
            ExecuteCommand().ExecuteNonQuery();
            CloseConnection();
        }

        public Dictionary<string, object> Fetch()
        {
            MySqlDataReader dataReader = ExecuteCommand().ExecuteReader();
            
            dataReader.Read();
            Dictionary<string, object> data = (dataReader.HasRows) ? Enumerable.Range(0, dataReader.FieldCount).ToDictionary(dataReader.GetName, dataReader.GetValue) : new Dictionary<string, object>();
            CloseConnection();
            return data;
        }

        public List<Dictionary<string, object>> FetchAll()
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            
            MySqlDataReader dataReader = ExecuteCommand().ExecuteReader();
            while (dataReader.Read())
            {
                Dictionary<string, object> values = new Dictionary<string, object>();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    values[dataReader.GetName(i)] = dataReader.GetValue(i);
                }
                
                data.Add(values);
            }
            
            dataReader.Close();
            CloseConnection();

            return data;
        }

        // WHERE
        public Database SingleWhere(string column, string value)
        {
            _whereStatement = " WHERE `" + column + "`='" + value + "'";
            return this;
        }
        
        public Database Where(Dictionary<string, string> whereStatements, string separator = "AND")
        {
            _whereStatement = " WHERE ";

            foreach (KeyValuePair<string, string> entry in whereStatements)
            {
                _whereStatement += "`" + entry.Key + "`='"+ entry.Value + "'" + ( entry.Equals(whereStatements.Last()) ? "" : " " + separator + " " );
            }
            return this;
        }

        public Database Where(List<string> columns, List<string> values, string separator = "AND")
        {
            Dictionary<string, string> columnsValues = new Dictionary<string, string>();
            foreach (var i in Enumerable.Range(0, columns.Count)) columnsValues.Add(columns[i], values[i]);
            return Where(columnsValues, separator);
        }
        
        // INSERT
        public Database BuildInsert(string table, List<string> columns, List<string> values)
        {
            _qt = QueryType.Update;
            _query = "INSERT INTO " + table + "(`" + String.Join("`, `", columns) + "`) VALUES('" + String.Join("', '", values) + "')";
            Console.WriteLine(_query);
            
            return this;
        }

        public Database BuildInsert(string table, Dictionary<string, string> columnsValues)
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

        public Database BuildInsert(string table, Dictionary<string, string> columnsValues, Dictionary<string, string> whereStatement)
        {
            return BuildInsert(table, columnsValues).Where(whereStatement);
        }

        public Database BuildInsert(string table, List<string> columns, List<string> values, Dictionary<string, string> whereStatement)
        {
            return BuildInsert(table, columns, values).Where(whereStatement);
        }
        
        // UPDATE
        public Database BuildUpdate(string table, Dictionary<string, string> columnsValues)
        {
            _qt = QueryType.Update;
            _query = "UPDATE `"+ table +"` SET ";

            foreach (KeyValuePair<string, string> entry in columnsValues)
            {
                _query += "`" + entry.Key + "`='" + entry.Value + "'" + ( entry.Equals(columnsValues.Last()) ? "" : ", " );
            }
            
            return this;
        }
        
        public Database BuildUpdate(string table, List<string> columns, List<string> values)
        {
            Dictionary<string, string> columnsValues = new Dictionary<string, string>();
            foreach (var i in Enumerable.Range(0, columns.Count)) columnsValues.Add(columns[i], values[i]);
            return BuildUpdate(table, columnsValues);
        }

        public Database BuildUpdate(string table, Dictionary<string, string> columnsValues, Dictionary<string, string> whereStatement)
        {
            return BuildUpdate(table, columnsValues).Where(whereStatement);
        }

        public Database BuildUpdate(string table, List<string> columns, List<string> values, Dictionary<string, string> whereStatement)
        {
            return BuildUpdate(table, columns, values).Where(whereStatement);
        }

        // DELETE
        public Database BuildDelete(string table)
        {
            _qt = QueryType.Delete;
            _query = "DELETE FROM " + table;
            return this;
        }
        
        public Database BuildDelete(string table, Dictionary<string, string> whereStatement)
        {
            return BuildDelete(table).Where(whereStatement);
        }
        
        // SELECT
        public Database BuildSelect(string table, List<string> columns)
        {
            _qt = QueryType.Select;
            _query = "SELECT `" + String.Join("`, `", columns) + "` FROM " + table;
            return this;
        }
        
        public Database BuildSelect(string table, List<string> columns, Dictionary<string, string> whereStatement)
        {
            return BuildSelect(table, columns).Where(whereStatement);
        }
        
        public Database BuildSelect(string table)
        {
            _qt = QueryType.Select;
            _query = "SELECT * FROM `" + table + "`";
            return this;
        }

        public Database BuildSelect(string table, Dictionary<string, string> whereStatement)
        {
            return BuildSelect(table).Where(whereStatement);
        }

        public List<Dictionary<string, object>> this[string table] => BuildSelect(table).FetchAll();
        public List<Dictionary<string, object>> this[string table, List<string> columns] => BuildSelect(table, columns).FetchAll();
        public List<Dictionary<string, object>> this[string table, Dictionary<string, string> whereStatement] => BuildSelect(table, whereStatement).FetchAll();
        public List<Dictionary<string, object>> this[string table, List<string> columns, Dictionary<string, string> whereStatement] => BuildSelect(table, columns, whereStatement).FetchAll();
    }
}