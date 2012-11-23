using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamX.Models.Validators
{
    public class ModelClientToekomstValidationRule : ModelClientValidationRule
    {
        public ModelClientToekomstValidationRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "indetoekomst";
        }
    }

    public class ModelClientIsNodigValidationRule : ModelClientValidationRule
    {
        public ModelClientIsNodigValidationRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "isnodig";
        }
    }

    public class ModelClientUurValidationRule : ModelClientValidationRule
    {
        public ModelClientUurValidationRule(string errorMessage, string regex)
        {
            ErrorMessage = errorMessage;
            ValidationType = "uurvalidatie";
            ValidationParameters.Add("regex", regex);
        }
    }

 
    public class ModelClientEmailValidationRule : ModelClientValidationRule
    {
        public ModelClientEmailValidationRule(string errorMessage, string regex)
        {
            ErrorMessage = errorMessage;
            ValidationType = "emailvalidatie";
            ValidationParameters.Add("regex", regex);
        }
    }


    public class ModelClientTelefoonValidationRule : ModelClientValidationRule
    {
        public ModelClientTelefoonValidationRule(string errorMessage, string regex)
        {
            ErrorMessage = errorMessage;
            ValidationType = "telefoonvalidatie";
            ValidationParameters.Add("regex", regex);
        }
    }

    public class ModelClientPostcodeValidationRule : ModelClientValidationRule
    {
        public ModelClientPostcodeValidationRule(string errorMessage, string regex)
        {
            ErrorMessage = errorMessage;
            ValidationType = "postcodevalidatie";
            ValidationParameters.Add("regex", regex);
        }
    }

    public class ModelClientWachtwoordValidationRule : ModelClientValidationRule
    {
        public ModelClientWachtwoordValidationRule(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "wachtwoordvalidatie";
        }
    }
}