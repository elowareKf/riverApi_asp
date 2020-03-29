using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
    public abstract class ModelBase {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Deleted { get; set; }
    }
}