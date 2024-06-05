namespace AdventureGame.Furnitures
{
    public class Furniture
    {
        public Furniture(string n, string d, string uMessage, bool cUse)
        {
            Name        = n;
            Description = d;
            UseMessage  = uMessage;
            CanUse      = cUse;
        }

        public string   Name        { get; set; }
        public string   Description { get; set; }
        public string   UseMessage  { get; set; }
        public bool     CanUse      { get; set; }
    }
}
