using DefaultAPI.Domain.Base;
using DefaultAPI.Infra.CrossCutting;
using DefaultAPI.Infra.CrossCutting.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DefaultAPI.Domain.Entities
{
    public class Customer : BaseEntity
    {

        [StringLength(maximumLength: 100, MinimumLength = 10)]

        public string Firstname { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 10)]

        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }


        [StringLength(maximumLength: 20, MinimumLength = 10)]
        [Column(TypeName = "VARCHAR(20)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(maximumLength: 100, MinimumLength = 10)]
        [ValidateEmail] 
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [StringLength(maximumLength: 20, MinimumLength = 10)]
        [ValidateBankAccountNumber]
        public string BankAccountNumber { get; set; }

       
    
    

       // public List<States> Estados { get; set; }
    }
}
