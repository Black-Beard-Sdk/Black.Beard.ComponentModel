//using System;
//using System.Diagnostics.Metrics;
//using System.Reflection;

//namespace Bb.Diagnostics
//{


//    /// <summary>
//    /// Managing metrics source.
//    /// </summary>
//    public static class ComponentModelMetricProvider
//    {

//        /// <summary>
//        /// initialize the metrics
//        /// </summary>
//        static ComponentModelMetricProvider()
//        {
//            Name = nameof(ComponentModelMetricProvider);
//            Name = Name.Substring(0, Name.Length - "Provider".Length);
//            Version = typeof(ComponentModelMetricProvider).Assembly.GetName().Version;

//            Source = new Meter(Name, Version?.ToString());

//            ComponentModelMetricProvider.Counter = Source.CreateCounter<long>("ComponentModelMetric", "unit", "description");
//            ComponentModelMetricProvider.Histogram = Source.CreateHistogram<long>("ComponentModelMetric", "unit", "description");

//            WithTelemetry = ComponentModelMetricProvider.Counter.Enabled;

//        }


//        public static Counter<long> Counter;
//        public static Histogram<long> Histogram;


//        internal static Meter Source;
//        public static readonly string Name;
//        public static readonly Version Version;
//        private static bool WithTelemetry = true;

//    }


//}
