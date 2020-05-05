using Lab3.Interfaces;
using System;
using System.Collections.Generic;

namespace Lab3.Classes {
    // class for generating random values using the quantile function method
    class QuantileFunctionGenerator : Generator<double>, IInitializeGenerator<QuantileFunctionGenerator>, IGenerateValues<QuantileFunctionGenerator>, IPrintValues<QuantileFunctionGenerator>, ICalcDistribution<QuantileFunctionGenerator>, IPrintDistribution<QuantileFunctionGenerator> {
        private readonly double[] probablilties = { 0.2, 0.4, 0.3, 0.1 };
        private readonly int[] values = { 0, 1, 2, 3, 4 };
        private List<Interval> intervals;

        // struct for storing intervals and coresponding probabilities
        class Interval {
            public double probablility;
            public int lowerValueBound;
            public int upperValueBound;
            public int count;

            public Interval(double probablility, int lowerValueBound, int upperValueBound) {
                this.probablility = probablility;
                this.lowerValueBound = lowerValueBound;
                this.upperValueBound = upperValueBound;
                count = 0;
            }
        }

        public QuantileFunctionGenerator() {
            intervals = new List<Interval>();
        }

        // initialize the intervals list
        public QuantileFunctionGenerator InitializeGenerator() {
            intervals.Clear();
            double prevProb = 0.0;

            // generate probablilities and intervals
            for (int i = 0; i < probablilties.Length; i++) {
                // add current probability to previous probabilities so later it can be easily compared
                double prob = probablilties[i] + prevProb;
                intervals.Add(new Interval(prob, values[i], values[i + 1]));
                prevProb = prob;
            }

            return this;
        }

        // generate n random values using the quantile function method and save the to a list
        public QuantileFunctionGenerator GenerateValues() {
            generatedValues.Clear();
            Random rand = new Random();

            for (int i = 0; i < n; i++) {
                // get random value beetween 0 and 1
                double U = rand.NextDouble();

                // check to which in to which interval the value belongs
                foreach (Interval interval in intervals) {
                    if (U < interval.probablility) {
                        // generate random values in range <lowerBound, upperBound)
                        generatedValues.Add((1 - rand.NextDouble()) * ((interval.upperValueBound) - interval.lowerValueBound) + interval.lowerValueBound);
                        break;
                    }
                }
            }

            return this;
        }

        // print generated values
        public new QuantileFunctionGenerator PrintValues() {
            return (QuantileFunctionGenerator)base.PrintValues();
        }

        // calculate how many values were generated in each interval
        public QuantileFunctionGenerator CalcDistribution() {
            // reset counters for each interval
            foreach (Interval interval in intervals)
                interval.count = 0;

            // iterate over all generated values
            foreach (double val in generatedValues) {
                // count how many values are in each interval
                foreach (Interval interval in intervals) {
                    if (val > interval.lowerValueBound && val <= interval.upperValueBound) {
                        interval.count++;
                        break;
                    }
                }
            }

            return this;
        }

        // print how many values were generated in each interval
        public QuantileFunctionGenerator PrintDistribution() {
            Console.Write(Environment.NewLine);

            foreach (Interval interval in intervals)
                Console.WriteLine("Generated " + interval.count + " random values in interval (" + interval.lowerValueBound + ", " + interval.upperValueBound + ">");

            return this;
        }
    }
}
