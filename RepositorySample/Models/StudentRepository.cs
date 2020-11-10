using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositorySample.Models
{
    public class StudentRepository
    {
        DataModel data;
        List<Student> db = new List<Student>();
        public StudentRepository()
        {
            data = new DataModel();
            List<string> datadb = data.GetStudent();
            GetStudent(datadb);
        }
        private void GetStudent (List<string> datadb)
        {
            foreach (var item in datadb)
            {
                Student std = new Student();
                std.Name = item.Split(',')[0];
                std.Age = Convert.ToInt32(item.Split(',')[1]) ;
                std.Average = Convert.ToInt32(item.Split(',')[2]);
                db.Add(std);
            }
        }
        //your data stored here
        public List<Student> GetStudent()
        {
            return db;
        }


        public int AddStudent (string Name , int Age , int Average)
        {
            return data.AddStudent(Name, Age, Average);
        }

        public int RemoveStudent(string name)
        {
            return data.RemoveStudent(name);
        }
    }
}