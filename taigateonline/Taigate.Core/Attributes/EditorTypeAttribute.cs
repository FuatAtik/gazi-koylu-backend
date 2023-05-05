using System.Collections.Generic;

namespace Taigate.Core.Attributes
{
    public class EditorTypeAttribute : System.Attribute
    {
        public EditorTypeAttribute(EditorType type)
        {
            this.Type = type;
        }
        public EditorType Type { get; private set; }
    }

    public class DropdownModel
    {
        public string Table { get; set; }
        public string IdField { get; set; }
        public string ValueField { get; set; }
        public string FkPropName { get; set; }
        public string PropName { get; set; }
        
        public IEnumerable<object> Dropdowns { get; set; }

        
    }   
    public class MultiselectDropdownModel
    {
        public string Table { get; set; }
        public string IdField { get; set; }
        public string ValueField { get; set; }
        public string ThisFkName { get; set; }
        public string RefFkName { get; set; }
        public string PropName { get; set; }
        
        public IEnumerable<object> Dropdowns { get; set; }
        public IEnumerable<int> SelectedItems { get; set; }
        
    }
    public class DropdownEditorAttribute : System.Attribute
    {
        public DropdownEditorAttribute()
        {
            Model = new DropdownModel
            {
                Table = Table,
                IdField = IdField,
                ValueField = ValueField,
                FkPropName = FkPropName,
                PropName = PropName,
                
            };
        }
        public DropdownModel Model { get; private set; }
        public string Table { get; set; }
        public string IdField { get; set; }
        public string ValueField { get; set; }
        public string FkPropName { get; set; }
        public string PropName { get; set; }
    }
    public class MultiselectDropdownEditorAttribute : System.Attribute
    {
        public MultiselectDropdownEditorAttribute()
        {
            Model = new MultiselectDropdownModel
            {
                Table = Table,
                IdField = IdField,
                ValueField = ValueField,
                ThisFkName = ThisFkName,
                RefFkName = RefFkName,
                PropName = PropName,
                
            };
        }
        public MultiselectDropdownModel Model { get; private set; }
        public string Table { get; set; }
        public string IdField { get; set; }
        public string ValueField { get; set; }
        public string ThisFkName { get; set; }
        public string RefFkName { get; set; }
        public string PropName { get; set; }
    }

    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class RenderTypeAttribute : System.Attribute
    {
        public RenderTypeAttribute(RenderType type)
        {
            this.Type = type;
        }
        public RenderType Type { get; private set; }
    }
    public class NotRenderAttribute : System.Attribute
    {
        public NotRenderAttribute(bool value)
        {
            this.Value = value;
        }
        public bool Value { get; private set; }
    }
    public class HiddenAttribute : System.Attribute
    {
        public HiddenAttribute(bool value)
        {
            this.Value = value;
        }
        public bool Value { get; private set; }
    }
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class MenuSiteAttribute : System.Attribute
    {
        public MenuSiteAttribute(string value)
        {
            this.Value = value;
        }
        public string Value { get; private set; }
    }
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class MenuDomainAttribute : System.Attribute
    {
        public MenuDomainAttribute(string value)
        {
            this.Value = value;
        }
        public string Value { get; private set; }
    }
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class MenuTitleAttribute : System.Attribute
    {
        public MenuTitleAttribute(string value)
        {
            this.Value = value;
        }
        public string Value { get; private set; }
    }
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class MenuItemTitleAttribute : System.Attribute
    {
        public MenuItemTitleAttribute(string value)
        {
            this.Value = value;
        }
        public string Value { get; private set; }
    }
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class MenuMainTitleAttribute : System.Attribute
    {
        public MenuMainTitleAttribute(string value)
        {
            this.Value = value;
        }
        public string Value { get; private set; }
    }
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class DetailSlugAttribute : System.Attribute
    {
        public DetailSlugAttribute(string value)
        {
            this.Value = value;
        }
        public string Value { get; private set; }
    }
}