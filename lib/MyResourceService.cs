using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using Microsoft.AspNetCore.Mvc;


namespace lib
{
    public interface IMyResourceService
    {
        IDictionary<string, string> GetValidationErrors(ModelStateDictionary modelState);
        string GetErrorMessage(string errorKey);
    }

    public class MyResourceService : IMyResourceService
    {
        private readonly ResourceManager _messagesResourceManager;
        private readonly ResourceManager _errorMessagesResourceManager;

        public MyResourceService()
        {
            _messagesResourceManager = new ResourceManager(typeof(Messages));
            _errorMessagesResourceManager = new ResourceManager(typeof(ErrorMessages));
        }

        public IDictionary<string, string> GetValidationErrors(ModelStateDictionary modelState)
        {
            var errors = new Dictionary<string, string>();
            foreach (var field in modelState)
            {
                if (field.Value.ValidationState == ModelValidationState.Invalid)
                {
                    foreach (var error in field.Value.Errors)
                    {
                        string errorMessage = GetErrorMessage(error.ErrorMessage);
                        errors.Add(field.Key, errorMessage);
                    }
                }
            }

            return errors;
        }

        public string GetErrorMessage(string errorKey)
        {
            return _errorMessagesResourceManager.GetString(errorKey);
        }
    }
}
