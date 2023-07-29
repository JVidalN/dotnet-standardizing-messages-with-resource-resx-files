using System.Resources;

namespace WebApiResource.Resources
{

    public class MessageResourceContext
    {
        private readonly ResourceManager _resourceManager;

        public MessageResourceContext(Type resourceType) => _resourceManager = new ResourceManager(resourceType);

        public string GetMessage(string name) => _resourceManager.GetString(name);
    }
}
