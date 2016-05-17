using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Social_Network.Providers
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path)
        { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string n = string.Format("Image-{0:yyyy-MM-dd_hh-mm-ss-tt}",DateTime.Now);
            var suppliedName = headers.ContentDisposition.FileName.Replace("\"", string.Empty); // this is here to deal with escaped quotation marks
            suppliedName = n+suppliedName;
            string extension = Path.GetExtension(suppliedName).Replace(".", "");
            if (extension != "jpg" && extension != "png" && extension != "jpeg") {
                return "NoName";
            }
            return !string.IsNullOrWhiteSpace(suppliedName) ? suppliedName : "NoName";
        }


    }
}
