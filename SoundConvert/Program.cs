using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundConvert
{
    class Program
    {
        /*==============================================================================
        Event 3D Example
        Copyright (c), Firelight Technologies Pty, Ltd 2012-2018.

        This example demonstrates how to position events in 3D for spatialization.
        ==============================================================================*/
//# include "fmod_studio.hpp"
//# include "fmod.hpp"
//# include "common.h"

        const int SCREEN_WIDTH = Common.NUM_COLUMNS;
        const int SCREEN_HEIGHT = 16;

        int currentScreenPosition = -1;
        char[] screenBuffer = new char[817];

        //void initializeScreenBuffer();
        //void updateScreenPosition(const FMOD_VECTOR& worldPosition);

        public static void Main()
        {
            void* extraDriverData = null;
            Common_Init(&extraDriverData);

            MagicalLifeAPI.Sound.FMOD.Studio.System system = null;
            MagicalLifeAPI.Sound.FMOD.Studio.System.create(out system);

            // The example Studio project is authored for 5.1 sound, so set up the system output mode to match
            MagicalLifeAPI.Sound.FMOD.System lowLevelSystem = null;
            system.getLowLevelSystem(out lowLevelSystem);
            lowLevelSystem.setSoftwareFormat(0, MagicalLifeAPI.Sound.FMOD.SPEAKERMODE._5POINT1, 0);

            system.initialize(1024, MagicalLifeAPI.Sound.FMOD.Studio.INITFLAGS.NORMAL, MagicalLifeAPI.Sound.FMOD.INITFLAGS.NORMAL, extraDriverData);

            MagicalLifeAPI.Sound.FMOD.Studio.Bank masterBank = null;
            ERRCHECK(system->loadBankFile(Common_MediaPath("Master Bank.bank"), FMOD_STUDIO_LOAD_BANK_NORMAL, &masterBank));

            MagicalLifeAPI.Sound.FMOD.Studio.Bank stringsBank = null;
            ERRCHECK(system->loadBankFile(Common_MediaPath("Master Bank.strings.bank"), FMOD_STUDIO_LOAD_BANK_NORMAL, &stringsBank));

            MagicalLifeAPI.Sound.FMOD.Studio.Bank vehiclesBank = null;
            ERRCHECK(system->loadBankFile(Common_MediaPath("Vehicles.bank"), FMOD_STUDIO_LOAD_BANK_NORMAL, &vehiclesBank));

            MagicalLifeAPI.Sound.FMOD.Studio.EventDescription eventDescription = null;
            ERRCHECK(system->getEvent("event:/Vehicles/Ride-on Mower", &eventDescription));

            MagicalLifeAPI.Sound.FMOD.Studio.EventInstance eventInstance = null;
            ERRCHECK(eventDescription->createInstance(&eventInstance));

            ERRCHECK(eventInstance->setParameterValue("RPM", 650.0f));
            ERRCHECK(eventInstance->start());

            // Position the listener at the origin ?CHECK THIS
            MagicalLifeAPI.Sound.FMOD.Studio._3D_ATTRIBUTES attributes = new MagicalLifeAPI.Sound.FMOD.Studio._3D_ATTRIBUTES();
            attributes.forward.z = 1.0f;
            attributes.up.y = 1.0f;
            system.setListenerAttributes(0, attributes);

            // Position the event 2 units in front of the listener
            attributes.position.z = 2.0f;
            eventInstance.set3DAttributes(attributes);

            initializeScreenBuffer();

            do
            {
                Common_Update();

                if (Common_BtnDown(BTN_LEFT))
                {
                    attributes.position.x -= 1.0f;
                    ERRCHECK(eventInstance->set3DAttributes(&attributes));
                }

                if (Common_BtnDown(BTN_RIGHT))
                {
                    attributes.position.x += 1.0f;
                    ERRCHECK(eventInstance->set3DAttributes(&attributes));
                }

                if (Common_BtnDown(BTN_UP))
                {
                    attributes.position.z += 1.0f;
                    ERRCHECK(eventInstance->set3DAttributes(&attributes));
                }

                if (Common_BtnDown(BTN_DOWN))
                {
                    attributes.position.z -= 1.0f;
                    ERRCHECK(eventInstance->set3DAttributes(&attributes));
                }

                ERRCHECK(system->update());

                updateScreenPosition(attributes.position);
                Common_Draw("==================================================");
                Common_Draw("Event 3D Example.");
                Common_Draw("Copyright (c) Firelight Technologies 2012-2018.");
                Common_Draw("==================================================");
                Common_Draw(screenBuffer);
                Common_Draw("Use the arrow keys (%s, %s, %s, %s) to control the event position",
                    Common_BtnStr(BTN_LEFT), Common_BtnStr(BTN_RIGHT), Common_BtnStr(BTN_UP), Common_BtnStr(BTN_DOWN));
                Common_Draw("Press %s to quit", Common_BtnStr(BTN_QUIT));

                Common_Sleep(50);
            } while (!Common_BtnPress(BTN_QUIT));

            ERRCHECK(system->release());

            Common_Close();

            return 0;
        }

        void initializeScreenBuffer()
        {
            memset(screenBuffer, ' ', sizeof(screenBuffer));

            int idx = SCREEN_WIDTH;
            for (int i = 0; i < SCREEN_HEIGHT; ++i)
            {
                screenBuffer[idx] = '\n';
                idx += SCREEN_WIDTH + 1;
            }

            screenBuffer[(SCREEN_WIDTH + 1) * SCREEN_HEIGHT] = '\0';
        }

        int getCharacterIndex(const FMOD_VECTOR& position)
{
    int row = static_cast<int>(-position.z + (SCREEN_HEIGHT / 2));
        int col = static_cast<int>(position.x + (SCREEN_WIDTH / 2));
    
    if (0 < row && row<SCREEN_HEIGHT && 0 < col && col<SCREEN_WIDTH)
    {
        return (row* (SCREEN_WIDTH + 1)) + col;
    }
    
    return -1;
}

void updateScreenPosition(const FMOD_VECTOR& eventPosition)
{
    if (currentScreenPosition != -1)
    {
        screenBuffer[currentScreenPosition] = ' ';
        currentScreenPosition = -1;
    }

    FMOD_VECTOR origin = { 0 };
    int idx = getCharacterIndex(origin);
    screenBuffer[idx] = '^';

    idx = getCharacterIndex(eventPosition);
    if (idx != -1)
    {
        screenBuffer[idx] = 'o';
        currentScreenPosition = idx;
    }
}

    }
}
