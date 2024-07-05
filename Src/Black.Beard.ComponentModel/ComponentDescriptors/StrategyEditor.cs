
using System;
using System.Collections.Generic;

namespace Bb.ComponentDescriptors
{

    public class StrategyEditor
    {

        public StrategyEditor(PropertyKingView propertyKingView, Type sourceType, (Type, Action<StrategyMapper, PropertyObjectDescriptor>) target, Func<object> createInstance)
            : this(propertyKingView.ToString(), sourceType, target, createInstance)
        {

        }

        public StrategyEditor(string propertyKingView, Type sourceType, (Type, Action<StrategyMapper, PropertyObjectDescriptor>) target, Func<object> createInstance)
        {
            this.PropertyKingView = propertyKingView.ToString();
            this.SourceType = sourceType;
            this.ComponentView = target.Item1;
            this.Initializer = target.Item2;
            this.CreateInstance = createInstance;
            Initializers = new List<Action<Type, StrategyMapper, PropertyObjectDescriptor>>();
        }

        public string PropertyKingView { get; }

        public Type SourceType { get; }

        public Type ComponentView { get; }

        public Func<object>? CreateInstance { get; }

        public string Source { get; internal set; }

        public Dictionary<Type, Action<Attribute, StrategyMapper, PropertyObjectDescriptor>> AttributeInitializers { get; internal set; }

        public List<Action<Type, StrategyMapper, PropertyObjectDescriptor>> Initializers { get; }

        public Action<StrategyMapper, PropertyObjectDescriptor> Initializer { get; }

    }

}
