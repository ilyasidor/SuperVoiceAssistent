using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Media;



namespace WinFormsApp1
{

    public partial class Form1 : Form
    {

        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern
            Boolean PlaySound(string lpszName, int hModule, int dwFlags);

        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            //StartSoundOnStartPC();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetAutorunValue(true);
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            SetAutorunValue(false);
        }

        public bool SetAutorunValue(bool autorun)
        {
            const string name = "MyTestApplication";
            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void StartSoundOnStartPC()
        {
            string fullpath = (AppDomain.CurrentDomain.BaseDirectory) + "\\SoundStart";
            string[] StartSounds = {
                              fullpath+"\\SoundRun2.mp3",
                              fullpath+"\\SoundRun3.mp3",
                              fullpath+"\\SoundRun4.mp3",
                              fullpath+"\\SoundRun5.mp3"};
            Random rand = new Random();

            this.Text = WMP.versionInfo;
            WMP.URL = StartSounds[rand.Next(0, StartSounds.Length-1)];
            WMP.controls.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartSoundOnStartPC();
        }
    }
}