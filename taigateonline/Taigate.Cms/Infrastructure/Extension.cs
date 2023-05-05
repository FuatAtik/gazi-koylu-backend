using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Taigate.Core.Helpers;

namespace Taigate.Cms.Infrastructure
{
    public class ExtensionMethods:IFileHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExtensionMethods(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void CreateHtml(string cshtml, string slug)
        {
            if (slug == "/")
            {
                slug = "anasayfa";
            }

            var newSlug = slug.Replace("/", "-");
            var path = _webHostEnvironment.WebRootPath + $"/HTMLS/{newSlug}.txt";
            try
            {
                // Create the file, or overwrite if the file exists.
                using var fs = File.Create(path);
                
                var info = new UTF8Encoding(true).GetBytes(cshtml);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
        public string ReadHtml(string slug)
        {
            if (slug == "/")
            {
                slug = "anasayfa";
            }
            var newSlug = slug.Replace("/", "-");
            var path = _webHostEnvironment.WebRootPath + $"/HTMLS/{newSlug}.txt";
            try
            {
                // Open the stream and read it back.
                using var sr = File.OpenText(path);
                
                var htmlString = sr.ReadToEnd();
                return htmlString;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "";
            }
        }
        
        public void DeleteHtml(string slug)
        {
            if (slug == "/")
            {
                slug = "anasayfa";
            }
            var newSlug = slug.Replace("/", "-");
            var path = _webHostEnvironment.WebRootPath + $"/HTMLS/{newSlug}.txt";
            try
            {
                File.Delete(path);
                
            }

            catch (Exception ex)
            {
                //delete fails
                Console.WriteLine(ex.ToString());
            }
        }
        
        public void DeleteAllHtmls()
        {
            
            var path = _webHostEnvironment.WebRootPath + "/HTMLS";
            try
            {
                var di = new DirectoryInfo(path);
                foreach (var file in di.EnumerateFiles())
                {
                    file.Delete(); 
                }
            }

            catch (Exception ex)
            {
                //delete fails
                Console.WriteLine(ex.ToString());
            }
        }
    }
}