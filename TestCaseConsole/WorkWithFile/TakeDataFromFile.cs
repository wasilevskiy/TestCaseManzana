using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TestCaseConsole
{
    class TakeDataFromFile
    {
        private string _FilePath;
        public TakeDataFromFile( string fPath)
        {
            _FilePath = fPath;
        }
        public List<Point> TakePoints()
        {
            List<Point> list = new List<Point>();
            StreamReader sReader = new StreamReader(_FilePath);
            string line;
            while ((line = sReader.ReadLine()) != null) 
            {
                Point p = new Point();
                p.X = int.Parse(line.Split(';')[0]);
                p.Y = int.Parse(line.Split(';')[1]);
                list.Add(p);
            }
            sReader.Close();
            return list;
        }
    }
}
