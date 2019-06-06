using System;

namespace SysInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            hw_info();
        }

        static void hw_info()
        {
            Hardware_info.CpuDetails();
            Console.WriteLine("=============");
            Hardware_info.GPU_info();
            Console.WriteLine("=============");
            Hardware_info.Mobo_info();
        }
    }
}
