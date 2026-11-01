using System.ComponentModel.DataAnnotations;

namespace BLL.Annotations
{
    public class MyAttribute(string[] extensions) : ValidationAttribute
    {
        private readonly string[] _extensions = extensions;
        public override bool IsValid(object? value)
        {
            if (value == null) return true;

            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if (string.IsNullOrEmpty(extension)) return false;

                return _extensions.Contains(extension.ToLowerInvariant());
            }

            return false;
        }
    }
}
