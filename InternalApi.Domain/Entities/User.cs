namespace InternalApi.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
}
