namespace Management.Vehicles.Core.Entities.Base;
public class Audit
{
    public DateTime CreateDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
}