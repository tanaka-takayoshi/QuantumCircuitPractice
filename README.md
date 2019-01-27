# QuantumCircuitPractice

## requirement

- python3
- qiskit `pip install qiskit`
- Quantum Development Kit by Microsoft

Please edit the following code.

QuantumCircuitPractice\OpenQASM\FileDriver.cs

Ensure python is under PATH environment variable or specify the full path of python.

```cs
var python = @"python.exe";
```

Right now, we have to specifythe how many Qubits you're using in the Q# code explicitly.

```cs
public override int QBitCount => 2;
```