using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Core
{
    public abstract class Entity
    {
        public Guid id { get; set; }

        protected Entity()
        {
            id = new Guid();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return id.Equals(compareTo.id);
        }
    }
}
