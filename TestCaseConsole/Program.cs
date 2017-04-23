using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TakeDataFromFile take = new TakeDataFromFile(@"C:\Users\Ilya\Desktop\input.txt");
            WriteDataToFile writePoints = new WriteDataToFile(@"C:\Users\Ilya\Desktop\output.txt");
            //Получение координат из файла
            List<Point> points = take.TakePoints();
            ComputationPoints comp = new ComputationPoints(points);
            points= comp.Compute();
            writePoints.AddPointsToFile(points);
            Console.ReadLine();
        }
    }

}
