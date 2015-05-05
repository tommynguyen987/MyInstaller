using System;
using System.Data;

namespace InstantApplicationInstaller
{
    public class DataBase
    {
        public DataBase()
        {
            CheckDB();    
        }
        public string Database
        {
            get
            {
                if (_database == null) _database = System.IO.Directory.GetCurrentDirectory() + "\\data.sqlite";
                return _database;
            }
            set
            {
                _database = value;
            }
        }
        private string _database = null;

        // Get or set the connection string to the SQLite database
        private string ConnectionString
        {
            get
            {
                return "Data Source=" + Database + ";Version=3;";
            }
        }

        public System.Data.DataTable LoadTry(string SQL)
        {
            try
            {
                return Load(SQL);
            }
            catch
            {
                return null;
            }
        }

        public System.Data.DataTable Load(string SQL)
        {
            DataSet ds = new DataSet();
            using (System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection(ConnectionString, true))
            {
                connection.Open();
                using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(SQL, connection))
                {
                    using (System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(command))
                    {
                        da.Fill(ds);
                    }
                }
                connection.Close();
            }
            if (ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        /// <summary>Save data in database</summary>
        public bool Update(string SQL)
        {
            using (System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection(ConnectionString, true))
            {
                connection.Open();
                using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(SQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        /// <summary>Save data in database</summary>
        public bool UpdateTry(string SQL)
        {
            try
            {
                return Update(SQL);
            }
            catch
            {
                return false;
            }            
        }

        public bool isTableExists(string tablename)
        {
            Int32 count = 0;
            string SQL = "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = '" + tablename + "'";
            try
            {
                using (System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection(ConnectionString, true))
                {
                    connection.Open();
                    using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(SQL, connection))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            if ((reader != null) && (reader.Read())) count = reader.GetInt32(0);
                        }
                    }
                    connection.Close();
                }
                return count > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool isColumnExists(String tableName, String columnName)
        {
            System.Data.DataTable tb = new System.Data.DataTable();
            tb = LoadTry("SELECT * FROM " + tableName + " LIMIT 0");
            for (int i = 0; i < tb.Columns.Count; i++)
            {
                if (tb.Columns[i].ColumnName == columnName)
                {
                    return true;
                }
            }
            return false;
        }        

        public string SafeValue(string value)
        {
            if (value == null) return string.Empty;
            return value.Replace('"', '\'');
        }

        public void CheckDB()
        {
            //create table ApplicationInfo
            UpdateTry("CREATE TABLE IF NOT EXISTS \"ApplicationInfo\" (\"ID\"  TEXT PRIMARY KEY NOT NULL,\"AppName\"  TEXT,\"AppPath\"  TEXT,\"AppType\"  TEXT);");
        }   
    }
}
