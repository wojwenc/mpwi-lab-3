using Lab3.Interfaces;
using System;

namespace Lab3.Classes {
    // class for generating random values using the elimination method
    class EliminationGenerator : Generator<Tuple<double, double>>, IGenerateValues<EliminationGenerator>, IPrintValues<EliminationGenerator> {
        private const int a = 20;
        private const int b = 60;
        private const int d = 30;

        // probability distribution function
        private double F(double x) {
            return 2 * x - 20;
        }

        // generate n random values using the elimination method and save U2 anf f(U2)
        public EliminationGenerator GenerateValues() {
            generatedValues.Clear();
            Random rand = new Random();

            // generate n values
            while (generatedValues.Count < n) {
                double U1 = (1 - rand.NextDouble()) * (b - a) + a;
                double U2 = (1 - rand.NextDouble()) * d;

                // if the condition is met save U1 and f(U1)
                if (F(U1) >= U2)
                    generatedValues.Add(Tuple.Create(U1, F(U1)));
            }

            return this;
        }

        // print generated pairs
        public new EliminationGenerator PrintValues() {
            return (EliminationGenerator)base.PrintValues();
        }
    }
}
