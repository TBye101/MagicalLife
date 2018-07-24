using FMOD.Studio;
using MagicalLifeAPI.Filing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Sound
{
    /// <summary>
    /// Some FMOD related utilities.
    /// </summary>
    public static class FMODUtil
    {
        public static FMOD.Studio.System System;

        public static Bank MainBank;

        public static Bank MainBankStrings;

        public static void Init()
        {
            FMOD.RESULT result7 = FMOD.Studio.System.create(out System);
            System.getLowLevelSystem(out FMOD.System low);
            FMOD.RESULT result11 = low.setSoftwareFormat(0, FMOD.SPEAKERMODE._7POINT1, 0);
            FMOD.RESULT result6 = System.initialize(1, INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
            FMOD.RESULT result = System.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master_Bank.bank", FMOD.Studio.LOAD_BANK_FLAGS.NORMAL, out MainBank);
            FMOD.RESULT result10 = System.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master_Bank.strings.bank", LOAD_BANK_FLAGS.NORMAL, out MainBankStrings);
        }

        public static void Test()
        {


            FMOD.RESULT result9 = MainBank.loadSampleData();
            FMOD.RESULT result5 = MainBank.getEventList(out EventDescription[] someArray);
            someArray.ElementAt(0).getID(out Guid id);
            System.getEventByID(id, out EventDescription eventDescription);
            eventDescription.createInstance(out EventInstance instance);
            FMOD.RESULT result3 = instance.setVolume(1F);
            FMOD.RESULT result2 = instance.start();

            while (true)
            {
                Thread.Sleep(1);

                // Update the playback system
                System.update();
            }
        }
    }
}
