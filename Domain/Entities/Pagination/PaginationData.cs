using Domain.Entities.Resources;

public class PaginationData
{
    public IEnumerable<ResourceObject> Resources { get; set; }
    public int Total { get; set; }
}
