using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseConsole
{
    class ComputationPoints
    {
        private List<Point> _Data;
        
        public ComputationPoints(List<Point> Data )
        {
            _Data = Data;
        }

        public List<Point> Compute()
        {
            Point minPoint = GetMinPoint();
            double[] array = new double[_Data.Count];
            int c = 0;
            foreach(Point p in _Data)
            {
                array[c]= Math.Atan2(GetKatetY(minPoint, p), GetKatetX(minPoint, p));
                c++;
            }
            Sort(ref _Data, array);
            return _Data;
        }

        private void Sort(ref List<Point> list, double [] array)
        {
            double tempArr;
            Point tempPoint;
            for(int i = 0;i<array.Length-1;i++)
            {
                for(int j=i+1;j<array.Length;j++)
                {
                    if(array[i]>array[j])
                    {
                        tempArr = array[i];
                        array[i] = array[j];
                        array[j] = tempArr;
                        tempPoint = list[i];
                        list[i] = list[j];
                        list[j] = tempPoint;
                    }
                }
            }
        }
        private Point GetMinPoint()
        {
            int min = _Data[0].X;
            int index = 0;
            for (int i = 0; i < _Data.Count; i++) 
            {
                if(min>_Data[i].X)
                {
                    min = _Data[i].X;
                    index = i;
                }
            }
            return _Data[index];
        }
        private int GetKatetY(Point minPoint, Point p)
        {
            return (p.Y - minPoint.Y);
        }
        private int GetKatetX(Point minPoint, Point p)
        {
            return (p.X - minPoint.X);
        }
            
    }
}
