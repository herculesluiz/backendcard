using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndCard.Models
{
    public class Card 
    {
        
        public Guid Id {get; set;}
        
        public string Email {get; set;}

        public string Number {get; set;}

        
    }
}