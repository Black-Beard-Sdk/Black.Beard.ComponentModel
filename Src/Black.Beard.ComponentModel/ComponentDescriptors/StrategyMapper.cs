

using System;
using System.Collections.Generic;

namespace Bb.ComponentDescriptors
{


    public class StrategyMapper
    {

        #region Ctors

        static StrategyMapper()
        {
            _mappers = new Dictionary<string, StrategyMapper>();
        }

        public StrategyMapper(string key)
        {
            this.Key = key;
            _strategySource = new Dictionary<Type, string>();
            _strategySourceCreators = new Dictionary<Type, Func<object>>();
            _strategyTargets = new Dictionary<string, (Type, Action<StrategyMapper, PropertyObjectDescriptor>)>();
            _strategies = new Dictionary<Type, StrategyEditor>();
            _strategyInitializer = new Dictionary<Type, Action<Attribute, StrategyMapper, PropertyObjectDescriptor>>();
            _strategyInitializer2 = new List<(Func<Type, bool>, Action<Type, StrategyMapper, PropertyObjectDescriptor>)>();
        }

        #endregion Ctors

        #region mappers

        public StrategyMapper Source<T>(PropertyKingView targetStrategyName, Func<T>? creator = null)
        {

            if (!_strategySource.ContainsKey(typeof(T)))
                _strategySource.Add(typeof(T), targetStrategyName.ToString());
            else
                _strategySource[typeof(T)] = targetStrategyName.ToString();


            if (creator != null)
            {
                if (!_strategySourceCreators.ContainsKey(typeof(T)))
                    _strategySourceCreators.Add(typeof(T), () => creator());
                else
                    _strategySourceCreators[typeof(T)] = () => creator();
            }
            else if (_strategySourceCreators.ContainsKey(typeof(T)))
                _strategySourceCreators.Remove(typeof(T));

            return this;
        }

        public StrategyMapper Source<T>(string targetStrategyName, Func<T>? creator = null)
        {
            if (!_strategySource.ContainsKey(typeof(T)))
                _strategySource.Add(typeof(T), targetStrategyName);
            else
                _strategySource[typeof(T)] = targetStrategyName;

            if (creator != null)
            {
                if (!_strategySourceCreators.ContainsKey(typeof(T)))
                    _strategySourceCreators.Add(typeof(T), () => creator());
                else
                    _strategySourceCreators[typeof(T)] = () => creator();
            }
            else if (_strategySourceCreators.ContainsKey(typeof(T)))
                _strategySourceCreators.Remove(typeof(T));

            return this;
        }

        public StrategyMapper ToTarget<T>(PropertyKingView targetStrategyName, Action<StrategyMapper, PropertyObjectDescriptor> initializer = null)
        {
            var key = targetStrategyName.ToString();
            if (!_strategyTargets.ContainsKey(key))
                _strategyTargets.Add(key, (typeof(T), initializer));
            else
                _strategyTargets[key] = (typeof(T), initializer);
            return this;
        }

        public StrategyMapper ToTarget<T>(string targetStrategyName, Action<StrategyMapper, PropertyObjectDescriptor> initializer = null)
        {
            if (!_strategyTargets.ContainsKey(targetStrategyName))
                _strategyTargets.Add(targetStrategyName, (typeof(T), initializer));
            else
                _strategyTargets[targetStrategyName] = (typeof(T), initializer);
            return this;
        }

        public StrategyMapper ToTarget<T>(Action<T, StrategyMapper, PropertyObjectDescriptor> initializer)
            where T : Attribute
        {

            if (!_strategyInitializer.TryGetValue(typeof(T), out var list))
                _strategyInitializer.Add(typeof(T), (d, e, f) => initializer((T)d, e, f));
            else
                _strategyInitializer[typeof(T)] = (d, e, f) => initializer((T)d, e, f);
            return this;
        }

        public StrategyMapper ToTarget(Func<Type, bool> filter, Action<Type, StrategyMapper, PropertyObjectDescriptor> initializer)
        {
            _strategyInitializer2.Add((filter, initializer));
            return this;
        }

        #endregion mappers

        #region Get

        public bool TryGetValueByType(Type type, out StrategyEditor? strategy)
        {

            if (!_strategies.TryGetValue(type, out strategy))
                lock (_lock)
                    if (!_strategies.TryGetValue(type, out strategy))
                        strategy = Create(type);

            return strategy != null;

        }

        private StrategyEditor? Create(Type type)
        {

            StrategyEditor? strategy = null;

            if (TryResolveStrategyName(type, out var strategyName))
                if (_strategyTargets.TryGetValue(strategyName, out var target))
                {
                    _strategySourceCreators.TryGetValue(type, out var creator);
                    strategy = new StrategyEditor(strategyName, type, target, creator) { Source = this.Key };
                    strategy.AttributeInitializers = _strategyInitializer;
                    return strategy;
                }

            strategy = new StrategyEditor(this.Key, type, (null, null), null) { Source = this.Key };
            foreach (var item in _strategyInitializer2)
                if (item.Item1(type))
                {
                    strategy = new StrategyEditor(this.Key, type, (null, null), null) { Source = this.Key };
                    strategy.Initializers.Add(item.Item2);
                }

            return strategy;

        }

        private bool TryResolveStrategyName(Type type, out string? strategyName)
        {

            if (type.IsEnum)
            {
                strategyName = PropertyKingView.Enumeration.ToString();
                return true;
            }

            if (_strategySource.TryGetValue(type, out strategyName))
                return true;

            return false;

        }

        #endregion Get

        public static StrategyMapper Get(string name)
        {

            if (!_mappers.TryGetValue(name, out var mapper))
                lock (_lock1)
                    if (!_mappers.TryGetValue(name, out mapper))
                        _mappers.Add(name, mapper = Default(name));

            return mapper;

        }

        public static StrategyMapper Default(string name)
        {

            var strategy = new StrategyMapper(name)
                .Source(PropertyKingView.String, () => string.Empty)
                .Source<char>(PropertyKingView.Char)
                .Source(PropertyKingView.Bool, () => true)
                .Source<Guid>(PropertyKingView.String, () => Guid.Empty)
                .Source<Guid?>(PropertyKingView.Bool, () => Guid.Empty)
                .Source<bool?>(PropertyKingView.Bool, () => default)
                .Source<short>(PropertyKingView.Int16, () => 0)
                .Source<short?>(PropertyKingView.Int16, () => 0)
                .Source<int>(PropertyKingView.Int32, () => 0)
                .Source<int?>(PropertyKingView.Int32, () => 0)
                .Source<long>(PropertyKingView.Int64, () => 0)
                .Source<long?>(PropertyKingView.Int64, () => 0)
                .Source<ushort>(PropertyKingView.UInt16, () => 0)
                .Source<ushort?>(PropertyKingView.UInt16, () => 0)
                .Source<uint>(PropertyKingView.UInt32, () => 0)
                .Source<uint?>(PropertyKingView.UInt32, () => 0)
                .Source<ulong>(PropertyKingView.UInt64, () => 0)
                .Source<ulong?>(PropertyKingView.UInt64, () => 0)
                .Source(PropertyKingView.Date, () => DateTime.UtcNow)
                .Source<DateTime?>(PropertyKingView.Date, () => DateTime.UtcNow)
                .Source(PropertyKingView.DateOffset, () => DateTimeOffset.UtcNow)
                .Source<DateTimeOffset?>(PropertyKingView.DateOffset, () => DateTimeOffset.UtcNow)
                .Source(PropertyKingView.Time, () => TimeSpan.FromMinutes(0))
                .Source<TimeSpan?>(PropertyKingView.Time, () => TimeSpan.FromMinutes(0))
                .Source(PropertyKingView.Float, () => 0f)
                .Source<float?>(PropertyKingView.Float, () => 0f)
                .Source(PropertyKingView.Double, () => 0d)
                .Source<double?>(PropertyKingView.Double, () => 0d)
                .Source<decimal>(PropertyKingView.Decimal, () => 0)
                .Source<decimal?>(PropertyKingView.Decimal, () => 0);

            if (DefaultInitializerExtension != null)
                DefaultInitializerExtension(strategy);

            return strategy;

        }

        public static Action<StrategyMapper> DefaultInitializerExtension { get; set; }

        public string Key { get; }

        private Dictionary<Type, string> _strategySource;
        private Dictionary<Type, Action<Attribute, StrategyMapper, PropertyObjectDescriptor>> _strategyInitializer;
        private List<(Func<Type, bool>, Action<Type, StrategyMapper, PropertyObjectDescriptor>)> _strategyInitializer2;
        private Dictionary<Type, Func<object>> _strategySourceCreators;
        private Dictionary<Type, StrategyEditor> _strategies;
        private volatile object _lock = new object();
        private static object _lock1 = new object();
        private Dictionary<string, (Type, Action<StrategyMapper, PropertyObjectDescriptor>)> _strategyTargets;
        private static Dictionary<string, StrategyMapper> _mappers;

    }


}
