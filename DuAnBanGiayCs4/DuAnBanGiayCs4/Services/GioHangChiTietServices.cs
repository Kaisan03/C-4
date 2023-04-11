using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;

namespace DuAnBanGiayCs4.Services
{
    public class GioHangChiTietServices : IGioHangChiTietServices
    {
        ShopDbContext context;
        public GioHangChiTietServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateGioHangChiTiet(GioHangChiTiet ghct)
        {
            try
            {
                context.GioHangChiTiets.Add(ghct);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGioHangChiTiet(Guid id)
        {
            try
            {
                var ghct = context.GioHangChiTiets.Find(id);
                context.GioHangChiTiets.Remove(ghct);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<GioHangChiTiet> GetAllGioHangChiTiet()
        {
            return context.GioHangChiTiets
                .Include(g=>g.GioHang).ThenInclude(c=>c.User).Include(x=>x.ChiTietSanPham).ThenInclude(y=>y.Anh).ToList();
        }

        public List<GioHangChiTiet> GetGioHangByUserLogin()
        {
            return new List<GioHangChiTiet>();
        }

        public GioHangChiTiet GetGioHangChiTietById(Guid id)
        {
            return context.GioHangChiTiets.FirstOrDefault(x => x.Id == id);
        }

        public List<GioHangChiTiet> GetGioHangChiTietByName(Guid id)
        {
            if(GetAllGioHangChiTiet==null) return new List<GioHangChiTiet> { };
            return GetAllGioHangChiTiet().Where(x=>x.GioHang.User.Id== id).ToList();
        }

        public bool UpdateGioHangChiTiet(GioHangChiTiet ghct)
        {
            try
            {
                var _ghct = context.GioHangChiTiets.Find(ghct.Id);
                context.GioHangChiTiets.Update(ghct);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
