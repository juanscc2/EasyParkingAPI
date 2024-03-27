using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyParking.Api.Data.Models
{
    public class User
    {
        [Key]
        //Incrementable
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Username { get;set; }

        public string Password { get; set; }
        public int IdRole { get; set; }

        [ForeignKey("Id")]
        
        public virtual Role Role { get; set; }

        public ICollection<Helmet> Helmets { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
