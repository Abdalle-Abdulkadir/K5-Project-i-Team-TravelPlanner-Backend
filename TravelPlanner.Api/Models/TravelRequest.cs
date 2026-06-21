using System;
using System.Collections.Generic;

namespace TravelPlanner.Api.Models;

public partial class TravelRequest
{
    public int Id { get; set; }

    public decimal Budget { get; set; }

    public int Days { get; set; }

    public DateTime DepartureDate { get; set; }

    public string FromLocation { get; set; } = null!;

    public virtual ICollection<TravelResponse> TravelResponses { get; set; } = new List<TravelResponse>();
}
