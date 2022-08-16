using System;

namespace Entities
{
    public class BaseEntities
    {
        public virtual Guid Id { get; set; }
        public string Name { get; set; }
        public bool Deletada { get; set; } = false;
    }
}
