using System;

namespace TeamCityExtensions.LocStatistics.TeamCity
{
    public class TeamCityReporter
    {
        public static void Report(string key, long value)
        {
            key = key.Replace(" ", "");
            Console.WriteLine("##teamcity[buildStatisticValue key='{0}' value='{1}']", key, value);
        }
    }
}