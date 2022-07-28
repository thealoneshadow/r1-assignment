using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FirstWebApp.Models
{
    [Table("Todo", Schema = "Aamio")]
    public class Todo {
        
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}