using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyParking.Api.Data.Models
{
    public class Helmet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Plate { get; set; }

        public int Value { get;set; }

        public int IdUser { get; set; } 
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
