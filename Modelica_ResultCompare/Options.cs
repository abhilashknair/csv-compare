﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace CsvCompare
{
    public enum OperationMode
    {
        NotSet,
        CsvFileCompare,
        CsvTreeCompare,
        FmuChecker
    }

    public class Options
    {
        [Option('a', "args", Required = false, HelpText = "Arguments to run fmu checker with. [Default is \"-l 5 -h 1e-2 -s 1.5\"]")]
        public string CheckerArgs { get; set; }

        [Option('c', "checker", Required = false, HelpText = "Complete path of the FMU Checker binary without arguments.")]
        public string CheckerPath { get; set; }

        [Option('l', "logfile", Required = false, HelpText = "Log the output to the given file.")]
        public string Logfile { get; set; }

        [Option('m', "mode", DefaultValue = OperationMode.CsvFileCompare, Required = false, HelpText = "Set the tools operation mode. Valid modes are: CsvFileCompare, CsvTreeCompare, FmuChecker")]
        public OperationMode Mode { get; set; }

        [Option('o', "override", DefaultValue = false, HelpText = "Override output files if they already exist (Default behaviour is to put the output next to the foudn file with a timestamp in the filename).")]
        public bool OverrideOutput { get; set; }

        [Option('e', "abserror", DefaultValue = false, HelpText = "Shows, if set, only 0 and 1 in the error graph (peeks) instead of the difference between the error and the penetrated tube.")]
        public bool AbsoluteError { get; set; }

        [Option('r', "reportdir", HelpText = "Specifies the directory where the html reports(s) are to be saved.")]
        public string ReportDir { get; set; }

        [Option('t', "tolerance", DefaultValue = "0.002", Required = false, HelpText = "Set the width of the tube at discontinuity in x-direction [Default is 0.002].")]
        public string Tolerance { get; set; }

        [Option('v', "verbosity", DefaultValue = 4, Required = false, HelpText = "Sets the verbositiy of the output (1 most to 4[Default] less verbose).")]
        public int Verbosity { get; set; }

        [Option('d', "delimiter", Required = false, HelpText = "Sets the delimiter that is used to parse and write csv files. Default accepts \";\" or \",\".")]
        public char Delimiter { get; set; }

        [ValueList(typeof(List<string>), MaximumElements = 2)]
        public IList<string> Items { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            Environment.ExitCode = 1;
            return HelpText.AutoBuild(this).ToString();
        }
    }
}
