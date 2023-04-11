using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;

namespace DuAnBanGiayCs4.Services
{
    public class ChiTietSanPhamServices : IChiTietSanPhamServices
    {
        ShopDbContext context;
        public ChiTietSanPhamServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateChiTietSanPham(ChiTietSanPham ctsp)
        {
            try
            {
                context.ChiTietSanPhams.Add(ctsp);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteChiTietSanPham(Guid id)
        {
            var ctsp = context.ChiTietSanPhams.Find(id);
            context.Remove(ctsp);
            context.SaveChanges();
            return true;
        }
       

        public List<ChiTietSanPham> GetAllChiTietSanPham()
        {
            try
            {
                var _lstChiTietSp = context.ChiTietSanPhams
                    .Join(context.Anhs, p => p.IdAnh, i => i.Id, (p, i) => new { ChiTietSanPham = p, Anh = i })
                    .Join(context.MauSacs, pi => pi.ChiTietSanPham.IdColor, m => m.Id, (pi, m) => new { pi.ChiTietSanPham, pi.Anh, MauSac = m })
                    .Join(context.SanPhams, pim => pim.ChiTietSanPham.IdSp, n => n.Id, (pim, n) => new { pim.ChiTietSanPham, pim.Anh, pim.MauSac, SanPham = n })
                    .Join(context.Nsxes, pimn => pimn.ChiTietSanPham.IdNsx, o => o.Id, (pimn, o) => new { pimn.ChiTietSanPham, pimn.Anh, pimn.MauSac, pimn.SanPham, Nsx = o })
                    .Join(context.Sizes, pimnc => pimnc.ChiTietSanPham.IdSize, x => x.Id, (pimnc, x) => new { pimnc.ChiTietSanPham, pimnc.Anh, pimnc.MauSac, pimnc.SanPham, pimnc.Nsx, Size = x })
                    .Select(pc => new ChiTietSanPham
                    {
                        Id = pc.ChiTietSanPham.Id,
                        IdSp = pc.SanPham.Id,
                        IdColor = pc.MauSac.Id,
                        IdNsx= pc.Nsx.Id,
                        IdSize=pc.Size.Id,
                        GiaBan=pc.ChiTietSanPham.GiaBan,
                        GiaNhap= pc.ChiTietSanPham.GiaNhap,
                        MoTa=pc.ChiTietSanPham.MoTa,
                        SoLuongTon=pc.ChiTietSanPham.SoLuongTon,
                        TrangThai=pc.ChiTietSanPham.TrangThai
                    }).ToList();
                return context.ChiTietSanPhams.Include("MauSac").Include("Nsx").Include("SanPham").Include("Size").Include("Anh").Include("Loai").ToList(); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ChiTietSanPham GetChiTietSanPhamById(Guid id)
        {
            return context.ChiTietSanPhams.Include("SanPham").FirstOrDefault(x => x.Id == id);
        }

        public List<ChiTietSanPham> GetChiTietSanPhamByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateChiTietSanPham(ChiTietSanPham ctsp)
        {
            try
            {
                var _ctsp = context.ChiTietSanPhams.Find(ctsp.Id);
                _ctsp.IdAnh = ctsp.IdAnh;
                _ctsp.IdColor = ctsp.IdColor;
                _ctsp.IdNsx = ctsp.IdNsx;
                _ctsp.IdSize = ctsp.IdSize;
                _ctsp.IdSp = ctsp.IdSp;
                _ctsp.GiaBan = ctsp.GiaBan;
                _ctsp.GiaNhap = ctsp.GiaNhap;
                _ctsp.MoTa = ctsp.MoTa;
                _ctsp.TrangThai = ctsp.TrangThai;
                _ctsp.SoLuongTon = ctsp.SoLuongTon;
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
