using FMOD.Studio;
using MagicalLifeAPI.Filing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Sound
{
    public class EffectPlayer
    {
        //public static int Effect_Test1 { get; private set; }
        //public static int Effect_Test2 { get; private set; }

        private readonly FMOD.System FMODSystem;
        private FMOD.Channel Channel;
        private readonly List<FMOD.Sound> Songs;

        public static EffectPlayer Instance { get; private set; }

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        public static void Init()
        {
            string fullPath = System.IO.Path.GetFullPath("fmod64.dll");
            LoadLibrary(fullPath);
            Instance = new EffectPlayer();
            

            //Effect_Test1 = RegisterEffect("Content/SFX/Test1.flac");
            //Effect_Test2 = RegisterEffect("Content/SFX/Test2.flac");

            //Instance.Play(Effect_Test1);
            //System.Threading.Thread.Sleep(1000);
            //Instance.Play(Effect_Test2);
        }

        /// <summary>
        /// Registers the effect with the internal sound system, and returns the numerical id that can be used to play the sound.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static int RegisterEffect(string fullPath)
        {
            return Instance.LoadEffect(fullPath);
        }

        public void Unload()
        {
            this.FMODSystem.release();
        }

        private EffectPlayer()
        {
            FMOD.Factory.System_Create(out this.FMODSystem);

            this.FMODSystem.setDSPBufferSize(1024, 10);
            this.FMODSystem.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)0);

            this.Songs = new List<FMOD.Sound>();
        }

        /// <summary>
        /// Loads an effect.
        /// </summary>
        /// <param name="fullPath">The full file path to the effect. Ex: C:/Programs/myeffect.flac</param>
        /// <returns></returns>
        private int LoadEffect(string fullPath)
        {
            FMOD.RESULT r = this.FMODSystem.createSound(fullPath, FMOD.MODE.DEFAULT, out FMOD.Sound o);
            int c = this.Songs.Count;

            this.Songs.Add(o);

            return c;
        }

        public bool IsPlaying()
        {
            bool isPlaying = false;

            if (this.Channel != null)
            {
                this.Channel.isPlaying(out isPlaying);
            }

            return isPlaying;
        }

        public void Play(int songId)
        {
            Console.WriteLine("Play(" + songId + ")");
            if (songId >= 0 && songId < this.Songs.Count && this.Songs[songId] != null)
            {
                this.FMODSystem.playSound(this.Songs[songId], null, false, out this.Channel);
                UpdateVolume();
                this.Channel.setMode(FMOD.MODE.DEFAULT);
                this.Channel.setLoopCount(-1);
            }
        }

        public void UpdateVolume()
        {
            if (this.Channel != null)
            {
                this.Channel.setVolume(SettingsManager.AudioSettings.Settings.MasterVolume / 100f);
            }
        }

        public void Stop()
        {
            if (IsPlaying())
            {
                this.Channel.stop();
            }
        }
    }
}
