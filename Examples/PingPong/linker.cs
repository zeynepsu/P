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
            Types.Types_pingpong();
            Events.Events_pingpong();
            (isSafeMap).Add("PONG", false);
            (isSafeMap).Add("Main", false);
            (machineDefMap).Add("PONG", "PONG");
            (machineDefMap).Add("Main", "Main");
            (createMachineMap).Add("PONG", CreateMachine_PONG);
            (createMachineMap).Add("Main", CreateMachine_Main);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("PONG", "PONG");
            (linkMap).Add("PONG", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Main", "Main");
            (_temp).Add("PONG", "PONG");
            (linkMap).Add("Main", _temp);
        }
    }
}
