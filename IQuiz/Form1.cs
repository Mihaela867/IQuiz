using System;
using System.Windows.Forms;
using System.Media;

namespace IQuiz
{
    public partial class Form1 : Form
    {

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


        bool sound=true, music=true;
        SoundPlayer player;

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Welcome!");
            player = new SoundPlayer(Properties.Resources.music1);
            player.PlayLooping();
            ToolTip tooltip1 = new ToolTip();
            tooltip1.ShowAlways = true;
            tooltip1.SetToolTip(Info_button, "Informatii");
            ToolTip tooltip2 = new ToolTip();
            tooltip2.ShowAlways = true;
            tooltip2.SetToolTip(sound_button, "Sunet on/off");
            ToolTip tooltip3 = new ToolTip();
            tooltip3.ShowAlways = true;
            tooltip3.SetToolTip(music_button, "Muzica on/off");
        }

        private void sound_button_Click(object sender, EventArgs e)
        {
            if(sound)
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

        private void music_button_Click(object sender, EventArgs e)
        {
            if (music) //daca muzica este pornita
            {
                music = false;
                player.Stop();//se opreste muzica
                music_button.BackgroundImage = Properties.Resources.music_off;
            }
            else //daca muzica este oprita
            {
                music = true;
                player.PlayLooping();//se porneste muzica
                music_button.BackgroundImage = Properties.Resources.music_icon;
            }
        }

        private void Info_button_Click(object sender, EventArgs e)
        {
            Form Info_form = new Info_form();
            Info_form.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.Stop();
            MessageBox.Show("Multumim pentru ca ai jucat!", "Bye!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.Bounds.Width <= 1153)
                Width = 1024;
            else
                Width = 1200;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void start_button_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Form Form2 = new Form2(music, sound);// se declara Form2
            if (WindowState == FormWindowState.Maximized)//daca prima pagina este maximizata,
                Form2.WindowState = FormWindowState.Maximized;//noua forma se va deschide in full screen
            Form2.Show();//se afiseaza Form2
            Form2.SendToBack();
            wait(1);
            Form2.BringToFront();
            Hide();//Form1 este ascunsa
        }
    }
}
