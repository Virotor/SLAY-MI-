using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAY_MI_
{
    class Equation
    {
        public List<double> Y { get; set; }
        public List<List<double>> X { get; set; }
        public double Presicion { get; set;} 

        public List<double> Calculate()
        {
            List<double> result = new() { 0,0,0,0,0};
            List<double> resultPrev = new();
            do
            {
                resultPrev.Clear();
                result.ForEach(x =>  resultPrev.Add(x));
                result[0] = (Y[0] - X[0][1] * resultPrev[1])/X[0][0];
                result[1] = (Y[1] - resultPrev[0] * X[1][0] - resultPrev[2] * X[1][2]) / X[1][1];
                result[2] = (Y[2] - resultPrev[1] * X[2][0] - resultPrev[3] * X[2][2]) / X[2][1];
                result[3] = (Y[3] - resultPrev[2] * X[3][0] - resultPrev[4] * X[3][2]) / X[3][1];
                result[4] = (Y[4] - resultPrev[3] * X[4][0]) / X[4][1];
            }while (!IsPrecision(result, resultPrev));

            


            return result;
        }


        private bool IsPrecision(List<double> values, List<double> valuesPref)
        {
            List<double> vs = values.Zip(valuesPref).ToList().Select(x => Math.Abs(Math.Abs(x.First - x.Second)-Presicion)).ToList();
            
            return vs.All(x => x.CompareTo(Presicion) <= 0);
        }


    }
}
