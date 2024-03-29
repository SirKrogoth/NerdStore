﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Core.DomainObject
{
    public abstract class Entity
    {
        public Guid id { get; set; }

        protected Entity()
        {
            id = new Guid();
        }

        //Sobreescrevendo o método Equals
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return id.Equals(compareTo.id);
        }

        //Sobreescrevendo o operador ==
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        //Método responsável por fazer nosso objeto ter um id único
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={id}]";
        }
    }
}
