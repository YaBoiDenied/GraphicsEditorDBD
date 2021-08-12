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
    public partial class UltraGraphicsEditor : UserControl
    {
        public UltraGraphicsEditor()
        {
            InitializeComponent();
            LoadData1();
        }
        public string SD = "";
        public string GUSDirectory = @"\GameUserSettings.ini";
        public string EngineDirectory = @"\Engine.ini";    
        public string ProgramDataDirectory = @"C:\ProgramData\WindowsNoEditorDirectory.txt";

        private void LoadData1()
        {
            StreamReader sr = new StreamReader(ProgramDataDirectory);
            SD = sr.ReadLine();
        }

        public void DisplayInfo1()
        {
            SettingsEditor settingsEditor = (SettingsEditor)this.FindForm();
            settingsEditor.DisplayInfo();
        }

        private void ViewDistance1_Scroll_1(object sender, EventArgs e)
        {
            LoadData1();
            FileInfo GameUserSettings = new FileInfo(@SD + GUSDirectory);
            //View Distance
            try
            {
                GameUserSettings.IsReadOnly = false;
                string text = File.ReadAllText(SD + GUSDirectory);
                text = text.Replace("sg.ViewDistanceQuality=0", "sg.ViewDistanceQuality=" + ViewDistance1.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ViewDistanceQuality=1", "sg.ViewDistanceQuality=" + ViewDistance1.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ViewDistanceQuality=2", "sg.ViewDistanceQuality=" + ViewDistance1.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ViewDistanceQuality=3", "sg.ViewDistanceQuality=" + ViewDistance1.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ViewDistanceQuality=4", "sg.ViewDistanceQuality=" + ViewDistance1.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
                text = text.Replace("sg.ViewDistanceQuality=5", "sg.ViewDistanceQuality=" + ViewDistance1.Value.ToString());
                File.WriteAllText(SD + GUSDirectory, text);
            }
            catch
            { }
            GameUserSettings.IsReadOnly = true;
            ViewDistanceFB.Text = ViewDistance1.Value.ToString();
            DisplayInfo1();
        }

        private void PostProcessing_Scroll_1(object sender, EventArgs e)
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
            { }
            GameUserSettings.IsReadOnly = true;
            PostProcessingFB.Text = PostProcessing.Value.ToString();
            DisplayInfo1();
        }

        private void Foliage_Scroll_1(object sender, EventArgs e)
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
            { }
            GameUserSettings.IsReadOnly = true;
            FoliageFB.Text = Foliage.Value.ToString();
            DisplayInfo1();
        }

        private void ShadingQuality_Scroll_1(object sender, EventArgs e)
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
            { }
            GameUserSettings.IsReadOnly = true;
            ShadingFB.Text = ShadingQuality.Value.ToString();
            DisplayInfo1();
        }

        private void AnimationQuality_Scroll_1(object sender, EventArgs e)
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
            { }
            GameUserSettings.IsReadOnly = true;
            AnimationFB.Text = AnimationQuality.Value.ToString();
            DisplayInfo1();
        }

        private void Sky_Scroll_1(object sender, EventArgs e)
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
            { }
            GameUserSettings.IsReadOnly = true;
            SkyFB.Text = Sky.Value.ToString();
            DisplayInfo1();
        }

        private void Texture_Scroll_1(object sender, EventArgs e)
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
            { }
            GameUserSettings.IsReadOnly = true;
            TextureFB.Text = Texture.Value.ToString();
            DisplayInfo1();
        }

        private void AntiAliasing_Scroll_1(object sender, EventArgs e)
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
            { }
            GameUserSettings.IsReadOnly = true;
            AntiAliasingFB.Text = AntiAliasing.Value.ToString();
            DisplayInfo1();
        }

        private void Shadows_Scroll_1(object sender, EventArgs e)
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
            { }
            GameUserSettings.IsReadOnly = true;
            ShadowFB.Text = Shadows.Value.ToString();
            DisplayInfo1();
        }

        private void Effects_Scroll_1(object sender, EventArgs e)
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
            { }
            GameUserSettings.IsReadOnly = true;
            EffectsFB.Text = Effects.Value.ToString();
            DisplayInfo1();
        }

        private void GroundClutter_Scroll_1(object sender, EventArgs e)
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
            { }
            GameUserSettings.IsReadOnly = true;
            GroundClutterFB.Text = GroundClutter.Value.ToString();
            DisplayInfo1();
        }
    }
}
