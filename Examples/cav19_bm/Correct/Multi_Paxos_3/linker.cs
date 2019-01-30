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
            CreateSpecMachine("ValmachineityCheck");
            CreateSpecMachine("BasicPaxosInvariant_P2b");
            CreateMainMachine("Main");
        }

        public override StateImpl MakeSkeleton()
        {
            return new Application();
        }

        static Application()
        {
            Types.Types_multi_paxos_3();
            Events.Events_multi_paxos_3();
            (isSafeMap).Add("Main", false);
            (isSafeMap).Add("Client", false);
            (isSafeMap).Add("PaxosNode", false);
            (isSafeMap).Add("LeaderElection", false);
            (isSafeMap).Add("Timer", false);
            (isSafeMap).Add("ValmachineityCheck", false);
            (isSafeMap).Add("BasicPaxosInvariant_P2b", false);
            (machineDefMap).Add("ValmachineityCheck", "ValmachineityCheck");
            (machineDefMap).Add("Main", "Main");
            (machineDefMap).Add("Client", "Client");
            (machineDefMap).Add("PaxosNode", "PaxosNode");
            (machineDefMap).Add("LeaderElection", "LeaderElection");
            (machineDefMap).Add("Timer", "Timer");
            (machineDefMap).Add("BasicPaxosInvariant_P2b", "BasicPaxosInvariant_P2b");
            (createSpecMap).Add("ValmachineityCheck", CreateSpecMachine_ValmachineityCheck);
            (createSpecMap).Add("BasicPaxosInvariant_P2b", CreateSpecMachine_BasicPaxosInvariant_P2b);
            (createMachineMap).Add("Main", CreateMachine_Main);
            (createMachineMap).Add("Client", CreateMachine_Client);
            (createMachineMap).Add("PaxosNode", CreateMachine_PaxosNode);
            (createMachineMap).Add("LeaderElection", CreateMachine_LeaderElection);
            (createMachineMap).Add("Timer", CreateMachine_Timer);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            (specMachineMap).Add("ValmachineityCheck", new List<string>()
            {"PaxosNode", "LeaderElection", "Timer", "ValmachineityCheck", "Main", "BasicPaxosInvariant_P2b", "Client"});
            (specMachineMap).Add("BasicPaxosInvariant_P2b", new List<string>()
            {"PaxosNode", "LeaderElection", "Timer", "ValmachineityCheck", "Main", "BasicPaxosInvariant_P2b", "Client"});
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("Main", "Main");
            (_temp).Add("Client", "Client");
            (_temp).Add("PaxosNode", "PaxosNode");
            (linkMap).Add("Main", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Client", "Client");
            (linkMap).Add("Client", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("PaxosNode", "PaxosNode");
            (_temp).Add("Timer", "Timer");
            (_temp).Add("LeaderElection", "LeaderElection");
            (linkMap).Add("PaxosNode", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("LeaderElection", "LeaderElection");
            (linkMap).Add("LeaderElection", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Timer", "Timer");
            (linkMap).Add("Timer", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("ValmachineityCheck", "ValmachineityCheck");
            (linkMap).Add("ValmachineityCheck", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("BasicPaxosInvariant_P2b", "BasicPaxosInvariant_P2b");
            (linkMap).Add("BasicPaxosInvariant_P2b", _temp);
        }
    }
}
