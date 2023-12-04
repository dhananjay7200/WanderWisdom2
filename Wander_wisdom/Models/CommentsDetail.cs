using System;
using System.Collections.Generic;

namespace Wander_wisdom.Models;

public partial class CommentsDetail
{
    public int CmtId { get; set; }

    public string? Comment { get; set; }

    public int? PostCmtFk { get; set; }

    public byte? IsDeleted { get; set; }

    public virtual PostDetail? PostCmtFkNavigation { get; set; }
}
