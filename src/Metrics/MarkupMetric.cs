using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TeamCityExtensions.LocStatistics.Metrics
{
    public class MarkupMetric: Metric
    {
        public override string Key
        {
            get { return "MarkupLOC"; }
        }

        public override string Pattern
        {
            get { return "*.aspx;*.ascx;*.cshtml;*.html;*.htm;*.master"; }
        }
    }
}