#pragma warning disable CS0162, CS0164, CS0168
using P.Runtime;
using System;
using System.Collections.Generic;

namespace P.Program
{
    using P.Runtime;
    using System;
    using System.Collections.Generic;

    public partial class Application : StateImpl
    {
        public partial class Events
        {
            public static PrtEventValue halt = PrtValue.halt;
            public static PrtEventValue @null = PrtValue.@null;
        }

        public Application(): base ()
        {
        }

        public Application(bool initialize): base ()
        {
            CreateMainMachine("Main2");
        }

        public override StateImpl MakeSkeleton()
        {
            return new Application();
        }

        static Application()
        {
            Types.Types_coffeemachine();
            Events.Events_coffeemachine();
            (isSafeMap).Add("CoffeeMakerMachine", false);
            (isSafeMap).Add("CoffeeMakerControllerMachine", false);
            (isSafeMap).Add("Timer", false);
            (isSafeMap).Add("DoorMachine", false);
            (isSafeMap).Add("Main2", false);
            (machineDefMap).Add("CoffeeMakerControllerMachine", "CoffeeMakerControllerMachine");
            (machineDefMap).Add("Timer", "Timer");
            (machineDefMap).Add("CoffeeMakerMachine", "CoffeeMakerMachine");
            (machineDefMap).Add("Main2", "Main2");
            (machineDefMap).Add("DoorMachine", "DoorMachine");
            (createMachineMap).Add("CoffeeMakerControllerMachine", CreateMachine_CoffeeMakerControllerMachine);
            (createMachineMap).Add("Timer", CreateMachine_Timer);
            (createMachineMap).Add("CoffeeMakerMachine", CreateMachine_CoffeeMakerMachine);
            (createMachineMap).Add("Main2", CreateMachine_Main2);
            (createMachineMap).Add("DoorMachine", CreateMachine_DoorMachine);
            interfaceMap["CoffeeMakerControllerMachine"] = new List<PrtEventValue>()
            {Events.event_CANCEL_FAILURE, Events.event_CANCEL_SUCCESS, Events.event_TIMEOUT, Events.event_eDoorClosed, Events.event_eDoorOpened, Events.event_eDumpComplete, Events.event_eEspressoButtonPressed, Events.event_eEspressoComplete, Events.event_eGrindComplete, Events.event_eInit, Events.event_eNoBeans, Events.event_eNoWater, Events.event_eReadyDoorOpened, Events.event_eSteamerButtonOff, Events.event_eSteamerButtonOn, Events.event_eTemperatureReached, Events.event_eUnknownError};
            interfaceMap["Timer"] = new List<PrtEventValue>()
            {Events.event_START, Events.event_CANCEL};
            interfaceMap["CoffeeMakerMachine"] = new List<PrtEventValue>()
            {Events.event_eBeginHeating, Events.event_eGrindBeans, Events.event_eDumpGrinds, Events.event_eStartEspresso, Events.event_eStartSteamer, Events.event_eStopSteamer};
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            ((PrtInterfaceType)(Types.type_CoffeeMakerControllerMachine)).permissions = interfaceMap["CoffeeMakerControllerMachine"];
            ((PrtInterfaceType)(Types.type_Timer)).permissions = interfaceMap["Timer"];
            ((PrtInterfaceType)(Types.type_CoffeeMakerMachine)).permissions = interfaceMap["CoffeeMakerMachine"];
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("CoffeeMakerMachine", "CoffeeMakerMachine");
            (_temp).Add("CoffeeMakerControllerMachine", "CoffeeMakerControllerMachine");
            (_temp).Add("DoorMachine", "DoorMachine");
            (linkMap).Add("Main2", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Timer", "Timer");
            (linkMap).Add("CoffeeMakerControllerMachine", _temp);
        }
    }
}
