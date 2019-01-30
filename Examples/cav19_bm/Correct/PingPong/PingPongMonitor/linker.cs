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
            CreateSpecMachine("M");
            CreateMainMachine("Main");
        }

        public override StateImpl MakeSkeleton()
        {
            return new Application();
        }

        static Application()
        {
            Types.Types_pingpongmonitor();
            Events.Events_pingpongmonitor();
            (isSafeMap).Add("M", false);
            (isSafeMap).Add("Main", false);
            (isSafeMap).Add("PONG", false);
            (machineDefMap).Add("M", "M");
            (machineDefMap).Add("Main", "Main");
            (machineDefMap).Add("PONG", "PONG");
            (createSpecMap).Add("M", CreateSpecMachine_M);
            (createMachineMap).Add("Main", CreateMachine_Main);
            (createMachineMap).Add("PONG", CreateMachine_PONG);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            (specMachineMap).Add("M", new List<string>()
            {"Main", "M", "PONG"});
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("Main", "Main");
            (_temp).Add("PONG", "PONG");
            (linkMap).Add("Main", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("M", "M");
            (linkMap).Add("M", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("PONG", "PONG");
            (linkMap).Add("PONG", _temp);
        }
    }
}
