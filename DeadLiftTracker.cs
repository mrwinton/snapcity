using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Kinect;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    class DeadLiftTracker : ILiftTracker
    {

        public Form track(Dictionary<string, double> angles, Tuple<JointType, JointType> bone, IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints)
        {
            double warnRange = 3;

            double neckLow = 79;
            double neckHigh = 170;

            if (bone.ToString().Contains("Neck"))
            {
                if (angles["neckAngle"] < neckLow || angles["neckAngle"] > neckHigh)
                {
                    return Form.Bad;
                } 
                else if (angles["neckAngle"] < neckLow + warnRange || angles["neckAngle"] > neckHigh - warnRange)
                {
                    return Form.Warn;
                }
            }

            double kneeLow = 75;

            if (bone.ToString().Contains("KneeLeft"))
            {
                if (angles["leftKneeAngle"] < kneeLow)
                {
                    return Form.Bad;
                }
                else if (angles["leftKneeAngle"] < kneeLow + warnRange)
                {
                    return Form.Warn;
                }
            }

            if (bone.ToString().Contains("KneeRight"))
            {
                if (angles["rightKneeAngle"] < kneeLow)
                {
                    return Form.Bad;
                }
                else if (angles["rightKneeAngle"] < kneeLow + warnRange)
                {
                    return Form.Warn;
                }
            }

            double spineWarnMultiplier = 10;

            double spineLow = 176;
            double spineHigh = 179.5;

            /*if (bone.ToString().Contains("SpineShoulder"))
            {
                if (angles["upperBackAngle"] < spineLow || angles["upperBackAngle"] > spineHigh)
                {
                    return Form.Bad;
                }
                else if (angles["upperBackAngle"] < spineLow + warnRange/spineWarnMultiplier || angles["upperBackAngle"] > spineHigh - warnRange/spineWarnMultiplier)
                {
                    return Form.Warn;
                }
            }*/

            if (bone.ToString().Contains("SpineMid"))
            {
                if (angles["lowerBackAngle"] < spineLow || angles["lowerBackAngle"] > spineHigh)
                {
                    return Form.Bad;
                }
                else if (angles["lowerBackAngle"] < spineLow + warnRange/spineWarnMultiplier || angles["lowerBackAngle"] > spineHigh - warnRange/spineWarnMultiplier)
                {
                    return Form.Warn;
                }
            }

            double shoulderLow = 135;
            double shoulderHigh = 160;

            if ((bone.ToString().Contains("ShoulderRight") && bone.ToString().Contains("SpineShoulder")) || (bone.ToString().Contains("ShoulderLeft") && bone.ToString().Contains("SpineShoulder")))
            {
                if (angles["shoulderAngle"] < shoulderLow || angles["shoulderAngle"] > shoulderHigh)
                {
                    return Form.Bad;
                }
                else if (angles["shoulderAngle"] < shoulderLow + warnRange || angles["shoulderAngle"] > shoulderHigh - warnRange)
                {
                    return Form.Warn;
                }
            }

            return Form.Good;
        }
    }
}
