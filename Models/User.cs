using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace RMCB.Models
{
    //Main user DB profile for all regs.
    public class User
    {
        [Key]
        public int UserID {get;set;}
        
        [Required]
        [MinLength(2, ErrorMessage = "Name must be 2 characters or longer!")]
        public string FirstName {get;set;}
        
        [Required]
        [MinLength(1, ErrorMessage = "Name must be 1 characters or longer!")]
        public string LastName {get;set;}
        
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage ="Password must contain at least 1 uppercase letter, 1 lowercase letter, 1 number, and 1 special character!")]
        public string Password {get;set;}
        
        
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
        public List<Review> Reviews {get;set;}
        
        
        [NotMapped]
        
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        [Compare("Password", ErrorMessage ="Password & Confirm Password must match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get;set;}
        
        [Required]
        [Compare("Email", ErrorMessage ="Email and Confirm Email must match!")]
        [DataType(DataType.EmailAddress)]
        public string ConfirmEmail {get;set;} 
        
        
        
        
        
        
    }
    
}