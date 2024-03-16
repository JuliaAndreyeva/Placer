using Placer.Core.Entities;

namespace Placer.WebUI.ViewModels.Tours;

public class PastTourDetailsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string AgencyName { get; set; }
    public string ManagerName { get; set; }     
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<TourPlaces> TourPlaces { get; set; }
}