using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMCB.Models
{
    public class Review
    {
        [Key]
        public int ReviewID {get;set;}
        
        [Required]
        public string Recommend {get;set;}
        
        [Required]
        public string Cohort {get;set;}
        
        [Required]
        public string Course {get;set;}
        
        [Required]
        public int Curriculum {get;set;}
        
        [Required]
        public int Instructors {get;set;}
        
        [Required]
        public int Difficulty {get;set;}
        
        [Required]
        public int JobSupport {get;set;}
        
        [Required]
        public int Facility {get;set;}
        
        [Required]
        public bool Online {get;set;}
        
        [Required]
        public string Textbook {get;set;}
        
        // public List<string> Tags {get;set;}
        
        [Required]
        public string Pros {get;set;}
        
        [Required]
        public string Cons {get;set;}
        
        [Required]
        public string Comments {get;set;}
        
        [Required]
        public string Location {get;set;}
        
        [Required]
        public string City {get;set;}
        
        public int UserID {get;set;}
        public User Creator {get;set;}
        
        public int BootcampID {get;set;}
        public Bootcamp Bootcamp {get;set;}
    }
}
