import sys, qiskit
import numpy as np
from qiskit import QuantumCircuit, ClassicalRegister, QuantumRegister
from qiskit import execute


print(sys.version)
print("qiskit version:", qiskit.__version__)

circ = QuantumCircuit.from_qasm_file("input.txt")

utf8stdout = open(1, 'w', encoding='utf-8', closefd=False)
circ.draw(filename="output.png",output="mpl")
