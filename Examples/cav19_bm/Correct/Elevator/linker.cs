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
            CreateMainMachine("Main");
        }

        public override StateImpl MakeSkeleton()
        {
            return new Application();
        }

        static Application()
        {
            Types.Types_elevator();
            Events.Events_elevator();
            (isSafeMap).Add("Elevator", false);
            (isSafeMap).Add("Timer", false);
            (isSafeMap).Add("Door", false);
            (isSafeMap).Add("Main", false);
            (machineDefMap).Add("Elevator", "Elevator");
            (machineDefMap).Add("Timer", "Timer");
            (machineDefMap).Add("Door", "Door");
            (machineDefMap).Add("Main", "Main");
            (createMachineMap).Add("Elevator", CreateMachine_Elevator);
            (createMachineMap).Add("Timer", CreateMachine_Timer);
            (createMachineMap).Add("Door", CreateMachine_Door);
            (createMachineMap).Add("Main", CreateMachine_Main);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("Door", "Door");
            (linkMap).Add("Door", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Elevator", "Elevator");
            (_temp).Add("Door", "Door");
            (_temp).Add("Timer", "Timer");
            (linkMap).Add("Elevator", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Elevator", "Elevator");
            (_temp).Add("Main", "Main");
            (linkMap).Add("Main", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Timer", "Timer");
            (linkMap).Add("Timer", _temp);
        }
    }
}
