using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;


namespace PrettyGirlsPodcast.Models
{
    public class Podcast
    {
        [Key]
        public int Podcast_Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title may not be longer than 100 characters.")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Podcasted")]
        public DateTime DateCasted { get; set; } = DateTime.Now;  

        public string Description { get; set; }

        [Required(ErrorMessage = "Host is required.")]
        public virtual Host PodcastHost { get; set; }

    }
}