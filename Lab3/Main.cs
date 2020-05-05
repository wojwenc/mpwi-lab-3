using Lab3.Classes;
using System;

namespace Lab3 {
    class RandomNumberGenerators {
        static void Main() {
            Console.WriteLine("\n\nElimination Generator");
            EliminationGenerator algoritm1 = new EliminationGenerator();
            algoritm1
                .GenerateValues()
                .PrintValues();

            Console.WriteLine("Quantile Function Generator");
            QuantileFunctionGenerator algoritm2 = new QuantileFunctionGenerator();
            algoritm2
                .InitializeGenerator()
                .GenerateValues()
                .PrintValues()
                .CalcDistribution()
                .PrintDistribution();
        }
    }
}
