using System;

namespace SysInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Hardware_info.CpuDetails();
            Hardware_info.GPU_info();
            Hardware_info.Mobo_info();
        }
    }
}
