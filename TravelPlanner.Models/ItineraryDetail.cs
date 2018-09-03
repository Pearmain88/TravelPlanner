﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data;

namespace TravelPlanner.Models
{
    public class ItineraryDetail
    {
        public int ItineraryID { get; set; }

        [Display(Name ="Completed:")]
        public bool Completed { get; set; }

        [Display(Name ="Activity Name:")]
        public string ActivityName {get; set; }

        [Display(Name ="Description:")]
        public string ActivityDescription { get; set; }

        [Display(Name ="Type:")]
        public ActivityType Type { get; set; }

        [Display(Name ="Cost:")]
        public decimal? ActivityCost { get; set; }

        [Display(Name ="Date:")]
        public DateTimeOffset? ActivityDate { get; set; }
    }
}
