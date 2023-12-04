using System;
using System.Collections.Generic;

namespace Wander_wisdom.Models;

public partial class PostDetail
{
    public int PostId { get; set; }

    public string PostTitle { get; set; } = null!;

    public string PostDescription { get; set; } = null!;

    public byte? IsDeleted { get; set; }

    public virtual ICollection<CommentsDetail> CommentsDetails { get; set; } = new List<CommentsDetail>();

    public virtual ICollection<LikesDetail> LikesDetails { get; set; } = new List<LikesDetail>();
}
