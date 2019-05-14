using System;
using System.Management;

namespace SysInfo
{
    class Hardware_info
    {
        /// <summary>
        /// This class gets the CPU details (number of cores and threads, architecture)
        /// </summary>
        public static void CpuDetails()
        {
            int numberOfCores = 0;
            //Number Of Physical Processors 
            foreach (ManagementBaseObject item in
                new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                Console.WriteLine("Number Of Physical Processors: {0} ", item["NumberOfProcessors"]);
            }
            //Number Of Cores
            foreach (ManagementBaseObject item in
                new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                numberOfCores += int.Parse(item["NumberOfCores"].ToString());
                Console.WriteLine("Number Of Cores: {0} ", numberOfCores);
            }
            //Number Of Threads
            foreach (ManagementBaseObject item in
                new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                Console.WriteLine("Number Of Threads: {0} ", item["NumberOfLogicalProcessors"]);
            }
            //Bitness and Architecture
            foreach (ManagementBaseObject item in
                new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                Console.WriteLine("Bitness: {0}", item["AddressWidth"]);
                Console.WriteLine("Architecture: {0}", GetArchitectureDetail(int.Parse(item["Architecture"].ToString())));
            }
        }
        /// <summary>
        /// Private method for GetArchitectureDetail
        /// </summary>
        /// <param name="architectureNumber"></param>
        /// <returns></returns>
        private static string GetArchitectureDetail(int architectureNumber)
        {
            switch (architectureNumber)
            {
                case 0: return "x86";
                case 1: return "MIPS";
                case 2: return "Alpha";
                case 3: return "PowerPC";
                case 6: return "Itanium-based systems";
                case 9: return "x64";
                default:
                    return "Unkown";
            }
        }
        /// <summary>
        /// Motherboard info
        /// </summary>
        private static class MotherboardInfo
        {
            private static ManagementObjectSearcher baseboardSearcher = 
                new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            private static ManagementObjectSearcher motherboardSearcher = 
                new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_MotherboardDevice");

            public static string Availability
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in motherboardSearcher.Get())
                        {
                            return GetAvailability(int.Parse(queryObj["Availability"].ToString()));
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static bool HostingBoard
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in baseboardSearcher.Get())
                        {
                            if (queryObj["HostingBoard"].ToString() == "True")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return false;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            public static string InstallDate
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in baseboardSearcher.Get())
                        {
                            return ConvertToDateTime(queryObj["InstallDate"].ToString());
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string Manufacturer
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in baseboardSearcher.Get())
                        {
                            return queryObj["Manufacturer"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string Model
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in baseboardSearcher.Get())
                        {
                            return queryObj["Model"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string PartNumber
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in baseboardSearcher.Get())
                        {
                            return queryObj["PartNumber"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string PNPDeviceID
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in motherboardSearcher.Get())
                        {
                            return queryObj["PNPDeviceID"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string PrimaryBusType
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in motherboardSearcher.Get())
                        {
                            return queryObj["PrimaryBusType"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string Product
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in baseboardSearcher.Get())
                        {
                            return queryObj["Product"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static bool Removable
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in baseboardSearcher.Get())
                        {
                            if (queryObj["Removable"].ToString() == "True")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return false;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            public static bool Replaceable
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in baseboardSearcher.Get())
                        {
                            if (queryObj["Replaceable"].ToString() == "True")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return false;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            public static string RevisionNumber
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in motherboardSearcher.Get())
                        {
                            return queryObj["RevisionNumber"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string SecondaryBusType
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in motherboardSearcher.Get())
                        {
                            return queryObj["SecondaryBusType"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string SerialNumber
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in baseboardSearcher.Get())
                        {
                            return queryObj["SerialNumber"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string Status
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject querObj in baseboardSearcher.Get())
                        {
                            return querObj["Status"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string SystemName
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in motherboardSearcher.Get())
                        {
                            return queryObj["SystemName"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            public static string Version
            {
                get
                {
                    try
                    {
                        foreach (ManagementObject queryObj in baseboardSearcher.Get())
                        {
                            return queryObj["Version"].ToString();
                        }
                        return "";
                    }
                    catch (Exception)
                    {
                        return "N/a";
                    }
                }
            }

            private static string GetAvailability(int availability)
            {
                switch (availability)
                {
                    case 1: return "Other";
                    case 2: return "Unknown";
                    case 3: return "Running or Full Power";
                    case 4: return "Warning";
                    case 5: return "In Test";
                    case 6: return "Not Applicable";
                    case 7: return "Power Off";
                    case 8: return "Off Line";
                    case 9: return "Off Duty";
                    case 10: return "Degraded";
                    case 11: return "Not Installed";
                    case 12: return "Install Error";
                    case 13: return "Power Save - Unknown";
                    case 14: return "Power Save - Low Power Mode";
                    case 15: return "Power Save - Standby";
                    case 16: return "Power Cycle";
                    case 17: return "Power Save - Warning";
                    default: return "Unknown";
                }
            }

            private static string ConvertToDateTime(string unconvertedTime)
            {
                string convertedTime = "";
                int year = int.Parse(unconvertedTime.Substring(0, 4));
                int month = int.Parse(unconvertedTime.Substring(4, 2));
                int date = int.Parse(unconvertedTime.Substring(6, 2));
                int hours = int.Parse(unconvertedTime.Substring(8, 2));
                int minutes = int.Parse(unconvertedTime.Substring(10, 2));
                int seconds = int.Parse(unconvertedTime.Substring(12, 2));
                string meridian = "AM";
                if (hours > 12)
                {
                    hours -= 12;
                    meridian = "PM";
                }
                convertedTime = date.ToString() + "/" + month.ToString() + "/" + year.ToString() + " " +
                hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString() + " " + meridian;
                return convertedTime;
            }
        }
        /// <summary>
        /// Method for calling the Mobo_info
        /// </summary>
        public static void Mobo_info()
        {
            Console.WriteLine("Availability: " + MotherboardInfo.Availability);
            Console.WriteLine("HostingBoard: " + MotherboardInfo.HostingBoard);
            Console.WriteLine("InstallDate: " + MotherboardInfo.InstallDate);
            Console.WriteLine("Manufacturer: " + MotherboardInfo.Manufacturer);
            Console.WriteLine("Model: " + MotherboardInfo.Model);
            Console.WriteLine("PartNumber: " + MotherboardInfo.PartNumber);
            Console.WriteLine("PNPDeviceID: " + MotherboardInfo.PNPDeviceID);
            Console.WriteLine("PrimaryBusType: " + MotherboardInfo.PrimaryBusType);
            Console.WriteLine("Product: " + MotherboardInfo.Product);
            Console.WriteLine("Removable: " + MotherboardInfo.Removable);
            Console.WriteLine("Replaceable: " + MotherboardInfo.Replaceable);
            Console.WriteLine("RevisionNumber: " + MotherboardInfo.RevisionNumber);
            Console.WriteLine("SecondaryBusType: " + MotherboardInfo.SecondaryBusType);
            Console.WriteLine("SerialNumber: " + MotherboardInfo.SerialNumber);
            Console.WriteLine("Status: " + MotherboardInfo.Status);
            Console.WriteLine("SystemName: " + MotherboardInfo.SystemName);
            Console.WriteLine("Version: " + MotherboardInfo.Version);
        }
        /// <summary>
        /// GPU info
        /// </summary>
        public static void GPU_info()
        {
            ManagementObjectSearcher myVideoObject = 
                new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                Console.WriteLine("Name  -  " + obj["Name"]);
                Console.WriteLine("Status  -  " + obj["Status"]);
                Console.WriteLine("Caption  -  " + obj["Caption"]);
                Console.WriteLine("DeviceID  -  " + obj["DeviceID"]);
                Console.WriteLine("AdapterRAM  -  " + obj["AdapterRAM"]);
                Console.WriteLine("AdapterDACType  -  " + obj["AdapterDACType"]);
                Console.WriteLine("Monochrome  -  " + obj["Monochrome"]);
                Console.WriteLine("InstalledDisplayDrivers  -  " + obj["InstalledDisplayDrivers"]);
                Console.WriteLine("DriverVersion  -  " + obj["DriverVersion"]);
                Console.WriteLine("VideoProcessor  -  " + obj["VideoProcessor"]);
                Console.WriteLine("VideoArchitecture  -  " + obj["VideoArchitecture"]);
                Console.WriteLine("VideoMemoryType  -  " + obj["VideoMemoryType"]);
            }
        }
    }
}
