using System;
using System.Collections.Generic;

namespace Wander_wisdom.Models;

public partial class LikesDetail
{
    public int LikeId { get; set; }

    public int? LikesCount { get; set; }

    public int? PostLikesFk { get; set; }

    public virtual PostDetail? PostLikesFkNavigation { get; set; }
}
