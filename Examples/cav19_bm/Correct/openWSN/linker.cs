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
            Types.Types_openwsn1();
            Events.Events_openwsn1();
            (isSafeMap).Add("OpenWSN_Mote", false);
            (isSafeMap).Add("SlotTimerMachine", false);
            (isSafeMap).Add("Main", false);
            (machineDefMap).Add("OpenWSN_Mote", "OpenWSN_Mote");
            (machineDefMap).Add("SlotTimerMachine", "SlotTimerMachine");
            (machineDefMap).Add("Main", "Main");
            (createMachineMap).Add("OpenWSN_Mote", CreateMachine_OpenWSN_Mote);
            (createMachineMap).Add("SlotTimerMachine", CreateMachine_SlotTimerMachine);
            (createMachineMap).Add("Main", CreateMachine_Main);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("SlotTimerMachine", "SlotTimerMachine");
            (linkMap).Add("SlotTimerMachine", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("OpenWSN_Mote", "OpenWSN_Mote");
            (linkMap).Add("OpenWSN_Mote", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("OpenWSN_Mote", "OpenWSN_Mote");
            (_temp).Add("SlotTimerMachine", "SlotTimerMachine");
            (_temp).Add("Main", "Main");
            (linkMap).Add("Main", _temp);
        }
    }
}
