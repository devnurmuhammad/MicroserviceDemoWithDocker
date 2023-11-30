using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroserviceDemoWithDocker.Models
{
    [Table(name:"Person", Schema = "dbo")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name:"Id")]
        public int Id { get; set; }
        [Column(name:"Name")]
        public string Name { get; set; }
        [Column(name:"Email")]
        public string Email { get; set; }
    }
}
