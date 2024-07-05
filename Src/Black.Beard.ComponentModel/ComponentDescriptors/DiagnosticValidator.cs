using System.Collections.Generic;
using System.Linq;

namespace Bb.ComponentDescriptors
{
    public class DiagnosticValidator
    {

        public DiagnosticValidator()
        {
            this._diagnostics = new List<DiagnosticValidatorItem>();
        }

        public DiagnosticValidatorItem Add(DiagnosticValidatorItem item)
        {
            _diagnostics.Add(item);
            return item;
        }

        private readonly List<DiagnosticValidatorItem> _diagnostics;

        public bool IsValid => !_diagnostics.Where(c => !c.IsValid).Any();
    }


}
