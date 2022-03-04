using System;
using System.Reflection;
using UnityEngine;

namespace Pingprovements
{
    public static class Extensions
    {
        public static void SetObjectValue(this object obj, string fieldName, object value)
        {
            obj.GetType()
                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(obj, value);
        }

        public static T GetObjectValue<T>(this object obj, string fieldName) =>
            (T) obj.GetType()
                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(obj);
        
        public static Color ToColor(this string colorString)
        {
            float[] colorValues = Array.ConvertAll(colorString.Split(','), 
                                                  str => float.Parse(str, System.Globalization.CultureInfo.InvariantCulture));

            return new Color(colorValues[0], colorValues[1], colorValues[2], colorValues[3]);
        }
        
        public static bool IsObjectVisible(this Camera camera, Transform targetObjectTransform)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(targetObjectTransform.position);
            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            {
                return true;
            }

            return false;
        }
    }
}
