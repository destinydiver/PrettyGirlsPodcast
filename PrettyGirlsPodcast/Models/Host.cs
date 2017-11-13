using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace PrettyGirlsPodcast.Models
{
    public class Host
    {
        [Key]
        public int Host_Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(30, ErrorMessage = "First name cannot contain more than 30 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot contain more than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Bio { get; set; }

        public virtual ICollection<Podcast> Podcasts { get; set; }
    }
}