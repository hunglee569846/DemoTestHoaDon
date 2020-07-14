using DemoTestHoaDon.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Xml.Linq;

namespace DemoTestHoaDon.Services
{
    public class HoaDonServices
    {
        public  static IEnumerable<HoaDons> GetHoaDon()
        {
            List<HoaDons> HoaDonList = new List<HoaDons>();
            using (IDbConnection con = new SqlConnection(KetNoi.strKetNoi))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                HoaDonList = con.Query<HoaDons>("HoDon_SelectAll").ToList();
            }
            return HoaDonList;
             
        }
        public static HoaDons GetHoaDonByID(string id)
        {
            HoaDons Hd = new HoaDons();
            if (id == null)
                return Hd;
            using (IDbConnection con = new SqlConnection(KetNoi.strKetNoi))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@SoHD", id);
                Hd = con.Query<HoaDons>("HoDon_SelectById", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return Hd;

        }

        public static int AddHoaDon(HoaDons HD)
        {
            try
            {
                int RowHD = 0;
                using (IDbConnection con = new SqlConnection(KetNoi.strKetNoi))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@SoHD", HD.SoHD);
                    para.Add("@HoTen", HD.HoTen);
                    para.Add("@DienThoai", HD.DienThoai);
                    para.Add("@NgayXuat", HD.NgayXuat);
                    para.Add("@TongTien", HD.TongTien);
                    RowHD = con.Execute("HoDon_Insert", para, commandType: CommandType.StoredProcedure);
                }
                return RowHD;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return -1;
            }
        }

        public static int Update_HoaDon(string id, HoaDons HD)
        {
            int RowHD = 0;
            using (IDbConnection con = new SqlConnection(KetNoi.strKetNoi))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@SoHD", HD.SoHD);
                para.Add("@HoTen", HD.HoTen);
                para.Add("@DienThoai", HD.DienThoai);
                para.Add("@NgayXuat", HD.NgayXuat);
                para.Add("@TongTien", HD.TongTien);
                RowHD = con.Execute("Update_HoaDon", para, commandType: CommandType.StoredProcedure);
            }
            return RowHD;
        }

        public static int Delete_HoaDon(string id)
        {
            int RowHD = 0;
            using(IDbConnection con = new SqlConnection(KetNoi.strKetNoi))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@SoHD", id);
                RowHD = con.Execute("Delete_HoaDonvsCT", para, commandType: CommandType.StoredProcedure);
            }
            return RowHD;
        }
    }
}
