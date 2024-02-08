namespace CodeSamurai.API.Core.Domains
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldNameAttribute : Attribute
    {
        private string name;

        public FieldNameAttribute(string name)
        {
            this.name = name;
        }

        public virtual string Name
        {
            get { return name; }
        }
    }
}
