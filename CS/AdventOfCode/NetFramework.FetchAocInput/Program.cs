using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using Microsoft.Build.BuildEngine;
//using System.Threading.Channels;
//using Microsoft.Build.BuildEngine;
using Microsoft.VisualBasic;
//using NetCore.stdLibCs;
//using Project = Microsoft.Build.Evaluation.Project;

namespace FetchAoCInput
{
    class Program
    {
        public static readonly string AocFolder = "C:\\users\\jaksl\\" + "AdventOfCode";

        public static readonly string CsAocFolder =
            AocFolder + "\\CS\\AdventOfCode\\2021";
        public const string AoCUri = "https://adventofcode.com/2021/day/";
        public const string cookieFile = "C:\\Users\\jaksl\\AdventOfCode\\cookies-adventofcode-com.txt";
        public static readonly string curlFmtString = "curl --cookie {0} -X GET https://adventofcode.com/2021/day/{1}/input";
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(CsAocFolder);
            List<DirectoryInfo> projects = dir.GetDirectories().ToList();
            projects = projects.Where(o => o.Name.Length == 5).ToList();

            List<DirectoryInfo> projectsNeedingInput = new List<DirectoryInfo>();
            foreach (var p in projects)
            {
                if (p.Name == "Day12")
                {
                    FileInfo inputFile;
                    Environment.CurrentDirectory = p.FullName;
                    try
                    {
                        inputFile = p.GetFiles("Input.txt").First();
                    }
                    catch (Exception e)
                    {
                        File.Create("Input.txt");
                        inputFile = new FileInfo("Input.txt");
                    }


                    if (inputFile.Length < 1)
                    {
                        
                        var input = CurlInputFile(int.Parse(p.Name.Substring(3, 2)));
                        SaveInputToFile(input);
                    }
                }
            }

            // Environment.CurrentDirectory = 
                ModifyCsProjForInputFile(); 

        }

        private static void SaveInputToFile(string input)
        {
            var inputDLFile = "Input.txt";
            
            if (File.Exists(inputDLFile))
                File.Delete(inputDLFile);

            using (StreamWriter sw = new StreamWriter(inputDLFile))
            {

                sw.Write(input.TrimEnd('\n', '\r'));
                sw.Flush();
                ModifyCsProjForInputFile();
            }
        }

        private static void ModifyCsProjForInputFile()
        {
            Console.WriteLine(Environment.Version);
            
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory);
            var csproj = dir.GetFiles("*.csproj").First();
            
            //var projFile = File.ReadAllText(csproj.FullName);
            var projFile = new XmlReader()


        }

        public static string GetCurlString(int day)
        {
            return String.Format(curlFmtString, cookieFile, day);
        }
        private static string CurlInputFile(int day)
        {
            string stdOut = string.Empty;
            string stdErr = string.Empty;
            using (Process proc = new Process()
                   {
                       StartInfo = new ProcessStartInfo()
                       {
                           FileName = "cmd.exe",
                           Arguments = "/c ",
                           CreateNoWindow = true,
                           UseShellExecute = false,
                           RedirectStandardOutput = true,
                           RedirectStandardError = true,
                       },
                   })
            {
                proc.OutputDataReceived += (sender, eventArgs) => stdOut += eventArgs.Data + "\n";
                proc.ErrorDataReceived += (sender, eventArgs) => stdErr += eventArgs.Data + "\n";

                proc.StartInfo.Arguments += GetCurlString(day);
                //"curl --cookie C:\\Users\\jaksl\\AdventOfCode\\cookies-adventofcode-com.txt -X GET https://adventofcode.com/2021/day/12/input";

                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();

                return stdOut;
            }
        }
    }
}