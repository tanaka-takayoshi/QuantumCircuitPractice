import sys, qiskit
from qiskit import load_qasm_string
from qiskit.tools.visualization import circuit_drawer
from qiskit import QuantumCircuit, ClassicalRegister, QuantumRegister

print(sys.version)
print("qiskit version:", qiskit.__version__)

circ = QuantumCircuit.from_qasm_file("input.txt")

utf8stdout = open(1, 'w', encoding='utf-8', closefd=False)
circ.draw(filename="output.txt")
