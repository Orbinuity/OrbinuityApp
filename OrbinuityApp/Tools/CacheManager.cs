namespace TermOS.Tools
{
    public class CacheManager
    {
        private readonly string cacheDirectory;

        public CacheManager(string exeDirectory)
        {
            cacheDirectory = Path.Combine(exeDirectory, "cache");

            if (!Directory.Exists(cacheDirectory))
            {
                Directory.CreateDirectory(cacheDirectory);
            }
        }

        public void Save(string key, string data)
        {
            try
            {
                var keyPath = Path.Combine(cacheDirectory, key);

                if (!Directory.Exists(cacheDirectory))
                {
                    Directory.CreateDirectory(cacheDirectory);
                }

                File.WriteAllText(keyPath, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving cache({key}): {ex.Message}");
            }
        }

        public string Load(string key)
        {
            try
            {
                var keyPath = Path.Combine(cacheDirectory, key);

                if (!Directory.Exists(cacheDirectory))
                {
                    Directory.CreateDirectory(cacheDirectory);
                }

                if (!Path.Exists(keyPath))
                {
                    Console.WriteLine($"Error loading cache({key}): key not found in cache!");
                    return "";
                }

                return File.ReadAllText(keyPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading cache({key}): {ex.Message}");
                return "";
            }
        }

        public void Remove(string key)
        {
            try
            {
                var keyPath = Path.Combine(cacheDirectory, key);

                if (!Directory.Exists(cacheDirectory))
                {
                    Directory.CreateDirectory(cacheDirectory);
                }

                if (!Path.Exists(keyPath))
                {
                    Console.WriteLine($"Error removing cache({key}): key not found in cache!");
                    return;
                }

                File.Delete(keyPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing cache({key}): {ex.Message}");
            }
        }

        public bool Exists(string key)
        {
            try
            {
                var keyPath = Path.Combine(cacheDirectory, key);

                if (!Directory.Exists(cacheDirectory))
                {
                    Directory.CreateDirectory(cacheDirectory);
                }

                return Path.Exists(keyPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking existence of cache({key}): {ex.Message}");
                return false;
            }
        }
    }
}
