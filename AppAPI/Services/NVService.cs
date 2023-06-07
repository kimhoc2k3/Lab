using AppAPI.ViewModels;
using AppData.Contexts;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace AppAPI.Services
{
    public class NVService : INVService
    {
        private readonly NVContext _context;
        public NVService(NVContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(NhanVienVM nv)
        {
            try
            {
                NhanVien nvien = new()
                {
                    Id = Guid.NewGuid(),
                    Ten = nv.Ten,
                    Tuoi = nv.Tuoi,
                    Email = nv.Email,
                    Luong = nv.Luong,
                    TrangThai = nv.TrangThai,
                    Role = nv.Role,
                };
                await _context.NhanViens.AddAsync(nvien);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var c = await _context.NhanViens.FindAsync(id);
                if (c == null)
                {
                    throw new Exception("Ko tim thay");
                }
                _context.NhanViens.Remove(c);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }

        public async Task<List<NhanVienVM>> GetAll()
        {
            return await _context.NhanViens
                .Select(i => new NhanVienVM()
                {
                    Id = i.Id,
                    Ten = i.Ten,
                    Tuoi = i.Tuoi,
                    Email = i.Email,
                    Luong = i.Luong,
                    Role = i.Role,
                    TrangThai = i.TrangThai,
                }).ToListAsync();
        }

        public async Task<NhanVienVM> GetByID(Guid id)
        {
            var i = await _context.NhanViens.FindAsync(id);
            if (i == null)
            {
                throw new Exception("Không tìm thấy nv");
            }
            else
            {
                var nhanVien = new NhanVienVM()
                {
                    Id = i.Id,
                    Ten = i.Ten,
                    Tuoi = i.Tuoi,
                    Email = i.Email,
                    Luong = i.Luong,
                    Role = i.Role,
                    TrangThai = i.TrangThai,
                };
                return nhanVien;
            }
        } 
        public async Task<bool> Update(NhanVienVM nv)
        {
            var x = await _context.NhanViens.FindAsync(nv.Id);
            if (x == null) throw new Exception($"Không thể tim thấy Id:  {nv.Id}");
            x.Ten = nv.Ten;
            x.Tuoi = nv.Tuoi;
            x.Email = nv.Email;
            x.Luong = nv.Luong;
            x.Role = nv.Role;
            x.TrangThai = nv.TrangThai;

            _context.NhanViens.Update(x);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
