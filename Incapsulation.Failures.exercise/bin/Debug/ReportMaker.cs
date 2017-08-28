using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Failures
{
    enum FailureType
    {
        UnexpectedShutdown = 0,
        NonResponding = 1,
        HardwareFailures = 2,
        ConnectionProblems = 3
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

        public static List<string> FindDevicesFailedBeforeDate(FailureTypes failure, Device device, DateTime date)
        {
            var problematicDevices = new HashSet<int>();
            //var failureType = new IEnumerable<int>(device.Id.AsEnumerable);
            
            for (int i = 0; i < failure.Types.Length; i++)
                if (FailureTypes.IsFailureSerious(failure.Types[i]) == 1 && 
                    DateTime.Earlier(date.Times[i], date.Day, date.Month, date.Year) == 1)
                {
                    problematicDevices.Add(device.Id[i]);
                }

            var result = new List<string>();

            foreach (var oneDevice in device.Id)
                if (problematicDevices.Contains(oneDevice))
                    result.Add(device.Name[oneDevice] as string);

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
            var failure = new FailureTypes(failureTypes);
            var device = new Device(deviceId);
            var date = new DateTime(day, month, year, times);

            foreach (var oneDevice in devices)
            {
                device.Name.Add(oneDevice["Name"]);
            }

            var result = FindDevicesFailedBeforeDate(failure, device, date);
            return result;
        }
    }

    public class Device
    {
        private int[] devices;
        private List<object> name;

        public int[] Id
        {
            get { return devices; }
            set { devices = value; }
        }

        public List<object> Name
        {
            get { return name; }
            set { name = value; }
        }

       public Device(int[] deviceId)
        {
            Id = deviceId;
            Name = new List<object> { };
        }
    }

    public class FailureTypes
    {
        private int[] failureTypes;

        public int[] Types
        {
            get { return failureTypes; }
            set { failureTypes = value; }
        }

        public FailureTypes(int[] types)
        {
            Types = types;
        }

        public static int IsFailureSerious(int failureType)
        {
            //if (failureType % 2 == 0) return 1;
            if (failureType == (int)FailureType.UnexpectedShutdown ||
                failureType == (int)FailureType.HardwareFailures) return 1;
            return 0;
        }
    }

    public class DateTime
    {
        private int day;
        private int month;
        private int year;
        private object[][] times;

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public object[][] Times
        {
            get { return times; }
            set { times = value; }
        }

        public DateTime(int day, int month, int year, object[][] times)
        {
            Day = day;
            Month = month;
            Year = year;
            Times = times;
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
}
