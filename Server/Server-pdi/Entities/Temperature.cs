namespace Entities
{
    public class Temperature : BaseEntities
    {
        public int Temp { get; set; }
        public int Offset { get; set; }
        public string Device { get; set; }
        public string Tag { get; set; }

    }
}
