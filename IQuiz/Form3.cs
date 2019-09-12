using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WMPLib;
using System.Runtime.InteropServices;

namespace IQuiz
{
    public partial class Form3 : Form
    {

        public static List<T> Shuffle<T>(List<T> list)
        {
            Random rnd = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int k = rnd.Next(0, i);
                T value = list[k];
                list[k] = list[i];
                list[i] = value;
            }
            return list;
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

        internal static class NativeWinAPI
        {
            internal static readonly int GWL_EXSTYLE = -20;
            internal static readonly int WS_EX_COMPOSITED = 0x02000000;

            [DllImport("user32")]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }

        void imaginea_categ(int nr_cat)
        {
            if(nr>0)
                 tooltip1.RemoveAll();
            tooltip1 = new ToolTip();
            tooltip1.ShowAlways = true;
            switch (nr_cat)
            {
                
                case 2:
                picture_category.BackgroundImage = Properties.Resources.picture_math;
                tooltip1.SetToolTip(picture_category, "Matematica");
                break;
                case 3:
                    picture_category.BackgroundImage = Properties.Resources.picture_biologie;
                    tooltip1.SetToolTip(picture_category, "Biologie");
                    break;
                case 4:
                    picture_category.BackgroundImage = Properties.Resources.picture_tehnologie;
                    tooltip1.SetToolTip(picture_category, "Tehnologie");
                    break;
                case 5:
                    picture_category.BackgroundImage = Properties.Resources.picture_istorie;
                    tooltip1.SetToolTip(picture_category, "Istorie");
                    break;
                case 6:
                    picture_category.BackgroundImage = Properties.Resources.picture_geografie;
                    tooltip1.SetToolTip(picture_category, "Geografie");
                    break;
                case 7:
                    picture_category.BackgroundImage = Properties.Resources.picture_literatura;
                    tooltip1.SetToolTip(picture_category, "Literatura");
                    break;
                case 8:
                    picture_category.BackgroundImage = Properties.Resources.picture_divertisment;
                    tooltip1.SetToolTip(picture_category, "Divertisment");
                    break;
                case 9:
                    picture_category.BackgroundImage = Properties.Resources.picture_fizica;
                    tooltip1.SetToolTip(picture_category, "Fizica");
                    break;
                case 10:
                    picture_category.BackgroundImage = Properties.Resources.picture_chimie;
                    tooltip1.SetToolTip(picture_category, "Chimie");
                    break;
                case 11:
                    picture_category.BackgroundImage = Properties.Resources.picture_arta;
                    tooltip1.SetToolTip(picture_category, "Arta");
                    break;
                case 12:
                    picture_category.BackgroundImage = Properties.Resources.picture_sport;
                    tooltip1.SetToolTip(picture_category, "Sport");
                    break;
            }
        }

        void update_highscores()
        {
            StreamReader file = new StreamReader(@"highscores.txt");
            string[] highscores = new string[12];
            int i = -1;
            string line;
            while ((line = file.ReadLine()) != null)
                highscores[++i] = line;
            file.Close();
            highscores[nr_cat - 1] = highscore.ToString();
            File.WriteAllLines("highscores.txt", highscores);
        }

        void new_question()
        {
            nr++;//creste numarul intrebarilor
            if (nr >= questions.Count)//daca nu au mai ramas intrebari
            {
                player2 = new WindowsMediaPlayer();
                player2.URL = "congrats.wav";
                player.controls.pause();
                player2.controls.play();
                MessageBox.Show("Felicitari! Ai castigat! Sigur ai un IQ urias! Scorul tau este " + score.ToString() + "!");
                highscore = score;
                update_highscores();
                //daca utilizatorul vrea sa joace din nou aplicatia se restarteaza
                //in caz contrar, aplicatia se inchide
                if (MessageBox.Show("Ai dori sa joci din nou?", "Restart", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Form Form2 = new Form2(music, sound);
                    if (WindowState == FormWindowState.Maximized)
                        Form2.WindowState = FormWindowState.Maximized;
                    Form2.Show();
                    player.controls.stop();
                    wait(500);
                    Hide();
                }
                else
                    Application.Exit();
            }
            //daca au mai ramas intrebari
            else
            {
                imaginea_categ(questions[nr].category);//se afiseaza imaginea specifica categoriei
                intrebare.Text = (nr+1).ToString() + ". " + questions[nr].description;//se afiseaza textul intrebarii
                //se afiseaza raspunsurile pe cele 4 butoane in ordine aleatorie
                button_raspuns1.Text =questions[nr].answers[rand.Next(questions[nr].answers.Length)];
                do
                    button_raspuns2.Text = questions[nr].answers[rand.Next(questions[nr].answers.Length)];
                while (button_raspuns2.Text == button_raspuns1.Text);
                do
                    button_raspuns3.Text =questions[nr].answers[rand.Next(questions[nr].answers.Length)];
                while (button_raspuns3.Text == button_raspuns1.Text || button_raspuns3.Text == button_raspuns2.Text);
                do
                    button_raspuns4.Text = questions[nr].answers[rand.Next(questions[nr].answers.Length)];
                while (button_raspuns4.Text == button_raspuns1.Text || button_raspuns4.Text == button_raspuns2.Text
                || button_raspuns4.Text == button_raspuns3.Text);
                 button_raspuns1.Text = "A. " + button_raspuns1.Text;
                button_raspuns2.Text = "B. " + button_raspuns2.Text;
                button_raspuns3.Text = "C. " + button_raspuns3.Text;
                button_raspuns4.Text = "D. " + button_raspuns4.Text;
                //se memoreaza raspunsul corect curent
                if (button_raspuns1.Text == "A. " + questions[nr].answers[0])
                    button_corect_curent = button_raspuns1;
                if (button_raspuns2.Text == "B. " + questions[nr].answers[0])
                    button_corect_curent = button_raspuns2;
                if (button_raspuns3.Text == "C. " + questions[nr].answers[0])
                    button_corect_curent = button_raspuns3;
                if (button_raspuns4.Text == "D. " + questions[nr].answers[0])
                    button_corect_curent = button_raspuns4;
               
            }
        }

        private void check_answer(bool ans, Button button)
        {
            if (var3 > 0)//daca a fost selectata varianta ajutatoare Raspuns Dublu
            {
                if (var3 == 1)//daca a fost apasat primul buton
                {
                    button.BackColor = Color.LightBlue;
                    button_sel1 = button;
                    var3++;
                }
                //daca a fost apasat al doilea buton
                else
                {
                    button.BackColor = Color.LightBlue;
                    button_sel2 = button;
                    if (button_sel2 == button_sel1)
                        MessageBox.Show("Selectati doua raspunsuri diferite");
                    var3 = -1;
                    double_answer(button_sel1, button_sel2);
                }
            }
            else
                if (rasp_selectat == false)
                {
                button.BackColor = Color.LightBlue;//se schimba culoarea butonului
                rasp_selectat = true;
                if (sound)
                {
                    player2 = new WindowsMediaPlayer();
                    player2.URL = "wait.wav";
                    player.settings.volume -= 40;
                    player2.controls.play();
                }
                wait(2010);//se asteapta 2 sec
                if (ans)//daca raspunsul este corect
                {
                    button.BackColor = Color.Green;//se schimba culoarea 
                                                    //butonului in verde
                    if (sound)
                    {
                        player2 = new WindowsMediaPlayer();
                        player2.URL = "right.wav";
                        player2.controls.play();
                    }
                    wait(1500);
                    button.BackColor = Color.White;//se revine la
                                                   //culoarea initiala
                    score = score + 10;//creste scorul curent
                    score_label.Text = score.ToString();
                    new_question();//se afiseaza o noua intrebare
                }
                else//daca raspunsul este gresit
                {
                    button.BackColor = Color.IndianRed;//se schimba culoarea
                                                       //butonului in rosu
                    if (sound)
                    {
                        player2 = new WindowsMediaPlayer();
                        player2.URL = "wrong.wav";
                        player2.controls.play();
                    }
                    wait(1500);
                    button_corect_curent.BackColor = Color.Green;//se schimba culoarea
                                                                //butonului corect in verde
                    if (sound)
                    {
                        player2 = new WindowsMediaPlayer();
                        player2.URL = "right.wav";
                        player2.controls.play();
                    }
                    wait(1000);
                    button_corect_curent.BackColor = Color.White;
                    lives = lives - 1;//scade numarul de vieti
                    if (lives == 2)
                        life1.BackgroundImage = Properties.Resources.life_gone;
                    else
                        if (lives == 1)
                        life2.BackgroundImage = Properties.Resources.life_gone;
                    else
                        if (lives == 0)
                        life3.BackgroundImage = Properties.Resources.life_gone;
                    button.BackColor = Color.White;
                    if (lives == 0)//daca ai ramas fara vieti
                    {
                        player2 = new WindowsMediaPlayer();
                        if (sound)
                        {
                            player2.URL = "fail.wav";
                            player2.controls.play();
                        }
                        MessageBox.Show("Ai pierdut! Mai mult noroc data viitoare! Scorul tau este " + score.ToString() + "!");
                        if (score > highscore)
                        {
                            highscore = score;
                            if (sound)
                            {
                                player2.URL = "congrats.wav";
                                player2.controls.play();
                            }
                            MessageBox.Show("Felicitari! Aveti un nou scor record: " + highscore.ToString());
                            update_highscores();
                        }
                        if (MessageBox.Show("Ai dori sa joci din nou?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            Application.Restart();
                        else
                            Application.Exit();
                    }
                    
                    new_question();//se trece la urmatoarea intrebare
                }
                rasp_selectat = false;
                if(sound)
                     player.settings.volume += 40;
            }
        }

        void double_answer(Button button1,Button button2)
        {
            if(sound)
            {
                player2 = new WindowsMediaPlayer();
                player2.URL = "wait.wav";
                player2.controls.play();
                player.settings.volume -= 40;
            }
            wait(2010);
            if (button1==button_corect_curent)
            {
                button2.BackColor = Color.IndianRed;
                if (sound)
                {
                    player2 = new WindowsMediaPlayer();
                    player2.URL = "wrong.wav";
                    player2.controls.play();
                  }
                wait(1000);
                check_answer(true, button1);
                
            }
            else
            {
                if (button2==button_corect_curent)
                { 
                    button1.BackColor = Color.IndianRed;
                    if (sound)
                    {
                        player2 = new WindowsMediaPlayer();
                        player2.URL = "wrong.wav";
                        player2.controls.play();
                    }
                    wait(1000);
                    check_answer(true, button2);
                }
                else
                {
                    wait(500);
                    button1.BackColor = Color.IndianRed;
                    if (sound)
                    {
                        player2 = new WindowsMediaPlayer();
                        player2.URL = "wrong.wav";
                        player2.controls.play();
                    }
                    wait(1000);
                    check_answer(false, button2);
                   
                }
            }
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;

        }

        int score = 0, highscore, nr = -1, lives = 3, var3 = 0,nr_cat;
        bool music, sound, rasp_selectat = false,var_ajutatoare1=true,var_ajutatoare2=true;
        Random rand = new Random();
        List<Question> questions;
        Button button_sel1, button_sel2,button_corect_curent;  
        WindowsMediaPlayer player, player2;
        ToolTip tooltip1;

        private void Form3_Load(object sender, EventArgs e)
        {

            if (Screen.PrimaryScreen.Bounds.Width <= 1153)
            {
                Width = 1024;
                intrebare.Font = new Font("Century", 18);
                intrebare.Width = 580;
            }
            else
            {
                Width = 1200;
                intrebare.Font = new Font("Century", 22);
                intrebare.Width = 738;
            }
            }

        



        public Form3(int nr_categ, bool Music, bool Sound, int Highscore)
        {
            InitializeComponent();
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
            player = new WindowsMediaPlayer();
            music = Music;
            sound = Sound;
            highscore = Highscore;
            nr_cat = nr_categ;
            highscore_label.Text = highscore.ToString();//se afiseaza scorul record 
            score_label.Text = "0";//scorul actual este egal cu 0
            //se creeaza lista cu intrebari (obiecte instanta a clasei Question) 
            questions = new List<Question>();
            StreamReader file = new StreamReader(@"questions.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] words = new string[6];
                words = line.Split('/');
                if (words[5] == nr_categ.ToString() || nr_categ == 1)
                    questions.Add(new Question(words[0], words[1], words[2], words[3], words[4], words[5]));  
            }
            questions = Shuffle(questions);//intrebarile sunt sortate aleatoriu
            player.URL = "music2.wav";//se initializeaza player-ul
            if (!music)
                player.controls.stop();
            if (!sound)
                sound_button.BackgroundImage = Properties.Resources.sound_off;
            if (!music)
                music_button.BackgroundImage = Properties.Resources.music_off;
            player.settings.setMode("loop", true);
            ToolTip tooltip2 = new ToolTip();
            tooltip2.ShowAlways = true;
            tooltip2.SetToolTip(sound_button, "Sunet on/off");
            ToolTip tooltip1 = new ToolTip();
            tooltip1.ShowAlways = true;
            tooltip1.SetToolTip(music_button, "Muzica on/off");
            ToolTip tooltip3 = new ToolTip();
            tooltip3.ShowAlways = true;
            tooltip3.SetToolTip(button_schimba_intrebarea, "Schimba intrebarea!");
            ToolTip tooltip4 = new ToolTip();
            tooltip4.ShowAlways = true;
            tooltip4.SetToolTip(button_suna_un_prieten, "Suna un prieten!");
            ToolTip tooltip5 = new ToolTip();
            tooltip5.ShowAlways = true;
            tooltip5.SetToolTip(button_doua_raspunsuri, "Selecteaza doua raspunsuri!");
            new_question();//se afiseaza o noua intrebare
        }

        private void button_raspuns1_Click(object sender, EventArgs e)
        {
            check_answer(button_raspuns1.Text == "A. " + questions[nr].answers[0], button_raspuns1);
        }

        private void button_raspuns2_Click(object sender, EventArgs e)
        {
            check_answer(button_raspuns2.Text == "B. " + questions[nr].answers[0], button_raspuns2);
        }

        private void button_raspuns3_Click(object sender, EventArgs e)
        {
            check_answer(button_raspuns3.Text =="C. " + questions[nr].answers[0], button_raspuns3);
        }

        private void button_raspuns4_Click(object sender, EventArgs e)
        {
            check_answer(button_raspuns4.Text == "D. "+questions[nr].answers[0], button_raspuns4);
        }

        private void button_schimba_intrebarea_Click(object sender, EventArgs e)
        {
            if (var_ajutatoare1)
            {
                new_question();
                var_ajutatoare1 = false;
                button_schimba_intrebarea.BackgroundImage = Properties.Resources.change_off;
            }
            else
                MessageBox.Show("Ai folosit deja aceasta varianta ajutatoare!", "Varianta ajutatoare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        private void button_suna_un_prieten_Click(object sender, EventArgs e)
        {
            if (var_ajutatoare2)
            {
                int x = rand.Next(10000);
                if (x % 3 == 0)
                    MessageBox.Show("Cred ca raspunsul corect este " + questions[nr].answers[1] + "!", "Gigel spune...",MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Cred ca raspunsul corect este " + questions[nr].answers[0] + "!","Gigel spune...",MessageBoxButtons.OK, MessageBoxIcon.Information);
                var_ajutatoare2 = false;
                button_suna_un_prieten.BackgroundImage = Properties.Resources.telefon_off;
            }
            else
                MessageBox.Show("Ai folosit deja aceasta varianta ajutatoare!","Varianta ajutatoare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void button_doua_raspunsuri_Click(object sender, EventArgs e)
        {
            if (var3 == 0)
            {
                var3 = 1;
                MessageBox.Show("Selectati doua raspunsuri!","Varianta ajutatoare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_doua_raspunsuri.BackgroundImage = Properties.Resources._2x_off;
            }
            else
                MessageBox.Show("Ai folosit deja aceasta varianta ajutatoare!","Varianta ajutatoare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void music_button_Click(object sender, EventArgs e)
        {
            if (music)
            {
                music = false;
                player.controls.pause();
                music_button.BackgroundImage = Properties.Resources.music_off;
            }
            else
            {
                music = true;
                player.controls.play();
                music_button.BackgroundImage = Properties.Resources.music_icon;
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

   }
}
