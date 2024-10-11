using System;
using System.Collections.Generic;

namespace Автотранспорт;

public partial class Driver
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int Experience { get; set; }

    public bool? B { get; set; }

    public bool? C { get; set; }

    public bool? D { get; set; }

    public virtual ICollection<Work> Works { get; set; } = new List<Work>();
}
