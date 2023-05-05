namespace Taigate.Core.Attributes
{
    public enum EditorType
    {
        SingleText=1,
        RichTinyMCE=2,
        FileManager=3,
        Checkbox=4,
        RadioButton=5,
        Datetime=6,
        Url=7,
        Number=8,
        CsHtml=9,
        Dropdown = 10,
        MultiselectDropdown = 11,
        DetailUrl = 12,
        SingleTextOnlyNumber=13,
        
        
        Undefined=9999,
    }
    public enum RenderType
    {
        Component=1,
        Page=2,
    }
    
}