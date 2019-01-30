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
            Types.Types_maxinstances_2();
            Events.Events_maxinstances_2();
            (isSafeMap).Add("Ghost", false);
            (isSafeMap).Add("Main", false);
            (machineDefMap).Add("Ghost", "Ghost");
            (machineDefMap).Add("Main", "Main");
            (createMachineMap).Add("Ghost", CreateMachine_Ghost);
            (createMachineMap).Add("Main", CreateMachine_Main);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("Main", "Main");
            (_temp).Add("Ghost", "Ghost");
            (linkMap).Add("Main", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Ghost", "Ghost");
            (linkMap).Add("Ghost", _temp);
        }
    }
}
