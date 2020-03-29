using System.Collections.Generic;

namespace Models {
    public class Section : ModelBase {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Grade { get; set; }
        public string SpotGrade { get; set; }
        public string PutIn { get; set; }
        public string TakeOut { get; set; }
        public string ParkPutIn { get; set; }
        public string ParkTakeOut { get; set; }
        public List<HotSpot> HotSpots { get; set; }
        public string Type { get; set; }
        public string Origin { get; set; }
        public string ExtLevelSpot { get; set; }
        public string ExtLevelType { get; set; }
        public double? MinFlow { get; set; }
        public double? MidFlow { get; set; }
        public double? MaxFlow { get; set; }
        public double? MinLevel { get; set; }
        public double? MidLevel { get; set; }
        public double? MaxLevel { get; set; }
        public string RiverName => River?.Name ?? "";
        public int? LevelSpotId { get; set; }
        public LevelSpot LevelSpot { get; set; }
        public River River { get; set; }
        public int RiverId { get; set; }
    }
}