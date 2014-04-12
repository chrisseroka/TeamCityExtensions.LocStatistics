using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TeamCityExtensions.LocStatistics.Metrics
{
    public class JavaScriptMetric: Metric
    {
        public override string Key
        {
            get { return "JavaScriptLOC"; }
        }

        public override string Pattern
        {
            get { return "*.js;*.json;*.ts;*.coffee"; }
        }
    }
}