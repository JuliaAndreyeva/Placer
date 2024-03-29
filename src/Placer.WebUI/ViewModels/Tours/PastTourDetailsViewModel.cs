﻿using Placer.Core.Entities;

namespace Placer.WebUI.ViewModels.Tours;

public class PastTourDetailsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string AgencyName { get; set; }
    public string ManagerName { get; set; }     
    public decimal Price { get; set; }   
    public string State { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<TourPhotoViewModel> TourPhotos { get; set; }
}