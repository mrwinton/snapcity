using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Kinect;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    class SquatLiftTracker : ILiftTracker
    {

        public Form track(Dictionary<string, double> angles, Tuple<JointType, JointType> bone, IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints)
        {
            int warnRange = 6;

            int neckLow = 80;
            int neckHigh = 160;

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

            int kneeLow = 60;

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

            int spineWarnMultiplier = 10;

            int spineLow = 177;
            int spineHigh = 178;

            if (bone.ToString().Contains("SpineShoulder"))
            {
                if (angles["upperBackAngle"] < spineLow || angles["upperBackAngle"] > spineHigh)
                {
                    return Form.Bad;
                }
                else if (angles["upperBackAngle"] < spineLow + warnRange / spineWarnMultiplier || angles["upperBackAngle"] > spineHigh - warnRange / spineWarnMultiplier)
                {
                    return Form.Warn;
                }
            }

            if (bone.ToString().Contains("SpineMid"))
            {
                if (angles["lowerBackAngle"] < spineLow || angles["lowerBackAngle"] > spineHigh)
                {
                    return Form.Bad;
                }
                else if (angles["lowerBackAngle"] < spineLow + warnRange / spineWarnMultiplier || angles["lowerBackAngle"] > spineHigh - warnRange / spineWarnMultiplier)
                {
                    return Form.Warn;
                }
            }

            return Form.Good;
        }
    }
}
