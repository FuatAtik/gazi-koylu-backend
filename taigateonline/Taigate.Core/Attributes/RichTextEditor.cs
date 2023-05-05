using System;

namespace Taigate.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RichTextEditor : Attribute,IEditorType
    {
        
    }
}