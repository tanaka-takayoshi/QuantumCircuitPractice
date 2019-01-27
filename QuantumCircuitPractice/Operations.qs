namespace QuantumCircuitPractice
{
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Primitive;

    operation HelloQ () : Unit {
        Message("Hello quantum world!");
    }

     operation MeasurementOneQubit () : Result {
        
        mutable result = Zero;
        
        // The following using block creates a fresh qubit and initializes it in |0〉.
        using (qubits = Qubit[2]) {
            let qubit = qubits[0];
            
            // Apply a Hadamard operation H to the state, thereby creating
            // the state 1/sqrt(2)(|0〉+|1〉).
            H(qubit);
            AssertProb([PauliZ], [qubit], Zero, 0.5, "Error: Outcomes of the measurement must be equally likely", 1E-05);
            
            // Now we measure the qubit in Z-basis
            set result = M(qubit);
            
            // As the qubit is now in an eigenstate of the measurement operator,
            // i.e., either in |0> or in |1>, and qubits need to be in |0> when they
            // are released, we have to manually reset the qubit before releasing it.
            if (result == One) {
                X(qubit);
            }
        }
        
        // Finally, we return the result of the measurement.
        return result;
    }

    operation MeasurementBellBasis () : (Result, Result) {
        
        mutable result = (Zero, Zero);
        
        // The following using block creates a fresh qubit and initializes it in |0〉.
        using (qubits = Qubit[2]) {
            
            // By applying the Hadamard operator and a CNOT, we create the cat state
            // 1/sqrt(2)(|00〉+|11〉).
            let qubit0 = qubits[0];
            let qubit1 = qubits[1];
            H(qubit0);
            CNOT(qubit0, qubit1);
            
            // The following two assertions ascertain that the created state is indeed
            // invariant under both, the XX and the ZZ operations, i.e., it projects
            // into the +1 eigenstate of these two Pauli operators.
            Assert([PauliZ, PauliZ], qubits, Zero, "Error: EPR state must be eigenstate of ZZ");
            Assert([PauliX, PauliX], qubits, Zero, "Error: EPR state must be eigenstate of XX");
            AssertProb([PauliZ, PauliZ], qubits, One, 0.0, "Error: 01 or 10 should never occur as an outcome", 1E-05);
            
            // Finally, we measure each qubit in Z-basis and construct a tuple from the results.
            set result = (M(qubit0), M(qubit1));
            
            // This time we use the canon function ResetAll to reset all the qubits at once.
            ResetAll(qubits);
        }
        
        // Finally, we return the result of the measurement.
        return result;
    }
}
