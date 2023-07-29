using System.ComponentModel.DataAnnotations;
using WebApiResource.Resources;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace WebApiResource.AttributeAdapterProvider;

public class ResourceValidationAttributeAdapterProvider : IValidationMetadataProvider
{
    private readonly MessageResourceContext _messageResourceContext;

    public ResourceValidationAttributeAdapterProvider(MessageResourceContext messageResourceContext)
    {
        _messageResourceContext = messageResourceContext;
    }

    public void CreateValidationMetadata(ValidationMetadataProviderContext context)
    {
        if (context.ValidationMetadata.ValidatorMetadata.Any())
        {
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                if (attribute is ValidationAttribute typedAttribute)
                {
                    var name = typedAttribute.GetType().Name.Replace("Attribute", "");
                    string validationMessage = _messageResourceContext.GetMessage(name);

                    typedAttribute.ErrorMessage = validationMessage ?? typedAttribute.ErrorMessage;
                }
            }
        }

    }
}
