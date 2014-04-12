using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TeamCityExtensions.LocStatistics.Metrics
{
    public class DotNetMetric: Metric
    {
        public override string Key
        {
            get { return "DotNetLOC"; }
        }

        public override string Pattern
        {
            get { return "*.cs;*.csproj;*.sln;*.config"; }
        }
    }
}