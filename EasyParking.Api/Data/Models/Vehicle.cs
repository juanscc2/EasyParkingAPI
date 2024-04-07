using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyParking.Api.Data.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Plate { get; set; }

        public string Model { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("Id")]

        public virtual User Users { get; set; }

        

    }
}
