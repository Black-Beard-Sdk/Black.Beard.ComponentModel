using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Bb.ComponentDescriptors
{
    public class DiagnosticValidatorItem
    {

        public DiagnosticValidatorItem(PropertyDescriptor descriptor)
        {
            this.Descriptor = descriptor;
            this._diagnostics = new List<string>();
        }

        public void Add(string message)
        {
            _diagnostics.Add(message);
        }

        public IEnumerable<string> Messages => _diagnostics;

        public string Message => String.Concat(_diagnostics.Select(c => ", " + c)).Trim(',', ' ');

        public bool IsValid => _diagnostics.Count == 0;

        public List<string> MessageService => _diagnostics;

        public PropertyDescriptor Descriptor { get; }
        public object Value { get; internal set; }

        private readonly List<string> _diagnostics;

    }


}
