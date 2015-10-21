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
            if (bone.ToString().Contains("Neck"))
            {
                if (angles["neckAngle"] < 160 && angles["neckAngle"] > 180)
                {
                    return Form.Bad;
                }
            }
            else if (bone.ToString().Contains("LeftKnee"))
            {
                if (angles["leftKneeAngle"] > 80)
                {
                    return Form.Bad;
                }

            }
            else if (bone.ToString().Contains("RightKnee"))
            {
                if (angles["rightKneeAngle"] > 170)
                {
                    return Form.Bad;
                }
            }
            else if (bone.ToString().Contains("SpineShoulder"))
            {
                if (angles["upperBackAngle"] > 170)
                {
                    return Form.Bad;
                }
            }
            else if (bone.ToString().Contains("SpineMid"))
            {
                if (angles["lowerBackAngle"] > 80)
                {
                    return Form.Bad;
                }
            }

            return Form.Good;
           
        }
    }
}
