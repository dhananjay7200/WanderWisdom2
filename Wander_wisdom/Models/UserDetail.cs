using System;
using System.Collections.Generic;

namespace Wander_wisdom.Models;

public partial class UserDetail
{
    public int UserIdPk { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserPhonenumber { get; set; } = null!;

    public string UserCity { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public byte? IsDeleted { get; set; }
}
