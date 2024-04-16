using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace Final_Project
{
    public partial class Instruction : Form
    {
        private int i;
        private string s = "Сериал рассказывает об отношениях между персонажами-геймерами. Юная Тун Яо - студентка, которая стала одной из первых девушек, что вступила в профессиональный киберспорт. Более того, она - пионер в Китайской Суперлиге. Здесь Тун ставит перед собой самые амбициозные цели. Главная героиня уверена в том, что сможет помочь своему коллективу выиграть турнир, который не поддается им уже в течение нескольких лет. Кто знает, что будет дальше. Шесть лет команда не знала больших побед, поэтому теперь девушка постарается помочь своим тиммейтам. Однако кроме игр героиня мечтает о счастливой личной жизни, которая уже не за горами.\n";
        public Instruction()
        {
            InitializeComponent();

            timer1.Interval = 100;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            i = 0;
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            char j = 'a';
            while (j != ' ' && j != '\n')
            {
                j = s[i];
                textBox1.Text += j;
                i++;
            }
            if (j == '\n')
            {
                timer1.Enabled = false;
            }
                

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Hide();
            Welcome form = new Welcome();
            form.ShowDialog();
        }
    }
}
