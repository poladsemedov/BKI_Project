using System;
using System.Drawing;
using System.Windows.Forms;

namespace BKI_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double ceki = Convert.ToDouble(maskedTextBox1.Text);
                double boySm = Convert.ToDouble(maskedTextBox2.Text);

                if (boySm <= 0 || ceki <= 0)
                {
                    MessageBox.Show("Çəki və boy 0-dan böyük olmalıdır!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double boyM = boySm / 100.0;
                double bki = ceki / (boyM * boyM);

                label5.Text = Math.Round(bki, 1).ToString();

                pictureBox2.Image = Properties.Resources.weight;

                if (bki < 18.5)
                {
                    label3.Text = "Çəki azlığı (Arıq)";
                    label4.Text = "İmmunitet zəifliyi, qida çatışmazlığı riski";
                    pictureBox1.Image = Properties.Resources.Underweight;
                }
                else if (bki >= 18.5 && bki <= 24.9)
                {
                    label3.Text = "Normal çəki";
                    label4.Text = "Minimum risk (İdeal status)";
                    pictureBox1.Image = Properties.Resources.normal;
                }
                else if (bki >= 25.0 && bki <= 32.0)
                {
                    label3.Text = "Artıq çəki";
                    label4.Text = "Ürək-damar və şəkər xəstəliyi riski artır";
                    pictureBox1.Image = Properties.Resources.Overweight;
                }
                else if (bki >= 33.0 && bki <= 39.9)
                {
                    label3.Text = "I dərəcəli piylənmə";
                    label4.Text = "Yüksək tibbi risk";
                    pictureBox1.Image = Properties.Resources.obez;
                }
                else
                {
                    label3.Text = "III dərəcəli (Morbid) piylənmə";
                    label4.Text = "Həyati təhlükəli risk";
                    pictureBox1.Image = Properties.Resources.morbid;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Zəhmət olmasa xanalara yalnız rəqəm daxil edin!", "Format Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gözlənilməz xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = "0";
        }
    }
}
