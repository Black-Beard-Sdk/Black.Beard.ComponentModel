namespace Bb.TypeDescriptors
{
    public interface IDynamicComparerProperty
    {


        /// <summary>
        /// Gets the order in which this property will be retrieved from its type descriptor.
        /// </summary>
        int? PropertyOrder { get; }

        string Name { get; }


    }


}
