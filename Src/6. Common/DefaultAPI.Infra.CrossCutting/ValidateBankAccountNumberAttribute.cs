using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace DefaultAPI.Infra.CrossCutting
{
    public class ValidateBankAccountNumberAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage("bank account number");
        }

        public override bool IsValid(object? bankAccountNumberValue)
        {
            string? bankAccountNumber = bankAccountNumberValue.ToString();
            if (string.IsNullOrEmpty(bankAccountNumber)) return false;

            Regex regex = new("^[0-9]{9,18}$");

            return regex.IsMatch(bankAccountNumber);
        }
    }

}
