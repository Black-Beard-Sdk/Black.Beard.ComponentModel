using System.Linq.Expressions;

namespace Bb.Expressions
{

    /// <summary>
    /// This class represents a label in an expression tree.
    /// </summary>
    public class Label
    {

        /// <summary>
        /// Gets or sets the <see cref="LabelTarget"/> instance associated with this label.
        /// </summary>
        /// <remarks>
        /// This property represents the target of the label in the expression tree.
        /// </remarks>
        public LabelTarget Instance { get; set; }

        /// <summary>
        /// Gets the name of the label.
        /// </summary>
        /// <remarks>
        /// This property holds the name of the label, which is used to identify it in the expression tree.
        /// </remarks>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the kind of the label.
        /// </summary>
        /// <remarks>
        /// This property specifies the type of label, such as break, continue, or return.
        /// </remarks>
        public KindLabel Kind { get; internal set; }

    }

    /// <summary>
    /// Specifies the kind of a label in an expression tree.
    /// </summary>
    public enum KindLabel
    {

        /// <summary>
        /// Represents a default label.
        /// </summary>
        Default,

        /// <summary>
        /// Represents a break label.
        /// </summary>
        Break,

        /// <summary>
        /// Represents a continue label.
        /// </summary>
        Continue,

        /// <summary>
        /// Represents a return label.
        /// </summary>
        Return,

    }

}
