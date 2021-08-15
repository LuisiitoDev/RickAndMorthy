using System.IO;
using System.Reflection;

namespace RickAndMorthy.Utils
{
    public static class ResourceUtils
    {
        /// <summary>
        /// Extracts the save resource.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="location">The location.</param>
        public static void ExtractSaveResource(string fileName, string location)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var resFileStream = assembly.GetManifestResourceStream(fileName);

            if (resFileStream != null)
            {
                var full = Path.Combine(location,fileName);
                using var stream = File.Create(full);
                resFileStream.CopyTo(stream);
            }
        }
    }
}
