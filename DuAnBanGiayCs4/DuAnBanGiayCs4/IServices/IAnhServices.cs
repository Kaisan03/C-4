using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface IAnhServices
    {
        public bool CreateAnh(Anh anh);
        public bool UpdateAnh(Anh anh);
        public bool DeleteAnh(Guid id);
        public List<Anh> GetAllAnh();
        public Anh GetAnhById(Guid id);
        public List<Anh> GetAnhByName(string name);
    }
}
