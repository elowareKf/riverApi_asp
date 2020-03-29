using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
    public abstract class ModelBase {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Deleted { get; set; }
    }
}