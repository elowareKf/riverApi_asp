using System.Collections.Generic;

namespace Models {
    public class River : ModelBase {
        public string Name { get; set; }
        public List<Section> Sections { get; set; }
        public List<LevelSpot> LevelSpots { get; set; }
    }
}