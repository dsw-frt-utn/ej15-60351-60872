using System;
using System.Collections.Generic;
using System.Text;
using Dsw2026Ej15.Domain;

namespace Dsw2026Ej15.Data
{
    internal interface IPercistence
    {
        IEnumerable<Speciality> GetSpecialities();
        Speciality? GetSpecialityById(Guid id);

        IEnumerable<Doctor> GetDoctor();
        Doctor? GetDoctorById(Guid id);
        void AddDoctor(Doctor doctor);
        bool DeleteDoctor(Guid id);
    }
}
