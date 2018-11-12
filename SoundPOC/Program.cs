using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Sound.FMOD.Studio;
using System;

namespace SoundPOC
{
    class Program
    {
        static ProtoArray<char> array = new ProtoArray<char>(9, 9);

        private static MagicalLifeAPI.Sound.FMOD.Studio.System _System;
        private static EventDescription[] MainEvents;

        static int x = 6;
        static int y = 5;
        private static EventInstance soundInstance;

        public static MagicalLifeAPI.Sound.FMOD.Studio.System System
        {
            get
            {
                return _System;
            }
            set
            {
                _System = value;
            }
        }

        public static void Main(string[] args)
        {
            Setup();

            char input;
            while (true)
            {
                input = (char)Console.Read();
                Move(input);
                Render();
                soundInstance.start();
                System.update();
            }
        }

        private static void Render()
        {
            int xMax = 9;
            int yMax = 9;
            int x = 0;
            int y = 0;

            while (x != xMax)
            {
                while (y != yMax)
                {
                    Console.Write(array[x, y]);
                    y++;
                }

                y = 0;
                x++;
                Console.Write("\r\n");
            }
        }

        private static void Move(char direction)
        {
            //Remove event position
            array[x, y] = ' ';
            soundInstance.get3DAttributes(out _3D_ATTRIBUTES atts);
            
            switch (direction)
            {
                case 'w':
                    x--;
                    atts.position.x--;
                    break;
                case 'd':
                    y++;
                    atts.position.z++;
                    break;
                case 'a':
                    y--;
                    atts.position.z--;
                    break;
                case 's':
                    x++;
                    atts.position.x++;
                    break;
            }
            array[x, y] = 'x';
            array[5, 5] = 'o';
            soundInstance.set3DAttributes(atts);
        }

        private static void Setup()
        {
            array[5, 5] = 'o';//listener
            array[6, 5] = 'x';//event

            MagicalLifeAPI.Sound.FMOD.Studio.System.create(out _System);
            _System.getLowLevelSystem(out MagicalLifeAPI.Sound.FMOD.System low);

            //low.setOutput(FMOD.OUTPUTTYPE.WINSONIC);
            //low.createDSPByType(FMOD.DSP_TYPE.MIXER, out FMOD.DSP dsp);

            low.setSoftwareFormat(0, MagicalLifeAPI.Sound.FMOD.SPEAKERMODE._5POINT1, 0);
            _System.initialize(1, MagicalLifeAPI.Sound.FMOD.Studio.INITFLAGS.NORMAL, MagicalLifeAPI.Sound.FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
            _System.loadBankFile("D:/Git Repositories/MagicalLife/SoundPOC/bin/Debug" + "/Content/Banks/Master_Bank.bank", MagicalLifeAPI.Sound.FMOD.Studio.LOAD_BANK_FLAGS.NORMAL, out Bank MainBank);
            _System.loadBankFile("D:/Git Repositories/MagicalLife/SoundPOC/bin/Debug" + "/Content/Banks/Master_Bank.strings.bank", LOAD_BANK_FLAGS.NORMAL, out Bank MainBankStrings);
            MainBank.getEventList(out MainEvents);

            // Position the listener at the origin
            _3D_ATTRIBUTES attributes = new _3D_ATTRIBUTES();
            attributes.forward.z = 1.0f;
            attributes.up.y = 1.0f;
            System.setListenerAttributes(0, attributes);
            //ERRCHECK(system->setListenerAttributes(0, &attributes));

            // Position the event 2 units in front of the listener
            //attributes.position.z = 2.0f;

            //FMOD::Studio::EventDescription* eventDescription = NULL;
            //ERRCHECK(system->getEvent("event:/Vehicles/Ride-on Mower", &eventDescription));

            //FMOD::Studio::EventInstance* eventInstance = NULL;
            //ERRCHECK(eventDescription->createInstance(&eventInstance));

            MainEvents[0].createInstance(out soundInstance);

            _3D_ATTRIBUTES atts = new _3D_ATTRIBUTES();
            atts.forward.z = 1.0f;
            atts.up.y = 1.0f;
            //ERRCHECK(system->setListenerAttributes(0, &attributes));

            // Position the event 2 units in front of the listener
            attributes.position.z = 2.0f;
            attributes.position.x = 1;

            //ERRCHECK(eventInstance->set3DAttributes(&attributes));
            soundInstance.set3DAttributes(atts);

        }
    }
}
