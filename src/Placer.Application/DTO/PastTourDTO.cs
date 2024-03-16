namespace Placer.Application.DTO;

public class PastTourDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public AgencyDTO AgencyDTO { get; set; }
    public ManagerDTO ManagerDTO { get; set; }     
    public  ICollection<PastTourPlaceDTO> TourPlacesDTO { get; set; }
    public  ICollection<TourPhotoDTO> PhotoDTO { get; set;}
}