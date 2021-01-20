using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Base_C_Lesson_6
{


    public class MyCollection
    {

        // Структура базы данных студентов
        public struct User
        {
            public string firstName, secondName, univercity, faculty, department, city;
            public int age, сourse, group;
        }

        // База студентов
        List<User> users = new List<User>();

        // Делегаты
        public delegate bool Cnt(int[] args, User u);


        public MyCollection()
        {
            // Парсим файл 
            GetData();
        }

        void GetData()
        {
            StreamReader sr = new StreamReader("..\\..\\students_1.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    users.Add(new User { 
                        firstName = s[0].Trim(),
                        secondName = s[1].Trim(),
                        univercity = s[2].Trim(),
                        faculty = s[3].Trim(),
                        department = s[4].Trim(),
                        age = Int32.Parse(s[5]),
                        сourse = Int32.Parse(s[6]),
                        group = Int32.Parse(s[7]),
                        city = s[8].Trim()
                    });
                }
                catch
                {
                }
            }
            sr.Close();
        }

        
        public List<User> GetUsers()
        {
            return users;
        }


        public int MyCount(Cnt D, int[] args)
        {
            int result = 0;
            result = users.Where(u => D(args, u)).Count();
            return result;
        }

        // [0] - min; [1] - max;
        public bool CountAge(int[] args, User u)
        {
            int min = 0, max = 0;
            if(args.Length == 1)
            {
                min = args[0];
            } else if(args.Length > 1)
            {
                min = args[0];
                max = args[1];
            }

            // Фильтр
            if(min!=0 || max!=0)
            {
                if(min!=0 && max==0)
                {
                    return (u.age >= min) ? true : false;
                } else if(min != 0 && max != 0) {
                    return (u.age >= min && u.age <= max) ? true : false;
                } else if(min == 0 && max != 0)
                {
                    return (u.age <= max) ? true : false;
                }
            }
            return false;
        }









    }
}