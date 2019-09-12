using System;
using System.Media;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace IQuiz
{
    public partial class Form2 : Form
    {

        internal static class NativeWinAPI
        {
            internal static readonly int GWL_EXSTYLE = -20;
            internal static readonly int WS_EX_COMPOSITED = 0x02000000;

            [DllImport("user32")]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }

        public void wait(int milliseconds)
        {
            Timer timer1 = new Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        

        private void alege_categoria(int nr_cat)
        {
            UseWaitCursor = true;
            player.Stop();//se opreste muzica
            if (sound)//daca sunetul este pornit
            {
                player = new SoundPlayer(Properties.Resources.wait);
                player.Play();
            }
            Form Form3 = new Form3(nr_cat, music, sound,highscores[nr_cat-1]);
            if (WindowState == FormWindowState.Maximized)
                Form3.WindowState = FormWindowState.Maximized;
            Form3.Show();
            Form3.SendToBack();
            wait(1);
            Form3.BringToFront();
            Hide();
        }

        bool music, sound;
        SoundPlayer player;
        int[] highscores;

        public Form2(bool Music, bool Sound)
        {
            InitializeComponent();
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
            player = new SoundPlayer(Properties.Resources.music1);// se initializeaza player-ul
            music = Music;
            sound = Sound;
            //daca sunetul sau muzica este oprita se modifica imaginea butonului
            if (!sound)
                sound_button.BackgroundImage = Properties.Resources.sound_off;
            if (!music)
                music_button.BackgroundImage = Properties.Resources.music_off;
            //se citesc scorurile record din fisier
            StreamReader file = new StreamReader(@"highscores.txt");
            highscores = new int[12];
            int i=-1;
            string line;
            while((line=file.ReadLine())!=null)
                Int32.TryParse(line, out highscores[++i]);
            //se memoreaza highscore-ul pentru fiecare categorie in labelul respectiv
            hs_general.Text ="Highscore:"+ highscores[0].ToString() ;
            hs_mate.Text = "Highscore:" + highscores[1].ToString();
            hs_biologie.Text = "Highscore:" + highscores[2].ToString();
            hs_tehno.Text = "Highscore:" + highscores[3].ToString();
            hs_istorie.Text = "Highscore:" + highscores[4].ToString();
            hs_geo.Text = "Highscore:" + highscores[5].ToString();
            hs_lit.Text = "Highscore:" + highscores[6].ToString();
            hs_div.Text = "Highscore:" + highscores[7].ToString();
            hs_fizica.Text = "Highscore:" + highscores[8].ToString();
            hs_chimie.Text = "Highscore:" + highscores[9].ToString();
            hs_arta.Text = "Highscore:" + highscores[10].ToString();
            hs_sport.Text = "Highscore:" + highscores[11].ToString();
            ToolTip tooltip2 = new ToolTip();
            tooltip2.ShowAlways = true;
            tooltip2.SetToolTip(sound_button, "Sunet on/off");
            ToolTip tooltip3 = new ToolTip();
            tooltip3.ShowAlways = true;
            tooltip3.SetToolTip(music_button, "Muzica on/off");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void music_button_Click(object sender, EventArgs e)
        {
            if (music)
            {
                music = false;
                player.Stop();
                music_button.BackgroundImage = Properties.Resources.music_off;
            }
            else
            {
                music = true;
                player.PlayLooping();
                music_button.BackgroundImage = Properties.Resources.music_icon;
            }
        }

       

        private void button_general_MouseEnter(object sender, EventArgs e)
        {
            //cand user-ul ajunge cu mouse-ul pe buton se afiseaza 
            //casuta cu scorul record
            hs_general.Visible = true;
        }

        private void button_general_MouseLeave(object sender, EventArgs e)
        {
            //cand mouse-ul nu mai este pe buton se 
            //ascunde casuta cu scorul record
            hs_general.Visible = false;
        }

        private void button_matematica_MouseEnter(object sender, EventArgs e)
        {
            hs_mate.Visible = true;
        }

        private void button_matematica_MouseLeave(object sender, EventArgs e)
        {
            hs_mate.Visible = false;
        }

        private void button_biologie_MouseEnter(object sender, EventArgs e)
        {
            hs_biologie.Visible = true;
        }

        private void button_biologie_MouseLeave(object sender, EventArgs e)
        {
            hs_biologie.Visible = false;
        }

        private void button_tehnologie_MouseEnter(object sender, EventArgs e)
        {
            hs_tehno.Visible = true;
        }

        private void button_tehnologie_MouseLeave(object sender, EventArgs e)
        {
            hs_tehno.Visible = false;
        }

        private void button_istorie_MouseEnter(object sender, EventArgs e)
        {
            hs_istorie.Visible = true;
        }

        private void button_istorie_MouseLeave(object sender, EventArgs e)
        {
            hs_istorie.Visible = false;
        }

        private void button_geografie_MouseEnter(object sender, EventArgs e)
        {
            hs_geo.Visible = true;
        }

        private void button_geografie_MouseLeave(object sender, EventArgs e)
        {
            hs_geo.Visible = false;
        }

        private void button_literatura_MouseEnter(object sender, EventArgs e)
        {
            hs_lit.Visible = true;
        }

        private void button_literatura_MouseLeave(object sender, EventArgs e)
        {
            hs_lit.Visible = false;
        }

        private void button_divertisment_MouseEnter(object sender, EventArgs e)
        {
            hs_div.Visible = true;
        }

        private void button_divertisment_MouseLeave(object sender, EventArgs e)
        {
            hs_div.Visible = false;
        }

        private void button_fizica_MouseEnter(object sender, EventArgs e)
        {
            hs_fizica.Visible = true;
        }

        private void button_fizica_MouseLeave(object sender, EventArgs e)
        {
            hs_fizica.Visible = false;
        }

        private void button_chimie_MouseEnter(object sender, EventArgs e)
        {
            hs_chimie.Visible = true;
        }

        private void button_chimie_MouseLeave(object sender, EventArgs e)
        {
            hs_chimie.Visible = false;
        }

        private void button_arta_MouseEnter(object sender, EventArgs e)
        {
            hs_arta.Visible = true;
        }

        private void button_arta_MouseLeave(object sender, EventArgs e)
        {
            hs_arta.Visible = false;
        }

        private void button_sport_MouseEnter(object sender, EventArgs e)
        {
            hs_sport.Visible = true;
        }

        private void button_sport_MouseLeave(object sender, EventArgs e)
        {
            hs_sport.Visible = false;
        }

        private void button_general_Click(object sender, EventArgs e)
        {
            alege_categoria(1);
        }

        private void button_matematica_Click(object sender, EventArgs e)
        {
            alege_categoria(2);
        }

        private void button_biologie_Click(object sender, EventArgs e)
        {
            alege_categoria(3);
        }

        private void button_tehnologie_Click(object sender, EventArgs e)
        {
            alege_categoria(4);
        }

        private void button_istorie_Click(object sender, EventArgs e)
        {
            alege_categoria(5);
        }

        private void button_geografie_Click(object sender, EventArgs e)
        {
            alege_categoria(6);
        }

        private void button_literatura_Click(object sender, EventArgs e)
        {
            alege_categoria(7);
        }

        private void button_divertisment_Click(object sender, EventArgs e)
        {
            alege_categoria(8);
        }

        private void button_fizica_Click(object sender, EventArgs e)
        {
            alege_categoria(9);
        }

        private void button_chimie_Click(object sender, EventArgs e)
        {
            alege_categoria(10);
        }

        private void button_arta_Click(object sender, EventArgs e)
        {
            alege_categoria(11);
        }

        private void button_sport_Click(object sender, EventArgs e)
        {
            alege_categoria(12);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.Bounds.Width <= 1153)
                Width = 1024;
            else
            {
                Width = 1200;
                sound_button.Location = new System.Drawing.Point(1022, 12);
                music_button.Location = new System.Drawing.Point(1098, 12);
            }
        }

        private void sound_button_Click(object sender, EventArgs e)
        {
            if (sound)
            {
                sound = false;
                sound_button.BackgroundImage = Properties.Resources.sound_off;
            }
            else
            {
                sound = true;
                sound_button.BackgroundImage = Properties.Resources.sound_icon;
            }
        }
    }
}
