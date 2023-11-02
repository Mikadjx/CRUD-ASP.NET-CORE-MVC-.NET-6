using System;
using System.Collections.Generic;

namespace MvcCRUD.Models;

public partial class Users
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Date { get; set; }

    public string? Password { get; set; }
}
