using Bb.Expressions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Bb.ComponentModel.Loaders
{

    public class CommandLineParser
    {


        /// <summary>
        /// Parse the command line arguments
        /// </summary>
        /// <param name="args"></param>
        public CommandLineParser(params string[] args)
        {

            if (args == null || args.Length == 0)
                args = Environment.GetCommandLineArgs();

            _args = Parse(args);

        }



        /// <summary>
        /// Resolve a value from the command line args and environment variables
        /// </summary>
        /// <param name="name"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TryResolveValue<T>(string name, out T result)
        {

            bool r = false;
            result = default;

            if (TryResolveStringValue(name, out string result1))
            {
                result = ConverterHelper.ToObject<T>(result1);
                r = true;
            }

            return r;
        }

        /// <summary>
        /// Resolve a value from the command line args and environment variables
        /// </summary>
        /// <param name="name"></param>
        /// <param name="result"></param>
        /// <param name="culture">culture for help conversion</param>
        /// <returns></returns>
        public bool TryResolveValue<T>(string name, CultureInfo culture, out T result)
        {

            bool r = false;
            result = default;

            if (TryResolveStringValue(name, out string result1))
            {
                result = ConverterHelper.ToObject<T>(result1, culture);
                r = true;
            }

            return r;
        }

        /// <summary>
        /// Resolve a value from the command line args and environment variables
        /// </summary>
        /// <param name="name"></param>
        /// <param name="result"></param>
        /// <param name="encoding">encoding for help conversion</param>
        /// <returns></returns>
        public bool TryResolveValue<T>(string name, Encoding encoding, out T result)
        {

            bool r = false;
            result = default;

            if (TryResolveStringValue(name, out string result1))
            {
                result = ConverterHelper.ToObject<T>(result1, encoding);
                r = true;
            }

            return r;
        }

        /// <summary>
        /// Resolve a value from the command line args and environment variables
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetValueString(string name)
        {

            if (TryResolveStringValue(name, out string result))
                return result;

            return null;

        }

        /// <summary>
        /// Resolve a value from the command line args and environment variables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetValue<T>(string name)
        {

            if (TryResolveValue(name, out T result))
                return result;

            return default;

        }

        /// <summary>
        /// Resolve a value from the command line args and environment variables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="culture">culture for help conversion</param>
        /// <returns></returns>
        public T GetValue<T>(string name, CultureInfo culture)
        {

            if (TryResolveValue(name, culture, out T result))
                return result;

            return default;

        }

        /// <summary>
        /// Resolve a value from the command line args and environment variables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="culture">culture for help conversion</param>
        /// <returns></returns>
        public T GetValue<T>(string name, Encoding encoding)
        {

            if (TryResolveValue(name, encoding, out T result))
                return result;

            return default;

        }

        /// <summary>
        /// Resolve a value from the command line args and environment variables
        /// </summary>
        /// <param name="name"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TryResolveStringValue(string name, out string result)
        {

            bool r = false;
            result = default;

            if (_args.TryGetValue(name, out result))
                r = true;

            else if (TryResolveFromEnvironement(name, out result))
                r = true;

            return r;

        }

        /// <summary>
        /// return true if the variable name can be resolved.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Contains(string name)
        {
            return _args.ContainsKey(name);
        }

        private bool TryResolveFromEnvironement(string name, out string result)
        {

            result = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
            if (!string.IsNullOrEmpty(result))
                return true;

            result = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);
            if (!string.IsNullOrEmpty(result))
                return true;

            result = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);
            if (!string.IsNullOrEmpty(result))
                return true;

            return false;

        }

        private static Dictionary<string, string> Parse(params string[] parts)
        {
            var variables = new Dictionary<string, string>();
            for (int i = 0; i < parts.Length; i++)
            {

                string key = null;
                string value = null;
                int cut = 0;

                var txt = parts[i];
                if (txt.StartsWith("--"))
                {
                    cut = 2;
                    if (ResolveSplitChar(txt, out var c)) // Format --key=value or --key:value
                    {
                        var keyValue = txt.Substring(cut);
                        var p = keyValue.Split(new[] { c }, 2);
                        if (p.Length == 2)
                        {
                            key = p[0].Trim();
                            value = p[1]?.Trim();
                        }
                    }
                    else if (ResolveKeyAlone(txt)) // Format --key
                    {
                        key = txt.Substring(cut).Trim();
                        if (i + 1 < parts.Length)
                            value = parts[++i]?.Trim();
                    }
                    else if (ResolveSpaceChar(txt, out var j)) // Format --key value 
                    {
                        key = txt.Substring(cut, j - cut).Trim();
                        if (i + 1 < parts.Length)
                            value = parts[++i]?.Trim();
                    }
                    else
                    {

                    }
                }

                // Format -key
                else if (txt.StartsWith("-"))
                {
                    cut = 1;
                    key = txt.Substring(cut);
                    value = i.ToString();
                }

                if (key != null && value != null && !variables.ContainsKey(key))
                    variables.Add(key, value);

            }

            return variables;

        }

        private static bool ResolveSplitChar(string txt, out char c)
        {
            c = '\0';
            if (txt.Contains('='))
                c = '=';

            else if (txt.Contains(':'))
                c = ':';

            else
            {


            }

            return c != '\0';

        }

        private static bool ResolveSpaceChar(string txt, out int c)
        {
            c = txt.IndexOf(' ');
            return c != -1;
        }

        private static bool ResolveKeyAlone(string txt)
        {
            return _r.IsMatch(txt);
        }

        private static Regex _r = new Regex(@"--[a-zA-Z0-9]+");
        private readonly Dictionary<string, string> _args;

    }

}
