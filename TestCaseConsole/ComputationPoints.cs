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

        public ComputationPoints(List<Point> Data)
        {
            _Data = Data;
        }

        public List<Point> Compute()
        {
            SortPoints(_Data);
            return _Data;
        }
        private void SortirovkaOnX(List<Point> list)
        {
            Point temp;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if(list[i].X>list[j].X)
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
        private void SortirovkaOnY( List<Point> list)
        {
            Point temp;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].X == list[j].X)
                    {
                        if (list[i].Y > list[j].Y)
                        {
                            temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                        }
                    }
                }
            }
        }
        
        private void SortPoints(List<Point> list)
        {
            SortirovkaOnX(list);
            SortirovkaOnY(list);
        }
                      
    }
}
