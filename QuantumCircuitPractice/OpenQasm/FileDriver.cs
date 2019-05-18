using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Quantum.Simulation.Core;

namespace Microsoft.Quantum.Samples.OpenQasm
{
    public class FileDriver : OpenQasmDriver
    {
        private readonly int qbitCount;
        
        public override string Name => "File";

        public FileDriver(int qbitCount) : base(qbitCount) => this.qbitCount = qbitCount;
        public FileDriver() : this(20) { }

        protected override IEnumerable<Result> RunOpenQasm(StringBuilder qasm, int runs)
        {
            //DOnothing
            return Enumerable.Repeat(Result.Zero, QBitCount);
        }

        public void Draw()
        {
            var input = "input.txt";
            var output = "output.jpg";
            File.WriteAllText(input, QasmLog.ToString(), Encoding.ASCII);

            var python = @"python.exe";
            var arguments = $"run.py";

            var processStart = new ProcessStartInfo()
            {
                FileName = python,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            var process = new Process()
            {
                StartInfo = processStart,
                EnableRaisingEvents = true
            };
            // process.OutputDataReceived += (p, o) => Console.WriteLine(o.Data);
            // process.ErrorDataReceived += (p, o) => Console.Error.WriteLine(o.Data);
            process.Start();
            // process.BeginErrorReadLine();
            // process.BeginOutputReadLine();
            process.WaitForExit();

            //if (File.Exists(output))
            //{
            //    var result = File.ReadAllText(output);
            //    Console.Write(result);
            //    Console.WriteLine();
            //}
            //else
            //{
            //    Console.WriteLine("Missing output in outputfile");
            //}
        }
    }
}