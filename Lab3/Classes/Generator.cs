using System;
using System.Collections.Generic;
using Lab3.Interfaces;

namespace Lab3.Classes {
    // base class for all generators
    public abstract class Generator<T> : IPrintValues<Generator<T>> {
        protected List<T> generatedValues;
        protected const int n = 10000;
        protected Generator() {
            generatedValues = new List<T>();
        }

        // print values ganarated by the generator
        public Generator<T> PrintValues() {
            foreach (T val in generatedValues)
                Console.Write(val + " ");

            return this;
        }
    }
}
