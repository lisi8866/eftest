using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyNoteItem.ViewModels
{
    public class NoteModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "标题")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "内容")]
        public string Content { get; set; }
    }
}
