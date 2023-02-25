using DefaultAPI.Domain.Entities;
using DefaultAPI.Infra.CrossCutting.Validation;
using DefaultAPI.Infra.CrossCutting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DefaultAPI.Domain.Dto
{
    public class CustomerDto : Customer
    {

    }
    public class CustomerAddDto //: Customer
    {

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 10)]

        public string Firstname { get; set; }


        [StringLength(maximumLength: 100, MinimumLength = 10)]
        [Required]
        public string Lastname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 10)]

        public string PhoneNumber { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 10)]
        [ValidateEmail]
        public string Email { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 10)]
        [ValidateBankAccountNumber]
        public string BankAccountNumber { get; set; }

    }

    public class CustomerEditDto// : Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 10)]
        
        public string Firstname { get; set; }


        [StringLength(maximumLength: 100, MinimumLength = 10)]
        [Required]
        public string Lastname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 10)]

        public string PhoneNumber { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 10)]
        [ValidateEmail]
        public string Email { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 10)]
        [ValidateBankAccountNumber]
        public string BankAccountNumber { get; set; }


    }


}
