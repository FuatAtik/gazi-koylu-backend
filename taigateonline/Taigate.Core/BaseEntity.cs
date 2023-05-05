using System;
using Taigate.Core.Attributes;

namespace Taigate.Core
{
    public abstract class BaseEntity
    {
        [Hidden(true)]
        public int Id { get; set; }
        [Hidden(true)]
        public Guid Guid { get; set; }
    }
}