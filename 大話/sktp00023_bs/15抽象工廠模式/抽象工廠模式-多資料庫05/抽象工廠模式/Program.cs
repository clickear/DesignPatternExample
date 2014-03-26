﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace 抽象工廠模式
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Department dept = new Department();

            IUser iu = DataAccess.CreateUser();

            iu.Insert(user);
            iu.GetUser(1);

            IDepartment id = DataAccess.CreateDepartment();
            id.Insert(dept);
            id.GetDepartment(1);

            Console.Read();
        }
    }

    class User
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    class Department
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _deptName;
        public string DeptName
        {
            get { return _deptName; }
            set { _deptName = value; }
        }
    }

    interface IUser
    {
        void Insert(User user);

        User GetUser(int id);
    }

    class SqlserverUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Sqlserver中給User表增加一條記錄");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在Sqlserver中根據ID得到User表一條記錄");
            return null;
        }
    }

    class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Access中給User表增加一條記錄");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在Access中根據ID得到User表一條記錄");
            return null;
        }
    }

    interface IDepartment
    {
        void Insert(Department department);

        Department GetDepartment(int id);
    }

    class SqlserverDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在Sqlserver中給Department表增加一條記錄");
        }

        public Department GetDepartment(int id)
        {
            Console.WriteLine("在Sqlserver中根據ID得到Department表一條記錄");
            return null;
        }
    }

    class AccessDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在Access中給Department表增加一條記錄");
        }

        public Department GetDepartment(int id)
        {
            Console.WriteLine("在Access中根據ID得到Department表一條記錄");
            return null;
        }
    }

    class DataAccess
    {
        private static readonly string AssemblyName = "抽象工廠模式";
        private static readonly string db = "Sqlserver";
        //private static readonly string db = "Access";

        public static IUser CreateUser()
        {
            string className = AssemblyName + "." + db + "User";
            return (IUser)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IDepartment CreateDepartment()
        {
            string className = AssemblyName + "." + db + "Department";
            return (IDepartment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }

}
