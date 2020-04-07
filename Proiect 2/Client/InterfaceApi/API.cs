using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class API
    {
        static string[] imageExtensions = {
            ".PNG", ".JPG", ".JPEG", ".BMP"
        };
        static string[] movieExtensions = {
            ".AVI", ".MP4", ".DIVX", ".WMV"
        };

        public static string fileType(string path)
        {
            /// Verifica tipul continutului fisierului primit ca parametru.
            /// Returneaza "Image", "Video" sau "Unsupported", dupa caz.

            if (Array.IndexOf(imageExtensions, Path.GetExtension(path).ToUpperInvariant()) != -1)
            {
                return "Image";
            }
            else if (Array.IndexOf(movieExtensions, Path.GetExtension(path).ToUpperInvariant()) != -1)
            {
                return "Video";
            }

            return "Unsupported";
        }
    }
}
