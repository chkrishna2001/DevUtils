namespace DevUtils.Core.Models
{
    public class LookupItem
    {
        public string ItemName { get; set; }
        public string ItemValue { get; set; }
        public override string ToString()
        {
            return ItemValue;
        }
    }
}
