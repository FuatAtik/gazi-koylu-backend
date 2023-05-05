using System;
using Taigate.Core;
using Taigate.Core.Attributes;

namespace Taigate.Data.Data.Entities.Base
{
    public abstract class ViewComponentBaseEntity: BaseEntity
    {
        [Hidden(true)]
        public int LanguageId { get; set; }
        public int DisplayOrder { get; set; }
    }
}