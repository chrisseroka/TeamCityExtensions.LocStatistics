using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TeamCityExtensions.LocStatistics.Metrics
{
    public abstract class Metric
    {
        public abstract string Pattern {get;}
        public abstract string Key { get; }
        public long Value { get; set; }

        private IEnumerable<Regex> extensionPatterns;
        protected IEnumerable<Regex> ExtensionPatterns 
        {
            get 
            {
                if (this.extensionPatterns == null) 
                {
                    this.extensionPatterns = this.Pattern
                                    .Split(new[] { ';' })
                                    .Select(x => x.Replace(".", "\\.").Replace("*", ".+") + "$")
                                    .Select(x => new Regex(x)).ToList();
                }
                return this.extensionPatterns;
            }
        }

        public virtual void Calculate(string file)
        {
            if (this.ExtensionPatterns.Any(x => x.IsMatch(file))) 
            {
                this.Value += System.IO.File.ReadAllLines(file).Length;
            }
        }
    }
}