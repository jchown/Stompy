using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Stompy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Looking for rogue Kotlin compile processes...");

            while (true)
            {
                Thread.Sleep(1000);
                
                var processes = Process.GetProcesses();
                if (!processes.Any(p => p.ProcessName == "idea64" || p.ProcessName == "idea"))
                {
                    Console.Out.WriteLine("IntelliJ process not found");
                    continue;
                }

                var java = processes.Where(p =>
                {
                    if (p.ProcessName != "java")
                        return false;

                    var parent = p.GetParent();
                    if (parent != null && !parent.HasExited)
                        return false;

                    return true;
                }).ToList();
                if (java.Count == 0)
                {
                    // Console.Out.WriteLine("No Java orphan processes found");
                    continue;
                }
                
                Log("Java orphan processes found");

                foreach (var process in java)
                {
                    Log($"Killing PID {process.Id}");

                    try
                    {
                        process.Kill();
                    }
                    catch (Exception e)
                    {
                        Log($"Failed to kill process: {e.Message}");
                    }
                }
            }
        }

        private static void Log(string message)
        {
            Console.Out.WriteLine(DateTime.Now.ToString() + ": " + message);
        }
    }
}