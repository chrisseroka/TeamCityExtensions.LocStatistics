using System.IO;
using System.Linq;
using TeamCityExtensions.LocStatistics.Metrics;

namespace TeamCityExtensions.LocStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Config().Load(args);

            if (config != null)
            {
                var metrics = SetUpMetrics();
                CalculateMetrics(metrics, config.Path);
                ReportMetrics(metrics);
            }
            else 
            {
                Config.ShowHelp();
            }
        }

        private static void CalculateMetrics(Metric[] metrics, string inputDir) 
        {
            var metricList = metrics.ToList();
            foreach (var file in Directory.GetFiles(inputDir, "*", SearchOption.AllDirectories))
            {
                metricList.ForEach(x => x.Calculate(file));
            }
        }

        private static void ReportMetrics(Metric[] metrics)
        {
            foreach (var metric in metrics)
            {
                TeamCity.TeamCityReporter.Report(metric.Key, metric.Value);
            }
        }

        private static Metric[] SetUpMetrics() 
        {
            return new Metric[]
                {
                    new DotNetMetric(),
                    new JavaScriptMetric(),
                    new MarkupMetric(),
                    new StylesMetric()
                };
        }
    }
}
