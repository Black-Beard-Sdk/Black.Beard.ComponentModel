namespace Bb.ComponentModel.DataAnnotations
{
    public class ListItem
    {

        public string Name { get; set; }

        public string Display { get; set; }

        public object Value { get; set; }

        public override string ToString()
        {
            return Display.ToString();
        }

        public override bool Equals(object o)
        {
            var other = o as ListItem;
            return other?.Value == Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

    }

}
