using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabProjectDemo.Core.Entities
{
    public class Markcode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        public string? Code { get; set; }
        /*public Markcode(string id, string code)
        {
            Id = id;
            Code = code;
        }*/
    }
}
