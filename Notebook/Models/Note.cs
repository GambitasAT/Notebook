using System.ComponentModel.DataAnnotations;

namespace Notebook.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
