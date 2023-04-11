using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface IThanhToanServices
    {
        public bool CreateThanhToan(ThanhToan th);
        public bool UpdateThanhToan(ThanhToan th);
        public bool DeleteThanhToan(Guid id);
        public List<ThanhToan> GetAllSize();
        public ThanhToan GetThanhToanById(Guid id);
        public List<ThanhToan> GetThanhToanByName(string name);
    }
}
