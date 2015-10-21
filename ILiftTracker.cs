using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Microsoft.Samples.Kinect.BodyBasics
{

    public enum Form
    {
        Good,
        Bad,
        Warn
    }

    interface ILiftTracker
    {

        Form track(Dictionary<String, Double> angles, Tuple<JointType, JointType> bone, IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints);

    }
}
