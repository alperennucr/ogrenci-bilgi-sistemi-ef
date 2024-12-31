using Microsoft.Data.SqlClient;
using MiniOgrenciBilgiSistemi.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniOgrenciBilgiSistemi
{
    public partial class Form2 : Form
    {
        Ogrenci ogrenci;
        public Form2(Ogrenci ogr)
        {
            InitializeComponent();

            ogrenci = ogr;

            lbl_OgrenciBilgisi.Text = $"{ogrenci.Ad} {ogrenci.Soyad} {ogrenci.Numara}";


            using (var ctx = new OgrenciYonetimDbContext())
            {
                dgw_table.DataSource = ctx.Dersler.ToList();
            }

            dgw_table.Columns[0].Visible = false;
            dgw_table.Columns[3].Visible = false;

            //
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Ders ders;
                using (var ctx = new OgrenciYonetimDbContext())
                {
                    foreach (DataGridViewRow row in dgw_table.SelectedRows)
                    {
                        if (row != null)
                        {
                            ders = (Ders)row.DataBoundItem;
                            OgrenciDers ogrenciDersKaydi = new OgrenciDers()
                            {
                                DersId = ders.DersId,
                                OgrenciId = ogrenci.OgrenciId
                            };

                            ctx.OgrenciDersler.Add(ogrenciDersKaydi);
                        }
                    }

                    ctx.SaveChanges();
                    MessageBox.Show("Ders(ler) başarıyla eklendi");
                }
            }
            catch (Exception Exc)
            {
                MessageBox.Show($"Hata: {Exc.Message}");
                
            }
        }
    }
}
