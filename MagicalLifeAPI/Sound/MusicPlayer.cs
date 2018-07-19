using MagicalLifeAPI.Filing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Sound
{
    public class MusicPlayer
    {
        public const int NUM_SONGS = 1;

        public const int SONG_MAIN_MENU = 0;

        private FMOD.System FMODSystem;
        private FMOD.Channel Channel;
        private FMOD.Sound[] Songs;

        private static MusicPlayer _instance;

        private int _current_song_id = -1;

        public static MusicPlayer Instance { get { return _instance; } }

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        public static void Init()
        {
            string fullPath = System.IO.Path.GetFullPath("fmod64.dll");
            LoadLibrary(fullPath);
            _instance = new MusicPlayer();
            _instance.Play(0);
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

            this.Songs = new FMOD.Sound[NUM_SONGS];

            LoadSong(SONG_MAIN_MENU, "MainMenu1");
        }

        private void LoadSong(int songId, string name)
        {
            FMOD.RESULT r = this.FMODSystem.createStream("Content/Music/" + name + ".flac", FMOD.MODE.DEFAULT, out this.Songs[songId]);
            //Console.WriteLine("loading " + songId + ", got result " + r);
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

                if (songId >= 0 && songId < NUM_SONGS && this.Songs[songId] != null)
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
