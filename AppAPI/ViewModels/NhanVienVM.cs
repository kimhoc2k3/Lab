using System.ComponentModel.DataAnnotations;

namespace AppAPI.ViewModels
{
    public class NhanVienVM
    {
        public Guid? Id { get; set; }
        [MaxLength(30)]
        public string Ten { get; set; }
        [Range(18, 50)]
        public int Tuoi { get; set; }

        public int Role { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(3000000, 5000000)]
        public int Luong { get; set; }

        public bool TrangThai { get; set; }
    }
}
