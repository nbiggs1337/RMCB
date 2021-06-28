using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMCB.Models
{
    public class Bootcamp
    {
        [Key]
        public int BootcampID {get;set;}
        
        [Required]
        public string Name {get;set;}
        
        [Required]
        public bool Flex {get;set;}
        
        [Required]
        public bool GIBill {get;set;}
        
        [Required]
        public bool Facility {get;set;}
        
        [Required]
        public bool Online {get;set;}
        
        
        public List<Location> Locations {get;set;}
        
        
        public List<Course> Courses {get;set;}
        
        [Required]
        public string Subjects {get;set;}
        
        public List<Review> Reviews {get;set;}
        
        
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
    }
    
}