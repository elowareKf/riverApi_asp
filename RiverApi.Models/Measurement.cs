namespace Models {
    public class Measurement : ModelBase {
        public string TimeStamp { get; set; }
        public double? Level { get; set; }
        public double? Flow { get; set; }
        public double? Temperature { get; set; }
        public string Origin { get; set; }
    }
}