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
            if (bone.ToString().Contains("Neck"))
            {
                if (angles["neckAngle"] < 130 || angles["neckAngle"] > 176)
                {
                    return Form.Bad;
                }
            }        
            if (bone.ToString().Contains("KneeLeft"))
            {
                if (angles["leftKneeAngle"] < 60)
                {
                    return Form.Bad;
                }
            }
            if (bone.ToString().Contains("KneeRight"))
            {
                if (angles["rightKneeAngle"] < 60)
                {
                    return Form.Bad;
                }
            }
            if (bone.ToString().Contains("SpineShoulder"))
            {
                // TODO: make the range larger for warning type
                // Generally the range is only between 176 and 178 FYI
                if (Math.Floor(angles["upperBackAngle"]) != 177)
                {
                    return Form.Bad;
                }
            }
            if (bone.ToString().Contains("SpineMid"))
            {
                if (Math.Floor(angles["lowerBackAngle"]) != 177 && Math.Floor(angles["lowerBackAngle"]) != 178)
                {
                    return Form.Bad;
                }
            }

            return Form.Good;
        }
    }
}
