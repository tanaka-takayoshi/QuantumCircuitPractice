using System;
using Microsoft.Quantum.Samples.OpenQasm;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace QuantumCircuitPractice
{
    class Driver
    {
        static void Main(string[] args)
        {
            var factory = new FileDriver(3);
            var result = SomeAdjointOperation.Run(factory).Result;
            factory.Draw();
        }
    }
}