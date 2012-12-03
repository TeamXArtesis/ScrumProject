using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TeamX.Models.Validators
{
    public class CostumError : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //EmailClient.Emailclient.ErrorEmail("admin@artesis.be", "Foutmelding", filterContext.Exception.Message);
            base.OnException(filterContext);
        }
    }

    public class MoetInDeToekomstAttribute : ValidationAttribute, IClientValidatable
    {
        public MoetInDeToekomstAttribute()
        {
            this.ErrorMessage = "{0} moet in de toekomst zijn";
        }

        public override bool IsValid(object datum)
        {
            var dt = (DateTime)datum;

            if (dt >= DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientToekomstValidationRule(metadata.GetDisplayName() + " moet in de toekomst zijn");
            yield return rule;
        }
    }


    public class UurvalidatieAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public UurvalidatieAttribute()
            : base(@"((?:(?:[0-1][0-9])|(?:[2][0-3])|(?:[0-9])):(?:[0-5][0-9])(?::[0-5][0-9])?(?:\\s?(?:am|AM|pm|PM))?)")
        {
            this.ErrorMessage = "{0} fomaat moet xx:xx zijn.";
        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientUurValidationRule(metadata.GetDisplayName() + " moet formaat xx:xx zijn.", this.Pattern);
            yield return rule;
        }
    }


    public class IsNodigAttribute : RequiredAttribute, IClientValidatable
    {
        public IsNodigAttribute()
        {
            this.ErrorMessage = "{0} moet ingevuld zijn!";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientIsNodigValidationRule(metadata.GetDisplayName() + " moet ingevuld zijn!");
            yield return rule;
        }
    }

 
    public class EmailValidationAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public EmailValidationAttribute()
            : base(@"^([\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+\.)*[\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$")
        {
            this.ErrorMessage = "{0} is geen correct e-mailadress";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientEmailValidationRule(metadata.GetDisplayName() + " is geen correct emailadres", this.Pattern);
            yield return rule;
        }
    }

    public class TelefoonValidationAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public TelefoonValidationAttribute()
            : base(@"^[0-9]+$")
        {
            this.ErrorMessage = "{0} enkel cijfers of 0";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientTelefoonValidationRule(metadata.GetDisplayName() + " enkel cijfers of 0", this.Pattern);
            yield return rule;
        }
    }

    public class PostcodeValidationAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public PostcodeValidationAttribute()
            : base(@"^[0-9]+$")
        {
            this.ErrorMessage = "{0} moet exact 4 cijfers zijn";
        }

        public override bool IsValid(object value)
        {
            var code = (int)value;
            if (code.ToString().Length == 4)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientPostcodeValidationRule(metadata.GetDisplayName() + " moet uit 4 cijfers bestaan", this.Pattern);
            yield return rule;
        }
    }

    public class PaswoordLengteAttribute : ValidationAttribute, IClientValidatable
    {
        public PaswoordLengteAttribute()
        {
            this.ErrorMessage = "Passwoord lengte moet minstens 5 zijn";
        }
        public override bool IsValid(object value)
        {
            string passwoord = (String)value;
            if (passwoord != null)
            {
                if (passwoord.Length > 4)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientWachtwoordValidationRule(metadata.GetDisplayName() + " moet een lengte hebben van 5");
            yield return rule;
        }
    }
}