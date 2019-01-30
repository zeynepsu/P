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
            Types.Types_osr();
            Events.Events_osr();
            (isSafeMap).Add("OSRDriver", false);
            (isSafeMap).Add("Main", false);
            (isSafeMap).Add("LED", false);
            (isSafeMap).Add("Switch", false);
            (isSafeMap).Add("Timer", false);
            (machineDefMap).Add("Timer", "Timer");
            (machineDefMap).Add("OSRDriver", "OSRDriver");
            (machineDefMap).Add("Main", "Main");
            (machineDefMap).Add("LED", "LED");
            (machineDefMap).Add("Switch", "Switch");
            (createMachineMap).Add("Timer", CreateMachine_Timer);
            (createMachineMap).Add("OSRDriver", CreateMachine_OSRDriver);
            (createMachineMap).Add("Main", CreateMachine_Main);
            (createMachineMap).Add("LED", CreateMachine_LED);
            (createMachineMap).Add("Switch", CreateMachine_Switch);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("OSRDriver", "OSRDriver");
            (_temp).Add("LED", "LED");
            (_temp).Add("Timer", "Timer");
            (_temp).Add("Switch", "Switch");
            (linkMap).Add("OSRDriver", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Main", "Main");
            (_temp).Add("OSRDriver", "OSRDriver");
            (linkMap).Add("Main", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Switch", "Switch");
            (linkMap).Add("Switch", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Timer", "Timer");
            (linkMap).Add("Timer", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("LED", "LED");
            (linkMap).Add("LED", _temp);
        }
    }
}
