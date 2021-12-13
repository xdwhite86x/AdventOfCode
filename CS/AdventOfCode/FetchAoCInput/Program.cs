using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using NetCore.stdLibCs;

namespace FetchAoCInput
{
    class Program
    {
        public static readonly string AocFolder = Std.GetUserHomeDir() + Std.Separator +"AdventOfCode";

        public static readonly string CsAocFolder =
            AocFolder + Std.Separator + "CS" + Std.Separator + "AdventOfCode" + Std.Separator + "2021";
        public const string AoCUri = "https://adventofcode.com/2021/day/";
        public const string cookieFile = "C:\\Users\\jaksl\\AdventOfCode\\cookies-adventofcode-com.txt";
        public static readonly string curlFmtString = "curl --cookie {0} -X GET https://adventofcode.com/2021/day/{1}/input";
        static void Main(string[] args)
        {
            DirectoryInfo dir = new(CsAocFolder);
            List<DirectoryInfo> projects = dir.GetDirectories().ToList();
            projects = projects.Where(o => o.Name.Length == 5).ToList();

            List<DirectoryInfo> projectsNeedingInput = new();
            foreach (var p in projects)
            {
                
                var dayNum = int.Parse(p.Name.Substring(3, 2));

                Console.WriteLine("Day {0}", dayNum);
                FileInfo inputFile;
                Environment.CurrentDirectory = p.FullName;
                Console.WriteLine(Environment.CurrentDirectory);
                try
                {
                    inputFile = p.GetFiles("Input.txt").First();
                    Console.WriteLine("found Input.txt");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Creating Input.txt");
                    File.Create("Input.txt");
                    inputFile = new ("Input.txt");
                }

                if (inputFile.Length < 1)
                {
                    Console.WriteLine("Fetching Data from AoC Website");
                    var input = CurlInputFile(dayNum);
                    SaveInputToFile(input);
                }
                else
                    Console.WriteLine("Input already Contains Data");
                
            }

            // Environment.CurrentDirectory = 
                ModifyCsProjForInputFile(); 

        }

        private static void SaveInputToFile(string input)
        {
            var inputDLFile = "Input.txt";
            
            if (File.Exists(inputDLFile))
                File.Delete(inputDLFile);

            using StreamWriter sw = new(inputDLFile);
            
            sw.Write(input.TrimEnd('\n', '\r'));
            sw.Flush();
            ModifyCsProjForInputFile();
        }

        private static void ModifyCsProjForInputFile()
        {

            bool found = false;
            //regex to find all ItemGroups and determine the files their children apply to
            //has capture groups for both filename and status
            Regex generalRegex = new(@"<None Update=""(?<filename>[\w.-]*\.\w*)"">\r\n *<CopyToOutputDirectory>(?<state>\w*)</CopyToOutputDirectory>\r\n *</None>");
            //regex to use for replacing an existing Input.txt entry (only has the state Capture group)
            Regex Inputregex = new(@"<None Update=""Input.txt"">\r\n *<CopyToOutputDirectory>(?<state>\w*)</CopyToOutputDirectory>\r\n *</None>");
            DirectoryInfo dir = new(Environment.CurrentDirectory);
            var csproj = dir.GetFiles("*.csproj").First();
            var csprojText = File.ReadAllText(csproj.FullName);
            var matches = generalRegex.Matches(csprojText);
            Match mat = Match.Empty;
            
            
            //go through our matches see if one if for plain Input.txt
            foreach (Match match in matches)
            {
                if (match.Groups["filename"].Value == "Input.txt")
                {
                    found = true;
                    mat = match;
                    Console.WriteLine("Input ItemGroup Found");
                }
            }
            //did we find an entry for Input.txt
            if (found && mat != Match.Empty)
            {
                //if we did is it already marked as always
                if (mat.Groups["state"].Value != "Always")
                {
                    //if its not then update it to be always
                    var temp = GetCsprojString("Input.txt", mat.Groups["state"].Value);
                    csprojText = Inputregex.Replace(csprojText, GetCsprojString());

                }else
                    Console.WriteLine("Nothing to do entry exists and is correct");
            }
            else
            {
                Console.WriteLine("Input ItemGroup Not Found Creating...");
                //find an the end to PropertyGroup Tag (usually the first one VS makes
                var searchString = "/PropertyGroup";
                var index = csprojText.IndexOf(searchString);
                //split the string in half at this point
                var firstHalf = csprojText.Substring(0, index + searchString.Length + 3); 
                var secondHalf = csprojText.Substring(index + searchString.Length + 3);
                //inject an ItemGroup entry for Input.txt to be copied always to Output Dir
                var inputText = "\t<ItemGroup>" + Environment.NewLine +  
                                GetCsprojString() + Environment.NewLine +
                                "\t</ItemGroup>" + Environment.NewLine;
                csprojText = firstHalf + inputText + secondHalf;
            }
            //save the new ProjectFile
            File.WriteAllText(csproj.FullName, csprojText);
            
            
        }

        public static string GetCsprojString(string filename = "Input.txt", string state = "Always")
        {
            var fmtString =
                "<None Update=\"{0}\">\r\n<CopyToOutputDirectory>{1}</CopyToOutputDirectory>\r\n</None>";
            return string.Format(fmtString, filename, state);
        }
        public static string GetCurlString(int day)
        {
            return String.Format(curlFmtString, cookieFile, day);
        }
        private static string CurlInputFile(int day)
        {
            string stdOut = string.Empty;
            string stdErr = string.Empty;
            using Process proc = new()
            {
                StartInfo = new()
                {
                    FileName = "cmd.exe",
                    Arguments = "/c ",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                },
            };
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