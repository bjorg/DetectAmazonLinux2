using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DetectAmazonLinux2 {

    public class Program {

        //--- Constants ---
        private static string SYSTEM_OS_INFORMATION = "/etc/system-release";

        //--- Class Methods ---
        public static void Main(string[] args) {
            Console.WriteLine($"Amazon Linux 2: {(IsAmazonLinux2() ? "Yes" : "No")}");
        }

        private static bool IsAmazonLinux2() {

            // check if running on Linux OS
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                try {
                    if(File.Exists(SYSTEM_OS_INFORMATION)) {
                        var osRelease = File.ReadAllText(SYSTEM_OS_INFORMATION);
                        return osRelease.StartsWith("Amazon Linux release 2", StringComparison.Ordinal);
                    }
                } catch { }
            }
            return false;
        }
    }
}
