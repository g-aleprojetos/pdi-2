namespace Models.Entities
{
    public class Led : BaseEntity
    {
        public string Device { get; set; }
        public string Tag { get; set; }
        public bool Status { get; set; }
    }
}
