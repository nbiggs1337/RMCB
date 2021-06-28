using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMCB.Models
{
    public class Course
    {
        [Key]
        public int CourseID {get;set;}
        
        public string Name {get;set;}
        
        public int BootcampID {get;set;}
        
        public Bootcamp Bootcamp {get;set;}
        
        public int CourseCatID {get;set;}
        
        public CourseCat Category {get;set;}
        
    }
}