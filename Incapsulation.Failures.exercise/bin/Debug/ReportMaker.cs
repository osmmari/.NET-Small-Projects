using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Failures
{

    public class Common
    {
        public static int IsFailureSerious(int failureType)
        {
            if (failureType%2==0) return 1;
            return 0;
        }


        public static int Earlier(object[] v, int day, int month, int year)
        {
            int vYear = (int)v[2];
            int vMonth = (int)v[1];
            int vDay = (int)v[0];
            if (vYear < year) return 1;
            if (vYear > year) return 0;
            if (vMonth < month) return 1;
            if (vMonth > month) return 0;
            if (vDay < day) return 1;
            return 0;
        }
    }

    public class ReportMaker
    {
        /// <summary>
        /// </summary>
        /// <param name="day"></param>
        /// <param name="failureTypes">
        /// 0 for unexpected shutdown, 
        /// 1 for short non-responding, 
        /// 2 for hardware failures, 
        /// 3 for connection problems
        /// </param>
        /// <param name="deviceId"></param>
        /// <param name="times"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        /// 

        private static int[] failureTypes;
        private static int[] deviceId;
        private static List<object> name;

        public static int[] FailureTypes
        {
            get { return failureTypes; }
            set { failureTypes = value; }
        }

        public static int[] Device
        {
            get { return deviceId; }
            set { deviceId = value; }
        }

        public static List<object> Name
        {
            get { return name; }
            set { name = value; }
        }

        public static List<string> FindDevicesFailedBeforeDate(
           int day,
           int month,
           int year,
           object[][] times)
        {

            var problematicDevices = new HashSet<int>();
            for (int i = 0; i < FailureTypes.Length; i++)
                if (Common.IsFailureSerious(failureTypes[i]) == 1 && Common.Earlier(times[i], day, month, year) == 1)
                {
                    problematicDevices.Add(deviceId[i]);
                }

            var result = new List<string>();

            foreach (var device in Device)
                if (problematicDevices.Contains(device))
                    result.Add(Name[device] as string);

            return result;
        }


        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,
            int[] failureTypes,
            int[] deviceId,
            object[][] times,
            List<Dictionary<string, object>> devices)
        {
            FailureTypes = failureTypes;
            Device = deviceId;

            Name = new List<object> { };
            foreach (var device in devices)
            {
                Name.Add(device["Name"]);
            }

            var result = FindDevicesFailedBeforeDate(
                day,
                month,
                year,
                times
                );
            return result;
        }
    }
}
