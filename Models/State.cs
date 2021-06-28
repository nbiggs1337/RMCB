using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMCB.Models
{
    public class State
    {
        [Key]
        public int StateID {get;set;}
        
        public string Name {get;set;}
        
        public List<Location> Locations {get;set;}
    }
}