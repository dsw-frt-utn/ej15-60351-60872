using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data
{
    public class PersistenceEF : IPersistence
    {
        private readonly Dsw2026Ej15DbContext _context;

        public PersistenceEF(Dsw2026Ej15DbContext context)
        {
            _context = context;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            _context.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(Doctor doctor)
        {
            _context.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctor()
        {
            return _context.Doctors.Where(d => d.IsActive).Include(d => d.Speciality);
        }

        public async Task<Doctor?> GetDoctorById(Guid id)
        {
            return await _context.Doctors.Include(d => d.Speciality).FirstOrDefaultAsync(d => d.IsActive && d.Id == id);
        }

        public async Task<Speciality?> GetSpecialityById(Guid id)
        {
            return await _context.Specialities.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
