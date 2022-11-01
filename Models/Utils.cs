using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace bai_1.Models
{
    class Utils
    {
        string fileName = "congty.xml";
        XmlDocument doc;
        XmlElement root;

        public Utils()
        {
            doc = new XmlDocument();
            if (!File.Exists(fileName))
            {
                XmlElement congty = doc.CreateElement("congty");
                doc.AppendChild(congty);
                doc.Save(fileName);
            }
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void addNhanVien(NhanVien nv)
        {
            XmlElement x = doc.CreateElement("nhanvien");
            x.SetAttribute("id", nv.id);

            //Họ Tên
            XmlElement hoTen = doc.CreateElement("hoten");
            hoTen.InnerText = nv.hoTen;
            x.AppendChild(hoTen);
            // Tuổi
            XmlElement tuoi = doc.CreateElement("tuoi");
            tuoi.InnerText = nv.tuoi;
            x.AppendChild(tuoi);

            // Lương
            XmlElement luong = doc.CreateElement("luong");
            luong.InnerText = nv.luong.ToString();
            x.AppendChild(luong);

            // Địa chỉ
            XmlElement diachi = doc.CreateElement("diachi");
            x.AppendChild(luong);
            XmlElement xa = doc.CreateElement("xa");
            xa.InnerText = nv.xa;
            diachi.AppendChild(xa);
            XmlElement huyen = doc.CreateElement("huyen");
            huyen.InnerText = nv.huyen;
            diachi.AppendChild(huyen);
            XmlElement tinh = doc.CreateElement("tinh");
            tinh.InnerText = nv.tinh;
            diachi.AppendChild(tinh);
            x.AppendChild(diachi);

            //Số điện thoại
            XmlElement sodienthoai = doc.CreateElement("sodienthoai");
            sodienthoai.InnerText = nv.soDienThoai;
            x.AppendChild(sodienthoai);

            root.AppendChild(x);
            // Lưu vào file
            doc.Save(fileName);
        }

        public void edit(NhanVien nv)
        {
            XmlNodeList a = root.SelectNodes("nhanvien");
            foreach (XmlNode item in a)
            {
                if (item.Attributes[0].InnerText.Equals(nv.id))
                {
                    XmlElement x = doc.CreateElement("nhanvien");
                    x.SetAttribute("id", nv.id);

                    //Họ Tên
                    XmlElement hoTen = doc.CreateElement("hoten");
                    hoTen.InnerText = nv.hoTen;
                    x.AppendChild(hoTen);
                    // Tuổi
                    XmlElement tuoi = doc.CreateElement("tuoi");
                    tuoi.InnerText = nv.tuoi;
                    x.AppendChild(tuoi);

                    // Lương
                    XmlElement luong = doc.CreateElement("luong");
                    luong.InnerText = nv.luong.ToString();
                    x.AppendChild(luong);

                    // Địa chỉ
                    XmlElement diachi = doc.CreateElement("diachi");
                    x.AppendChild(luong);
                    XmlElement xa = doc.CreateElement("xa");
                    xa.InnerText = nv.xa;
                    diachi.AppendChild(xa);
                    XmlElement huyen = doc.CreateElement("huyen");
                    huyen.InnerText = nv.huyen;
                    diachi.AppendChild(huyen);
                    XmlElement tinh = doc.CreateElement("tinh");
                    tinh.InnerText = nv.tinh;
                    diachi.AppendChild(tinh);
                    x.AppendChild(diachi);

                    //Số điện thoại
                    XmlElement sodienthoai = doc.CreateElement("sodienthoai");
                    sodienthoai.InnerText = nv.soDienThoai;
                    x.AppendChild(sodienthoai);

                    root.ReplaceChild(x, item);
                    // Lưu vào file
                    doc.Save(fileName);
                    Console.WriteLine("Thành công");

                }
                else
                {
                    Console.WriteLine("Lỗi");
                }

            }
        }

        public Boolean checkID(string id)
        {
            XmlNodeList a = root.SelectNodes("nhanvien");
            List<NhanVien> b = new List<NhanVien>();
            foreach (XmlNode item in a)
            {
                if (id.Equals(item.Attributes[0].InnerText))
                    return true;
            }

            return false;
        }

        public List<NhanVien> searchById(string id)
        {
            XmlNodeList a = root.SelectNodes("nhanvien");
            List<NhanVien> b = new List<NhanVien>();
            foreach (XmlNode item in a)
            {
                if (item.Attributes[0].InnerText.Equals(id))
                {
                    NhanVien x = new NhanVien();
                    x.id = item.Attributes[0].InnerText;
                    x.hoTen = item.SelectSingleNode("hoten").InnerText;
                    x.tuoi = item.SelectSingleNode("tuoi").InnerText;
                    x.luong = float.Parse(item.SelectSingleNode("luong").InnerText);
                    x.soDienThoai = item.SelectSingleNode("sodienthoai").InnerText;

                    XmlNode dc = item.SelectSingleNode("diachi");
                    x.xa = dc.SelectSingleNode("xa").InnerText;
                    x.huyen = dc.SelectSingleNode("huyen").InnerText;
                    x.tinh = dc.SelectSingleNode("tinh").InnerText;

                    b.Add(x);
                }
            }
            return b;

        }

        public List<NhanVien> searchByLuong(int luong)
        {
            XmlNodeList a = root.SelectNodes("nhanvien");
            List<NhanVien> b = new List<NhanVien>();
            foreach (XmlNode item in a)
            {
                if (float.Parse(item.SelectSingleNode("luong").InnerText) >= luong)
                {
                    NhanVien x = new NhanVien();
                    x.id = item.Attributes[0].InnerText;
                    x.hoTen = item.SelectSingleNode("hoten").InnerText;
                    x.tuoi = item.SelectSingleNode("tuoi").InnerText;
                    x.luong = float.Parse(item.SelectSingleNode("luong").InnerText);
                    x.soDienThoai = item.SelectSingleNode("sodienthoai").InnerText;
                    XmlNode dc = item.SelectSingleNode("diachi");
                    x.xa = dc.SelectSingleNode("xa").InnerText;
                    x.huyen = dc.SelectSingleNode("huyen").InnerText;
                    x.tinh = dc.SelectSingleNode("tinh").InnerText;

                    b.Add(x);
                }
            }
            return b;
        }

        public List<NhanVien> searchByTinh(string tinh)
        {
            XmlNodeList a = root.SelectNodes("nhanvien");
            List<NhanVien> b = new List<NhanVien>();
            foreach (XmlNode item in a)
            {
                XmlNode dc = item.SelectSingleNode("diachi");

                if (dc.SelectSingleNode("tinh").InnerText.Equals(tinh))
                {
                    NhanVien x = new NhanVien();
                    x.id = item.Attributes[0].InnerText;
                    x.hoTen = item.SelectSingleNode("hoten").InnerText;
                    x.tuoi = item.SelectSingleNode("tuoi").InnerText;
                    x.luong = float.Parse(item.SelectSingleNode("luong").InnerText);
                    x.soDienThoai = item.SelectSingleNode("sodienthoai").InnerText;

                    x.xa = dc.SelectSingleNode("xa").InnerText;
                    x.huyen = dc.SelectSingleNode("huyen").InnerText;
                    x.tinh = dc.SelectSingleNode("tinh").InnerText;

                    b.Add(x);
                }
            }
            return b;
        }

        public List<NhanVien> getAllDatas()
        {
            XmlNodeList a = root.SelectNodes("nhanvien");
            List<NhanVien> b = new List<NhanVien>();
            foreach (XmlNode item in a)
            {
                NhanVien x = new NhanVien();
                x.id = item.Attributes[0].InnerText;
                x.hoTen = item.SelectSingleNode("hoten").InnerText;
                x.tuoi = item.SelectSingleNode("tuoi").InnerText;
                x.luong = float.Parse(item.SelectSingleNode("luong").InnerText);
                x.soDienThoai = item.SelectSingleNode("sodienthoai").InnerText;

                XmlNode dc = item.SelectSingleNode("diachi");
                x.xa = dc.SelectSingleNode("xa").InnerText;
                x.huyen = dc.SelectSingleNode("huyen").InnerText;
                x.tinh = dc.SelectSingleNode("tinh").InnerText;


                b.Add(x);
            }
            return b;
        }

        public void delete(string id)
        {
            XmlNodeList a = root.SelectNodes("nhanvien");
            foreach (XmlNode item in a)
            {
                if (item.Attributes[0].InnerText.Equals(id))
                {

                    // Lưu vào file
                    root.RemoveChild(item);
                    doc.Save(fileName);
                }
            }
        }
    }
}
