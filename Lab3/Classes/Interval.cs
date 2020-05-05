namespace Lab3.Classes {
    // class for storing intervals, coresponding probabilities and the number of generated values in each interval
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
}
