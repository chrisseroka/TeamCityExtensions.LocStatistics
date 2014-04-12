using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TeamCityExtensions.LocStatistics.Metrics
{
    public class StylesMetric: Metric
    {
        public override string Key
        {
            get { return "StylesLOC"; }
        }

        public override string Pattern
        {
            get { return "*.css;*.less;*.scss;*.less"; }
        }
    }
}