using System;
using System.Collections.Generic;

namespace GalaxyAutoEntity.WpfApplication.GalaxyMemoryDatabase
{
    public static class MemoryDatabaseServer
    {

        public static Dictionary<string, MemoryDatabase> Instances = new Dictionary<string, MemoryDatabase>();

    }
    public class MemoryDatabase
    {

        public MemoryDatabase()
        {

        }
        public Dictionary<string, MemoryTable> Tables = new Dictionary<string, MemoryTable>();

        public void CreateTable(string tableName)
        {
            var memoryTable = new MemoryTable(tableName);
            this.Tables.Add(tableName, memoryTable);
        }
    }
    public class MemoryTable
    {
        public string TableName { get; set; }

        public MemoryTable(string tableName)
        {
            TableName = tableName;
        }
    }
}