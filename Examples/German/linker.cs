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
            Types.Types_german_1_unbounded();
            Events.Events_german_1_unbounded();
            (isSafeMap).Add("Client", false);
            (isSafeMap).Add("CPU", false);
            (isSafeMap).Add("Main", false);
            (machineDefMap).Add("Client", "Client");
            (machineDefMap).Add("Main", "Main");
            (machineDefMap).Add("CPU", "CPU");
            (createMachineMap).Add("Client", CreateMachine_Client);
            (createMachineMap).Add("Main", CreateMachine_Main);
            (createMachineMap).Add("CPU", CreateMachine_CPU);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("Client", "Client");
            (_temp).Add("Main", "Main");
            (_temp).Add("CPU", "CPU");
            (linkMap).Add("Main", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("CPU", "CPU");
            (linkMap).Add("CPU", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Client", "Client");
            (linkMap).Add("Client", _temp);
        }
    }
}
