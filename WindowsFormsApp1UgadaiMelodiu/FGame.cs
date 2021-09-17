using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1UgadaiMelodiu
{
    public partial class FGame : Form
    {
        Random rnd = new Random();

        int musicDuration= Victorina.musicDuration;

        public FGame()
        {
            InitializeComponent();
        }

        void MakeMusic()
        {
            if (Victorina.list.Count==0)
            {
                EndGame();
            }
            else
            {
                musicDuration = Victorina.musicDuration;
                int n = rnd.Next(0, Victorina.list.Count);
                WMP.URL = Victorina.list[n];
                //WMP.Ctlcontrols.play();
                Victorina.list.RemoveAt(n);
                lblMelodyCount.Text = Victorina.list.Count.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
            MakeMusic();
            //WMP.URL = Victorina.list[0];
        }

        private void WMP_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            WMP.Ctlcontrols.stop();
        }

        private void FGame_Load(object sender, EventArgs e)
        {
            lblMelodyCount.Text = Victorina.list.Count.ToString();
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Victorina.gameDuration;
            lblMusicDuration.Text = musicDuration.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            musicDuration--;
            lblMusicDuration.Text = musicDuration.ToString();
            if (progressBar1.Value == progressBar1.Maximum)
            {
                EndGame();
                return;
            }
            if (musicDuration ==0)
            {
                MakeMusic();
            }
        }

        void EndGame()
        {
            timer1.Stop();
            WMP.Ctlcontrols.stop();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            GamePause();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            GamePlayContinue();
        }

        private void FGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
            {
                GamePause();
                if (MessageBox.Show("Good answer ?", "Player 1",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lblCounter1.Text = Convert.ToString(Convert.ToInt32(lblCounter1.Text) + 1);
                    MakeMusic();
                }
                GamePlayContinue();
            }

            if (e.KeyData == Keys.P)
            {
                GamePause();
                if (MessageBox.Show("Good answer ?", "Player 2", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lblCounter2.Text = Convert.ToString(Convert.ToInt32(lblCounter2.Text) + 1);
                    MakeMusic();
                }
                GamePlayContinue();
            }
        }

        private void GamePlayContinue()
        {
            timer1.Start();
            WMP.Ctlcontrols.play();
        }

        void GamePause()
        {
            timer1.Stop();
            WMP.Ctlcontrols.pause();
        }
    }
}
