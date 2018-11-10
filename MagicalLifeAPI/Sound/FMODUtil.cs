using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Sound.FMOD.Studio;
using System;

namespace MagicalLifeAPI.Sound
{
    /// <summary>
    /// Some FMOD related utilities.
    /// </summary>
    public static class FMODUtil
    {
        private static FMOD.Studio.System _System;

        public static FMOD.Studio.System System
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

        private static EventDescription[] MainEvents;

        public static void Update()
        {
            _3D_ATTRIBUTES atts = new _3D_ATTRIBUTES();
            atts.forward.x = 1;
            atts.forward.y = 1;
            atts.forward.z = 0;

            Point2D camera = RenderInfo.GetCameraCenter();
            atts.position.x = camera.X;
            atts.position.y = camera.Y;
            atts.position.z = 0;

            atts.up.x = 1;
            atts.up.y = 1;
            atts.up.z = -1;

            System.setListenerAttributes(0, atts);
            System.update();
        }

        public static void Init()
        {
            FMOD.Studio.System.create(out _System);
            _System.getLowLevelSystem(out FMOD.System low);

            //low.setOutput(FMOD.OUTPUTTYPE.WINSONIC);
            //low.createDSPByType(FMOD.DSP_TYPE.MIXER, out FMOD.DSP dsp);

            low.setSoftwareFormat(0, FMOD.SPEAKERMODE._7POINT1, 0);
            _System.initialize(1, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
            _System.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master_Bank.bank", FMOD.Studio.LOAD_BANK_FLAGS.NORMAL, out Bank MainBank);
            _System.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master_Bank.strings.bank", LOAD_BANK_FLAGS.NORMAL, out Bank MainBankStrings);
            MainBank.getEventList(out MainEvents);
            DumpEventInformation();
        }

        /// <summary>
        /// Raises the specified event.
        /// </summary>
        /// <param name="eventPath">The path to the event in a bank file. Ex: event:/Footsteps</param>
        public static void RaiseEvent(string eventPath)
        {
            //_System.getEvent(eventPath, out EventDescription _event);
            //_event.createInstance(out EventInstance instance);
            //instance.start();
        }

        /// <summary>
        /// Raises the specified event and passes <paramref name="value"/> to a parameter with a name of <paramref name="parameterName"/>.
        /// </summary>
        /// <param name="eventPath">The path to the event in a bank file. Ex: event:/Footsteps</param>
        /// <param name="parameterName">The name of the parameter to pass <paramref name="value"/> to.</param>
        /// <param name="value">The value to be passed into the event.</param>
        public static void RaiseEvent(string eventPath, string parameterName, int value)
        {
            _System.getEvent(eventPath, out EventDescription _event);
            _event.createInstance(out EventInstance instance);
            instance.setParameterValue(parameterName, value);
            instance.start();
        }

        public static void RaiseEvent(string eventPath, string parameterName, int value, Point2D screenPosition)
        {
            //RaiseEvent(eventPath, parameterName, value);
            _System.getEvent(eventPath, out EventDescription _event);
            _event.createInstance(out EventInstance instance);
            instance.setParameterValue(parameterName, value);

            _3D_ATTRIBUTES D3 = new _3D_ATTRIBUTES();

            FMOD.VECTOR forward = new FMOD.VECTOR();
            forward.x = 1;
            forward.y = 1;
            forward.z = 0;

            FMOD.VECTOR up = new FMOD.VECTOR();
            up.x = 1;
            up.y = 1;
            up.z = -1;

            FMOD.VECTOR position = new FMOD.VECTOR();
            position.x = screenPosition.X;
            position.y = screenPosition.Y;
            position.z = 0;

            D3.forward = forward;
            D3.up = up;
            D3.position = position;

            instance.set3DAttributes(D3);
            instance.start();
        }

        public static void Test()
        {
            //Temp method
        }

        public static void DumpEventInformation()
        {
            MasterLog.DebugWriteLine("Dumping Sound Events");
            foreach (EventDescription item in MainEvents)
            {
                item.getPath(out string path);
                MasterLog.DebugWriteLine(path);
                item.is3D(out bool is3D);
                MasterLog.DebugWriteLine("Is 3D: " + is3D.ToString());

                item.getParameterCount(out int length);

                for (int i = 0; i < length; i++)
                {
                    item.getParameterByIndex(i, out PARAMETER_DESCRIPTION parameter);
                    MasterLog.DebugWriteLine("Parameter name: " + parameter.name);
                    MasterLog.DebugWriteLine("Parameter type: " + parameter.type);
                    MasterLog.DebugWriteLine("Parameter index: " + parameter.index);
                    MasterLog.DebugWriteLine("Parameter default value: " + parameter.defaultvalue);
                    MasterLog.DebugWriteLine("Parameter minimum: " + parameter.minimum);
                    MasterLog.DebugWriteLine("Parameter maximum: " + parameter.maximum);
                }
            }
            MasterLog.DebugWriteLine("End of Sound Events");
        }
    }
}