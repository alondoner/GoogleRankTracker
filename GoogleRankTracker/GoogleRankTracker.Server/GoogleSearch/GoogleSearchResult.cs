using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GoogleRankTracker.Server
{
    
    public class GoogleSearchResult
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Keywords { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Rankings { get; set; }

        public string Formatteddatetime { get; set; }
    }
}
