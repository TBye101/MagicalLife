using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MLAPI.Filing;

namespace MLAPI.Sound
{
    public class MusicPlayer
    {
        public static int SongMainMenu { get; private set; }

        private readonly FMOD.System FmodSystem;
        private FMOD.Channel Channel;
        private readonly List<FMOD.Sound> Songs = new List<FMOD.Sound>();
        private int CurrentSongId = -1;

        public static MusicPlayer Instance { get; private set; }

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        public static void Init()
        {
            string fullPath = System.IO.Path.GetFullPath("fmod64.dll");
            LoadLibrary(fullPath);
            Instance = new MusicPlayer();

            MusicPlayer.SongMainMenu = Instance.LoadSong("MainMenu1");
            //Instance.Play(SONG_MAIN_MENU);
            FmodUtil.Init();
        }

        public void Unload()
        {
            this.FmodSystem.release();
        }

        private MusicPlayer()
        {
            FMOD.Factory.System_Create(out this.FmodSystem);

            this.FmodSystem.setDSPBufferSize(1024, 10);
            this.FmodSystem.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)0);
        }

        private int LoadSong(string name)
        {
            FMOD.RESULT r = this.FmodSystem.createStream("Content/Music/" + name + ".flac", FMOD.MODE.DEFAULT, out FMOD.Sound s);

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

            if (this.CurrentSongId != songId)
            {
                this.Stop();

                if (songId >= 0 && songId < this.Songs.Count && this.Songs[songId] != null)
                {
                    this.FmodSystem.playSound(this.Songs[songId], null, false, out this.Channel);
                    this.UpdateVolume();
                    this.Channel.setMode(FMOD.MODE.LOOP_NORMAL);
                    this.Channel.setLoopCount(-1);

                    this.CurrentSongId = songId;
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
            if (this.IsPlaying())
            {
                this.Channel.stop();
            }

            this.CurrentSongId = -1;
        }
    }
}