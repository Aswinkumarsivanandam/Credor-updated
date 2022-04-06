﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Credor.Data.Entities
{
    public class  PortfolioGallery
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PortfolioOffering")]
        public int OfferingId { get; set; }
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
        public int Status { get; set; }
        public bool IsDefaultImage { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }        
    }
}
