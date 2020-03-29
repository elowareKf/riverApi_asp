using System;
using System.Collections.Generic;

namespace Models {
    public class LevelSpot : ModelBase {
        public string ApiUrl { get; set; }
        public string Name { get; set; }
        public double? CreekKm { get; set; }
        public string LatLng { get; set; }
        public DateTime LastMeasurement { get; set; }
        public double? Flow { get; set; }
        public double? Level { get; set; }
        public double? Temperature { get; set; }
        public List<Measurement> Measurements { get; set; }
        public int RiverId { get; set; }
        public int? SectionId { get; set; }
    }
}