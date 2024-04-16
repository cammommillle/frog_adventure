using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Welcome : Form
    {
        private static bool simpleCheck;
        private bool audioFlag;
        public Welcome()
        {
            InitializeComponent();
        }

        public static bool GetSimpleCheck()
        {
            return simpleCheck;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            simpleCheck = false;
            Hide();
            Game form = new Game();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "D:\\study\\FinalProject\\Final-Project\\Final-Project\\Resources\\sound-1.wav";
            if (!audioFlag)
            {
                player.Play();
                audioFlag = true;
            }
            else
            {
                player.Stop();
                audioFlag = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            simpleCheck = true;
            Hide();
            Game form = new Game();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Instruction form = new Instruction();
            form.ShowDialog();
        }
    }
}
