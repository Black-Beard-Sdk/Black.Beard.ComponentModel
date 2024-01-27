using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.PEReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Bb.ComponentModel
{


    public class WalkerFilter : PeWalker
    {

        public WalkerFilter(IEnumerable<Type> typeToSearchs, IEnumerable<Type> typeInterfacesToSearchs, string context)
        {

            this.Items = new List<TypeMatched>();

            this.Context = context;
            _typeBases = typeToSearchs.ToList();
            _interfaces = typeInterfacesToSearchs.ToList();


            if (!string.IsNullOrEmpty(this.Context))
                _filter = new Filter(this, (c) =>
                {

                    foreach (var item in c.CustomAttributes)
                        if (item.Name == nameof(ExposeClassAttribute))
                            if (item.Arguments.Count > 0 && item.Arguments[0] == this.Context)
                            {

                            }

                    return false;

                });

            //foreach (var item in _interfaces)
            //{

            //}

            //foreach (var item in _typeBases)
            //{

            //}

        }

        private bool IsAssignableFromInterface(PeTypeDefinition self)
        {

            if (!self.IsNil)
                foreach (var item in self.InterfaceImplementations)
                {

                    if (item.Type.Name == _name && item.Type.Namespace == _namespace)
                        return true;

                    if (!self.IsNil && self.BaseType != null)
                    {
                        var resolver = self as ITypeResolver;
                        if (resolver != null)
                        {

                            var resolved = resolver.Resolve();

                            if (!resolved.IsNil && !resolved.Equals(resolver))
                                return IsAssignableFromInterface(resolved);

                        }
                    }
                }

            return false;
        }

        private bool IsAssignableFromBaseType(IPeNamespace self)
        {

            if (self.Namespace == _namespace && self.Name == _name)
                return true;

            var resolver = self as ITypeResolver;
            if (resolver != null)
            {

                var resolved = resolver.Resolve();

                if (!resolved.IsNil && !resolved.Equals(resolver) && resolved.BaseType != default)
                    return IsAssignableFromBaseType(resolved.BaseType);

            }

            return false;
        }

        public override void Visit(PeAssemblyModel self)
        {

            //foreach (var item in _typeBases)
            //{


            //    if (self.Location.FullName != item.Assembly.Location)
            //    {

            //        _namespace = item.Namespace;
            //        _name = item.Name;
            //        _assemblyName = item.Assembly.GetName().Name;


            //        AssemblyReferenceFilter = (c) => _assemblyName == c.AssemblyName.Name;





            //        var version = self.CustomAttributes.FirstOrDefault(c => c.Name == nameof(AssemblyFileVersionAttribute));

            //        if (!version.IsNil)
            //        {
            //            var ver = version.Arguments.FirstOrDefault().ToString();
            //            _assemblyVersion = Version.Parse(ver);
            //        }
            //        else
            //            _assemblyVersion = new Version(0, 0, 0, 0);

            //        Visit(self.AssemblyReferences);

            //        if (_exit)
            //            return;

            //    }



            //    self.Module.Accept(this);

            //    //Visit(self.AssemblyFiles);

            //    //Visit(self.CustomAttributes);

            //    //Visit(self.ExportedTypes);

            //    //Visit(self.ManifestResources);

            //}

            Visit(self.Types);

        }

        public override void Visit(IEnumerable<PeAssemblyReference> self)
        {

            foreach (var item in self)
            {
                item.Accept(this);
            }

        }

        public override void Visit(IEnumerable<PeTypeDefinition> self)
        {

            this._exit = true;

            foreach (var item in self)
                item.Accept(this);

        }

        public override void Visit(PeAssemblyReference self)
        {

            //if (_match = AssemblyReferenceFilter(self))
            //{

            //}

        }

        public override void Visit(PeTypeDefinition self)
        {

            if (_filter == null || _filter.Evaluate(self))
            {

                _match = true;

                var newItem = new TypeMatched()
                {

                    AssemblyLocation = self.Root.Location,
                    AssemblyName = self.Root.Name,
                    AssemblyVersion = _assemblyVersion,

                    TypeNamespace = self.Namespace,
                    TypeName = self.Name,

                };

                if (Filter == null || Filter(newItem))
                    this.Items.Add(newItem);

            }

        }


        public Func<TypeMatched, bool> Filter { get; set; }

        public Func<PeAssemblyReference, bool> AssemblyReferenceFilter { get; set; }


        public List<TypeMatched> Items { get; }
        public string Context { get; }

        private bool _exit;
        private bool _match;
        private readonly List<Type> _typeBases;
        private readonly List<Type> _interfaces;

        //private readonly string _location;

        private string _name;
        private string _namespace;
        private string _assemblyName;
        private Filter _filter;

        private Version _assemblyVersion;


    }

    
}



