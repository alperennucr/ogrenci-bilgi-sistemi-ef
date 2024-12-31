using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniOgrenciBilgiSistemi.models;

namespace MiniOgrenciBilgiSistemi
{
    public partial class Form1 : Form
    {
        Ogrenci bulunanOgrenci;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ogrEkle_Click(object sender, EventArgs e)
        {
            Ogrenci ogrenci = new Ogrenci();
            if (cmbBox_ogrSinif.SelectedItem != null && txtBox_ogrAd != null && txtBox_ogrSoyad != null && txtBox_ogrNumara != null)
            {
                Sinif sinif = (Sinif)cmbBox_ogrSinif.SelectedItem;
                ogrenci.Ad = txtBox_ogrAd.Text.Trim();
                ogrenci.Soyad = txtBox_ogrSoyad.Text.Trim();
                ogrenci.Numara = txtBox_ogrNumara.Text.Trim();
                ogrenci.SinifId = sinif.SinifId;
                using (var ctx = new OgrenciYonetimDbContext())
                {

                    if (ctx.Ogrenciler.FirstOrDefault(o => o.Numara == ogrenci.Numara) != null)
                    {
                        MessageBox.Show("Bu numaraya sahip bir öğrenci zaten var :(");
                    }
                    else
                    {
                        ctx.Ogrenciler.Add(ogrenci);
                        ctx.SaveChanges();
                        MessageBox.Show("Öğrenci eklendi");
                    }


                }
            }
            else
            {
                MessageBox.Show("Metin kutularını boş bırakma dost");
            }

        }

        private void btn_ogrGuncelle_Click(object sender, EventArgs e)
        {
            if (bulunanOgrenci != null)
            {

                if (cmbBox_ogrSinif.SelectedItem != null && txtBox_ogrAd != null && txtBox_ogrSoyad != null && txtBox_ogrNumara != null)
                {

                    using (var ctx = new OgrenciYonetimDbContext())
                    {
                        if (ctx.Ogrenciler.FirstOrDefault(o => o.Numara == bulunanOgrenci.Numara) != null)
                        {

                            var sinif = (Sinif)cmbBox_ogrSinif.SelectedItem;
                            bulunanOgrenci.Ad = txtBox_ogrAd.Text.Trim();
                            bulunanOgrenci.Soyad = txtBox_ogrSoyad.Text.Trim();
                            bulunanOgrenci.Numara = txtBox_ogrNumara.Text.Trim();
                            bulunanOgrenci.SinifId = sinif.SinifId;

                            using (var ctx2 = new OgrenciYonetimDbContext())
                            {
                                ctx2.Entry(bulunanOgrenci).State = EntityState.Modified;
                                ctx2.SaveChanges();
                            }

                            MessageBox.Show("Öğrenci güncellendi");
                        }
                        else
                        {
                            MessageBox.Show("else çalıştı bro");

                        }


                    }
                }
                else
                {
                    MessageBox.Show("Metin kutularını boş bırakma dost");
                }
            }
            else
            {
                MessageBox.Show("Numarasına göre bir öğrenci bulunuz daha sonra onun için bir güncelleme yapınız");
            }
        }

        private void btn_ogrBul_Click(object sender, EventArgs e)
        {
            string ogrNumara;
            if (txtBox_ogrNumara.Text.Trim().IsNullOrEmpty())
            {
                MessageBox.Show("Numara giriniz!");
            }
            else
            {
                ogrNumara = txtBox_ogrNumara.Text.Trim();

                using (var ctx = new OgrenciYonetimDbContext())
                {
                    //List<Sinif> Siniflar = SiniflariGetir();

                    List<Ogrenci> bulunanOgrenciler;
                    bulunanOgrenciler = ctx.Ogrenciler.Where(o => o.Numara == ogrNumara).ToList();

                    if (bulunanOgrenciler.Count >= 1)
                    {
                        bulunanOgrenci = bulunanOgrenciler[0];

                        Sinif ogrSinif = ctx.Siniflar.Where(o => o.SinifId == bulunanOgrenci.SinifId).FirstOrDefault();

                        txtBox_ogrAd.Text = bulunanOgrenciler[0].Ad.ToString();
                        txtBox_ogrSoyad.Text = bulunanOgrenciler[0].Soyad.ToString();
                        txtBox_ogrNumara.Text = bulunanOgrenciler[0].Numara.ToString();
                        cmbBox_ogrSinif.SelectedText = ogrSinif.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bu numaraya ait bir öğrenci bulunamadı");

                        txtBox_ogrAd.Text = "";
                        txtBox_ogrSoyad.Text = "";
                        txtBox_ogrNumara.Text = "";
                        cmbBox_ogrSinif.Items.Clear();
                    }

                }
            }


        }

        static List<Sinif> SiniflariGetir()
        {
            List<Sinif> Siniflar;

            using (var ctx = new OgrenciYonetimDbContext())
            {
                Siniflar = ctx.Siniflar.ToList();
            }

            return Siniflar;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var ctx = new OgrenciYonetimDbContext())
            {

                    ctx.Siniflar.ToList().ForEach(e =>
                    {
                        if(e != null)
                        {
                            cmbBox_ogrSinif.Items.Add(e);
                        }
                    });

            }
        }

        private void btn_dersSecimi_Click(object sender, EventArgs e)
        {
            Form2 dersSecimiForm = new Form2(bulunanOgrenci);
            dersSecimiForm.Show();
        }

        private void btn_sinifEkle_Click(object sender, EventArgs e)
        {
            Sinif sinif = new Sinif();
            if (txtBox_sinifAd.Text != string.Empty && numUpD_sinifKontenjan.Value != 0)
            {
                sinif.SinifAd = txtBox_sinifAd.Text.Trim();
                sinif.Kontenjan = (byte)numUpD_sinifKontenjan.Value;
                using (var ctx = new OgrenciYonetimDbContext())
                {

                    if (ctx.Siniflar.FirstOrDefault(s => s.SinifAd == sinif.SinifAd) != null)
                    {
                        MessageBox.Show("Böyle bir sınıf zaten var :(");
                    }
                    else
                    {
                        ctx.Siniflar.Add(sinif);
                        ctx.SaveChanges();
                        MessageBox.Show("Sınıf eklendi");
                    }


                }
            }
            else
            {
                MessageBox.Show("Metin kutularını boş bırakma dost");
            }
        }

        private void btn_sinifGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void btn_sinifBul_Click(object sender, EventArgs e)
        {
            if (txtBox_sinifAd.Text != string.Empty) {
                using (var ctx = new OgrenciYonetimDbContext())
                {
                    var siniflar = ctx.Siniflar.Where(s => s.SinifAd == txtBox_sinifAd.Text).ToList();
                    if (siniflar.Count > 0)
                    {
                        Sinif sinif = siniflar[0];
                        txtBox_sinifAd.Text = sinif.SinifAd;
                        numUpD_sinifKontenjan.Value = sinif.Kontenjan;
                    }
                }
            }
        }
    }
}
