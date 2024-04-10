using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos.Command
{
    public class UpdateCommandDto
    {        

        [Required]  //Data Annotation
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }
    }
}
    