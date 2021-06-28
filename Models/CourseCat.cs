using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMCB.Models
{
    public class CourseCat
    {
        [Key]
        public int CourseCatID {get;set;}
        
        public string CategoryName {get;set;}
        
        public List<Course> Courses {get;set;}
        
        
        
    }
}