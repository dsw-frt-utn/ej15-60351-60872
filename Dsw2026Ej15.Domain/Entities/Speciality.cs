using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Speciality : BaseEntity
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public Speciality(Guid? id, string name, string description) : base (id)
        {
            Name = name;
            Description = description;
        }

    }
}
