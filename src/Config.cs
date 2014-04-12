using System.Reflection;
using System.Linq;
using TeamCityExtensions.LocStatistics.Metrics;

namespace TeamCityExtensions.LocStatistics
{
    public class Config
    {
        public string Path { get; set; }

        public Config Load(string[] args)
        {
            this.Path = this.GetValue(args, "path");

            return string.IsNullOrWhiteSpace(this.Path) ? null : this;
        }

        private string GetValue(string[] args, string name) 
        {
            var namePattern = "/" + name.ToLower() + ":";
            var arg = args.FirstOrDefault(x => x.ToLower().StartsWith(namePattern));
            return arg != null ? arg.Substring(namePattern.Length) : null;
        }

        public static void ShowHelp() 
        {
            var assembly = Assembly.GetAssembly(typeof(Program));
            System.Console.WriteLine("{0} ver: {1}", assembly.GetName().Name, assembly.GetName().Version);
            System.Console.WriteLine("Usage:");
            System.Console.WriteLine("\t /path:PATH \t Input solution path");
            System.Console.WriteLine("Example:");
            System.Console.WriteLine("\t {0} /path:\"C:\\Projects\\MySolution\"", assembly.GetName().Name);

        }
    }
}
