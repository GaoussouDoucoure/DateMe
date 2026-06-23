using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DateMe.Models
{
    public class Application   // this is eventually going to be a table and this is the name
    {
        [Key] //setting ApplicationID as primary key
        [Required] // to make it required
        public int AplicationID { get; set; }   // this will be a field and use as primary key
        public string FirstName { get; set; }   // this will be a field in the table
        public string LastName { get; set; }    // this will be a field in the table
        //[Range(0, 130)] // this is if we want to set a range for age in the database
        public int Age { get; set; }            // this will be a field in the table
        public string PhoneNumber { get; set; } // this will be a field in the table
        [ForeignKey("MajorId")]
        public int MajorId { get; set; }       // this will be a field in the table
        public Major Major { get; set; }
        /* from line 16 to 18 we're basically saying that the majorid from this Application table
           will be the foreign key of an object in Major table. Basically link them. */
        public bool CreeperStalker { get; set; } // this will be a field in the table
    }
    /* This model is basically going to hold information from our form DatingApplication.cshtml */
}
