using System;
using ICSharpCode.Decompiler.TypeSystem;

namespace Bb.ComponentModel
{
    internal class Filter
    {

        public Filter(Func<ITypeDefinition, bool> filter)
        {
            this.Where = filter;
        }

        public bool Evaluate(ITypeDefinition type)
        {

            if (this.Where(type))
            {
                if (this.Next != null)
                    return this.Next.Evaluate(type);

                return true;
            }

            return false;

        }

        public void Fill(Filter next)
        {
            if (this.Next != null)
                this.Next.Fill(next);
            else
                this.Next = next;
        }

        public Filter Next { get; set; }

        public Func<ITypeDefinition, bool> Where { get; }



    }



}
