using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Bb.Translations.Stores
{

    /// <summary>
    /// Represents a file-based translation store.
    /// </summary>
    public class StoreFile : ITranslationStore
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreFile"/> class with the default directory.
        /// </summary>
        /// <remarks>
        /// the folder by default is created in the same directory as the executable.
        /// </remarks>
        public StoreFile()
            : this(new System.IO.DirectoryInfo(GetPath()))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreFile"/> class with the specified directory.
        /// </summary>
        /// <param name="directory">directory to store files</param>
        public StoreFile(DirectoryInfo directory)
        {

            if (directory == null)
                throw new ArgumentNullException(nameof(directory), "The directory cannot be null.");

            if (!directory.Exists)
                directory.Create();

            _directory = directory;

        }



        /// <summary>
        /// Reads all translations from the store and processes them using the specified action.
        /// </summary>
        /// <param name="stream">The action to process each translation. The tuple contains the path, key, culture, and translation data.</param>
        /// <remarks>
        /// This method iterates through all translation files in the directory and invokes the provided action for each translation.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// store.ReadAll(item =>
        /// {
        ///     Console.WriteLine($"Path: {item.path}, Key: {item.key}, Culture: {item.culture}, Data: {item.datas}");
        /// });
        /// </code>
        /// </example>
        public void ReadAll(Action<(string path, string key, CultureInfo culture, string datas)> stream)
        {
            foreach (var file in _directory.GetFiles("*.csv").Select(c => c.FullName))
                using (GetFileLock(file))
                    foreach (var item in ReadFile(file))
                    {
                        var data = item.IsBase64 == '1' ? Convert.ToBase64String(Encoding.UTF8.GetBytes(item.Translation)) : item.Translation;
                        stream((item.Path, item.Key, CultureInfo.GetCultureInfoByIetfLanguageTag(item.Culture), data));
                    }
        }

        /// <summary>
        /// Reads all translations from the store and processes them using the specified action.
        /// </summary>
        /// <param name="stream">The action to process each translation. The tuple contains the path, key, culture, and translation data.</param>
        /// <param name="path">The path where the translation is stored.</param>
        /// <remarks>
        /// This method iterates through all translation files in the directory and invokes the provided action for each translation.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// store.ReadAll(item =>
        /// {
        ///     Console.WriteLine($"Path: {item.path}, Key: {item.key}, Culture: {item.culture}, Data: {item.datas}");
        /// });
        /// </code>
        /// </example>
        public void ReadAll(Action<(string path, string key, CultureInfo culture, string datas)> stream, string path)
        {
            var filename = GetPath(path);
            using (GetFileLock(filename))
                foreach (var entry in ReadFile(filename).Where(c => c.Path.Equals(path, StringComparison.OrdinalIgnoreCase)))
                {
                    var data = entry.IsBase64 == '1' ? Convert.ToBase64String(Encoding.UTF8.GetBytes(entry.Translation)) : entry.Translation;
                    stream((entry.Path, entry.Key, CultureInfo.GetCultureInfoByIetfLanguageTag(entry.Culture), data));
                }
        }

        /// <summary>
        /// Reads a translation from the store.
        /// </summary>
        /// <param name="path">The path where the translation is stored.</param>
        /// <param name="key">The key associated with the translation.</param>
        /// <param name="culture">The culture of the translation.</param>
        /// <param name="result">The translation text if found; otherwise, <c>null</c>.</param>
        /// <returns>
        /// true if the translation was found; otherwise, false.
        /// </returns>
        /// <remarks>
        /// This method retrieves a translation for a specific key and culture from the specified path.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ITranslationStore store = ...;
        /// bool success = store.Read("translations", "greeting", CultureInfo.GetCultureInfo("en-US"), out string? translation);
        /// Console.WriteLine(translation); // Output: "Hello"
        /// </code>
        /// </example>
        public bool Read(string path, string key, CultureInfo culture, out string? result)
        {

            var filename = GetPath(path);
            using (GetFileLock(filename))
                foreach (var entry in ReadFile(filename))
                    if (entry.Path.Equals(path, StringComparison.OrdinalIgnoreCase) &&
                    entry.Key.Equals(key, StringComparison.OrdinalIgnoreCase) &&
                    entry.Culture.Equals(culture.IetfLanguageTag, StringComparison.OrdinalIgnoreCase))
                    {
                        result = entry.IsBase64 == '1'
                            ? Convert.ToBase64String(Encoding.UTF8.GetBytes(entry.Translation))
                            : entry.Translation;
                        return true;
                    }

            result = null;
            return false;

        }


        /// <summary>
        /// Writes a translation to the store.
        /// </summary>
        /// <param name="path">The path where the translation is stored.</param>
        /// <param name="key">The key associated with the translation.</param>
        /// <param name="culture">The culture of the translation.</param>
        /// <param name="result">The translation text to store.</param>
        /// <remarks>
        /// This method saves a translation for a specific key and culture at the specified path.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ITranslationStore store = ...;
        /// store.Write("translations", "greeting", CultureInfo.GetCultureInfo("en-US"), "Hello");
        /// </code>
        /// </example>
        public void Write(string path, string key, CultureInfo culture, string result)
        {

            var filename = GetPath(path);

            using (GetFileLock(filename))
            {

                bool isBase64 = ShouldEncodeBase64(result);
                var items = new List<(string Path, string Key, string Culture, char IsBase64, string Translation)>();
                var updated = false;

                foreach (var entry in ReadFile(filename))
                    if (entry.Path.Equals(path, StringComparison.OrdinalIgnoreCase) &&
                        entry.Key.Equals(key, StringComparison.OrdinalIgnoreCase) &&
                        entry.Culture.Equals(culture.IetfLanguageTag, StringComparison.OrdinalIgnoreCase))
                    {
                        items.Add(Format(path, key, culture, result, isBase64));
                        updated = true;
                        break;
                    }
                    else
                        items.Add(entry);

                if (!updated)
                    items.Add(Format(path, key, culture, result, isBase64));

                Sort(items);

                using (var writer = new StreamWriter(filename, false, Encoding.UTF8))
                    foreach (var entry in items)
                        writer.WriteLine($"{entry.Path},{entry.Key},{entry.Culture},{entry.IsBase64},{entry.Translation}");

            }

        }

        /// <summary>
        /// Copies all translations from the specified source store to the current store.
        /// </summary>
        /// <param name="sourceStore">The source store to copy translations from.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="sourceStore"/> is <c>null</c>.</exception>
        /// <remarks>
        /// This method reads all translations from the source store and writes them to the current store.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// store.CopyFrom(sourceStore);
        /// </code>
        /// </example>
        public void CopyFrom(ITranslationStore sourceStore)
        {

            if (sourceStore == null)
                throw new ArgumentNullException(nameof(sourceStore), "The source store cannot be null.");

            sourceStore.ReadAll(entry =>
            {
                var filename = GetPath(entry.path);
                using (GetFileLock(filename))
                {
                    using (var writer = new StreamWriter(filename, true, Encoding.UTF8))
                    {
                        bool isBase64 = ShouldEncodeBase64(entry.datas);
                        var datas = isBase64 ? Convert.ToBase64String(Encoding.UTF8.GetBytes(entry.datas)) : entry.datas;
                        string encoded = isBase64 ? "1" : "0";
                        writer.WriteLine($"{entry.path},{entry.key},{entry.culture.IetfLanguageTag.ToLower()},{encoded},{datas}");
                    }
                }
            });

        }


        #region private

        private static void Sort(List<(string Path, string Key, string Culture, char IsBase64, string Translation)> items)
        {
            items.Sort((a, b) =>
            {
                var pathComparison = string.Compare(a.Path, b.Path, StringComparison.OrdinalIgnoreCase);
                if (pathComparison != 0) return pathComparison;

                var keyComparison = string.Compare(a.Key, b.Key, StringComparison.OrdinalIgnoreCase);
                if (keyComparison != 0) return keyComparison;

                return string.Compare(a.Culture, b.Culture, StringComparison.OrdinalIgnoreCase);
            });
        }

        private static (string path, string key, string Name, char, string datas) Format(string path, string key, CultureInfo culture, string result, bool isBase64)
        {
            var datas = isBase64 ? Convert.ToBase64String(Encoding.UTF8.GetBytes(result)) : result;
            var i = (path, key, culture.IetfLanguageTag.ToLower(), isBase64 ? '1' : '0', datas);
            return i;
        }

        private static IEnumerable<(string Path, string Key, string Culture, char IsBase64, string Translation)> ReadFile(string filename)
        {

            if (File.Exists(filename))
                using (var reader = new StreamReader(filename, Encoding.UTF8, true))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var columns = line.Split(',');

                        if (columns.Length != 5)
                            throw new FormatException("Each line in the CSV file must have exactly 5 columns.");

                        var filePath = columns[0].Trim();
                        var fileKey = columns[1].Trim();
                        var fileCulture = columns[2].Trim();
                        var isBase64 = columns[3].Trim().Equals("1", StringComparison.OrdinalIgnoreCase);
                        var translation = columns[4].Trim();

                        yield return (filePath, fileKey, fileCulture.ToLower(), isBase64 ? '1' : '0', translation);

                    }
                }

        }

        private static bool ShouldEncodeBase64(string value)
        {
            foreach (char c in value)
                if (char.IsControl(c) || c == ',' || c == '"' || c == '\n' || c == '\r')
                    return true;
            return false;
        }

        private string GetPath(string path)
        {

            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("The path cannot be null or empty.", nameof(path));

            foreach (var invalidChar in Path.GetInvalidPathChars())
                path = path.Replace(invalidChar, '_');
            path = path.Replace("___", "_").Replace("__", "_");

            return Path.Combine(_directory.FullName, path + ".csv");

        }


        private IDisposable GetFileLock(string filename)
        {

            string lockFilePath = filename + ".lock";

            while (File.Exists(lockFilePath))
                System.Threading.Thread.Sleep(50);

            lock (_lock)
            {
                while (File.Exists(lockFilePath))
                    System.Threading.Thread.Sleep(50);

                using (var stream = File.Create(lockFilePath))
                {
                    stream.Close();
                }


            }

            return new FileLock(lockFilePath);

        }

        private sealed class FileLock : IDisposable
        {
            private readonly string _lockFilePath;

            public FileLock(string lockFilePath)
            {
                _lockFilePath = lockFilePath;
            }

            public void Dispose()
            {
                if (File.Exists(_lockFilePath))
                    File.Delete(_lockFilePath);
            }
        }

        private readonly DirectoryInfo _directory;
        private readonly object _lock = new object();

        #endregion private

        private static string GetPath()
        {
            var file = new FileInfo(Assembly.GetEntryAssembly().Location);
            var path = Path.Combine(file.Directory.FullName, ".translations");
            return path;
        }

    }

}
