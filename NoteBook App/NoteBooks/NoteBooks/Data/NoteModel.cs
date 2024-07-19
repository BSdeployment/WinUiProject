using System;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace NoteBooks.Data
{
    public class NoteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteNumber { get; set; }
        public string Title { get; set; } = "My Title";
        public string Content { get; set; } = "My Content";
        public string CreatedDate { get; set; } = DateTime.Now.Date.ToString("d");

   }
}
