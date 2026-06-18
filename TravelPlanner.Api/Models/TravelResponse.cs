using System;
using System.Collections.Generic;

namespace TravelPlanner.Api.Models;

public partial class TravelResponse
{
    public int Id { get; set; }

    public int TravelRequestId { get; set; }

    public string Summary { get; set; } = null!;

    public string? SelectedDestination { get; set; }

    public decimal EstimatedCost { get; set; }

    public string TravelPlanText { get; set; } = null!;

    public string QualityNotes { get; set; } = null!;

    public string TraceId { get; set; } = null!;

    public virtual TravelRequest TravelRequest { get; set; } = null!;
}
