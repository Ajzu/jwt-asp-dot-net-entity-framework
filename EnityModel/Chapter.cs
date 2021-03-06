﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EnityModel
{
    public class Chapter : BaseEntity
    {
        [StringLength(50)]
        public string Name { set; get; }
        public string Description { set; get; }
        public int Duration { set; get; }
        public string Thumbnail { set; get; }
        public string Content { set; get; }
        public string Hints { set; get; }
        //public DateTime2 CreateDate { set; get; }
        //public DateTime LastModifiedDate { set; get; }
    }


}
