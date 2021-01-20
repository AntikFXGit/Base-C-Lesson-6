using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Base_C_Lesson_6
{
    public class MyFunc
    {

        // Делегат на функцию
        public delegate double Func(double x);

        public double FuncCalc(double x)
        {
            return x * x - 50 * x + 10;
        }

        public double FuncCalc2(double x)
        {
            return x * x - 20 * x + 15;
        }

        public double FuncCalc3(double x)
        {
            return x * x - 100 * x + 25;
        }


        public void SaveData(Func F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        public double LoadData(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }


        public double LoadData2(string fileName, ref List<double> result, out double minValue)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                result.Add(d);
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            minValue = min;
            return min;
        }

        public List<Func> getFunctions()
        {
            List<Func> functions = new List<Func>();

            // Создаем переменную делегата
            Func fn;

            // Добавляем в список
            fn = FuncCalc;
            functions.Add(fn);

            fn = FuncCalc2;
            functions.Add(fn);

            fn = FuncCalc3;
            functions.Add(fn);

            return functions;
        }


        public int getAnswer(string patternCheck)
        {
            var regex = new Regex(""+ patternCheck + "", RegexOptions.IgnoreCase);
            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (regex.IsMatch(answer))
                {
                    return Int32.Parse(answer);
                }
                else
                {
                    Console.WriteLine("Необходимо использовать только цифры: "+ patternCheck + ".");
                }
            }
        }
    }
}