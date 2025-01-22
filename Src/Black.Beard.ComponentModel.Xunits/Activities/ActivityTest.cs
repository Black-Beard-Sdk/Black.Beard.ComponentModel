using Xunit;
using Bb.Diagnostics;
using System.Diagnostics;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

namespace Black.Beard.ComponentModel.Xunits.Activities
{

    public class ActivityTest
    {

        [Fact]
        public void StaticMemberTest1()
        {
            var type = typeof(Bb.ComponentModel.TypeDiscovery);
            var list = type.FindActivitySourceCreations();
            Assert.True(list.Count() > 0);
            Assert.Equal(type.Assembly.GetName().Name, list.FirstOrDefault().SourceName);   
        
        }

        [Fact]
        public void ConstantTest2()
        {
            var type = typeof(Activity1Provider);
            var assemblyName = type.Assembly.GetName().Name;
            var list = type.FindActivitySourceCreations().Where(c => c.AssemblyName == assemblyName).ToList();
            Assert.True(list.Count() > 0);
            Assert.Contains("ActivityTestName", list.FirstOrDefault(c => c.SourceName == "ActivityTestName").SourceName);
            Assert.Contains("ActivityTestName2", list.FirstOrDefault(c => c.SourceName == "ActivityTestName2").SourceName);
            Assert.Contains("ActivityTestName3", list.FirstOrDefault(c => c.SourceName == "ActivityTestName3").SourceName);
            Assert.Contains("ActivityTestName4", list.FirstOrDefault(c => c.SourceName == "ActivityTestName4").SourceName);
        }

    }

    /// <summary>
    /// Managing initialize activity source.
    /// </summary>
    public static class Activity1Provider
    {

        /// <summary>
        /// Initializes the <see cref="ActivitySource"/> object.
        /// </summary>
        static Activity1Provider()
        {
            var type = typeof(ComponentModelActivityProvider);
            Version = type.GetActivityVersion();
            Source = new ActivitySource("ActivityTestName", Version?.ToString());
        }

        internal static ActivitySource Source;
        public static readonly Version Version;
        public static bool WithTelemetry = true;

    }

    /// <summary>
    /// Managing initialize activity source.
    /// </summary>
    public static class Activity2Provider
    {

        /// <summary>
        /// Initializes the <see cref="ActivitySource"/> object.
        /// </summary>
        static Activity2Provider()
        {
            var type = typeof(ComponentModelActivityProvider);
            Version = type.GetActivityVersion();
            Source = new ActivitySource(Name, Version?.ToString());
        }

        public const string Name = "ActivityTestName2";

        internal static ActivitySource Source;
        public static readonly Version Version;
        public static bool WithTelemetry = true;

    }

    /// <summary>
    /// Managing initialize activity source.
    /// </summary>
    public static class Activity3Provider
    {

        /// <summary>
        /// Initializes the <see cref="ActivitySource"/> object.
        /// </summary>
        static Activity3Provider()
        {

            string Name = "ActivityTestName3";
            var type = typeof(ComponentModelActivityProvider);
            Version = type.GetActivityVersion();
            Source = new ActivitySource(Name, Version?.ToString());
        }

        internal static ActivitySource Source;
        public static readonly Version Version;
        public static bool WithTelemetry = true;

    }

    /// <summary>
    /// Managing initialize activity source.
    /// </summary>
    public static class Activity4Provider
    {

        /// <summary>
        /// Initializes the <see cref="ActivitySource"/> object.
        /// </summary>
        static Activity4Provider()
        {
            var name2 = Name2;
            var type = typeof(ComponentModelActivityProvider);
            Version = type.GetActivityVersion();
            Source = new ActivitySource(name2, Version?.ToString());
        }

        internal static ActivitySource Source;
        public static readonly Version Version;
        public static bool WithTelemetry = true;

        public static string Name2 { get; } = "ActivityTestName4";

    }

}
