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
            Types.Types_tokenring();
            Events.Events_tokenring();
            (isSafeMap).Add("Node", false);
            (isSafeMap).Add("Main", false);
            (machineDefMap).Add("Node", "Node");
            (machineDefMap).Add("Main", "Main");
            (createMachineMap).Add("Node", CreateMachine_Node);
            (createMachineMap).Add("Main", CreateMachine_Main);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("Node", "Node");
            (_temp).Add("Main", "Main");
            (linkMap).Add("Main", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Node", "Node");
            (linkMap).Add("Node", _temp);
        }
    }
}
