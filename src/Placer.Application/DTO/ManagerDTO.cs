namespace Placer.Application.DTO;

public class ManagerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int AgencyId { get; set; }
    public AgencyDTO Agency { get; set; }
}