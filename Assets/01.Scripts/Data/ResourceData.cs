
public class ResourceData : AddData_Root
{
    public ResourceType ResourceType { get; private set; }

    public ResourceData(ResourceType resourceType)
    {
        ResourceType = resourceType;
    }
}