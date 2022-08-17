namespace Models.Entities
{
    public class Temperature : BaseEntity
    {
        public int Temp { get; set; }
        public int Offset { get; set; }
        public string Device { get; set; }
        public string Tag { get; set; }

    }
}
