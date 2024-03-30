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

        public ICollection<Helmet> Helmet { get; set; }

        public ICollection<Vehicle> Vehicle { get; set; }
        public ICollection<Bill> Bill { get; set; }
    }
}
