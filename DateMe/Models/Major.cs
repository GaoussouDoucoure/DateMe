using System.ComponentModel.DataAnnotations;

namespace DateMe.Models
{
    public class Major          //this is going to be our 2nd table in the database
    {
        [Key]
        public int MajorId{ get; set; }
        public string MajorName{ get; set; }
    }
}
