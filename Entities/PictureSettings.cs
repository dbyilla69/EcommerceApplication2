using System.IO;
using System.Linq;

namespace EcommerceApplication2.Entities
{
    public class PictureSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }
        public bool IsSupported (string fileName)
        {
            return AcceptedFileTypes.Any(s => s == Path.GetExtension(fileName).ToLower());
        }
    }
}