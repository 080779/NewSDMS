using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDMS.Web.Models.Home
{
    public class NewsDetailsViewModel
    {
        [Required]
        public long Id { get; set; }
    }
}