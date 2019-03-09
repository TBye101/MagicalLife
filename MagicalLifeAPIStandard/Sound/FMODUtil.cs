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

        internal static FMOD.Studio.System System
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

        internal static void Update()
        {
            Point2D camera = RenderInfo.GetCameraCenter();

            _3D_ATTRIBUTES attributes = new _3D_ATTRIBUTES();
            attributes.forward.z = 1.0f;
            attributes.up.y = 1.0f;
            attributes.position.x = camera.X;
            attributes.position.y = camera.Y;

            System.setListenerAttributes(0, attributes);

            System.update();
        }

        internal static void Init()
        {
            FMOD.Studio.System.create(out _System);
            _System.getLowLevelSystem(out FMOD.System low);

            low.setSoftwareFormat(0, FMOD.SPEAKERMODE._5POINT1, 0);
            _System.initialize(64, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
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
            _System.getEvent(eventPath, out EventDescription _event);
            _event.createInstance(out EventInstance instance);
            instance.start();
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

        /// <param name="screenPosition">The position on screen to play at. This is not adjusted for where the user is looking.</param>
        public static void RaiseEvent(string eventPath, string parameterName, int value, Point2D screenPosition)
        {
            _System.getEvent(eventPath, out EventDescription _event);
            _event.createInstance(out EventInstance instance);

            if (parameterName != string.Empty)
            {
                instance.setParameterValue(parameterName, value);
            }

            _3D_ATTRIBUTES attributes = new _3D_ATTRIBUTES();
            attributes.forward.y = 1.0f;
            attributes.up.z = 1.0f;
            attributes.position.x = screenPosition.X;
            attributes.position.z = screenPosition.Y;
            //attributes.position.y = -200;
            instance.setProperty(EVENT_PROPERTY.MINIMUM_DISTANCE, 300);
            instance.setProperty(EVENT_PROPERTY.MAXIMUM_DISTANCE, 1600);

            instance.set3DAttributes(attributes);
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