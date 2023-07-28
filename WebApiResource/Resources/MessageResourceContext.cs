using System.Resources;

namespace WebApiResource.Resources
{

    public class MessageResourceContext
    {
        private readonly ResourceManager _resourceManager;

        public MessageResourceContext(Type resourceType) => _resourceManager = new ResourceManager(resourceType);

        public string GetMessage(string name)
        {
            return _resourceManager.GetString(name);
        }
    }


    // public interface IMessageResource
    // {
    //     string GetMessage(Type resourceType, string name);
    // }

    // public class MessageResourceContext : IMessageResource
    // {
    //     private MessageResourceFactory _messageResourceFactory = new MessageResourceFactory();
    //     private static ResourceManager _resourceManager;


    //     public string GetMessage(Type resourceType, string name)
    //     {
    //         _resourceManager = _messageResourceFactory.createMessageResource(resourceType);
    //         return _resourceManager.GetString(name);
    //     }
    // }

    // public class MessageResourceFactory
    // {
    //     public ResourceManager createMessageResource(Type resourceType)
    //     {

    //         return new ResourceManager(resourceType);
    //     }
    // }


    // ===========


    // public interface IBuilderMessageResourceError
    // {
    //     string GetMessage(int statusCode);
    // }
    // public interface IBuilderMessageResourceValidation
    // {
    //     string GetMessage(string name);
    // }

    // public class BuilderMessageResourceError : IBuilderMessageResourceError
    // {
    //     private ResourceManager? _resourceManager;

    //     public BuilderMessageResourceError(ResourceManager resourceManager)
    //     {
    //         _resourceManager = resourceManager;
    //     }

    //     public string GetMessage(int statusCode)
    //     {
    //         _resourceManager = new ResourceManager(typeof(ErrorMessages));
    //         return _resourceManager.GetString(name: $"{statusCode}");
    //     }
    // }

    // public class BuilderMessageResourceValidation : IBuilderMessageResourceValidation
    // {
    //     private ResourceManager? _resourceManager;

    //     public BuilderMessageResourceValidation(ResourceManager resourceManager)
    //     {
    //         _resourceManager = resourceManager;
    //     }

    //     public string GetMessage(string name)
    //     {
    //         _resourceManager = new ResourceManager(typeof(ValidationMessages));
    //         return _resourceManager.GetString(name);
    //     }
    // }
}
