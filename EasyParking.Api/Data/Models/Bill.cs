using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyParking.Api.Data.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime Entry_Time { get; set; }

        public DateTime Departure_Time { get; set; }

        public int Amount_Payable { get; set; }

        public int IdUser { get; set; }

        [ForeignKey("Id")]
        public virtual User Users { get; set; }
        
    }
}
