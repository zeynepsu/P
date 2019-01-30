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
            Types.Types_two_phase_commit_1();
            Events.Events_two_phase_commit_1();
            (isSafeMap).Add("Replica", false);
            (isSafeMap).Add("Timer", false);
            (isSafeMap).Add("Client", false);
            (isSafeMap).Add("Coordinator", false);
            (isSafeMap).Add("Main", false);
            (machineDefMap).Add("Replica", "Replica");
            (machineDefMap).Add("Timer", "Timer");
            (machineDefMap).Add("Client", "Client");
            (machineDefMap).Add("Coordinator", "Coordinator");
            (machineDefMap).Add("Main", "Main");
            (createMachineMap).Add("Replica", CreateMachine_Replica);
            (createMachineMap).Add("Timer", CreateMachine_Timer);
            (createMachineMap).Add("Client", CreateMachine_Client);
            (createMachineMap).Add("Coordinator", CreateMachine_Coordinator);
            (createMachineMap).Add("Main", CreateMachine_Main);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("Timer", "Timer");
            (linkMap).Add("Timer", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Coordinator", "Coordinator");
            (_temp).Add("Timer", "Timer");
            (_temp).Add("Replica", "Replica");
            (linkMap).Add("Coordinator", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Replica", "Replica");
            (linkMap).Add("Replica", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Client", "Client");
            (_temp).Add("Coordinator", "Coordinator");
            (_temp).Add("Main", "Main");
            (linkMap).Add("Main", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Client", "Client");
            (linkMap).Add("Client", _temp);
        }
    }
}
