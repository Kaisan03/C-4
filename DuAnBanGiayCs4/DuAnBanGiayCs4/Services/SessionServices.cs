using DuAnBanGiayCs4.Models;
using Newtonsoft.Json;

namespace DuAnBanGiayCs4.Services
{
    public static class SessionServices
    {
        public static List<GioHangChiTiet> GetObjFromSession(ISession session, string key)
        {
            //Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<GioHangChiTiet>();//News null thì trả về 1 list rỗng
            // Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var products = JsonConvert.DeserializeObject<List<GioHangChiTiet>>(jsonData);

            return products;
        }
        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);
        }
        public static bool CheckObjInList(Guid id, List<GioHangChiTiet> products)
        {
            return products.Any(x => x.Id == id);
        }
    }
}
