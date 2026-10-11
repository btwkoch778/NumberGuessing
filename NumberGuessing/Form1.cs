
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NumberGuessing
{
    public partial class Form1 : Form
    {
        private int num;
        private int cehdSayi;
        private bool oyunAktivdir;
        private readonly Random r = new Random();

        public Form1()
        {
            InitializeComponent();

            textBox1.Enabled = false;
            button1.Enabled = false;

            textBox1.TextChanged += textBox1_TextChanged;
            button1.Click += button1_Click;
            yenioyunbtn.Click += yenioyunbtn_Click;
        }

        private void yenioyunbtn_Click(object sender, EventArgs e)
        {
            num = r.Next(0, 101);
            cehdSayi = 0;
            oyunAktivdir = true;

            textBox1.Clear();
            errorProvider1.Clear();

            richTextBox1.Clear();

            textBox1.Enabled = true;
            button1.Enabled = true;

            richTextBox1.AppendText("Yeni oyun başladı!\n");
            richTextBox1.AppendText("Cəhd sayı: 0\n");

            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!oyunAktivdir)
                return;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(
                    textBox1,
                    "Zəhmət olmasa, ədəd daxil edin!"
                );

                textBox1.Focus();
                return;
            }

            if (!int.TryParse(textBox1.Text, out int daxilEdilen))
            {
                errorProvider1.SetError(
                    textBox1,
                    "Tam ədəd daxil edin!"
                );

                textBox1.Focus();
                return;
            }

            if (daxilEdilen < 0 || daxilEdilen > 100)
            {
                errorProvider1.SetError(
                    textBox1,
                    "Ədəd 0 ilə 100 arasında olmalıdır!"
                );

                textBox1.Focus();
                return;
            }

            errorProvider1.Clear();
            cehdSayi++;

            richTextBox1.Clear();

            if (daxilEdilen == num)
            {
                richTextBox1.AppendText("Oyunu qazandınız!\n");
                richTextBox1.AppendText(
                    "Cəhd sayı: " + cehdSayi
                );

                oyunAktivdir = false;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                richTextBox1.AppendText("Siz yanlış tapdınız!\n");
                richTextBox1.AppendText(
                    "Cəhd sayı: " + cehdSayi + "\n"
                );
                richTextBox1.AppendText(
                    "Daxil edilən ədəd yanlışdır.\n"
                );

                if (daxilEdilen < num)
                {
                    richTextBox1.AppendText(
                        "Təsadüfi ədəddən kiçikdir."
                    );
                }
                else
                {
                    richTextBox1.AppendText(
                        "Təsadüfi ədəddən böyükdür."
                    );
                }
            }

            textBox1.SelectAll();
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }
    }
}
