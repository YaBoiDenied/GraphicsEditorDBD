using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditorDBD
{
    public partial class SettingsEditor : Form
    {
        public SettingsEditor()
        {
            InitializeComponent();
            Startup();
            LoadData();
        }
        public string SD = "";
        public string GUSDirectory = @"\GameUserSettings.ini";  
        public string EngineDirectory = @"\Engine.ini";    
        public string ProgramDataDirectory = @"C:\ProgramData\WindowsNoEditorDirectory.txt";
        public string contents;

        public void Startup()
        {
            DisplayInfo();
            ultraGraphicsEditor1.Hide();
        }

        public void DisplayInfo()
        {
            DisplayGUS();
            DisplayEngine();
        }

        public void DisplayGUS()
        {
            List<string> lines = new List<string>();
            try
            {
                lines = File.ReadAllLines(SD + GUSDirectory).ToList();
            }
            catch { }
            GUSListBox.Items.Clear();
            foreach (String line in lines)
            {
                GUSListBox.Items.Add(line);
            }
        }

        public void DisplayEngine()
        {
            List<string> lines = new List<string>();
            try
            {
                lines = File.ReadAllLines(SD + EngineDirectory).ToList();
            }
            catch { }
            EngineListBox.Items.Clear();
            foreach (String line in lines)
            {
                EngineListBox.Items.Add(line);
            }
        }


        private void FPSCap1_Click(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //No FPS Cap
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("FrameRateLimit=60", "FrameRateLimit=0");
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("FrameRateLimit=120", "FrameRateLimit=0");
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("FrameRateLimit=144", "FrameRateLimit=0");
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to remove FPS Cap.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
        }

        private void FPSCap2_Click(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //144FPS Cap
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("FrameRateLimit=60", "FrameRateLimit=144");
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("FrameRateLimit=120", "FrameRateLimit=144");
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("FrameRateLimit=0", "FrameRateLimit=144");
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change FPS Cap setting to 144.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
        }

        private void FPSCap3_Click(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //120FPS Cap
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("FrameRateLimit=60", "FrameRateLimit=120");
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("FrameRateLimit=144", "FrameRateLimit=120");
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("FrameRateLimit=0", "FrameRateLimit=120");
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change FPS Cap setting to 144.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
        }


        private void FPSCap4_Click(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //60 FPS Cap
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("FrameRateLimit=0", "FrameRateLimit=60");
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("FrameRateLimit=120", "FrameRateLimit=60");
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("FrameRateLimit=144", "FrameRateLimit=60");
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change FPS Cap setting to 60.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
        }

        private void Vsync_CheckedChanged(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            try
            {
                if (Vsync.Checked)
                {
                    GameUserSettings.IsReadOnly = false;

                    string text = File.ReadAllText(SD + GUSDirectory);
                    text = text.Replace("bUseVSync=False", "bUseVSync=True");
                    File.WriteAllText(SD + GUSDirectory, text);
                }
                else
                {
                    GameUserSettings.IsReadOnly = false;
                    string text = File.ReadAllText(SD + GUSDirectory);
                    text = text.Replace("bUseVSync=True", "bUseVSync=False");
                    File.WriteAllText(SD + GUSDirectory, text);
                }
                GameUserSettings.IsReadOnly = true;
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Vsync Settings");
            }
            DisplayInfo();
        }

        private void Sky_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //Sky Quality
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.TrueSkyQuality=0", "sg.TrueSkyQuality=" + Sky.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.TrueSkyQuality=1", "sg.TrueSkyQuality=" + Sky.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.TrueSkyQuality=2", "sg.TrueSkyQuality=" + Sky.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.TrueSkyQuality=3", "sg.TrueSkyQuality=" + Sky.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.TrueSkyQuality=4", "sg.TrueSkyQuality=" + Sky.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.TrueSkyQuality=5", "sg.TrueSkyQuality=" + Sky.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Sky Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            SkyFB.Text = Sky.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Sky Quality set to: " + Sky.Value);
        }

        private void PostProcessing_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //Post Processing Quality
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.PostProcessQuality=0", "sg.PostProcessQuality=" + PostProcessing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.PostProcessQuality=1", "sg.PostProcessQuality=" + PostProcessing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.PostProcessQuality=2", "sg.PostProcessQuality=" + PostProcessing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.PostProcessQuality=3", "sg.PostProcessQuality=" + PostProcessing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.PostProcessQuality=4", "sg.PostProcessQuality=" + PostProcessing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.PostProcessQuality=5", "sg.PostProcessQuality=" + PostProcessing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Post Processing Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            PostProcessingFB.Text = PostProcessing.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Post Processing Quality set to: " + PostProcessing.Value);
        }

        private void Shadows_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //Shadow Quality
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.ShadowQuality=0", "sg.ShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ShadowQuality=1", "sg.ShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ShadowQuality=2", "sg.ShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ShadowQuality=3", "sg.ShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ShadowQuality=4", "sg.ShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ShadowQuality=5", "sg.ShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);

                text = text.Replace("sg.HeightFieldShadowQuality=0", "sg.HeightFieldShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.HeightFieldShadowQuality=1", "sg.HeightFieldShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.HeightFieldShadowQuality=2", "sg.HeightFieldShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.HeightFieldShadowQuality=3", "sg.HeightFieldShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.HeightFieldShadowQuality=4", "sg.HeightFieldShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.HeightFieldShadowQuality=5", "sg.HeightFieldShadowQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);

                text = text.Replace("sg.IBLQuality=0", "sg.IBLQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.IBLQuality=1", "sg.IBLQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.IBLQuality=2", "sg.IBLQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.IBLQuality=3", "sg.IBLQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.IBLQuality=4", "sg.IBLQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.IBLQuality=5", "sg.IBLQuality=" + Shadows.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Shadow Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            ShadowFB.Text = Shadows.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Shadow Quality set to: " + Shadows.Value);
        }

        private void Foliage_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //Foliage Quality
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.FoliageQuality=0", "sg.FoliageQuality=" + Foliage.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.FoliageQuality=1", "sg.FoliageQuality=" + Foliage.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.FoliageQuality=2", "sg.FoliageQuality=" + Foliage.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.FoliageQuality=3", "sg.FoliageQuality=" + Foliage.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.FoliageQuality=4", "sg.FoliageQuality=" + Foliage.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.FoliageQuality=5", "sg.FoliageQuality=" + Foliage.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Foliage Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            FoliageFB.Text = Foliage.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Foliage Quality set to: " + Foliage.Value);
        }

        private void Effects_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //Effects Quality
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.EffectsQuality=0", "sg.EffectsQuality=" + Effects.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.EffectsQuality=1", "sg.EffectsQuality=" + Effects.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.EffectsQuality=2", "sg.EffectsQuality=" + Effects.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.EffectsQuality=3", "sg.EffectsQuality=" + Effects.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.EffectsQuality=4", "sg.EffectsQuality=" + Effects.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.EffectsQuality=5", "sg.EffectsQuality=" + Effects.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Effects Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            EffectsFB.Text = Effects.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Effects Quality set to: " + Effects.Value);
        }

        private void AntiAliasing_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //Anti Aliasing Quality
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.AntiAliasingQuality=0", "sg.AntiAliasingQuality=" + AntiAliasing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.AntiAliasingQuality=1", "sg.AntiAliasingQuality=" + AntiAliasing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.AntiAliasingQuality=2", "sg.AntiAliasingQuality=" + AntiAliasing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.AntiAliasingQuality=3", "sg.AntiAliasingQuality=" + AntiAliasing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.AntiAliasingQuality=4", "sg.AntiAliasingQuality=" + AntiAliasing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.AntiAliasingQuality=5", "sg.AntiAliasingQuality=" + AntiAliasing.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Anti Aliasing Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            AntiAliasingFB.Text = AntiAliasing.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("AntiAlising Quality set to: " + AntiAliasing.Value);
        }

        private void ViewDistance_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //View Distance
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.ViewDistanceQuality=0", "sg.ViewDistanceQuality=" + ViewDistance.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ViewDistanceQuality=1", "sg.ViewDistanceQuality=" + ViewDistance.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ViewDistanceQuality=2", "sg.ViewDistanceQuality=" + ViewDistance.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ViewDistanceQuality=3", "sg.ViewDistanceQuality=" + ViewDistance.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ViewDistanceQuality=4", "sg.ViewDistanceQuality=" + ViewDistance.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ViewDistanceQuality=5", "sg.ViewDistanceQuality=" + ViewDistance.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change View Distance Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            ViewDistanceFB.Text = ViewDistance.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("View Distance set to: " + ViewDistance.Value);
        }

        private void Texture_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //Texture Quality
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.TextureQuality=0", "sg.TextureQuality=" + Texture.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.TextureQuality=1", "sg.TextureQuality=" + Texture.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.TextureQuality=2", "sg.TextureQuality=" + Texture.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.TextureQuality=3", "sg.TextureQuality=" + Texture.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.TextureQuality=4", "sg.TextureQuality=" + Texture.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.TextureQuality=5", "sg.TextureQuality=" + Texture.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Texture Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            TextureFB.Text = Texture.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Texture Quality set to: " + Texture.Value);
        }

        private void GroundClutter_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //Ground Clutter Quality
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.GroundClutterQuality=0", "sg.GroundClutterQuality=" + GroundClutter.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.GroundClutterQuality=1", "sg.GroundClutterQuality=" + GroundClutter.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.GroundClutterQuality=2", "sg.GroundClutterQuality=" + GroundClutter.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.GroundClutterQuality=3", "sg.GroundClutterQuality=" + GroundClutter.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.GroundClutterQuality=4", "sg.GroundClutterQuality=" + GroundClutter.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.GroundClutterQuality=5", "sg.GroundClutterQuality=" + GroundClutter.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Ground Clutter Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            GroundClutterFB.Text = GroundClutter.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Ground Clutter set to: " + GroundClutter.Value);
        }

        private void DirectorySet_Click(object sender, EventArgs e)
        {
            SD = Directory.Text;
            StreamWriter sw = new StreamWriter(ProgramDataDirectory);
            sw.WriteLine(SD);
            sw.Close();

            DisplayInfo();
        }

        private void LoadData()
        {
            try
            {
                StreamReader sr = new StreamReader(ProgramDataDirectory);
                SD = sr.ReadLine();
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to find WindowsNoEditor Directory text file in C:\\ProgramData.");
            }
            DisplayInfo();
            try
            {
                StreamReader sr = new StreamReader(@"C:\ProgramData\Mode.txt");
                string Mode = sr.ReadLine();
                if(Mode == "Purple")
                {
                    Purple();
                    PurpleMode.CheckState = CheckState.Checked;
                }
                if(Mode == "Light")
                {
                    Light();
                    LightMode.CheckState = CheckState.Checked;
                }
            }
            catch { }
        }

        private void FullScreenOn_Click(object sender, EventArgs e)
        {
            //FullscreenMode=0
            //LastConfirmedFullscreenMode=0
            //PreferredFullscreenMode=0
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            GameUserSettings.IsReadOnly = false;
            using (StreamReader sr = new StreamReader(SD + GUSDirectory))
            {
                contents = sr.ReadToEnd();
                sr.Close();
            }
            string text = File.ReadAllText(SD + GUSDirectory);
            text = text.Replace("FullscreenMode=1", "FullscreenMode=0");
            File.WriteAllText(SD + GUSDirectory, text);
            text = text.Replace("LastConfirmedFullscreenMode=1", "LastConfirmedFullscreenMode=0");
            File.WriteAllText(SD + GUSDirectory, text);
            text = text.Replace("LastConfirmedFullscreenMode=1", "LastConfirmedFullscreenMode=0");
            File.WriteAllText(SD + GUSDirectory, text);
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Dead By Daylight will now run in Proper Fullscreen.");
            DisplayInfo();
            GameUserSettings.IsReadOnly = false;
        }

        private void FullScreenOff_Click(object sender, EventArgs e)
        {
            //FullscreenMode=1
            //LastConfirmedFullscreenMode=1
            //PreferredFullscreenMode=1
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            GameUserSettings.IsReadOnly = false;
            using (StreamReader sr = new StreamReader(SD + GUSDirectory))
            {
                contents = sr.ReadToEnd();
                sr.Close();
            }
            string text = File.ReadAllText(SD + GUSDirectory);
            text = text.Replace("FullscreenMode=0", "FullscreenMode=1");
            File.WriteAllText(SD + GUSDirectory, text);
            text = text.Replace("LastConfirmedFullscreenMode=0", "LastConfirmedFullscreenMode=1");
            File.WriteAllText(SD + GUSDirectory, text);
            text = text.Replace("LastConfirmedFullscreenMode=0", "LastConfirmedFullscreenMode=1");
            File.WriteAllText(SD + GUSDirectory, text);
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Dead By Daylight will now run in Windowed Fullscreen.");
            DisplayInfo();
            GameUserSettings.IsReadOnly = false;
        }

        private void AntiAliasingOn_Click(object sender, EventArgs e)
        {
            FileInfo EngineSettings = new FileInfo(@SD + EngineDirectory);
            EngineSettings.IsReadOnly = false;
            using (StreamReader sr = new StreamReader(SD + EngineDirectory))
            {
                contents = sr.ReadToEnd();
                sr.Close();
            }
            if (contents.Contains("[/Script/Engine.GarbageCollectionSettings]"))
            {
                string text = File.ReadAllText(SD + EngineDirectory);
                text = text.Replace("[/Script/Engine.GarbageCollectionSettings]", "temp1");
                File.WriteAllText(SD + EngineDirectory, text);
                text = text.Replace("r.DefaultFeature.AntiAliasing=0", "temp2");
                File.WriteAllText(SD + EngineDirectory, text);
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Revert Anti Aliasing in Dead By Daylight(It now has Anti Aliasing).");
            }
            DisplayInfo();
            EngineSettings.IsReadOnly = false;
        }

        private void AntiAliasingOff_Click(object sender, EventArgs e)
        {
            FileInfo EngineSettings = new FileInfo(@SD + EngineDirectory);
            EngineSettings.IsReadOnly = false;
            using (StreamReader sr = new StreamReader(SD + EngineDirectory))
            {
                contents = sr.ReadToEnd();
                sr.Close();
            }
            if (contents.Contains("temp"))
            {
                string text = File.ReadAllText(SD + EngineDirectory);
                text = text.Replace("temp1", "[/Script/Engine.GarbageCollectionSettings]");
                File.WriteAllText(SD + EngineDirectory, text);
                text = text.Replace("temp2", "r.DefaultFeature.AntiAliasing=0");
                File.WriteAllText(SD + EngineDirectory, text);
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Removed Anti Aliasing in Dead By Daylight(It does NOT have Anti Aliasing).");
            }
            else
            {
                if (!contents.Contains("AntiAliasing="))
                {
                    StreamWriter sw = new StreamWriter(SD + EngineDirectory, true);
                    sw.WriteLine("[/Script/Engine.GarbageCollectionSettings]", Environment.NewLine);
                    sw.WriteLine("r.DefaultFeature.AntiAliasing=0", Environment.NewLine);
                    sw.Close();
                    ReportLog.Items.Clear();
                    ReportLog.Items.Add("Removed Anti Aliasing in Dead By Daylight(It does NOT have Anti Aliasing).");
                }
            }
            DisplayInfo();
            EngineSettings.IsReadOnly = true;
        }

        private void ShadingQuality_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //Shading Quality
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.ShadingQuality=0", "sg.ShadingQuality=" + ShadingQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ShadingQuality=1", "sg.ShadingQuality=" + ShadingQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ShadingQuality=2", "sg.ShadingQuality=" + ShadingQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ShadingQuality=3", "sg.ShadingQuality=" + ShadingQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ShadingQuality=4", "sg.ShadingQuality=" + ShadingQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ShadingQuality=5", "sg.ShadingQuality=" + ShadingQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Shading Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            ShadingFB.Text = ShadingQuality.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Shading Quality set to: " + ShadingQuality.Value);
        }

        private void AnimationQuality_Scroll(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //Animation Quality
            if (AnimationQuality.Value == 0) //Warning for setting AnimationQuality to 0, it causes major issues.
            {
                MessageBox.Show("Having AnimationQuality set to 0 casuses MAJOR FPS issues, however, access to this feature is kept in to allow for educational purposes, but DO NOT USE IT AT 0!!!!");
            }
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.AnimationQuality=0", "sg.AnimationQuality=" + AnimationQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.AnimationQuality=1", "sg.AnimationQuality=" + AnimationQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.AnimationQuality=2", "sg.AnimationQuality=" + AnimationQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.AnimationQuality=3", "sg.AnimationQuality=" + AnimationQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.AnimationQuality=4", "sg.AnimationQuality=" + AnimationQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.AnimationQuality=5", "sg.AnimationQuality=" + AnimationQuality.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            {
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Unable to change Animation Quality.");
            }
            GameUserSettings.IsReadOnly = true;
            DisplayInfo();
            AnimationFB.Text = AnimationQuality.Value.ToString();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Animation Quality set to: " + AnimationQuality.Value);
        }

        private void UltraGraphics_Click(object sender, EventArgs e)
        {
            ultraGraphicsEditor1.Show();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Entered Ultra Graphics Editing Mode.");
        }

        private void NormalEditor_Click(object sender, EventArgs e)
        {
            ultraGraphicsEditor1.Hide();
            ReportLog.Items.Clear();
            ReportLog.Items.Add("Entered Normal Graphics Editing Mode.");
        }

        private void LightMode_CheckedChanged(object sender, EventArgs e)
        {
            if (PurpleMode.Checked)
            {
                LightMode.CheckState = CheckState.Unchecked;
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Lilac Theme is already selected, untick this first.");
            }
            else
            {
                if (LightMode.Checked)
                {
                    Light();
                    LightMode.ForeColor = Color.Gold;
                    StreamWriter sw = new StreamWriter(@"C:\ProgramData\Mode.txt");
                    sw.WriteLine("Light");
                    sw.Close();
                }
                else
                {
                    Revert();
                    LightMode.ForeColor = Color.White;
                    StreamWriter sw = new StreamWriter(@"C:\ProgramData\Mode.txt");
                    sw.WriteLine("");
                    sw.Close();
                }
            }
        }

        private void PurpleMode_CheckedChanged(object sender, EventArgs e)
        {
            if (LightMode.Checked)
            {
                PurpleMode.CheckState = CheckState.Unchecked;
                ReportLog.Items.Clear();
                ReportLog.Items.Add("Light Theme is already selected, untick this first.");
            }
            else
            {
                if (PurpleMode.Checked)
                {
                    Purple();
                    PurpleMode.ForeColor = Color.Gold;
                    StreamWriter sw = new StreamWriter(@"C:\ProgramData\Mode.txt");
                    sw.WriteLine("Purple");
                    sw.Close();
                }
                else
                {
                    Revert();
                    PurpleMode.ForeColor = Color.White;
                    StreamWriter sw = new StreamWriter(@"C:\ProgramData\Mode.txt");
                    sw.WriteLine("");
                    sw.Close();
                }
            }
        }

        private void Light()
        {
            this.BackColor = Color.White;
            FPSCap1.BackColor = Color.FromArgb(136, 136, 136);
            FPSCap1.ForeColor = Color.Black;
            FPSCap2.BackColor = Color.FromArgb(136, 136, 136);
            FPSCap2.ForeColor = Color.Black;
            FPSCap3.BackColor = Color.FromArgb(136, 136, 136);
            FPSCap3.ForeColor = Color.Black;
            FPSCap4.BackColor = Color.FromArgb(136, 136, 136);
            FPSCap4.ForeColor = Color.Black;
            GUSListBox.BackColor = Color.FromArgb(202, 202, 201);
            GUSListBox.ForeColor = Color.Black;
            EngineListBox.BackColor = Color.FromArgb(202, 202, 201);
            EngineListBox.ForeColor = Color.Black;
            label1.BackColor = Color.FromArgb(136, 136, 136);
            label1.ForeColor = Color.Black;
            label2.BackColor = Color.FromArgb(136, 136, 136);
            label2.ForeColor = Color.Black;
            label3.BackColor = Color.FromArgb(136, 136, 136);
            label3.ForeColor = Color.Black;
            label4.BackColor = Color.FromArgb(136, 136, 136);
            label4.ForeColor = Color.Black;
            label5.BackColor = Color.FromArgb(136, 136, 136);
            label5.ForeColor = Color.Black;
            label6.BackColor = Color.FromArgb(136, 136, 136);
            label6.ForeColor = Color.Black;
            label7.BackColor = Color.FromArgb(136, 136, 136);
            label7.ForeColor = Color.Black;
            label8.BackColor = Color.FromArgb(136, 136, 136);
            label8.ForeColor = Color.Black;
            label9.BackColor = Color.FromArgb(136, 136, 136);
            label9.ForeColor = Color.Black;
            label10.BackColor = Color.FromArgb(136, 136, 136);
            label10.ForeColor = Color.Black;
            label11.BackColor = Color.FromArgb(136, 136, 136);
            label11.ForeColor = Color.Black;
            label12.BackColor = Color.FromArgb(136, 136, 136);
            label12.ForeColor = Color.Black;
            label13.BackColor = Color.FromArgb(136, 136, 136);
            label13.ForeColor = Color.Black;
            label14.BackColor = Color.FromArgb(136, 136, 136);
            label14.ForeColor = Color.Black;
            label15.BackColor = Color.FromArgb(136, 136, 136);
            label15.ForeColor = Color.Black;
            GoToDir.BackColor = Color.FromArgb(136, 136, 136);
            GoToDir.ForeColor = Color.Black;
            label16.BackColor = Color.FromArgb(136, 136, 136);
            label16.ForeColor = Color.Black;
            label17.BackColor = Color.FromArgb(136, 136, 136);
            label17.ForeColor = Color.Black;
            ReadOnlyOff.BackColor = Color.FromArgb(136, 136, 136);
            ReadOnlyOff.ForeColor = Color.Black;
            ReadOnlyOn.BackColor = Color.FromArgb(136, 136, 136);
            ReadOnlyOn.ForeColor = Color.Black;

            Vsync.BackColor = Color.FromArgb(136, 136, 136);
            Vsync.ForeColor = Color.Black;
            FullScreenOn.BackColor = Color.FromArgb(136, 136, 136);
            FullScreenOn.ForeColor = Color.Black;
            FullScreenOff.BackColor = Color.FromArgb(136, 136, 136);
            FullScreenOff.ForeColor = Color.Black;
            AntiAliasingOn.BackColor = Color.FromArgb(136, 136, 136);
            AntiAliasingOn.ForeColor = Color.Black;
            AntiAliasingOff.BackColor = Color.FromArgb(136, 136, 136);
            AntiAliasingOff.ForeColor = Color.Black;
            Directory.BackColor = Color.FromArgb(136, 136, 136);
            Directory.ForeColor = Color.Black;
            DirectorySet.BackColor = Color.FromArgb(136, 136, 136);
            DirectorySet.ForeColor = Color.Black;
            panel4.BackColor = Color.FromArgb(202, 202, 201);
            panel4.ForeColor = Color.Black;
            ViewDistance.BackColor = Color.Black;
            ViewDistanceFB.BackColor = Color.FromArgb(136, 136, 136);
            ViewDistanceFB.ForeColor = Color.Black;
            PostProcessing.BackColor = Color.Black;
            PostProcessingFB.BackColor = Color.FromArgb(136, 136, 136);
            PostProcessingFB.ForeColor = Color.Black;
            Foliage.BackColor = Color.Black;
            FoliageFB.BackColor = Color.FromArgb(136, 136, 136);
            FoliageFB.ForeColor = Color.Black;
            ShadingQuality.BackColor = Color.Black;
            ShadingFB.BackColor = Color.FromArgb(136, 136, 136);
            ShadingFB.ForeColor = Color.Black;
            AntiAliasing.BackColor = Color.Black;
            AntiAliasingFB.BackColor = Color.FromArgb(136, 136, 136);
            AntiAliasingFB.ForeColor = Color.Black;
            Texture.BackColor = Color.Black;
            TextureFB.BackColor = Color.FromArgb(136, 136, 136);
            TextureFB.ForeColor = Color.Black;
            Sky.BackColor = Color.Black;
            SkyFB.BackColor = Color.FromArgb(136, 136, 136);
            SkyFB.ForeColor = Color.Black;
            AnimationQuality.BackColor = Color.Black;
            AnimationFB.BackColor = Color.FromArgb(136, 136, 136);
            AnimationFB.ForeColor = Color.Black;
            Shadows.BackColor = Color.Black;
            ShadowFB.BackColor = Color.FromArgb(136, 136, 136);
            ShadowFB.ForeColor = Color.Black;
            Effects.BackColor = Color.Black;
            EffectsFB.BackColor = Color.FromArgb(136, 136, 136);
            EffectsFB.ForeColor = Color.Black;
            GroundClutter.BackColor = Color.Black;
            GroundClutterFB.BackColor = Color.FromArgb(136, 136, 136);
            GroundClutterFB.ForeColor = Color.Black;
        }

        private void Revert()
        {
            this.BackColor = Color.FromArgb(37, 42, 64);
            FPSCap1.BackColor = Color.FromArgb(24, 30, 54);
            FPSCap1.ForeColor = Color.FromArgb(0, 156, 149);
            FPSCap2.BackColor = Color.FromArgb(24, 30, 54);
            FPSCap2.ForeColor = Color.FromArgb(0, 156, 149);
            FPSCap3.BackColor = Color.FromArgb(24, 30, 54);
            FPSCap3.ForeColor = Color.FromArgb(0, 156, 149);
            FPSCap4.BackColor = Color.FromArgb(24, 30, 54);
            FPSCap4.ForeColor = Color.FromArgb(0, 156, 149);
            GUSListBox.BackColor = Color.FromArgb(24, 30, 54);
            GUSListBox.ForeColor = Color.FromArgb(0, 156, 149);
            EngineListBox.BackColor = Color.FromArgb(24, 30, 54);
            EngineListBox.ForeColor = Color.FromArgb(0, 156, 149);
            label1.BackColor = Color.FromArgb(24, 30, 54);
            label1.ForeColor = Color.FromArgb(0, 156, 149);
            label2.BackColor = Color.FromArgb(24, 30, 54);
            label2.ForeColor = Color.FromArgb(0, 156, 149);
            label3.BackColor = Color.FromArgb(24, 30, 54);
            label3.ForeColor = Color.FromArgb(0, 156, 149);
            label4.BackColor = Color.FromArgb(24, 30, 54);
            label4.ForeColor = Color.FromArgb(0, 156, 149);
            label5.BackColor = Color.FromArgb(24, 30, 54);
            label5.ForeColor = Color.FromArgb(0, 156, 149);
            label6.BackColor = Color.FromArgb(24, 30, 54);
            label6.ForeColor = Color.FromArgb(0, 156, 149);
            label7.BackColor = Color.FromArgb(24, 30, 54);
            label7.ForeColor = Color.FromArgb(0, 156, 149);
            label8.BackColor = Color.FromArgb(24, 30, 54);
            label8.ForeColor = Color.FromArgb(0, 156, 149);
            label9.BackColor = Color.FromArgb(24, 30, 54);
            label9.ForeColor = Color.FromArgb(0, 156, 149);
            label10.BackColor = Color.FromArgb(24, 30, 54);
            label10.ForeColor = Color.FromArgb(0, 156, 149);
            label11.BackColor = Color.FromArgb(24, 30, 54);
            label11.ForeColor = Color.FromArgb(0, 156, 149);
            label12.BackColor = Color.FromArgb(24, 30, 54);
            label12.ForeColor = Color.FromArgb(0, 156, 149);
            label13.BackColor = Color.FromArgb(24, 30, 54);     
            GoToDir.ForeColor = Color.FromArgb(0, 156, 149);
            GoToDir.BackColor = Color.FromArgb(24, 30, 54);
            label13.ForeColor = Color.FromArgb(0, 156, 149);
            label14.BackColor = Color.FromArgb(24, 30, 54);
            label14.ForeColor = Color.FromArgb(0, 156, 149);
            label15.BackColor = Color.FromArgb(24, 30, 54);
            label15.ForeColor = Color.FromArgb(0, 156, 149);
            label16.BackColor = Color.FromArgb(24, 30, 54);
            label16.ForeColor = Color.FromArgb(0, 156, 149);
            label17.BackColor = Color.FromArgb(24, 30, 54);
            label17.ForeColor = Color.FromArgb(0, 156, 149);
            ReadOnlyOff.BackColor = Color.FromArgb(24, 30, 54);
            ReadOnlyOff.ForeColor = Color.FromArgb(0, 156, 149);
            ReadOnlyOn.BackColor = Color.FromArgb(24, 30, 54);
            ReadOnlyOn.ForeColor = Color.FromArgb(0, 156, 149);

            Vsync.BackColor = Color.FromArgb(24, 30, 54);
            Vsync.ForeColor = Color.FromArgb(0, 156, 149);
            FullScreenOn.BackColor = Color.FromArgb(24, 30, 54);
            FullScreenOn.ForeColor = Color.FromArgb(0, 156, 149);
            FullScreenOff.BackColor = Color.FromArgb(24, 30, 54);
            FullScreenOff.ForeColor = Color.FromArgb(0, 156, 149);
            AntiAliasingOn.BackColor = Color.FromArgb(24, 30, 54);
            AntiAliasingOn.ForeColor = Color.FromArgb(0, 156, 149);
            AntiAliasingOff.BackColor = Color.FromArgb(24, 30, 54);
            AntiAliasingOff.ForeColor = Color.FromArgb(0, 156, 149);
            Directory.BackColor = Color.FromArgb(24, 30, 54);
            Directory.ForeColor = Color.FromArgb(0, 156, 149);
            DirectorySet.BackColor = Color.FromArgb(24, 30, 54);
            DirectorySet.ForeColor = Color.FromArgb(0, 156, 149);
            panel4.BackColor = Color.FromArgb(24, 30, 54);
            panel4.ForeColor = Color.FromArgb(0, 156, 149);
            ViewDistance.BackColor = Color.FromArgb(24, 30, 54);
            ViewDistanceFB.BackColor = Color.FromArgb(24, 30, 54);
            ViewDistanceFB.ForeColor = Color.FromArgb(0, 156, 149);
            PostProcessing.BackColor = Color.FromArgb(24, 30, 54);
            PostProcessingFB.BackColor = Color.FromArgb(24, 30, 54);
            PostProcessingFB.ForeColor = Color.FromArgb(0, 156, 149);
            Foliage.BackColor = Color.FromArgb(24, 30, 54);
            FoliageFB.BackColor = Color.FromArgb(24, 30, 54);
            FoliageFB.ForeColor = Color.FromArgb(0, 156, 149);
            ShadingQuality.BackColor = Color.FromArgb(24, 30, 54);
            ShadingFB.BackColor = Color.FromArgb(24, 30, 54);
            ShadingFB.ForeColor = Color.FromArgb(0, 156, 149);
            AntiAliasing.BackColor = Color.FromArgb(24, 30, 54);
            AntiAliasingFB.BackColor = Color.FromArgb(24, 30, 54);
            AntiAliasingFB.ForeColor = Color.FromArgb(0, 156, 149);
            Texture.BackColor = Color.FromArgb(24, 30, 54);
            TextureFB.BackColor = Color.FromArgb(24, 30, 54);
            TextureFB.ForeColor = Color.FromArgb(0, 156, 149);
            Sky.BackColor = Color.FromArgb(24, 30, 54);
            SkyFB.BackColor = Color.FromArgb(24, 30, 54);
            SkyFB.ForeColor = Color.FromArgb(0, 156, 149);
            AnimationQuality.BackColor = Color.FromArgb(24, 30, 54);
            AnimationFB.BackColor = Color.FromArgb(24, 30, 54);
            AnimationFB.ForeColor = Color.FromArgb(0, 156, 149);
            Shadows.BackColor = Color.FromArgb(24, 30, 54);
            ShadowFB.BackColor = Color.FromArgb(24, 30, 54);
            ShadowFB.ForeColor = Color.FromArgb(0, 156, 149);
            Effects.BackColor = Color.FromArgb(24, 30, 54);
            EffectsFB.BackColor = Color.FromArgb(24, 30, 54);
            EffectsFB.ForeColor = Color.FromArgb(0, 156, 149);
            GroundClutter.BackColor = Color.FromArgb(24, 30, 54);
            GroundClutterFB.BackColor = Color.FromArgb(24, 30, 54);
            GroundClutterFB.ForeColor = Color.FromArgb(0, 156, 149);
        }

        private void Purple()
        {
            this.BackColor = Color.MediumPurple;
            FPSCap1.BackColor = Color.FromArgb(66, 46, 126);
            FPSCap1.ForeColor = Color.White;
            FPSCap2.BackColor = Color.FromArgb(66, 46, 126);
            FPSCap2.ForeColor = Color.White;
            FPSCap3.BackColor = Color.FromArgb(66, 46, 126);
            FPSCap3.ForeColor = Color.White;
            FPSCap4.BackColor = Color.FromArgb(66, 46, 126);
            FPSCap4.ForeColor = Color.White;
            GUSListBox.BackColor = Color.FromArgb(96, 76, 156);
            GUSListBox.ForeColor = Color.White;
            EngineListBox.BackColor = Color.FromArgb(96, 76, 156);
            EngineListBox.ForeColor = Color.White;
            label1.BackColor = Color.FromArgb(66, 46, 126);
            label1.ForeColor = Color.White;
            GoToDir.BackColor = Color.FromArgb(66, 46, 126);
            GoToDir.ForeColor = Color.White;
            label2.BackColor = Color.FromArgb(66, 46, 126);
            label2.ForeColor = Color.White;
            label3.BackColor = Color.FromArgb(66, 46, 126);
            label3.ForeColor = Color.White;
            label4.BackColor = Color.FromArgb(66, 46, 126);
            label4.ForeColor = Color.White;
            label5.BackColor = Color.FromArgb(66, 46, 126);
            label5.ForeColor = Color.White;
            label6.BackColor = Color.FromArgb(66, 46, 126);
            label6.ForeColor = Color.White;
            label7.BackColor = Color.FromArgb(66, 46, 126);
            label7.ForeColor = Color.White;
            label8.BackColor = Color.FromArgb(66, 46, 126);
            label8.ForeColor = Color.White;
            label9.BackColor = Color.FromArgb(66, 46, 126);
            label9.ForeColor = Color.White;
            label10.BackColor = Color.FromArgb(66, 46, 126);
            label10.ForeColor = Color.White;
            label11.BackColor = Color.FromArgb(66, 46, 126);
            label11.ForeColor = Color.White;
            label12.BackColor = Color.FromArgb(66, 46, 126);
            label12.ForeColor = Color.White;
            label13.BackColor = Color.FromArgb(66, 46, 126);
            label13.ForeColor = Color.White;
            label14.BackColor = Color.FromArgb(66, 46, 126);
            label14.ForeColor = Color.White;
            label15.BackColor = Color.FromArgb(66, 46, 126);
            label15.ForeColor = Color.White;
            label16.BackColor = Color.FromArgb(66, 46, 126);
            label16.ForeColor = Color.White;
            label17.BackColor = Color.FromArgb(66, 46, 126);
            label17.ForeColor = Color.White;            
            ReadOnlyOff.BackColor = Color.FromArgb(66, 46, 126);
            ReadOnlyOff.ForeColor = Color.White;
            ReadOnlyOn.BackColor = Color.FromArgb(66, 46, 126);
            ReadOnlyOn.ForeColor = Color.White;
            Vsync.BackColor = Color.FromArgb(66, 46, 126);
            Vsync.ForeColor = Color.White;
            FullScreenOn.BackColor = Color.FromArgb(66, 46, 126);
            FullScreenOn.ForeColor = Color.White;
            FullScreenOff.BackColor = Color.FromArgb(66, 46, 126);
            FullScreenOff.ForeColor = Color.White;
            AntiAliasingOn.BackColor = Color.FromArgb(66, 46, 126);
            AntiAliasingOn.ForeColor = Color.White;
            AntiAliasingOff.BackColor = Color.FromArgb(66, 46, 126);
            AntiAliasingOff.ForeColor = Color.White;
            Directory.BackColor = Color.FromArgb(66, 46, 126);
            Directory.ForeColor = Color.White;
            DirectorySet.BackColor = Color.FromArgb(66, 46, 126);
            DirectorySet.ForeColor = Color.White;
            panel4.BackColor = Color.FromArgb(66, 46, 126);
            panel4.ForeColor = Color.White;
            ViewDistance.BackColor = Color.FromArgb(76, 56, 136);
            ViewDistanceFB.BackColor = Color.FromArgb(96, 76, 156);
            ViewDistanceFB.ForeColor = Color.White;
            PostProcessing.BackColor = Color.FromArgb(76, 56, 136);
            PostProcessingFB.BackColor = Color.FromArgb(96, 76, 156);
            PostProcessingFB.ForeColor = Color.White;
            Foliage.BackColor = Color.FromArgb(76, 56, 136);
            FoliageFB.BackColor = Color.FromArgb(96, 76, 156);
            FoliageFB.ForeColor = Color.White;
            ShadingQuality.BackColor = Color.FromArgb(76, 56, 136);
            ShadingFB.BackColor = Color.FromArgb(96, 76, 156);
            ShadingFB.ForeColor = Color.White;
            AntiAliasing.BackColor = Color.FromArgb(76, 56, 136);
            AntiAliasingFB.BackColor = Color.FromArgb(96, 76, 156);
            AntiAliasingFB.ForeColor = Color.White;
            Texture.BackColor = Color.FromArgb(76, 56, 136);
            TextureFB.BackColor = Color.FromArgb(96, 76, 156);
            TextureFB.ForeColor = Color.White;
            Sky.BackColor = Color.FromArgb(76, 56, 136);
            SkyFB.BackColor = Color.FromArgb(96, 76, 156);
            SkyFB.ForeColor = Color.White;
            AnimationQuality.BackColor = Color.FromArgb(76, 56, 136);
            AnimationFB.BackColor = Color.FromArgb(96, 76, 156);
            AnimationFB.ForeColor = Color.White;
            Shadows.BackColor = Color.FromArgb(76, 56, 136);
            ShadowFB.BackColor = Color.FromArgb(96, 76, 156);
            ShadowFB.ForeColor = Color.White;
            Effects.BackColor = Color.FromArgb(76, 56, 136);
            EffectsFB.BackColor = Color.FromArgb(96, 76, 156);
            EffectsFB.ForeColor = Color.White;
            GroundClutter.BackColor = Color.FromArgb(76, 56, 136);
            GroundClutterFB.BackColor = Color.FromArgb(96, 76, 156);
            GroundClutterFB.ForeColor = Color.White;
        }

        private void ReadOnlyOff_Click(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            GameUserSettings.IsReadOnly = false;
            FileInfo EngineSettings = new FileInfo(@SD + EngineDirectory);
            EngineSettings.IsReadOnly = false;
        }

        private void ReadOnlyOn_Click_1(object sender, EventArgs e)
        {
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            GameUserSettings.IsReadOnly = true;
            FileInfo EngineSettings = new FileInfo(@SD + EngineDirectory);
            EngineSettings.IsReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //GUS
            Process.Start(@SD);
        }
    }
}
