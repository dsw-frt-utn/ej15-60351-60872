using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Xml.Linq;

namespace Dsw2026Ej15.Domain
{
    internal abstract class BaseEntity
    {
    public Guid Id { get; }

    public BaseEntity(Guid id)
    {
        Id = id;
    }

}
}
