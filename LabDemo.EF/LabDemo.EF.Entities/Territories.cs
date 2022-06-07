namespace LabDemo.EF.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Territories
    {
        [Key]
        [StringLength(20)]
        public string TerritoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }

        public virtual Region Region { get; set; }
    }
}
