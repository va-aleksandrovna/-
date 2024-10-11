using System;
using System.Collections.Generic;

namespace Автотранспорт;

public partial class Car
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double PriceHour { get; set; }

    public double PriceKm { get; set; }

    public int? NumberSeats { get; set; }

    public double? Length { get; set; }

    public double? Width { get; set; }

    public double? Capacity { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Work> Works { get; set; } = new List<Work>();
}
