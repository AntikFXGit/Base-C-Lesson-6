using System;

namespace Base_C_Lesson_6
{
    public class MyDelegate
    {

        // Объявляем делегат
        public delegate double MyDel(double a, double x);
        
        public void Table(MyDel F, double x, double a)
        {
            Console.WriteLine("| {0,8} | {1,8}  | {2,8} |", "X", "Y", "FUNC");
            while (x <= a)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000}  | {2,8:0.000} |", x, a, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public double MyFunc(double x, double a)
        {
            return a * (x * x);
        }

        public double MyFunc2(double x, double a)
        {
            return a * Math.Sin(x);
        }

    }
}