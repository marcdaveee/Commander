using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos.Command
{
    public class CreateCommandDto
    {        

        [Required]  //Data Annotation
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
