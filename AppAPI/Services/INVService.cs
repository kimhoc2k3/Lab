using AppAPI.ViewModels;

namespace AppAPI.Services
{
    public interface INVService
    {
        public Task<List<NhanVienVM>> GetAll();
        public Task<NhanVienVM> GetByID(Guid id);
        public Task<bool> Create(NhanVienVM nv);
        public Task<bool> Update(NhanVienVM nv);
        public Task<bool> Delete(Guid id);
        
    }
}
