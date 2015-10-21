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
                if (angles["neckAngle"] < 130 || angles["neckAngle"] > 176)
                {
                    return Form.Bad;
                } 
                // TODO: Example of how to add warning state.
                else if (angles["neckAngle"] < 120 || angles["neckAngle"] > 120)
                {
                    return Form.Warn;
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
            //if (bone.ToString().Contains("SpineShoulder"))
            //{
            //    // TODO: make the range larger for warning type
            //    // Generally the range is only between 176 and 178 FYI
            //    if (Math.Floor(angles["upperBackAngle"]) != 177)
            //    {
            //        return Form.Bad;
            //    }
            //}
            if (bone.ToString().Contains("SpineMid"))
            {
                if (Math.Floor(angles["lowerBackAngle"]) != 177 && Math.Floor(angles["lowerBackAngle"]) != 178)
                {
                    return Form.Bad;
                }
            }
            if ((bone.ToString().Contains("ShoulderRight") && bone.ToString().Contains("SpineShoulder")) || (bone.ToString().Contains("ShoulderLeft") && bone.ToString().Contains("SpineShoulder")))
            {
                if (angles["shoulderAngle"] < 130 || angles["shoulderAngle"] > 155)
                {
                    return Form.Bad;
                }
            }

            return Form.Good;
        }
    }
}
