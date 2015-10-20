using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    public class SimpleKalman

    {

        private double Q = 0.0001;
        //private double Q = 0.000001;

        private double R = 0.01;

        private double P = 1;

        private double X = 0;

        private double K;


        private void measurementUpdate()

        {

            K = (P + Q) / (P + Q + R);

            P = R * (P + Q) / (R + P + Q);

        }



        public double update(double measurement)

        {

            measurementUpdate();

            double result = X + (measurement - X) * K;

            X = result;

            return result;

        }

    }

}
