using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface INsxServices
    {
        public bool CreateNsx(Nsx nsx);
        public bool UpdateNsx(Nsx nsx);
        public bool DeleteNsx(Guid id);
        public List<Nsx> GetAllNsx();
        public Nsx GetNsxById(Guid id);
        public List<Nsx> GetNsxByName(string name);
    }
}
