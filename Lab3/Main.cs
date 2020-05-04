using Lab3.Classes;
using System;

namespace Lab3 {
    class RandomNumberGenerators {
        static void Main() {
            Console.WriteLine("Quantile Function Generator");
            QuantileFunctionGenerator algoritm1 = new QuantileFunctionGenerator();
            algoritm1
                .InitializeGenerator()
                .GenerateValues()
                .PrintValues();

            Console.WriteLine("\n\nElimination Generator");
            EliminationGenerator algoritm2 = new EliminationGenerator();
            algoritm2
                .GenerateValues()
                .PrintValues();
        }
    }
}
