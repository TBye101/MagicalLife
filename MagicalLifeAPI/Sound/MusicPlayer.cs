using MagicalLifeAPI.Filing;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MagicalLifeAPI.Sound
{
    public class MusicPlayer
    {
        public static int SONG_MAIN_MENU { get; private set; }

        private readonly FMOD.System FMODSystem;
        private FMOD.Channel Channel;
        private readonly List<FMOD.Sound> Songs = new List<FMOD.Sound>();
        private int _current_song_id = -1;

        public static MusicPlayer Instance { get; private set; }

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        public static void Init()
        {
            string fullPath = System.IO.Path.GetFullPath("fmod64.dll");
            LoadLibrary(fullPath);
            Instance = new MusicPlayer();

            MusicPlayer.SONG_MAIN_MENU = Instance.LoadSong("MainMenu1");
            //Instance.Play(SONG_MAIN_MENU);
            FMODUtil.Init();
            FMODUtil.Test();
        }

        public void Unload()
        {
            this.FMODSystem.release();
        }

        private MusicPlayer()
        {
            FMOD.Factory.System_Create(out this.FMODSystem);

            this.FMODSystem.setDSPBufferSize(1024, 10);
            this.FMODSystem.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)0);
        }

        private int LoadSong(string name)
        {
            FMOD.RESULT r = this.FMODSystem.createStream("Content/Music/" + name + ".flac", FMOD.MODE.DEFAULT, out FMOD.Sound s);

            int c = this.Songs.Count;
            this.Songs.Add(s);

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

            if (this._current_song_id != songId)
            {
                Stop();

                if (songId >= 0 && songId < this.Songs.Count && this.Songs[songId] != null)
                {
                    this.FMODSystem.playSound(this.Songs[songId], null, false, out this.Channel);
                    UpdateVolume();
                    this.Channel.setMode(FMOD.MODE.LOOP_NORMAL);
                    this.Channel.setLoopCount(-1);

                    this._current_song_id = songId;
                }
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

            this._current_song_id = -1;
        }
    }
}