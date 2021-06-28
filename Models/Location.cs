using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMCB.Models
{
    public class Location 
    {
        [Key]
        public int LocationID {get;set;}
        
        public int BootcampID {get;set;}
        
        public int StateID {get;set;}
        
        public State State {get;set;}
        
        public Bootcamp Bootcamp {get;set;}
        
    }
}