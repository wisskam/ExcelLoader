using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExcelLoader
{
    static class ConnectionList
    {
        public static List<Connection> Connections = new List<Connection>();
        public static int Selected;
        private static string ListFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //private static string ListFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\'ExcelLoader";


        public static void Add(Connection connection)
        {
            Connections.Add(connection);
            Selected = Connections.IndexOf(connection);
        }        
        public static void Remove(Connection connection)
        {
            Connections.Remove(connection);
            Selected = -1;
        }
        public static void Load()
        {
            string json;
            if(File.Exists(Path.Combine(ListFilePath, "Connections.json"))){
                using (var sr = new StreamReader(Path.Combine(ListFilePath, "Connections.json")))
                {
                    json = sr.ReadToEnd();
                }
                Connections = JsonConvert.DeserializeObject<List<Connection>>(json);
            }
            else
            {
                Save();
            }
        } 
        public static void Save()
        {
            string json = JsonConvert.SerializeObject(Connections);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(ListFilePath, "Connections.json")))
            {
                outputFile.WriteLine(json);
            }

        }
        public static bool isEmpty()
        {
            return !Connections.Any();
        }
        public static Connection Current()
        {
            return ConnectionList.Connections[Selected];
        }
    }
}
