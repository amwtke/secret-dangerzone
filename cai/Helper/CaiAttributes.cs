using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cai
{
    [AttributeUsage(AttributeTargets.Field)]
    public class KeyAttribute : Attribute
    {
        string _keyName;
        public KeyAttribute(string KeyName)
        {
            _keyName = KeyName;
        }

        public string KeyName
        {
            get { return _keyName; }
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TreeInforAttribute : Attribute
    {
        string _dbName;
        string _treeName;
        public TreeInforAttribute(string dbName, string treeName)
        {
            _dbName = dbName;
            _treeName = treeName;
        }

        public string DBName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }

        public string TreeName
        {
            get { return _treeName; }
            set { _treeName = value; }
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class DB4OClassAttribute : Attribute
    {
        string _dbName;
        public DB4OClassAttribute(string dbName)
        {
            _dbName = dbName;
        }

        public string DBName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }
    }
}
