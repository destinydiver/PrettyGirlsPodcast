using PrettyGirlsPodcast.DAL;
using PrettyGirlsPodcast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrettyGirlsPodcast.ViewModels
{
    public class PodcastViewModel
    {
        public Podcast viewPodcast{ get; set; }
        public List<Host> hostList { get; set; }
    }
}