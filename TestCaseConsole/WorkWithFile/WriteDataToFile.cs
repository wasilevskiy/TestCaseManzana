using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestCaseConsole
{
    class WriteDataToFile
    {
        private string _FilePath;
        public WriteDataToFile(string path)
        {
            _FilePath = path;
        }

        public void AddPointsToFile(List<Point> InputList)
        {
            List<Point> list = InputList;
            StreamWriter sWriter = new StreamWriter(_FilePath);
            foreach(Point p in list)
            {
                sWriter.WriteLine(p.X + ";" + p.Y);
            }
            sWriter.Close();
        }
    }
}
