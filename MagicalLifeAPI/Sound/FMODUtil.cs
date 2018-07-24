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
        public static void Test()
        {
            FMOD.RESULT result7 = FMOD.Studio.System.create(out FMOD.Studio.System a);
            a.getLowLevelSystem(out FMOD.System low);
            FMOD.RESULT result11 = low.setSoftwareFormat(0, FMOD.SPEAKERMODE._7POINT1, 0);
            FMOD.RESULT result6 = a.initialize(1, INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
            FMOD.RESULT result = a.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master_Bank.bank", FMOD.Studio.LOAD_BANK_FLAGS.NORMAL, out Bank testBank);
            FMOD.RESULT result10 = a.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master_Bank.strings.bank", LOAD_BANK_FLAGS.NORMAL, out Bank bank);

            FMOD.RESULT result9 = testBank.loadSampleData();
            FMOD.RESULT result5 = testBank.getEventList(out EventDescription[] someArray);
            someArray.ElementAt(0).getID(out Guid id);
            a.getEventByID(id, out EventDescription eventDescription);
            eventDescription.createInstance(out EventInstance instance);
            //FMOD.RESULT result12 = someArray[0].setCallback(testmethod, EVENT_CALLBACK_TYPE.STARTED);
            //FMOD.RESULT result8 = someArray[0].loadSampleData();
            //FMOD.RESULT result4 = someArray[0].createInstance(out EventInstance instance);
            FMOD.RESULT result3 = instance.setVolume(1F);
            FMOD.RESULT result2 = instance.start();
            //FMOD.Studio.EVENT_CALLBACK

            while (true)
            {
                Thread.Sleep(1);

                // Update the playback system
                a.update();
            }
        }

        //private static FMOD.RESULT testmethod(FMOD.Studio.EVENT_CALLBACK_TYPE type, IntPtr eventInstance, IntPtr parameters)
        //{
        //    GCHandle handle = (GCHandle)eventInstance;
        //    object target = handle.Target;
        //    EventInstance instance = (EventInstance)target;

        //    switch (type)
        //    {
        //        case EVENT_CALLBACK_TYPE.STARTED:
        //            instance.setVolume(1F);
        //            return instance.start();
        //    }
        //    return FMOD.RESULT.ERR_UNIMPLEMENTED;
        //}
    }
}
