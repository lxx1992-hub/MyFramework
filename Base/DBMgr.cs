using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

namespace MyFramework
{
    public class DBMgr:Singleton<DBMgr>
    {
        string path;
        SqliteConnection connect;
        public void Init()
        {
            string str= Resources.Load<TextAsset>("DataBaseConfig").text;
            path= "Data Source=" + Application.dataPath + str.Trim();
            connect = new SqliteConnection(path);                  
        }
        public void ExecuteNonQuery(string commandString)
        {
            connect.Open();
            SqliteCommand command = connect.CreateCommand();
            command.CommandText = commandString;
            command.ExecuteNonQuery();
            command.Dispose();
            connect.Close();
        }
        public Object ExecuteScalar(string commandString)
        {
            connect.Open();
            SqliteCommand command = connect.CreateCommand();
            command.CommandText = commandString;
            object obj= command.ExecuteScalar();
            command.Dispose();
            connect.Close();
            return obj as Object;
        }
        public SqliteDataReader ExecuteReader(string commandString)
        {
            connect.Open();
            SqliteCommand command = connect.CreateCommand();
            command.CommandText = commandString;
            SqliteDataReader datas = command.ExecuteReader();
            command.Dispose();
            connect.Close();
            return datas;
        }
    }
}
