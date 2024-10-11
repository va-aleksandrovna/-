using System;
using System.Collections.Generic;

namespace Автотранспорт;

public partial class Work
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public DateTime Data { get; set; }

    public TimeSpan Time { get; set; }

    public string AddressFrom { get; set; } = null!;

    public string AddressTo { get; set; } = null!;

    public string TypeTransit { get; set; } = null!;

    public int? NumberPassenger { get; set; }

    public string? Comment { get; set; }

    public int? DriversId { get; set; }

    public int? CarsId { get; set; }

    public bool? Status { get; set; }

    public virtual Car? Cars { get; set; }

    public virtual Driver? Drivers { get; set; }
}
