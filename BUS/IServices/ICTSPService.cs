using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.IServices
{
    public interface ICTSPService
    {
        bool Add(ChiTietSanPham obj);
        bool Update(ChiTietSanPham obj);
        bool Delete(ChiTietSanPham obj);
        List<ChiTietSanPham> GetAll();
        List<ChiTietSanPham> GetById(string input);
        
    }
}
