using System.ComponentModel.DataAnnotations;
using System.Resources;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using WebApiResource.Resources;

public class ResourceValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
{
    private readonly IValidationAttributeAdapterProvider _baseProvider;
    private readonly MessageResourceContext _messageResourceContext;

    public ResourceValidationAttributeAdapterProvider(IValidationAttributeAdapterProvider baseProvider, MessageResourceContext messageResourceFactory)
    {
        _baseProvider = baseProvider;
        _messageResourceContext = messageResourceFactory;
    }

    public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
    {
        if (attribute is RequiredAttribute requiredAttribute)
        {
            var resourceManager = _messageResourceContext.GetMessage(name);
            return new RequiredAttributeAdapter(requiredAttribute, _messageResourceContext);
        }

        if (attribute is StringLengthAttribute stringLengthAttribute)
        {
            var resourceManager = _resourceManagerFactory.Create(typeof(ValidationMessages));
            return new StringLengthAttributeAdapter(stringLengthAttribute, resourceManager);
        }

        // Add more custom attribute adapters as needed

        return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
    }

    private class RequiredAttributeAdapter : AttributeAdapterBase<RequiredAttribute>
    {
        public RequiredAttributeAdapter(RequiredAttribute attribute, ResourceManager resourceManager)
            : base(attribute, resourceManager)
        {
        }
    }

    private class StringLengthAttributeAdapter : AttributeAdapterBase<StringLengthAttribute>
    {
        public StringLengthAttributeAdapter(StringLengthAttribute attribute, ResourceManager resourceManager)
            : base(attribute, resourceManager)
        {
        }
    }

// public LocalizedValidationAttributeAdapterProvider(IValidationAttributeAdapterProvider baseProvider, IStringLocalizer<ValidationMessages> localizer)
// {
//     _baseProvider = baseProvider;
//     _localizer = localizer;
// }

// public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
// {
//     var baseAdapter = _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);

//     if (baseAdapter is ValidationAttributeAdapter adapter)
//     {
//         adapter.Attribute.ErrorMessage = _resourceManager.GetString(name: adapter.Attribute.ErrorMessage);
//     }
//     return baseAdapter;
// }
// }
