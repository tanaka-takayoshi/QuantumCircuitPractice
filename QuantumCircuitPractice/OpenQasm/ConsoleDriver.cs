// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Quantum.Simulation.Common;
using Microsoft.Quantum.Simulation.Core;

namespace Microsoft.Quantum.Samples.OpenQasm
{
    public class ConsoleDriver : OpenQasmDriver
    {
        public ConsoleDriver(int qbitCount, IQubitManager qubitManager = null) : base(qbitCount, qubitManager)
        {
        }

        public override string Name => "Console";

        protected override IEnumerable<Result> RunOpenQasm(StringBuilder qasm, int runs)
        {
            Console.WriteLine(qasm);
            //No measurement
            return Enumerable.Repeat(Result.Zero, QBitCount);
        }
    }
}