using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RMCB.Models
{
    //Login profile for pulling DB user;
    public class LUser
    {
        [Required]
        [EmailAddress]
        public string LEmail {get;set;}
        
        
        [Required]
        [DataType(DataType.Password)]
        public string LPassword {get;set;}
        
    }
    
}