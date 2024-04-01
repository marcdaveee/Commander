using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos.Command
{
    public class CommandReadDto
    {
        public int Id { get; set; }

        [Required]  //Data Annotation
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }
    }
}
