using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerdeBordo.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }

        public Guid Id { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime LastUpdate { get; private set; } = DateTime.Now;

        public void ToggleActiveStatus() => IsActive = !IsActive;
    }
}
