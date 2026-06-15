using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain
{
    internal class Doctor : BaseEntity
    {

        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public bool IsActive { get; set; }
        public Speciality Speciality { get; set; }

        public Doctor(Guid id, string name, string licenseNumber, bool isActive, Speciality speciality) : base (id)
        {
            Name = name;
            LicenseNumber = licenseNumber;
            IsActive = isActive;
            Speciality = speciality;
        }
     }
}
