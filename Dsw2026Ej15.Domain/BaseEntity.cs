using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Xml.Linq;

namespace Dsw2026Ej15.Domain
{
    public abstract class BaseEntity
    {
        public Guid? Id { get; }

        public BaseEntity(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }
    }
}
