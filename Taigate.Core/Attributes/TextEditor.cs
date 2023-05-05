using System;

namespace Taigate.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TextEditor : Attribute,IEditorType
    {
        
    }
}