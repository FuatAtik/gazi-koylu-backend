namespace Taigate.Core.Helpers
{
    public interface IFileHelper
    {
        public void CreateHtml(string cshtml, string slug);

        public string ReadHtml(string slug);

        public void DeleteHtml(string slug);

        public void DeleteAllHtmls();
    }
}