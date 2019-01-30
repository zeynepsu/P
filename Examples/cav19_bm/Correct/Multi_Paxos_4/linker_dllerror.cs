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
            Types.Types_multi_paxos_4();
            Events.Events_multi_paxos_4();
            (isSafeMap).Add("BasicPaxosInvariant_P2b", false);
            (isSafeMap).Add("PaxosNode", false);
            (isSafeMap).Add("Timer", false);
            (isSafeMap).Add("LeaderElection", false);
            (isSafeMap).Add("ValmachineityCheck", false);
            (isSafeMap).Add("Client", false);
            (isSafeMap).Add("Main", false);
            (machineDefMap).Add("BasicPaxosInvariant_P2b", "BasicPaxosInvariant_P2b");
            (machineDefMap).Add("PaxosNode", "PaxosNode");
            (machineDefMap).Add("Timer", "Timer");
            (machineDefMap).Add("LeaderElection", "LeaderElection");
            (machineDefMap).Add("ValmachineityCheck", "ValmachineityCheck");
            (machineDefMap).Add("Client", "Client");
            (machineDefMap).Add("Main", "Main");
            (createSpecMap).Add("BasicPaxosInvariant_P2b", CreateSpecMachine_BasicPaxosInvariant_P2b);
            (createSpecMap).Add("ValmachineityCheck", CreateSpecMachine_ValmachineityCheck);
            (createMachineMap).Add("PaxosNode", CreateMachine_PaxosNode);
            (createMachineMap).Add("Timer", CreateMachine_Timer);
            (createMachineMap).Add("LeaderElection", CreateMachine_LeaderElection);
            (createMachineMap).Add("Client", CreateMachine_Client);
            (createMachineMap).Add("Main", CreateMachine_Main);
            visibleEvents = new List<string>()
            {};
            visibleInterfaces = new List<string>()
            {};
            (specMachineMap).Add("ValmachineityCheck", new List<string>()
            {"PaxosNode", "Client", "Timer", "LeaderElection", "ValmachineityCheck", "BasicPaxosInvariant_P2b", "Main"});
            (specMachineMap).Add("BasicPaxosInvariant_P2b", new List<string>()
            {"PaxosNode", "Client", "Timer", "LeaderElection", "ValmachineityCheck", "BasicPaxosInvariant_P2b", "Main"});
            Dictionary<string, string> _temp;
            _temp = new Dictionary<string, string>();
            (_temp).Add("PaxosNode", "PaxosNode");
            (_temp).Add("LeaderElection", "LeaderElection");
            (_temp).Add("Timer", "Timer");
            (linkMap).Add("PaxosNode", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("LeaderElection", "LeaderElection");
            (linkMap).Add("LeaderElection", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("ValmachineityCheck", "ValmachineityCheck");
            (linkMap).Add("ValmachineityCheck", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("BasicPaxosInvariant_P2b", "BasicPaxosInvariant_P2b");
            (linkMap).Add("BasicPaxosInvariant_P2b", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("PaxosNode", "PaxosNode");
            (_temp).Add("Client", "Client");
            (_temp).Add("Main", "Main");
            (linkMap).Add("Main", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Client", "Client");
            (linkMap).Add("Client", _temp);
            _temp = new Dictionary<string, string>();
            (_temp).Add("Timer", "Timer");
            (linkMap).Add("Timer", _temp);
        }
    }
}
#pragma warning disable CS0162, CS0164, CS0168, CS0649
namespace P.Program
{
    using P.Runtime;
    using System;
    using System.Collections.Generic;

    public partial class Application : StateImpl
    {
        public partial class Events
        {
            public static PrtEventValue event_prepare;
            public static PrtEventValue event_accept;
            public static PrtEventValue event_agree;
            public static PrtEventValue event_reject;
            public static PrtEventValue event_accepted;
            public static PrtEventValue event_local;
            public static PrtEventValue event_success;
            public static PrtEventValue event_allNodes;
            public static PrtEventValue event_goPropose;
            public static PrtEventValue event_chosen;
            public static PrtEventValue event_update;
            public static PrtEventValue event_announce_valueChosen;
            public static PrtEventValue event_announce_valueProposed;
            public static PrtEventValue event_announce_client_sent;
            public static PrtEventValue event_announce_proposer_sent;
            public static PrtEventValue event_announce_proposer_chosen;
            public static PrtEventValue event_Ping;
            public static PrtEventValue event_newLeader;
            public static PrtEventValue event_timeout;
            public static PrtEventValue event_startTimer;
            public static PrtEventValue event_cancelTimer;
            public static PrtEventValue event_cancelTimerSuccess;
            public static PrtEventValue event_response;
            public static void Events_multi_paxos_4()
            {
                event_prepare = new PrtEventValue(new PrtEvent("prepare", Types.type_15_115039180, 3, true));
                event_accept = new PrtEventValue(new PrtEvent("accept", Types.type_14_115039180, 3, true));
                event_agree = new PrtEventValue(new PrtEvent("agree", Types.type_18_115039180, 6, true));
                event_reject = new PrtEventValue(new PrtEvent("reject", Types.type_19_115039180, 6, true));
                event_accepted = new PrtEventValue(new PrtEvent("accepted", Types.type_18_115039180, 6, true));
                event_local = new PrtEventValue(new PrtEvent("local", Types.type_22_115039180, PrtEvent.DefaultMaxInstances, false));
                event_success = new PrtEventValue(new PrtEvent("success", Types.type_22_115039180, PrtEvent.DefaultMaxInstances, false));
                event_allNodes = new PrtEventValue(new PrtEvent("allNodes", Types.type_1_115039180, PrtEvent.DefaultMaxInstances, false));
                event_goPropose = new PrtEventValue(new PrtEvent("goPropose", Types.type_22_115039180, PrtEvent.DefaultMaxInstances, false));
                event_chosen = new PrtEventValue(new PrtEvent("chosen", Types.type_18_115039180, PrtEvent.DefaultMaxInstances, false));
                event_update = new PrtEventValue(new PrtEvent("update", Types.type_7_115039180, PrtEvent.DefaultMaxInstances, false));
                event_announce_valueChosen = new PrtEventValue(new PrtEvent("announce_valueChosen", Types.type_14_115039180, PrtEvent.DefaultMaxInstances, false));
                event_announce_valueProposed = new PrtEventValue(new PrtEvent("announce_valueProposed", Types.type_14_115039180, PrtEvent.DefaultMaxInstances, false));
                event_announce_client_sent = new PrtEventValue(new PrtEvent("announce_client_sent", Types.type_4_115039180, PrtEvent.DefaultMaxInstances, false));
                event_announce_proposer_sent = new PrtEventValue(new PrtEvent("announce_proposer_sent", Types.type_4_115039180, PrtEvent.DefaultMaxInstances, false));
                event_announce_proposer_chosen = new PrtEventValue(new PrtEvent("announce_proposer_chosen", Types.type_4_115039180, PrtEvent.DefaultMaxInstances, false));
                event_Ping = new PrtEventValue(new PrtEvent("Ping", Types.type_10_115039180, 4, true));
                event_newLeader = new PrtEventValue(new PrtEvent("newLeader", Types.type_10_115039180, PrtEvent.DefaultMaxInstances, false));
                event_timeout = new PrtEventValue(new PrtEvent("timeout", Types.type_6_115039180, PrtEvent.DefaultMaxInstances, false));
                event_startTimer = new PrtEventValue(new PrtEvent("startTimer", Types.type_22_115039180, PrtEvent.DefaultMaxInstances, false));
                event_cancelTimer = new PrtEventValue(new PrtEvent("cancelTimer", Types.type_22_115039180, PrtEvent.DefaultMaxInstances, false));
                event_cancelTimerSuccess = new PrtEventValue(new PrtEvent("cancelTimerSuccess", Types.type_22_115039180, PrtEvent.DefaultMaxInstances, false));
                event_response = new PrtEventValue(new PrtEvent("response", Types.type_22_115039180, PrtEvent.DefaultMaxInstances, false));
            }
        }

        public partial class Types
        {
            public static PrtType type_ValmachineityCheck;
            public static PrtType type_2_115039180;
            public static PrtType type_1_115039180;
            public static PrtType type_4_115039180;
            public static PrtType type_3_115039180;
            public static PrtType type_5_115039180;
            public static PrtType type_6_115039180;
            public static PrtType type_7_115039180;
            public static PrtType type_8_115039180;
            public static PrtType type_9_115039180;
            public static PrtType type_10_115039180;
            public static PrtType type_11_115039180;
            public static PrtType type_12_115039180;
            public static PrtType type_13_115039180;
            public static PrtType type_14_115039180;
            public static PrtType type_15_115039180;
            public static PrtType type_17_115039180;
            public static PrtType type_16_115039180;
            public static PrtType type_18_115039180;
            public static PrtType type_19_115039180;
            public static PrtType type_20_115039180;
            public static PrtType type_21_115039180;
            public static PrtType type_22_115039180;
            public static PrtType type_BasicPaxosInvariant_P2b;
            public static PrtType type_Client;
            public static PrtType type_Main;
            public static PrtType type_Timer;
            public static PrtType type_LeaderElection;
            public static PrtType type_PaxosNode;
            static public void Types_multi_paxos_4()
            {
                Types.type_ValmachineityCheck = new PrtMachineType();
                Types.type_2_115039180 = new PrtSeqType(Types.type_ValmachineityCheck);
                Types.type_1_115039180 = new PrtNamedTupleType(new object[]{"nodes", Types.type_2_115039180});
                Types.type_4_115039180 = new PrtIntType();
                Types.type_3_115039180 = new PrtNamedTupleType(new object[]{"servers", Types.type_2_115039180, "parentServer", Types.type_ValmachineityCheck, "rank", Types.type_4_115039180});
                Types.type_5_115039180 = new PrtTupleType(new PrtType[]{Types.type_ValmachineityCheck, Types.type_4_115039180});
                Types.type_6_115039180 = new PrtNamedTupleType(new object[]{"mymachine", Types.type_ValmachineityCheck});
                Types.type_7_115039180 = new PrtNamedTupleType(new object[]{"seqmachine", Types.type_4_115039180, "command", Types.type_4_115039180});
                Types.type_8_115039180 = new PrtNamedTupleType(new object[]{"round", Types.type_4_115039180, "servermachine", Types.type_4_115039180});
                Types.type_9_115039180 = new PrtMapType(Types.type_4_115039180, Types.type_4_115039180);
                Types.type_10_115039180 = new PrtNamedTupleType(new object[]{"rank", Types.type_4_115039180, "server", Types.type_ValmachineityCheck});
                Types.type_11_115039180 = new PrtNamedTupleType(new object[]{"rank", Types.type_4_115039180});
                Types.type_12_115039180 = new PrtAnyType();
                Types.type_13_115039180 = new PrtTupleType(new PrtType[]{Types.type_4_115039180, Types.type_ValmachineityCheck});
                Types.type_14_115039180 = new PrtNamedTupleType(new object[]{"proposer", Types.type_ValmachineityCheck, "slot", Types.type_4_115039180, "proposal", Types.type_8_115039180, "value", Types.type_4_115039180});
                Types.type_15_115039180 = new PrtNamedTupleType(new object[]{"proposer", Types.type_ValmachineityCheck, "slot", Types.type_4_115039180, "proposal", Types.type_8_115039180});
                Types.type_17_115039180 = new PrtNamedTupleType(new object[]{"proposal", Types.type_8_115039180, "value", Types.type_4_115039180});
                Types.type_16_115039180 = new PrtMapType(Types.type_4_115039180, Types.type_17_115039180);
                Types.type_18_115039180 = new PrtNamedTupleType(new object[]{"slot", Types.type_4_115039180, "proposal", Types.type_8_115039180, "value", Types.type_4_115039180});
                Types.type_19_115039180 = new PrtNamedTupleType(new object[]{"slot", Types.type_4_115039180, "proposal", Types.type_8_115039180});
                Types.type_20_115039180 = new PrtEventType();
                Types.type_21_115039180 = new PrtBoolType();
                Types.type_22_115039180 = new PrtNullType();
                Types.type_BasicPaxosInvariant_P2b = Types.type_ValmachineityCheck;
                Types.type_Client = Types.type_ValmachineityCheck;
                Types.type_Main = Types.type_ValmachineityCheck;
                Types.type_Timer = Types.type_ValmachineityCheck;
                Types.type_LeaderElection = Types.type_ValmachineityCheck;
                Types.type_PaxosNode = Types.type_ValmachineityCheck;
            }
        }

        public static PrtImplMachine CreateMachine_Client(StateImpl application, PrtValue payload)
        {
            var machine = new Client(application, PrtImplMachine.DefaultMaxBufferSize, false);
            ((machine).self).permissions = null;
            (machine).sends = null;
            (machine).currentPayload = payload;
            return machine;
        }

        public static PrtImplMachine CreateMachine_Main(StateImpl application, PrtValue payload)
        {
            var machine = new Main(application, PrtImplMachine.DefaultMaxBufferSize, false);
            ((machine).self).permissions = null;
            (machine).sends = null;
            (machine).currentPayload = payload;
            return machine;
        }

        public static PrtImplMachine CreateMachine_Timer(StateImpl application, PrtValue payload)
        {
            var machine = new Timer(application, PrtImplMachine.DefaultMaxBufferSize, false);
            ((machine).self).permissions = null;
            (machine).sends = null;
            (machine).currentPayload = payload;
            return machine;
        }

        public static PrtImplMachine CreateMachine_LeaderElection(StateImpl application, PrtValue payload)
        {
            var machine = new LeaderElection(application, PrtImplMachine.DefaultMaxBufferSize, false);
            ((machine).self).permissions = null;
            (machine).sends = null;
            (machine).currentPayload = payload;
            return machine;
        }

        public static PrtSpecMachine CreateSpecMachine_ValmachineityCheck(StateImpl application)
        {
            var machine = new ValmachineityCheck(application);
            ((machine).observes).Add(Events.event_announce_proposer_chosen);
            ((machine).observes).Add(Events.event_announce_proposer_sent);
            ((machine).observes).Add(Events.event_announce_client_sent);
            (machine).PrtEnqueueEvent(PrtEventValue.@null, PrtEventValue.@null, null);
            return machine;
        }

        public static PrtSpecMachine CreateSpecMachine_BasicPaxosInvariant_P2b(StateImpl application)
        {
            var machine = new BasicPaxosInvariant_P2b(application);
            ((machine).observes).Add(Events.event_announce_valueProposed);
            ((machine).observes).Add(Events.event_announce_valueChosen);
            (machine).PrtEnqueueEvent(PrtEventValue.@null, PrtEventValue.@null, null);
            return machine;
        }

        public static PrtImplMachine CreateMachine_PaxosNode(StateImpl application, PrtValue payload)
        {
            var machine = new PaxosNode(application, PrtImplMachine.DefaultMaxBufferSize, false);
            ((machine).self).permissions = null;
            (machine).sends = null;
            (machine).currentPayload = payload;
            return machine;
        }

        public class Client : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return Client_Init;
                }
            }

            public PrtValue var_servers
            {
                get
                {
                    return fields[0];
                }

                set
                {
                    fields[0] = value;
                }
            }

            public override PrtImplMachine MakeSkeleton()
            {
                return new Client();
            }

            public override int NextInstanceNumber(StateImpl app)
            {
                return app.NextMachineInstanceNumber(this.GetType());
            }

            public override string Name
            {
                get
                {
                    return "Client";
                }
            }

            public Client(): base ()
            {
            }

            public Client(StateImpl app, int maxB, bool assume): base (app, maxB, assume)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_115039180));
            }

            public class ignore_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class ignore_StackFrame : PrtFunStackFrame
                {
                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    ignore_StackFrame currFun = (ignore_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new ignore_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "ignore";
                }
            }

            public static ignore_Class ignore = new ignore_Class();
            public class AnonFun0_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun0_StackFrame : PrtFunStackFrame
                {
                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun0_StackFrame currFun = (AnonFun0_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun0_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun0";
                }
            }

            public static AnonFun0_Class AnonFun0 = new AnonFun0_Class();
            public class AnonFun1_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun1_StackFrame : PrtFunStackFrame
                {
                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun1_StackFrame currFun = (AnonFun1_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun1_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun1";
                }
            }

            public static AnonFun1_Class AnonFun1 = new AnonFun1_Class();
            public class AnonFun2_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun2_StackFrame : PrtFunStackFrame
                {
                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun2_StackFrame currFun = (AnonFun2_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_servers = ((currFun).var_payload).Clone();
                    if (!!(Events.event_local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(543,4,543,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_local)).evt).name);
                    (parent).currentTrigger = Events.event_local;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun2_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun2";
                }
            }

            public static AnonFun2_Class AnonFun2 = new AnonFun2_Class();
            public class AnonFun3_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun3_StackFrame : PrtFunStackFrame
                {
                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun3_StackFrame currFun = (AnonFun3_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun3_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun3";
                }
            }

            public static AnonFun3_Class AnonFun3 = new AnonFun3_Class();
            public class AnonFun4_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun4_StackFrame : PrtFunStackFrame
                {
                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_8
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun4_StackFrame currFun = (AnonFun4_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun4_1;
                        case 2:
                            goto AnonFun4_2;
                    }

                    (application).Announce((PrtEventValue)(Events.event_announce_client_sent), new PrtIntValue(1), parent);
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto AnonFun4_if_0_else;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_servers)).Lookup(new PrtIntValue(0))).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_update), new PrtNamedTupleValue(Types.type_7_115039180, new PrtIntValue(0), new PrtIntValue(1)), parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_servers)).Lookup(new PrtIntValue(0))).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun4_1:
                        ;
                    goto AnonFun4_if_0_end;
                    AnonFun4_if_0_else:
                        ;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_servers)).Lookup(new PrtIntValue(((PrtIntValue)(new PrtIntValue(((parent).var_servers).Size()))).nt - ((PrtIntValue)(new PrtIntValue(1))).nt))).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_update), new PrtNamedTupleValue(Types.type_7_115039180, new PrtIntValue(0), new PrtIntValue(1)), parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_servers)).Lookup(new PrtIntValue(((PrtIntValue)(new PrtIntValue(((parent).var_servers).Size()))).nt - ((PrtIntValue)(new PrtIntValue(1))).nt))).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    AnonFun4_2:
                        ;
                    AnonFun4_if_0_end:
                        ;
                    if (!!(Events.event_response).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(557,4,557,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_response)).evt).name);
                    (parent).currentTrigger = Events.event_response;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun4_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun4";
                }
            }

            public static AnonFun4_Class AnonFun4 = new AnonFun4_Class();
            public class AnonFun5_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun5_StackFrame : PrtFunStackFrame
                {
                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun5_StackFrame currFun = (AnonFun5_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun5_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun5";
                }
            }

            public static AnonFun5_Class AnonFun5 = new AnonFun5_Class();
            public class AnonFun6_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun6_StackFrame : PrtFunStackFrame
                {
                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun6_StackFrame currFun = (AnonFun6_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun6_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun6";
                }
            }

            public static AnonFun6_Class AnonFun6 = new AnonFun6_Class();
            public class AnonFun7_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun7_StackFrame : PrtFunStackFrame
                {
                    public AnonFun7_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun7_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_9
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun7_StackFrame currFun = (AnonFun7_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun7_1;
                        case 2:
                            goto AnonFun7_2;
                    }

                    (application).Announce((PrtEventValue)(Events.event_announce_client_sent), new PrtIntValue(2), parent);
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto AnonFun7_if_0_else;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_servers)).Lookup(new PrtIntValue(0))).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_update), new PrtNamedTupleValue(Types.type_7_115039180, new PrtIntValue(0), new PrtIntValue(2)), parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_servers)).Lookup(new PrtIntValue(0))).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun7_1:
                        ;
                    goto AnonFun7_if_0_end;
                    AnonFun7_if_0_else:
                        ;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_servers)).Lookup(new PrtIntValue(((PrtIntValue)(new PrtIntValue(((parent).var_servers).Size()))).nt - ((PrtIntValue)(new PrtIntValue(1))).nt))).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_update), new PrtNamedTupleValue(Types.type_7_115039180, new PrtIntValue(0), new PrtIntValue(2)), parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_servers)).Lookup(new PrtIntValue(((PrtIntValue)(new PrtIntValue(((parent).var_servers).Size()))).nt - ((PrtIntValue)(new PrtIntValue(1))).nt))).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    AnonFun7_2:
                        ;
                    AnonFun7_if_0_end:
                        ;
                    if (!!(Events.event_response).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(571,4,571,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_response)).evt).name);
                    (parent).currentTrigger = Events.event_response;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun7_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun7";
                }
            }

            public static AnonFun7_Class AnonFun7 = new AnonFun7_Class();
            public class AnonFun8_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun8_StackFrame : PrtFunStackFrame
                {
                    public AnonFun8_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun8_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun8_StackFrame currFun = (AnonFun8_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun8_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun8";
                }
            }

            public static AnonFun8_Class AnonFun8 = new AnonFun8_Class();
            public class AnonFun9_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun9_StackFrame : PrtFunStackFrame
                {
                    public AnonFun9_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun9_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun9_StackFrame currFun = (AnonFun9_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun9_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun9";
                }
            }

            public static AnonFun9_Class AnonFun9 = new AnonFun9_Class();
            public class AnonFun10_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun10_StackFrame : PrtFunStackFrame
                {
                    public AnonFun10_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun10_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun10_StackFrame currFun = (AnonFun10_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun10_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun10";
                }
            }

            public static AnonFun10_Class AnonFun10 = new AnonFun10_Class();
            public class AnonFun11_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun11_StackFrame : PrtFunStackFrame
                {
                    public AnonFun11_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun11_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun11_StackFrame currFun = (AnonFun11_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun11_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun11";
                }
            }

            public static AnonFun11_Class AnonFun11 = new AnonFun11_Class();
            public class AnonFun12_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun12_StackFrame : PrtFunStackFrame
                {
                    public AnonFun12_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun12_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun12_StackFrame currFun = (AnonFun12_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun12_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun12";
                }
            }

            public static AnonFun12_Class AnonFun12 = new AnonFun12_Class();
            public class AnonFun13_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun13_StackFrame : PrtFunStackFrame
                {
                    public AnonFun13_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun13_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Client parent = (Client)(_parent);
                    AnonFun13_StackFrame currFun = (AnonFun13_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun13_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun13";
                }
            }

            public static AnonFun13_Class AnonFun13 = new AnonFun13_Class();
            public class Client_PumpRequestTwo_Class : PrtState
            {
                public Client_PumpRequestTwo_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Client_PumpRequestTwo_Class Client_PumpRequestTwo;
            public class Client_PumpRequestOne_Class : PrtState
            {
                public Client_PumpRequestOne_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Client_PumpRequestOne_Class Client_PumpRequestOne;
            public class Client_Init_Class : PrtState
            {
                public Client_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Client_Init_Class Client_Init;
            public class Client_Done_Class : PrtState
            {
                public Client_Done_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Client_Done_Class Client_Done;
            static Client()
            {
                Client_PumpRequestTwo = new Client_PumpRequestTwo_Class("Client_PumpRequestTwo", AnonFun7, AnonFun8, false, StateTemperature.Warm);
                Client_PumpRequestOne = new Client_PumpRequestOne_Class("Client_PumpRequestOne", AnonFun4, AnonFun10, false, StateTemperature.Warm);
                Client_Init = new Client_Init_Class("Client_Init", AnonFun2, AnonFun13, false, StateTemperature.Warm);
                Client_Done = new Client_Done_Class("Client_Done", AnonFun1, AnonFun0, false, StateTemperature.Warm);
                PrtTransition transition_1 = new PrtTransition(AnonFun11, Client_Done, false);
                Client_PumpRequestTwo.transitions.Add(Events.event_response, transition_1);
                PrtTransition transition_2 = new PrtTransition(AnonFun9, Client_PumpRequestTwo, false);
                Client_PumpRequestOne.transitions.Add(Events.event_response, transition_2);
                PrtTransition transition_3 = new PrtTransition(AnonFun12, Client_PumpRequestOne, false);
                Client_Init.transitions.Add(Events.event_local, transition_3);
            }
        }

        public class Main : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return Main_Init;
                }
            }

            public PrtValue var_iter
            {
                get
                {
                    return fields[0];
                }

                set
                {
                    fields[0] = value;
                }
            }

            public PrtValue var_temp
            {
                get
                {
                    return fields[1];
                }

                set
                {
                    fields[1] = value;
                }
            }

            public PrtValue var_paxosnodes
            {
                get
                {
                    return fields[2];
                }

                set
                {
                    fields[2] = value;
                }
            }

            public override PrtImplMachine MakeSkeleton()
            {
                return new Main();
            }

            public override int NextInstanceNumber(StateImpl app)
            {
                return app.NextMachineInstanceNumber(this.GetType());
            }

            public override string Name
            {
                get
                {
                    return "Main";
                }
            }

            public Main(): base ()
            {
            }

            public Main(StateImpl app, int maxB, bool assume): base (app, maxB, assume)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_ValmachineityCheck));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_115039180));
            }

            public class ignore_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class ignore_StackFrame : PrtFunStackFrame
                {
                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Main parent = (Main)(_parent);
                    ignore_StackFrame currFun = (ignore_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new ignore_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "ignore";
                }
            }

            public static ignore_Class ignore = new ignore_Class();
            public class AnonFun0_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun0_StackFrame : PrtFunStackFrame
                {
                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Main parent = (Main)(_parent);
                    AnonFun0_StackFrame currFun = (AnonFun0_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun0_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun0";
                }
            }

            public static AnonFun0_Class AnonFun0 = new AnonFun0_Class();
            public class AnonFun1_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun1_StackFrame : PrtFunStackFrame
                {
                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_7
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Main parent = (Main)(_parent);
                    AnonFun1_StackFrame currFun = (AnonFun1_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun1_1;
                        case 2:
                            goto AnonFun1_2;
                        case 3:
                            goto AnonFun1_3;
                        case 4:
                            goto AnonFun1_4;
                        case 5:
                            goto AnonFun1_5;
                    }

                    (parent).var_temp = (application).CreateInterface(parent, "PaxosNode", new PrtNamedTupleValue(Types.type_11_115039180, new PrtIntValue(3)));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 1);
                    return;
                    AnonFun1_1:
                        ;
                    ((PrtSeqValue)((parent).var_paxosnodes)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_temp))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_temp))).fieldValues[1]);
                    (parent).var_temp = (application).CreateInterface(parent, "PaxosNode", new PrtNamedTupleValue(Types.type_11_115039180, new PrtIntValue(2)));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 2);
                    return;
                    AnonFun1_2:
                        ;
                    ((PrtSeqValue)((parent).var_paxosnodes)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_temp))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_temp))).fieldValues[1]);
                    (parent).var_temp = (application).CreateInterface(parent, "PaxosNode", new PrtNamedTupleValue(Types.type_11_115039180, new PrtIntValue(1)));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 3);
                    return;
                    AnonFun1_3:
                        ;
                    ((PrtSeqValue)((parent).var_paxosnodes)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_temp))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_temp))).fieldValues[1]);
                    (parent).var_iter = (new PrtIntValue(0)).Clone();
                    AnonFun1_loop_start_0:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((parent).var_iter)).nt < ((PrtIntValue)(new PrtIntValue(((parent).var_paxosnodes).Size()))).nt))).bl)
                        goto AnonFun1_loop_end_0;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_paxosnodes)).Lookup((parent).var_iter)).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_allNodes), new PrtNamedTupleValue(Types.type_1_115039180, (parent).var_paxosnodes), parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_paxosnodes)).Lookup((parent).var_iter)).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 4);
                    return;
                    AnonFun1_4:
                        ;
                    (parent).var_iter = (new PrtIntValue(((PrtIntValue)((parent).var_iter)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto AnonFun1_loop_start_0;
                    AnonFun1_loop_end_0:
                        ;
                    (application).CreateInterface((parent).renamedName, "Client", (parent).var_paxosnodes);
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 5);
                    return;
                    AnonFun1_5:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun1_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun1";
                }
            }

            public static AnonFun1_Class AnonFun1 = new AnonFun1_Class();
            public class AnonFun2_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun2_StackFrame : PrtFunStackFrame
                {
                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Main parent = (Main)(_parent);
                    AnonFun2_StackFrame currFun = (AnonFun2_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun2_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun2";
                }
            }

            public static AnonFun2_Class AnonFun2 = new AnonFun2_Class();
            public class Main_Init_Class : PrtState
            {
                public Main_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Main_Init_Class Main_Init;
            static Main()
            {
                Main_Init = new Main_Init_Class("Main_Init", AnonFun1, AnonFun0, false, StateTemperature.Warm);
            }
        }

        public class Timer : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return Timer_Init;
                }
            }

            public PrtValue var_timeoutvalue
            {
                get
                {
                    return fields[0];
                }

                set
                {
                    fields[0] = value;
                }
            }

            public PrtValue var_target
            {
                get
                {
                    return fields[1];
                }

                set
                {
                    fields[1] = value;
                }
            }

            public override PrtImplMachine MakeSkeleton()
            {
                return new Timer();
            }

            public override int NextInstanceNumber(StateImpl app)
            {
                return app.NextMachineInstanceNumber(this.GetType());
            }

            public override string Name
            {
                get
                {
                    return "Timer";
                }
            }

            public Timer(): base ()
            {
            }

            public Timer(StateImpl app, int maxB, bool assume): base (app, maxB, assume)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_ValmachineityCheck));
            }

            public class ignore_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class ignore_StackFrame : PrtFunStackFrame
                {
                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    ignore_StackFrame currFun = (ignore_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new ignore_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "ignore";
                }
            }

            public static ignore_Class ignore = new ignore_Class();
            public class AnonFun0_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun0_StackFrame : PrtFunStackFrame
                {
                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_6
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun0_StackFrame currFun = (AnonFun0_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto AnonFun0_if_0_else;
                    if (!!(Events.event_local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(503,5,503,10): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_local)).evt).name);
                    (parent).currentTrigger = Events.event_local;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto AnonFun0_if_0_end;
                    AnonFun0_if_0_else:
                        ;
                    AnonFun0_if_0_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun0_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun0";
                }
            }

            public static AnonFun0_Class AnonFun0 = new AnonFun0_Class();
            public class AnonFun1_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun1_StackFrame : PrtFunStackFrame
                {
                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun1_StackFrame currFun = (AnonFun1_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun1_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun1";
                }
            }

            public static AnonFun1_Class AnonFun1 = new AnonFun1_Class();
            public class AnonFun2_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun2_StackFrame : PrtFunStackFrame
                {
                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun2_StackFrame currFun = (AnonFun2_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun2_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun2";
                }
            }

            public static AnonFun2_Class AnonFun2 = new AnonFun2_Class();
            public class AnonFun3_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun3_StackFrame : PrtFunStackFrame
                {
                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun3_StackFrame currFun = (AnonFun3_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun3_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun3";
                }
            }

            public static AnonFun3_Class AnonFun3 = new AnonFun3_Class();
            public class AnonFun4_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun4_StackFrame : PrtFunStackFrame
                {
                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun4_StackFrame currFun = (AnonFun4_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun4_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun4";
                }
            }

            public static AnonFun4_Class AnonFun4 = new AnonFun4_Class();
            public class AnonFun5_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun5_StackFrame : PrtFunStackFrame
                {
                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun5_StackFrame currFun = (AnonFun5_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun5_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun5";
                }
            }

            public static AnonFun5_Class AnonFun5 = new AnonFun5_Class();
            public class AnonFun6_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun6_StackFrame : PrtFunStackFrame
                {
                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun6_StackFrame currFun = (AnonFun6_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun6_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun6";
                }
            }

            public static AnonFun6_Class AnonFun6 = new AnonFun6_Class();
            public class AnonFun7_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun7_StackFrame : PrtFunStackFrame
                {
                    public AnonFun7_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun7_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun7_StackFrame currFun = (AnonFun7_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun7_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun7";
                }
            }

            public static AnonFun7_Class AnonFun7 = new AnonFun7_Class();
            public class AnonFun8_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun8_StackFrame : PrtFunStackFrame
                {
                    public AnonFun8_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun8_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun8_StackFrame currFun = (AnonFun8_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun8_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun8";
                }
            }

            public static AnonFun8_Class AnonFun8 = new AnonFun8_Class();
            public class AnonFun9_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun9_StackFrame : PrtFunStackFrame
                {
                    public AnonFun9_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun9_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun9_StackFrame currFun = (AnonFun9_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun9_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun9";
                }
            }

            public static AnonFun9_Class AnonFun9 = new AnonFun9_Class();
            public class AnonFun10_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun10_StackFrame : PrtFunStackFrame
                {
                    public AnonFun10_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun10_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun10_StackFrame currFun = (AnonFun10_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun10_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun10";
                }
            }

            public static AnonFun10_Class AnonFun10 = new AnonFun10_Class();
            public class AnonFun11_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun11_StackFrame : PrtFunStackFrame
                {
                    public AnonFun11_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun11_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Timer parent = (Timer)(_parent);
                    AnonFun11_StackFrame currFun = (AnonFun11_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_target = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone()).Clone();
                    (parent).var_timeoutvalue = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone()).Clone();
                    if (!!(Events.event_local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(488,4,488,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_local)).evt).name);
                    (parent).currentTrigger = Events.event_local;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun11_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun11";
                }
            }

            public static AnonFun11_Class AnonFun11 = new AnonFun11_Class();
            public class Timer_TimerStarted_Class : PrtState
            {
                public Timer_TimerStarted_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Timer_TimerStarted_Class Timer_TimerStarted;
            public class Timer_Loop_Class : PrtState
            {
                public Timer_Loop_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Timer_Loop_Class Timer_Loop;
            public class Timer_Init_Class : PrtState
            {
                public Timer_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Timer_Init_Class Timer_Init;
            static Timer()
            {
                Timer_TimerStarted = new Timer_TimerStarted_Class("Timer_TimerStarted", AnonFun0, AnonFun3, false, StateTemperature.Warm);
                Timer_Loop = new Timer_Loop_Class("Timer_Loop", AnonFun4, AnonFun5, false, StateTemperature.Warm);
                Timer_Init = new Timer_Init_Class("Timer_Init", AnonFun11, AnonFun10, false, StateTemperature.Warm);
                Timer_TimerStarted.dos.Add(Events.event_startTimer, PrtFun.IgnoreFun);
                PrtTransition transition_1 = new PrtTransition(AnonFun9, Timer_Loop, false);
                Timer_TimerStarted.transitions.Add(Events.event_cancelTimer, transition_1);
                PrtTransition transition_2 = new PrtTransition(AnonFun8, Timer_Loop, false);
                Timer_TimerStarted.transitions.Add(Events.event_local, transition_2);
                Timer_Loop.dos.Add(Events.event_cancelTimer, PrtFun.IgnoreFun);
                PrtTransition transition_3 = new PrtTransition(AnonFun7, Timer_TimerStarted, false);
                Timer_Loop.transitions.Add(Events.event_startTimer, transition_3);
                PrtTransition transition_4 = new PrtTransition(AnonFun6, Timer_Loop, false);
                Timer_Init.transitions.Add(Events.event_local, transition_4);
            }
        }

        public class LeaderElection : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return LeaderElection_Init;
                }
            }

            public PrtValue var_iter
            {
                get
                {
                    return fields[0];
                }

                set
                {
                    fields[0] = value;
                }
            }

            public PrtValue var_myRank
            {
                get
                {
                    return fields[1];
                }

                set
                {
                    fields[1] = value;
                }
            }

            public PrtValue var_currentLeader
            {
                get
                {
                    return fields[2];
                }

                set
                {
                    fields[2] = value;
                }
            }

            public PrtValue var_parentServer
            {
                get
                {
                    return fields[3];
                }

                set
                {
                    fields[3] = value;
                }
            }

            public PrtValue var_servers
            {
                get
                {
                    return fields[4];
                }

                set
                {
                    fields[4] = value;
                }
            }

            public override PrtImplMachine MakeSkeleton()
            {
                return new LeaderElection();
            }

            public override int NextInstanceNumber(StateImpl app)
            {
                return app.NextMachineInstanceNumber(this.GetType());
            }

            public override string Name
            {
                get
                {
                    return "LeaderElection";
                }
            }

            public LeaderElection(): base ()
            {
            }

            public LeaderElection(StateImpl app, int maxB, bool assume): base (app, maxB, assume)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_10_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_ValmachineityCheck));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_115039180));
            }

            public class ignore_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class ignore_StackFrame : PrtFunStackFrame
                {
                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    LeaderElection parent = (LeaderElection)(_parent);
                    ignore_StackFrame currFun = (ignore_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new ignore_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "ignore";
                }
            }

            public static ignore_Class ignore = new ignore_Class();
            public class GetNewLeader_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class GetNewLeader_StackFrame : PrtFunStackFrame
                {
                    public GetNewLeader_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public GetNewLeader_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    LeaderElection parent = (LeaderElection)(_parent);
                    GetNewLeader_StackFrame currFun = (GetNewLeader_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).PrtFunContReturnVal(new PrtNamedTupleValue(Types.type_10_115039180, new PrtIntValue(1), (((PrtSeqValue)((parent).var_servers)).Lookup(new PrtIntValue(0))).Clone()), (currFun).locals);
                    return;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new GetNewLeader_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "GetNewLeader";
                }
            }

            public static GetNewLeader_Class GetNewLeader = new GetNewLeader_Class();
            public class AnonFun0_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun0_StackFrame : PrtFunStackFrame
                {
                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    LeaderElection parent = (LeaderElection)(_parent);
                    AnonFun0_StackFrame currFun = (AnonFun0_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun0_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun0";
                }
            }

            public static AnonFun0_Class AnonFun0 = new AnonFun0_Class();
            public class AnonFun1_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun1_StackFrame : PrtFunStackFrame
                {
                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    LeaderElection parent = (LeaderElection)(_parent);
                    AnonFun1_StackFrame currFun = (AnonFun1_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun1_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun1";
                }
            }

            public static AnonFun1_Class AnonFun1 = new AnonFun1_Class();
            public class AnonFun2_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun2_StackFrame : PrtFunStackFrame
                {
                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    LeaderElection parent = (LeaderElection)(_parent);
                    AnonFun2_StackFrame currFun = (AnonFun2_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun2_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun2";
                }
            }

            public static AnonFun2_Class AnonFun2 = new AnonFun2_Class();
            public class AnonFun3_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun3_StackFrame : PrtFunStackFrame
                {
                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    LeaderElection parent = (LeaderElection)(_parent);
                    AnonFun3_StackFrame currFun = (AnonFun3_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun3_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun3";
                }
            }

            public static AnonFun3_Class AnonFun3 = new AnonFun3_Class();
            public class AnonFun4_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun4_StackFrame : PrtFunStackFrame
                {
                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    LeaderElection parent = (LeaderElection)(_parent);
                    AnonFun4_StackFrame currFun = (AnonFun4_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun4_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun4";
                }
            }

            public static AnonFun4_Class AnonFun4 = new AnonFun4_Class();
            public class AnonFun5_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun5_StackFrame : PrtFunStackFrame
                {
                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    LeaderElection parent = (LeaderElection)(_parent);
                    AnonFun5_StackFrame currFun = (AnonFun5_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_servers = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone()).Clone();
                    (parent).var_parentServer = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone()).Clone();
                    (parent).var_myRank = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[2]).Clone()).Clone();
                    (parent).var_currentLeader = (new PrtNamedTupleValue(Types.type_10_115039180, (parent).var_myRank, parent.self)).Clone();
                    if (!!(Events.event_local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(448,4,448,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_local)).evt).name);
                    (parent).currentTrigger = Events.event_local;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun5_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun5";
                }
            }

            public static AnonFun5_Class AnonFun5 = new AnonFun5_Class();
            public class AnonFun6_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun6_StackFrame : PrtFunStackFrame
                {
                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_5
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    LeaderElection parent = (LeaderElection)(_parent);
                    AnonFun6_StackFrame currFun = (AnonFun6_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun6_1;
                    }

                    (parent).var_currentLeader = ((GetNewLeader).ExecuteToCompletion(application, parent)).Clone();
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((parent).var_currentLeader)).fieldValues[0]).Clone())).nt <= ((PrtIntValue)((parent).var_myRank)).nt))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(457,4,457,10): error PC1001: Assert failed");
                    (((PrtMachineValue)((parent).var_parentServer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_newLeader), (parent).var_currentLeader, parent, (PrtMachineValue)((parent).var_parentServer));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun6_1:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun6_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun6";
                }
            }

            public static AnonFun6_Class AnonFun6 = new AnonFun6_Class();
            public class LeaderElection_Init_Class : PrtState
            {
                public LeaderElection_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static LeaderElection_Init_Class LeaderElection_Init;
            public class LeaderElection_SendLeader_Class : PrtState
            {
                public LeaderElection_SendLeader_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static LeaderElection_SendLeader_Class LeaderElection_SendLeader;
            static LeaderElection()
            {
                LeaderElection_Init = new LeaderElection_Init_Class("LeaderElection_Init", AnonFun5, AnonFun2, false, StateTemperature.Warm);
                LeaderElection_SendLeader = new LeaderElection_SendLeader_Class("LeaderElection_SendLeader", AnonFun6, AnonFun4, false, StateTemperature.Warm);
                PrtTransition transition_1 = new PrtTransition(AnonFun3, LeaderElection_SendLeader, false);
                LeaderElection_Init.transitions.Add(Events.event_local, transition_1);
            }
        }

        public class ValmachineityCheck : PrtSpecMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return ValmachineityCheck_Init;
                }
            }

            public PrtValue var_ProposedSet
            {
                get
                {
                    return fields[0];
                }

                set
                {
                    fields[0] = value;
                }
            }

            public PrtValue var_clientSet
            {
                get
                {
                    return fields[1];
                }

                set
                {
                    fields[1] = value;
                }
            }

            public override PrtSpecMachine MakeSkeleton()
            {
                return new ValmachineityCheck();
            }

            public override string Name
            {
                get
                {
                    return "ValmachineityCheck";
                }
            }

            public ValmachineityCheck(): base ()
            {
            }

            public ValmachineityCheck(StateImpl app): base (app)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_9_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_9_115039180));
            }

            public class ignore_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class ignore_StackFrame : PrtFunStackFrame
                {
                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    ValmachineityCheck parent = (ValmachineityCheck)(_parent);
                    ignore_StackFrame currFun = (ignore_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new ignore_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "ignore";
                }
            }

            public static ignore_Class ignore = new ignore_Class();
            public class AnonFun0_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun0_StackFrame : PrtFunStackFrame
                {
                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    ValmachineityCheck parent = (ValmachineityCheck)(_parent);
                    AnonFun0_StackFrame currFun = (AnonFun0_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtMapValue)((parent).var_clientSet)).Contains((currFun).var_payload)))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(416,50,416,56): error PC1001: Assert failed");
                    ((PrtMapValue)((parent).var_ProposedSet)).Update(PrtValue.PrtCastValue((currFun).var_payload, Types.type_4_115039180), (new PrtIntValue(0)).Clone());
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun0_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun0";
                }
            }

            public static AnonFun0_Class AnonFun0 = new AnonFun0_Class();
            public class AnonFun1_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun1_StackFrame : PrtFunStackFrame
                {
                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    ValmachineityCheck parent = (ValmachineityCheck)(_parent);
                    AnonFun1_StackFrame currFun = (AnonFun1_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    ((PrtMapValue)((parent).var_clientSet)).Update((currFun).var_payload, (new PrtIntValue(0)).Clone());
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun1_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun1";
                }
            }

            public static AnonFun1_Class AnonFun1 = new AnonFun1_Class();
            public class AnonFun2_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun2_StackFrame : PrtFunStackFrame
                {
                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    ValmachineityCheck parent = (ValmachineityCheck)(_parent);
                    AnonFun2_StackFrame currFun = (AnonFun2_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun2_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun2";
                }
            }

            public static AnonFun2_Class AnonFun2 = new AnonFun2_Class();
            public class AnonFun3_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun3_StackFrame : PrtFunStackFrame
                {
                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    ValmachineityCheck parent = (ValmachineityCheck)(_parent);
                    AnonFun3_StackFrame currFun = (AnonFun3_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun3_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun3";
                }
            }

            public static AnonFun3_Class AnonFun3 = new AnonFun3_Class();
            public class AnonFun4_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun4_StackFrame : PrtFunStackFrame
                {
                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    ValmachineityCheck parent = (ValmachineityCheck)(_parent);
                    AnonFun4_StackFrame currFun = (AnonFun4_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtMapValue)((parent).var_ProposedSet)).Contains((currFun).var_payload)))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(418,52,418,58): error PC1001: Assert failed");
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun4_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun4";
                }
            }

            public static AnonFun4_Class AnonFun4 = new AnonFun4_Class();
            public class AnonFun5_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun5_StackFrame : PrtFunStackFrame
                {
                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    ValmachineityCheck parent = (ValmachineityCheck)(_parent);
                    AnonFun5_StackFrame currFun = (AnonFun5_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun5_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun5";
                }
            }

            public static AnonFun5_Class AnonFun5 = new AnonFun5_Class();
            public class AnonFun6_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun6_StackFrame : PrtFunStackFrame
                {
                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    ValmachineityCheck parent = (ValmachineityCheck)(_parent);
                    AnonFun6_StackFrame currFun = (AnonFun6_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun6_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun6";
                }
            }

            public static AnonFun6_Class AnonFun6 = new AnonFun6_Class();
            public class AnonFun7_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun7_StackFrame : PrtFunStackFrame
                {
                    public AnonFun7_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun7_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    ValmachineityCheck parent = (ValmachineityCheck)(_parent);
                    AnonFun7_StackFrame currFun = (AnonFun7_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun7_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun7";
                }
            }

            public static AnonFun7_Class AnonFun7 = new AnonFun7_Class();
            public class AnonFun8_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun8_StackFrame : PrtFunStackFrame
                {
                    public AnonFun8_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun8_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_4
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    ValmachineityCheck parent = (ValmachineityCheck)(_parent);
                    AnonFun8_StackFrame currFun = (AnonFun8_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!!(Events.event_local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(409,4,409,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_local)).evt).name);
                    (parent).currentTrigger = Events.event_local;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun8_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun8";
                }
            }

            public static AnonFun8_Class AnonFun8 = new AnonFun8_Class();
            public class ValmachineityCheck_Wait_Class : PrtState
            {
                public ValmachineityCheck_Wait_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static ValmachineityCheck_Wait_Class ValmachineityCheck_Wait;
            public class ValmachineityCheck_Init_Class : PrtState
            {
                public ValmachineityCheck_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static ValmachineityCheck_Init_Class ValmachineityCheck_Init;
            static ValmachineityCheck()
            {
                ValmachineityCheck_Wait = new ValmachineityCheck_Wait_Class("ValmachineityCheck_Wait", AnonFun6, AnonFun5, false, StateTemperature.Warm);
                ValmachineityCheck_Init = new ValmachineityCheck_Init_Class("ValmachineityCheck_Init", AnonFun8, AnonFun7, false, StateTemperature.Warm);
                ValmachineityCheck_Wait.dos.Add(Events.event_announce_proposer_chosen, AnonFun4);
                ValmachineityCheck_Wait.dos.Add(Events.event_announce_proposer_sent, AnonFun0);
                ValmachineityCheck_Wait.dos.Add(Events.event_announce_client_sent, AnonFun1);
                PrtTransition transition_1 = new PrtTransition(AnonFun3, ValmachineityCheck_Wait, false);
                ValmachineityCheck_Init.transitions.Add(Events.event_local, transition_1);
            }
        }

        public class BasicPaxosInvariant_P2b : PrtSpecMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return BasicPaxosInvariant_P2b_Init;
                }
            }

            public PrtValue var_receivedValue
            {
                get
                {
                    return fields[0];
                }

                set
                {
                    fields[0] = value;
                }
            }

            public PrtValue var_returnVal
            {
                get
                {
                    return fields[1];
                }

                set
                {
                    fields[1] = value;
                }
            }

            public PrtValue var_lastValueChosen
            {
                get
                {
                    return fields[2];
                }

                set
                {
                    fields[2] = value;
                }
            }

            public override PrtSpecMachine MakeSkeleton()
            {
                return new BasicPaxosInvariant_P2b();
            }

            public override string Name
            {
                get
                {
                    return "BasicPaxosInvariant_P2b";
                }
            }

            public BasicPaxosInvariant_P2b(): base ()
            {
            }

            public BasicPaxosInvariant_P2b(StateImpl app): base (app)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_14_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_21_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_16_115039180));
            }

            public class ignore_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class ignore_StackFrame : PrtFunStackFrame
                {
                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    ignore_StackFrame currFun = (ignore_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new ignore_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "ignore";
                }
            }

            public static ignore_Class ignore = new ignore_Class();
            public class lessThan_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class lessThan_StackFrame : PrtFunStackFrame
                {
                    public lessThan_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public lessThan_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_p1
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }

                    public PrtValue var_p2
                    {
                        get
                        {
                            return locals[1];
                        }

                        set
                        {
                            locals[1] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    lessThan_StackFrame currFun = (lessThan_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((currFun).var_p1)).fieldValues[0]).Clone())).nt < ((PrtIntValue)((((PrtTupleValue)((currFun).var_p2)).fieldValues[0]).Clone())).nt))).bl)
                        goto lessThan_if_2_else;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(true), (currFun).locals);
                    return;
                    goto lessThan_if_2_end;
                    lessThan_if_2_else:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((currFun).var_p1)).fieldValues[0]).Clone()).Equals((((PrtTupleValue)((currFun).var_p2)).fieldValues[0]).Clone())))).bl)
                        goto lessThan_if_1_else;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((currFun).var_p1)).fieldValues[1]).Clone())).nt < ((PrtIntValue)((((PrtTupleValue)((currFun).var_p2)).fieldValues[1]).Clone())).nt))).bl)
                        goto lessThan_if_0_else;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(true), (currFun).locals);
                    return;
                    goto lessThan_if_0_end;
                    lessThan_if_0_else:
                        ;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(false), (currFun).locals);
                    return;
                    lessThan_if_0_end:
                        ;
                    goto lessThan_if_1_end;
                    lessThan_if_1_else:
                        ;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(false), (currFun).locals);
                    return;
                    lessThan_if_1_end:
                        ;
                    lessThan_if_2_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new lessThan_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "lessThan";
                }
            }

            public static lessThan_Class lessThan = new lessThan_Class();
            public class AnonFun0_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun0_StackFrame : PrtFunStackFrame
                {
                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun0_StackFrame currFun = (AnonFun0_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun0_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun0";
                }
            }

            public static AnonFun0_Class AnonFun0 = new AnonFun0_Class();
            public class AnonFun1_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun1_StackFrame : PrtFunStackFrame
                {
                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun1_StackFrame currFun = (AnonFun1_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun1_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun1";
                }
            }

            public static AnonFun1_Class AnonFun1 = new AnonFun1_Class();
            public class AnonFun2_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun2_StackFrame : PrtFunStackFrame
                {
                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun2_StackFrame currFun = (AnonFun2_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun2_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun2";
                }
            }

            public static AnonFun2_Class AnonFun2 = new AnonFun2_Class();
            public class AnonFun3_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun3_StackFrame : PrtFunStackFrame
                {
                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun3_StackFrame currFun = (AnonFun3_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun3_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun3";
                }
            }

            public static AnonFun3_Class AnonFun3 = new AnonFun3_Class();
            public class AnonFun4_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun4_StackFrame : PrtFunStackFrame
                {
                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_receivedValue
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun4_StackFrame currFun = (AnonFun4_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    ((PrtMapValue)((parent).var_lastValueChosen)).Update((((PrtTupleValue)((currFun).var_receivedValue)).fieldValues[1]).Clone(), (new PrtNamedTupleValue(Types.type_17_115039180, (((PrtTupleValue)((currFun).var_receivedValue)).fieldValues[2]).Clone(), (((PrtTupleValue)((currFun).var_receivedValue)).fieldValues[3]).Clone())).Clone());
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun4_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun4";
                }
            }

            public static AnonFun4_Class AnonFun4 = new AnonFun4_Class();
            public class AnonFun5_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun5_StackFrame : PrtFunStackFrame
                {
                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun5_StackFrame currFun = (AnonFun5_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun5_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun5";
                }
            }

            public static AnonFun5_Class AnonFun5 = new AnonFun5_Class();
            public class AnonFun6_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun6_StackFrame : PrtFunStackFrame
                {
                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_3
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun6_StackFrame currFun = (AnonFun6_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun6_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun6";
                }
            }

            public static AnonFun6_Class AnonFun6 = new AnonFun6_Class();
            public class AnonFun7_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun7_StackFrame : PrtFunStackFrame
                {
                    public AnonFun7_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun7_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_receivedValue
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun7_StackFrame currFun = (AnonFun7_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((((PrtMapValue)((parent).var_lastValueChosen)).Lookup((((PrtTupleValue)((currFun).var_receivedValue)).fieldValues[1]).Clone())).Clone())).fieldValues[1]).Clone()).Equals((((PrtTupleValue)((currFun).var_receivedValue)).fieldValues[3]).Clone())))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(381,4,381,10): error PC1001: Assert failed");
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun7_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun7";
                }
            }

            public static AnonFun7_Class AnonFun7 = new AnonFun7_Class();
            public class AnonFun8_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun8_StackFrame : PrtFunStackFrame
                {
                    public AnonFun8_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun8_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun8_StackFrame currFun = (AnonFun8_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun8_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun8";
                }
            }

            public static AnonFun8_Class AnonFun8 = new AnonFun8_Class();
            public class AnonFun9_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun9_StackFrame : PrtFunStackFrame
                {
                    public AnonFun9_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun9_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun9_StackFrame currFun = (AnonFun9_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun9_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun9";
                }
            }

            public static AnonFun9_Class AnonFun9 = new AnonFun9_Class();
            public class AnonFun10_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun10_StackFrame : PrtFunStackFrame
                {
                    public AnonFun10_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun10_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_2
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun10_StackFrame currFun = (AnonFun10_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!!(Events.event_local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(343,4,343,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_local)).evt).name);
                    (parent).currentTrigger = Events.event_local;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun10_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun10";
                }
            }

            public static AnonFun10_Class AnonFun10 = new AnonFun10_Class();
            public class AnonFun11_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun11_StackFrame : PrtFunStackFrame
                {
                    public AnonFun11_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun11_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_receivedValue
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    BasicPaxosInvariant_P2b parent = (BasicPaxosInvariant_P2b)(_parent);
                    AnonFun11_StackFrame currFun = (AnonFun11_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_returnVal = ((lessThan).ExecuteToCompletion(application, parent, (((PrtTupleValue)((((PrtMapValue)((parent).var_lastValueChosen)).Lookup((((PrtTupleValue)((currFun).var_receivedValue)).fieldValues[1]).Clone())).Clone())).fieldValues[0]).Clone(), (((PrtTupleValue)((currFun).var_receivedValue)).fieldValues[2]).Clone())).Clone();
                    if (!((PrtBoolValue)((parent).var_returnVal)).bl)
                        goto AnonFun11_if_0_else;
                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((((PrtMapValue)((parent).var_lastValueChosen)).Lookup((((PrtTupleValue)((currFun).var_receivedValue)).fieldValues[1]).Clone())).Clone())).fieldValues[1]).Clone()).Equals((((PrtTupleValue)((currFun).var_receivedValue)).fieldValues[3]).Clone())))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(387,5,387,11): error PC1001: Assert failed");
                    goto AnonFun11_if_0_end;
                    AnonFun11_if_0_else:
                        ;
                    AnonFun11_if_0_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun11_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun11";
                }
            }

            public static AnonFun11_Class AnonFun11 = new AnonFun11_Class();
            public class BasicPaxosInvariant_P2b_WaitForValueChosen_Class : PrtState
            {
                public BasicPaxosInvariant_P2b_WaitForValueChosen_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static BasicPaxosInvariant_P2b_WaitForValueChosen_Class BasicPaxosInvariant_P2b_WaitForValueChosen;
            public class BasicPaxosInvariant_P2b_CheckValueProposed_Class : PrtState
            {
                public BasicPaxosInvariant_P2b_CheckValueProposed_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static BasicPaxosInvariant_P2b_CheckValueProposed_Class BasicPaxosInvariant_P2b_CheckValueProposed;
            public class BasicPaxosInvariant_P2b_Init_Class : PrtState
            {
                public BasicPaxosInvariant_P2b_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static BasicPaxosInvariant_P2b_Init_Class BasicPaxosInvariant_P2b_Init;
            static BasicPaxosInvariant_P2b()
            {
                BasicPaxosInvariant_P2b_WaitForValueChosen = new BasicPaxosInvariant_P2b_WaitForValueChosen_Class("BasicPaxosInvariant_P2b_WaitForValueChosen", AnonFun6, AnonFun5, false, StateTemperature.Warm);
                BasicPaxosInvariant_P2b_CheckValueProposed = new BasicPaxosInvariant_P2b_CheckValueProposed_Class("BasicPaxosInvariant_P2b_CheckValueProposed", AnonFun3, AnonFun2, false, StateTemperature.Warm);
                BasicPaxosInvariant_P2b_Init = new BasicPaxosInvariant_P2b_Init_Class("BasicPaxosInvariant_P2b_Init", AnonFun10, AnonFun9, false, StateTemperature.Warm);
                BasicPaxosInvariant_P2b_WaitForValueChosen.dos.Add(Events.event_announce_valueProposed, PrtFun.IgnoreFun);
                PrtTransition transition_1 = new PrtTransition(AnonFun4, BasicPaxosInvariant_P2b_CheckValueProposed, false);
                BasicPaxosInvariant_P2b_WaitForValueChosen.transitions.Add(Events.event_announce_valueChosen, transition_1);
                PrtTransition transition_2 = new PrtTransition(AnonFun11, BasicPaxosInvariant_P2b_CheckValueProposed, false);
                BasicPaxosInvariant_P2b_CheckValueProposed.transitions.Add(Events.event_announce_valueProposed, transition_2);
                PrtTransition transition_3 = new PrtTransition(AnonFun7, BasicPaxosInvariant_P2b_CheckValueProposed, false);
                BasicPaxosInvariant_P2b_CheckValueProposed.transitions.Add(Events.event_announce_valueChosen, transition_3);
                PrtTransition transition_4 = new PrtTransition(AnonFun8, BasicPaxosInvariant_P2b_WaitForValueChosen, false);
                BasicPaxosInvariant_P2b_Init.transitions.Add(Events.event_local, transition_4);
            }
        }

        public class PaxosNode : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return PaxosNode_Init;
                }
            }

            public PrtValue var_lastExecutedSlot
            {
                get
                {
                    return fields[0];
                }

                set
                {
                    fields[0] = value;
                }
            }

            public PrtValue var_learnerSlots
            {
                get
                {
                    return fields[1];
                }

                set
                {
                    fields[1] = value;
                }
            }

            public PrtValue var_receivedMess_2
            {
                get
                {
                    return fields[2];
                }

                set
                {
                    fields[2] = value;
                }
            }

            public PrtValue var_acceptorSlots
            {
                get
                {
                    return fields[3];
                }

                set
                {
                    fields[3] = value;
                }
            }

            public PrtValue var_currCommitOperation
            {
                get
                {
                    return fields[4];
                }

                set
                {
                    fields[4] = value;
                }
            }

            public PrtValue var_nextSlotForProposer
            {
                get
                {
                    return fields[5];
                }

                set
                {
                    fields[5] = value;
                }
            }

            public PrtValue var_receivedMess_1
            {
                get
                {
                    return fields[6];
                }

                set
                {
                    fields[6] = value;
                }
            }

            public PrtValue var_timer
            {
                get
                {
                    return fields[7];
                }

                set
                {
                    fields[7] = value;
                }
            }

            public PrtValue var_returnVal
            {
                get
                {
                    return fields[8];
                }

                set
                {
                    fields[8] = value;
                }
            }

            public PrtValue var_tempVal
            {
                get
                {
                    return fields[9];
                }

                set
                {
                    fields[9] = value;
                }
            }

            public PrtValue var_countAgree
            {
                get
                {
                    return fields[10];
                }

                set
                {
                    fields[10] = value;
                }
            }

            public PrtValue var_countAccept
            {
                get
                {
                    return fields[11];
                }

                set
                {
                    fields[11] = value;
                }
            }

            public PrtValue var_maxRound
            {
                get
                {
                    return fields[12];
                }

                set
                {
                    fields[12] = value;
                }
            }

            public PrtValue var_iter
            {
                get
                {
                    return fields[13];
                }

                set
                {
                    fields[13] = value;
                }
            }

            public PrtValue var_receivedAgree
            {
                get
                {
                    return fields[14];
                }

                set
                {
                    fields[14] = value;
                }
            }

            public PrtValue var_nextProposal
            {
                get
                {
                    return fields[15];
                }

                set
                {
                    fields[15] = value;
                }
            }

            public PrtValue var_myRank
            {
                get
                {
                    return fields[16];
                }

                set
                {
                    fields[16] = value;
                }
            }

            public PrtValue var_roundNum
            {
                get
                {
                    return fields[17];
                }

                set
                {
                    fields[17] = value;
                }
            }

            public PrtValue var_majority
            {
                get
                {
                    return fields[18];
                }

                set
                {
                    fields[18] = value;
                }
            }

            public PrtValue var_proposeVal
            {
                get
                {
                    return fields[19];
                }

                set
                {
                    fields[19] = value;
                }
            }

            public PrtValue var_commitValue
            {
                get
                {
                    return fields[20];
                }

                set
                {
                    fields[20] = value;
                }
            }

            public PrtValue var_acceptors
            {
                get
                {
                    return fields[21];
                }

                set
                {
                    fields[21] = value;
                }
            }

            public PrtValue var_leaderElectionService
            {
                get
                {
                    return fields[22];
                }

                set
                {
                    fields[22] = value;
                }
            }

            public PrtValue var_currentLeader
            {
                get
                {
                    return fields[23];
                }

                set
                {
                    fields[23] = value;
                }
            }

            public override PrtImplMachine MakeSkeleton()
            {
                return new PaxosNode();
            }

            public override int NextInstanceNumber(StateImpl app)
            {
                return app.NextMachineInstanceNumber(this.GetType());
            }

            public override string Name
            {
                get
                {
                    return "PaxosNode";
                }
            }

            public PaxosNode(): base ()
            {
            }

            public PaxosNode(StateImpl app, int maxB, bool assume): base (app, maxB, assume)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_16_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_14_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_16_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_21_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_18_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_ValmachineityCheck));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_21_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_17_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_8_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_115039180));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_ValmachineityCheck));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_10_115039180));
            }

            public class ignore_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class ignore_StackFrame : PrtFunStackFrame
                {
                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public ignore_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    ignore_StackFrame currFun = (ignore_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new ignore_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "ignore";
                }
            }

            public static ignore_Class ignore = new ignore_Class();
            public class CheckIfLeader_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class CheckIfLeader_StackFrame : PrtFunStackFrame
                {
                    public CheckIfLeader_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public CheckIfLeader_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    CheckIfLeader_StackFrame currFun = (CheckIfLeader_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto CheckIfLeader_1;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((parent).var_currentLeader)).fieldValues[0]).Clone()).Equals((parent).var_myRank)))).bl)
                        goto CheckIfLeader_if_0_else;
                    (parent).var_commitValue = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone()).Clone();
                    (parent).var_proposeVal = ((parent).var_commitValue).Clone();
                    if (!!(Events.event_goPropose).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(79,4,79,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_goPropose)).evt).name);
                    (parent).currentTrigger = Events.event_goPropose;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto CheckIfLeader_if_0_end;
                    CheckIfLeader_if_0_else:
                        ;
                    (((PrtMachineValue)((((PrtTupleValue)((parent).var_currentLeader)).fieldValues[1]).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_update), (currFun).var_payload, parent, (PrtMachineValue)((((PrtTupleValue)((parent).var_currentLeader)).fieldValues[1]).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    CheckIfLeader_1:
                        ;
                    CheckIfLeader_if_0_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new CheckIfLeader_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "CheckIfLeader";
                }
            }

            public static CheckIfLeader_Class CheckIfLeader = new CheckIfLeader_Class();
            public class UpdateAcceptors_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class UpdateAcceptors_StackFrame : PrtFunStackFrame
                {
                    public UpdateAcceptors_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public UpdateAcceptors_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    UpdateAcceptors_StackFrame currFun = (UpdateAcceptors_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto UpdateAcceptors_1;
                    }

                    (parent).var_acceptors = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone()).Clone();
                    (parent).var_majority = (new PrtIntValue(((PrtIntValue)(new PrtIntValue(((PrtIntValue)(new PrtIntValue(((parent).var_acceptors).Size()))).nt / ((PrtIntValue)(new PrtIntValue(2))).nt))).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_majority).Equals(new PrtIntValue(2))))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(67,3,67,9): error PC1001: Assert failed");
                    (parent).var_leaderElectionService = (application).CreateInterface(parent, "LeaderElection", new PrtNamedTupleValue(Types.type_3_115039180, (parent).var_acceptors, parent.self, (parent).var_myRank));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 1);
                    return;
                    UpdateAcceptors_1:
                        ;
                    if (!!(Events.event_local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(71,3,71,8): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_local)).evt).name);
                    (parent).currentTrigger = Events.event_local;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new UpdateAcceptors_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "UpdateAcceptors";
                }
            }

            public static UpdateAcceptors_Class UpdateAcceptors = new UpdateAcceptors_Class();
            public class RunReplicatedMachine_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class RunReplicatedMachine_StackFrame : PrtFunStackFrame
                {
                    public RunReplicatedMachine_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public RunReplicatedMachine_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    RunReplicatedMachine_StackFrame currFun = (RunReplicatedMachine_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    RunReplicatedMachine_loop_start_0:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(true))).bl)
                        goto RunReplicatedMachine_loop_end_0;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtMapValue)((parent).var_learnerSlots)).Contains(new PrtIntValue(((PrtIntValue)((parent).var_lastExecutedSlot)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt))))).bl)
                        goto RunReplicatedMachine_if_0_else;
                    (parent).var_lastExecutedSlot = (new PrtIntValue(((PrtIntValue)((parent).var_lastExecutedSlot)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto RunReplicatedMachine_if_0_end;
                    RunReplicatedMachine_if_0_else:
                        ;
                    (parent).PrtFunContReturn((currFun).locals);
                    return;
                    RunReplicatedMachine_if_0_end:
                        ;
                    goto RunReplicatedMachine_loop_start_0;
                    RunReplicatedMachine_loop_end_0:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new RunReplicatedMachine_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "RunReplicatedMachine";
                }
            }

            public static RunReplicatedMachine_Class RunReplicatedMachine = new RunReplicatedMachine_Class();
            public class equal_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class equal_StackFrame : PrtFunStackFrame
                {
                    public equal_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public equal_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_p1
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }

                    public PrtValue var_p2
                    {
                        get
                        {
                            return locals[1];
                        }

                        set
                        {
                            locals[1] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    equal_StackFrame currFun = (equal_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((currFun).var_p1)).fieldValues[0]).Clone()).Equals((((PrtTupleValue)((currFun).var_p2)).fieldValues[0]).Clone())))).bl && ((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((currFun).var_p1)).fieldValues[1]).Clone()).Equals((((PrtTupleValue)((currFun).var_p2)).fieldValues[1]).Clone())))).bl))).bl)
                        goto equal_if_0_else;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(true), (currFun).locals);
                    return;
                    goto equal_if_0_end;
                    equal_if_0_else:
                        ;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(false), (currFun).locals);
                    return;
                    equal_if_0_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new equal_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "equal";
                }
            }

            public static equal_Class equal = new equal_Class();
            public class lessThan_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class lessThan_StackFrame : PrtFunStackFrame
                {
                    public lessThan_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public lessThan_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_p1
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }

                    public PrtValue var_p2
                    {
                        get
                        {
                            return locals[1];
                        }

                        set
                        {
                            locals[1] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    lessThan_StackFrame currFun = (lessThan_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((currFun).var_p1)).fieldValues[0]).Clone())).nt < ((PrtIntValue)((((PrtTupleValue)((currFun).var_p2)).fieldValues[0]).Clone())).nt))).bl)
                        goto lessThan_if_5_else;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(true), (currFun).locals);
                    return;
                    goto lessThan_if_5_end;
                    lessThan_if_5_else:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((currFun).var_p1)).fieldValues[0]).Clone()).Equals((((PrtTupleValue)((currFun).var_p2)).fieldValues[0]).Clone())))).bl)
                        goto lessThan_if_4_else;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((currFun).var_p1)).fieldValues[1]).Clone())).nt < ((PrtIntValue)((((PrtTupleValue)((currFun).var_p2)).fieldValues[1]).Clone())).nt))).bl)
                        goto lessThan_if_3_else;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(true), (currFun).locals);
                    return;
                    goto lessThan_if_3_end;
                    lessThan_if_3_else:
                        ;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(false), (currFun).locals);
                    return;
                    lessThan_if_3_end:
                        ;
                    goto lessThan_if_4_end;
                    lessThan_if_4_else:
                        ;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(false), (currFun).locals);
                    return;
                    lessThan_if_4_end:
                        ;
                    lessThan_if_5_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new lessThan_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "lessThan";
                }
            }

            public static lessThan_Class lessThan = new lessThan_Class();
            public class BroadCastAcceptors_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class BroadCastAcceptors_StackFrame : PrtFunStackFrame
                {
                    public BroadCastAcceptors_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public BroadCastAcceptors_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_mess
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }

                    public PrtValue var_pay
                    {
                        get
                        {
                            return locals[1];
                        }

                        set
                        {
                            locals[1] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    BroadCastAcceptors_StackFrame currFun = (BroadCastAcceptors_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto BroadCastAcceptors_1;
                    }

                    (parent).var_iter = (new PrtIntValue(0)).Clone();
                    BroadCastAcceptors_loop_start_0:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((parent).var_iter)).nt < ((PrtIntValue)(new PrtIntValue(((parent).var_acceptors).Size()))).nt))).bl)
                        goto BroadCastAcceptors_loop_end_0;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_acceptors)).Lookup((parent).var_iter)).Clone())).mach).PrtEnqueueEvent((PrtEventValue)((currFun).var_mess), (currFun).var_pay, parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_acceptors)).Lookup((parent).var_iter)).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    BroadCastAcceptors_1:
                        ;
                    (parent).var_iter = (new PrtIntValue(((PrtIntValue)((parent).var_iter)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto BroadCastAcceptors_loop_start_0;
                    BroadCastAcceptors_loop_end_0:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new BroadCastAcceptors_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "BroadCastAcceptors";
                }
            }

            public static BroadCastAcceptors_Class BroadCastAcceptors = new BroadCastAcceptors_Class();
            public class getHighestProposedValue_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class getHighestProposedValue_StackFrame : PrtFunStackFrame
                {
                    public getHighestProposedValue_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public getHighestProposedValue_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    getHighestProposedValue_StackFrame currFun = (getHighestProposedValue_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(!((((PrtTupleValue)((parent).var_receivedAgree)).fieldValues[1]).Clone()).Equals(new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt))))).bl)
                        goto getHighestProposedValue_if_0_else;
                    (parent).var_currCommitOperation = (new PrtBoolValue(false)).Clone();
                    (parent).PrtFunContReturnVal((((PrtTupleValue)((parent).var_receivedAgree)).fieldValues[1]).Clone(), (currFun).locals);
                    return;
                    goto getHighestProposedValue_if_0_end;
                    getHighestProposedValue_if_0_else:
                        ;
                    (parent).var_currCommitOperation = (new PrtBoolValue(true)).Clone();
                    (parent).PrtFunContReturnVal((parent).var_commitValue, (currFun).locals);
                    return;
                    getHighestProposedValue_if_0_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new getHighestProposedValue_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "getHighestProposedValue";
                }
            }

            public static getHighestProposedValue_Class getHighestProposedValue = new getHighestProposedValue_Class();
            public class preparefun_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class preparefun_StackFrame : PrtFunStackFrame
                {
                    public preparefun_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public preparefun_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_receivedMess_2
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    preparefun_StackFrame currFun = (preparefun_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto preparefun_1;
                        case 2:
                            goto preparefun_2;
                        case 3:
                            goto preparefun_3;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)(new PrtBoolValue(((PrtMapValue)((parent).var_acceptorSlots)).Contains((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone())))).bl))).bl)
                        goto preparefun_if_0_else;
                    (((PrtMachineValue)((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[0]).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_agree), new PrtNamedTupleValue(Types.type_18_115039180, (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone(), new PrtNamedTupleValue(Types.type_8_115039180, new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt), new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt)), new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt)), parent, (PrtMachineValue)((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[0]).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    preparefun_1:
                        ;
                    ((PrtMapValue)((parent).var_acceptorSlots)).Update((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone(), (new PrtNamedTupleValue(Types.type_17_115039180, (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[2]).Clone(), new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt))).Clone());
                    (parent).PrtFunContReturn((currFun).locals);
                    return;
                    goto preparefun_if_0_end;
                    preparefun_if_0_else:
                        ;
                    preparefun_if_0_end:
                        ;
                    (parent).var_returnVal = ((lessThan).ExecuteToCompletion(application, parent, (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[2]).Clone(), (((PrtTupleValue)((((PrtMapValue)((parent).var_acceptorSlots)).Lookup((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone())).Clone())).fieldValues[0]).Clone())).Clone();
                    if (!((PrtBoolValue)((parent).var_returnVal)).bl)
                        goto preparefun_if_1_else;
                    (((PrtMachineValue)((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[0]).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_reject), new PrtNamedTupleValue(Types.type_19_115039180, (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone(), (((PrtTupleValue)((((PrtMapValue)((parent).var_acceptorSlots)).Lookup((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone())).Clone())).fieldValues[0]).Clone()), parent, (PrtMachineValue)((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[0]).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    preparefun_2:
                        ;
                    goto preparefun_if_1_end;
                    preparefun_if_1_else:
                        ;
                    (((PrtMachineValue)((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[0]).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_agree), new PrtNamedTupleValue(Types.type_18_115039180, (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone(), (((PrtTupleValue)((((PrtMapValue)((parent).var_acceptorSlots)).Lookup((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone())).Clone())).fieldValues[0]).Clone(), (((PrtTupleValue)((((PrtMapValue)((parent).var_acceptorSlots)).Lookup((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone())).Clone())).fieldValues[1]).Clone()), parent, (PrtMachineValue)((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[0]).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 3);
                    return;
                    preparefun_3:
                        ;
                    ((PrtMapValue)((parent).var_acceptorSlots)).Update((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone(), (new PrtNamedTupleValue(Types.type_17_115039180, (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[2]).Clone(), new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt))).Clone());
                    preparefun_if_1_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new preparefun_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "preparefun";
                }
            }

            public static preparefun_Class preparefun = new preparefun_Class();
            public class GetNextProposal_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class GetNextProposal_StackFrame : PrtFunStackFrame
                {
                    public GetNextProposal_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public GetNextProposal_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_maxRound
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    GetNextProposal_StackFrame currFun = (GetNextProposal_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).PrtFunContReturnVal(new PrtNamedTupleValue(Types.type_8_115039180, new PrtIntValue(((PrtIntValue)((currFun).var_maxRound)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt), (parent).var_myRank), (currFun).locals);
                    return;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new GetNextProposal_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "GetNextProposal";
                }
            }

            public static GetNextProposal_Class GetNextProposal = new GetNextProposal_Class();
            public class acceptfun_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class acceptfun_StackFrame : PrtFunStackFrame
                {
                    public acceptfun_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public acceptfun_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_receivedMess_2
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    acceptfun_StackFrame currFun = (acceptfun_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto acceptfun_1;
                        case 2:
                            goto acceptfun_2;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtMapValue)((parent).var_acceptorSlots)).Contains((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone())))).bl)
                        goto acceptfun_if_1_else;
                    (parent).var_returnVal = ((equal).ExecuteToCompletion(application, parent, (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[2]).Clone(), (((PrtTupleValue)((((PrtMapValue)((parent).var_acceptorSlots)).Lookup((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone())).Clone())).fieldValues[0]).Clone())).Clone();
                    if (!((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)((parent).var_returnVal)).bl))).bl)
                        goto acceptfun_if_0_else;
                    (((PrtMachineValue)((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[0]).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_reject), new PrtNamedTupleValue(Types.type_19_115039180, (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone(), (((PrtTupleValue)((((PrtMapValue)((parent).var_acceptorSlots)).Lookup((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone())).Clone())).fieldValues[0]).Clone()), parent, (PrtMachineValue)((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[0]).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    acceptfun_1:
                        ;
                    goto acceptfun_if_0_end;
                    acceptfun_if_0_else:
                        ;
                    ((PrtMapValue)((parent).var_acceptorSlots)).Update((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone(), (new PrtNamedTupleValue(Types.type_17_115039180, (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[2]).Clone(), (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[3]).Clone())).Clone());
                    (((PrtMachineValue)((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[0]).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_accepted), new PrtNamedTupleValue(Types.type_18_115039180, (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[1]).Clone(), (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[2]).Clone(), (((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[3]).Clone()), parent, (PrtMachineValue)((((PrtTupleValue)((currFun).var_receivedMess_2)).fieldValues[0]).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    acceptfun_2:
                        ;
                    acceptfun_if_0_end:
                        ;
                    goto acceptfun_if_1_end;
                    acceptfun_if_1_else:
                        ;
                    acceptfun_if_1_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new acceptfun_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "acceptfun";
                }
            }

            public static acceptfun_Class acceptfun = new acceptfun_Class();
            public class CountAccepted_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class CountAccepted_StackFrame : PrtFunStackFrame
                {
                    public CountAccepted_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public CountAccepted_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_receivedMess_1
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    CountAccepted_StackFrame currFun = (CountAccepted_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto CountAccepted_1;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((currFun).var_receivedMess_1)).fieldValues[0]).Clone()).Equals((parent).var_nextSlotForProposer)))).bl)
                        goto CountAccepted_if_2_else;
                    (parent).var_returnVal = ((equal).ExecuteToCompletion(application, parent, (((PrtTupleValue)((currFun).var_receivedMess_1)).fieldValues[1]).Clone(), (parent).var_nextProposal)).Clone();
                    if (!((PrtBoolValue)((parent).var_returnVal)).bl)
                        goto CountAccepted_if_0_else;
                    (parent).var_countAccept = (new PrtIntValue(((PrtIntValue)((parent).var_countAccept)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto CountAccepted_if_0_end;
                    CountAccepted_if_0_else:
                        ;
                    CountAccepted_if_0_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_countAccept).Equals((parent).var_majority)))).bl)
                        goto CountAccepted_if_1_else;
                    (application).Announce((PrtEventValue)(Events.event_announce_valueChosen), new PrtNamedTupleValue(Types.type_14_115039180, parent.self, (parent).var_nextSlotForProposer, (parent).var_nextProposal, (parent).var_proposeVal), parent);
                    (((PrtMachineValue)((parent).var_timer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_cancelTimer), Events.@null, parent, (PrtMachineValue)((parent).var_timer));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    CountAccepted_1:
                        ;
                    (application).Announce((PrtEventValue)(Events.event_announce_proposer_chosen), (parent).var_proposeVal, parent);
                    (parent).var_nextSlotForProposer = (new PrtIntValue(((PrtIntValue)((parent).var_nextSlotForProposer)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    if (!!(Events.event_chosen).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(242,5,242,10): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_chosen)).evt).name);
                    (parent).currentTrigger = Events.event_chosen;
                    (parent).currentPayload = (currFun).var_receivedMess_1;
                    (parent).PrtFunContRaise();
                    return;
                    goto CountAccepted_if_1_end;
                    CountAccepted_if_1_else:
                        ;
                    CountAccepted_if_1_end:
                        ;
                    goto CountAccepted_if_2_end;
                    CountAccepted_if_2_else:
                        ;
                    CountAccepted_if_2_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new CountAccepted_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "CountAccepted";
                }
            }

            public static CountAccepted_Class CountAccepted = new CountAccepted_Class();
            public class AnonFun0_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun0_StackFrame : PrtFunStackFrame
                {
                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun0_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun0_StackFrame currFun = (AnonFun0_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun0_1;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((parent).var_nextProposal)).fieldValues[0]).Clone())).nt <= ((PrtIntValue)((((PrtTupleValue)((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone())).fieldValues[0]).Clone())).nt))).bl)
                        goto AnonFun0_if_1_else;
                    (parent).var_maxRound = ((((PrtTupleValue)((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone())).fieldValues[0]).Clone()).Clone();
                    goto AnonFun0_if_1_end;
                    AnonFun0_if_1_else:
                        ;
                    AnonFun0_if_1_end:
                        ;
                    (((PrtMachineValue)((parent).var_timer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_cancelTimer), Events.@null, parent, (PrtMachineValue)((parent).var_timer));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun0_1:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun0_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun0";
                }
            }

            public static AnonFun0_Class AnonFun0 = new AnonFun0_Class();
            public class AnonFun1_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun1_StackFrame : PrtFunStackFrame
                {
                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun1_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_receivedMess_1
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun1_StackFrame currFun = (AnonFun1_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun1_1;
                    }

                    ((PrtMapValue)((parent).var_learnerSlots)).Update((((PrtTupleValue)((currFun).var_receivedMess_1)).fieldValues[0]).Clone(), (new PrtNamedTupleValue(Types.type_17_115039180, (((PrtTupleValue)((currFun).var_receivedMess_1)).fieldValues[1]).Clone(), (((PrtTupleValue)((currFun).var_receivedMess_1)).fieldValues[2]).Clone())).Clone());
                    (parent).PrtPushFunStackFrame(RunReplicatedMachine, (RunReplicatedMachine).CreateLocals());
                    AnonFun1_1:
                        ;
                    (RunReplicatedMachine).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtBoolValue)((parent).var_currCommitOperation)).bl && ((PrtBoolValue)(new PrtBoolValue(((parent).var_commitValue).Equals((((PrtTupleValue)((currFun).var_receivedMess_1)).fieldValues[2]).Clone())))).bl))).bl)
                        goto AnonFun1_if_0_else;
                    (parent).currentTrigger = Events.@null;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContPop();
                    return;
                    goto AnonFun1_if_0_end;
                    AnonFun1_if_0_else:
                        ;
                    (parent).var_proposeVal = ((parent).var_commitValue).Clone();
                    if (!!(Events.event_goPropose).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(319,5,319,10): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_goPropose)).evt).name);
                    (parent).currentTrigger = Events.event_goPropose;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    AnonFun1_if_0_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun1_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun1";
                }
            }

            public static AnonFun1_Class AnonFun1 = new AnonFun1_Class();
            public class AnonFun2_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun2_StackFrame : PrtFunStackFrame
                {
                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun2_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_receivedMess
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun2_StackFrame currFun = (AnonFun2_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((currFun).var_receivedMess)).fieldValues[0]).Clone()).Equals((parent).var_nextSlotForProposer)))).bl)
                        goto AnonFun2_if_2_else;
                    (parent).var_countAgree = (new PrtIntValue(((PrtIntValue)((parent).var_countAgree)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    (parent).var_returnVal = ((lessThan).ExecuteToCompletion(application, parent, (((PrtTupleValue)((parent).var_receivedAgree)).fieldValues[0]).Clone(), (((PrtTupleValue)((currFun).var_receivedMess)).fieldValues[1]).Clone())).Clone();
                    if (!((PrtBoolValue)((parent).var_returnVal)).bl)
                        goto AnonFun2_if_0_else;
                    ((PrtTupleValue)((parent).var_receivedAgree)).Update(0, ((((PrtTupleValue)((currFun).var_receivedMess)).fieldValues[1]).Clone()).Clone());
                    ((PrtTupleValue)((parent).var_receivedAgree)).Update(1, ((((PrtTupleValue)((currFun).var_receivedMess)).fieldValues[2]).Clone()).Clone());
                    goto AnonFun2_if_0_end;
                    AnonFun2_if_0_else:
                        ;
                    AnonFun2_if_0_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_countAgree).Equals((parent).var_majority)))).bl)
                        goto AnonFun2_if_1_else;
                    if (!!(Events.event_success).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\multi_paxos_4\\\\multi_paxos_4.p(209,6,209,11): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_success)).evt).name);
                    (parent).currentTrigger = Events.event_success;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto AnonFun2_if_1_end;
                    AnonFun2_if_1_else:
                        ;
                    AnonFun2_if_1_end:
                        ;
                    goto AnonFun2_if_2_end;
                    AnonFun2_if_2_else:
                        ;
                    AnonFun2_if_2_end:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun2_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun2";
                }
            }

            public static AnonFun2_Class AnonFun2 = new AnonFun2_Class();
            public class AnonFun3_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun3_StackFrame : PrtFunStackFrame
                {
                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun3_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun3_StackFrame currFun = (AnonFun3_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun3_1;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((parent).var_nextProposal)).fieldValues[0]).Clone())).nt <= ((PrtIntValue)((((PrtTupleValue)((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone())).fieldValues[0]).Clone())).nt))).bl)
                        goto AnonFun3_if_0_else;
                    (parent).var_maxRound = ((((PrtTupleValue)((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone())).fieldValues[0]).Clone()).Clone();
                    goto AnonFun3_if_0_end;
                    AnonFun3_if_0_else:
                        ;
                    AnonFun3_if_0_end:
                        ;
                    (((PrtMachineValue)((parent).var_timer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_cancelTimer), Events.@null, parent, (PrtMachineValue)((parent).var_timer));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun3_1:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun3_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun3";
                }
            }

            public static AnonFun3_Class AnonFun3 = new AnonFun3_Class();
            public class AnonFun4_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun4_StackFrame : PrtFunStackFrame
                {
                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun4_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun4_StackFrame currFun = (AnonFun4_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_currentLeader = ((currFun).var_payload).Clone();
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun4_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun4";
                }
            }

            public static AnonFun4_Class AnonFun4 = new AnonFun4_Class();
            public class AnonFun5_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun5_StackFrame : PrtFunStackFrame
                {
                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun5_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun5_StackFrame currFun = (AnonFun5_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun5_1;
                    }

                    (parent).PrtPushFunStackFrame(CountAccepted, (CountAccepted).CreateLocals((currFun).var_payload));
                    AnonFun5_1:
                        ;
                    (CountAccepted).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun5_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun5";
                }
            }

            public static AnonFun5_Class AnonFun5 = new AnonFun5_Class();
            public class AnonFun6_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun6_StackFrame : PrtFunStackFrame
                {
                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun6_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun6_StackFrame currFun = (AnonFun6_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun6_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun6";
                }
            }

            public static AnonFun6_Class AnonFun6 = new AnonFun6_Class();
            public class AnonFun7_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun7_StackFrame : PrtFunStackFrame
                {
                    public AnonFun7_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun7_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun7_StackFrame currFun = (AnonFun7_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun7_1;
                    }

                    (parent).PrtPushFunStackFrame(preparefun, (preparefun).CreateLocals((currFun).var_payload));
                    AnonFun7_1:
                        ;
                    (preparefun).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun7_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun7";
                }
            }

            public static AnonFun7_Class AnonFun7 = new AnonFun7_Class();
            public class AnonFun8_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun8_StackFrame : PrtFunStackFrame
                {
                    public AnonFun8_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun8_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun8_StackFrame currFun = (AnonFun8_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun8_1;
                    }

                    (parent).PrtPushFunStackFrame(acceptfun, (acceptfun).CreateLocals((currFun).var_payload));
                    AnonFun8_1:
                        ;
                    (acceptfun).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun8_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun8";
                }
            }

            public static AnonFun8_Class AnonFun8 = new AnonFun8_Class();
            public class AnonFun9_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun9_StackFrame : PrtFunStackFrame
                {
                    public AnonFun9_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun9_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun9_StackFrame currFun = (AnonFun9_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun9_1;
                    }

                    (((PrtMachineValue)((parent).var_leaderElectionService)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Ping), (currFun).var_payload, parent, (PrtMachineValue)((parent).var_leaderElectionService));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun9_1:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun9_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun9";
                }
            }

            public static AnonFun9_Class AnonFun9 = new AnonFun9_Class();
            public class AnonFun10_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun10_StackFrame : PrtFunStackFrame
                {
                    public AnonFun10_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun10_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun10_StackFrame currFun = (AnonFun10_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun10_1;
                        case 2:
                            goto AnonFun10_2;
                    }

                    (parent).var_countAgree = (new PrtIntValue(0)).Clone();
                    (parent).var_nextProposal = ((GetNextProposal).ExecuteToCompletion(application, parent, (parent).var_maxRound)).Clone();
                    (parent).var_receivedAgree = (new PrtNamedTupleValue(Types.type_17_115039180, new PrtNamedTupleValue(Types.type_8_115039180, new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt), new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt)), new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt))).Clone();
                    (parent).PrtPushFunStackFrame(BroadCastAcceptors, (BroadCastAcceptors).CreateLocals(Events.event_prepare, new PrtNamedTupleValue(Types.type_15_115039180, parent.self, (parent).var_nextSlotForProposer, new PrtNamedTupleValue(Types.type_8_115039180, (((PrtTupleValue)((parent).var_nextProposal)).fieldValues[0]).Clone(), (parent).var_myRank))));
                    AnonFun10_1:
                        ;
                    (BroadCastAcceptors).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    (application).Announce((PrtEventValue)(Events.event_announce_proposer_sent), (parent).var_proposeVal, parent);
                    (((PrtMachineValue)((parent).var_timer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_startTimer), Events.@null, parent, (PrtMachineValue)((parent).var_timer));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    AnonFun10_2:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun10_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun10";
                }
            }

            public static AnonFun10_Class AnonFun10 = new AnonFun10_Class();
            public class AnonFun11_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun11_StackFrame : PrtFunStackFrame
                {
                    public AnonFun11_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun11_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_1
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun11_StackFrame currFun = (AnonFun11_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun11_1;
                        case 2:
                            goto AnonFun11_2;
                        case 3:
                            goto AnonFun11_3;
                    }

                    (parent).var_countAccept = (new PrtIntValue(0)).Clone();
                    (parent).PrtPushFunStackFrame(getHighestProposedValue, (getHighestProposedValue).CreateLocals());
                    AnonFun11_1:
                        ;
                    (getHighestProposedValue).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                        (parent).var_proposeVal = ((parent).continuation).retVal;
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    (application).Announce((PrtEventValue)(Events.event_announce_valueProposed), new PrtNamedTupleValue(Types.type_14_115039180, parent.self, (parent).var_nextSlotForProposer, (parent).var_nextProposal, (parent).var_proposeVal), parent);
                    (application).Announce((PrtEventValue)(Events.event_announce_proposer_sent), (parent).var_proposeVal, parent);
                    (parent).PrtPushFunStackFrame(BroadCastAcceptors, (BroadCastAcceptors).CreateLocals(Events.event_accept, new PrtNamedTupleValue(Types.type_14_115039180, parent.self, (parent).var_nextSlotForProposer, (parent).var_nextProposal, (parent).var_proposeVal)));
                    AnonFun11_2:
                        ;
                    (BroadCastAcceptors).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 2);
                        return;
                    }

                    (((PrtMachineValue)((parent).var_timer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_startTimer), Events.@null, parent, (PrtMachineValue)((parent).var_timer));
                    (parent).PrtFunContSend(this, (currFun).locals, 3);
                    return;
                    AnonFun11_3:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun11_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun11";
                }
            }

            public static AnonFun11_Class AnonFun11 = new AnonFun11_Class();
            public class AnonFun12_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun12_StackFrame : PrtFunStackFrame
                {
                    public AnonFun12_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun12_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun12_StackFrame currFun = (AnonFun12_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun12_1;
                    }

                    (parent).var_myRank = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone()).Clone();
                    (parent).var_currentLeader = (new PrtNamedTupleValue(Types.type_10_115039180, (parent).var_myRank, parent.self)).Clone();
                    (parent).var_roundNum = (new PrtIntValue(0)).Clone();
                    (parent).var_maxRound = (new PrtIntValue(0)).Clone();
                    (parent).var_timer = (application).CreateInterface(parent, "Timer", new PrtTupleValue(parent.self, new PrtIntValue(10)));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 1);
                    return;
                    AnonFun12_1:
                        ;
                    (parent).var_lastExecutedSlot = (new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    (parent).var_nextSlotForProposer = (new PrtIntValue(0)).Clone();
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun12_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun12";
                }
            }

            public static AnonFun12_Class AnonFun12 = new AnonFun12_Class();
            public class AnonFun13_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun13_StackFrame : PrtFunStackFrame
                {
                    public AnonFun13_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun13_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun13_StackFrame currFun = (AnonFun13_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun13_1;
                    }

                    (parent).PrtPushFunStackFrame(CheckIfLeader, (CheckIfLeader).CreateLocals((currFun).var_payload));
                    AnonFun13_1:
                        ;
                    (CheckIfLeader).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun13_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun13";
                }
            }

            public static AnonFun13_Class AnonFun13 = new AnonFun13_Class();
            public class AnonFun14_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun14_StackFrame : PrtFunStackFrame
                {
                    public AnonFun14_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun14_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_payload
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun14_StackFrame currFun = (AnonFun14_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun14_1;
                    }

                    (parent).PrtPushFunStackFrame(UpdateAcceptors, (UpdateAcceptors).CreateLocals((currFun).var_payload));
                    AnonFun14_1:
                        ;
                    (UpdateAcceptors).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun14_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun14";
                }
            }

            public static AnonFun14_Class AnonFun14 = new AnonFun14_Class();
            public class AnonFun15_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun15_StackFrame : PrtFunStackFrame
                {
                    public AnonFun15_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun15_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun15_StackFrame currFun = (AnonFun15_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun15_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun15";
                }
            }

            public static AnonFun15_Class AnonFun15 = new AnonFun15_Class();
            public class AnonFun16_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun16_StackFrame : PrtFunStackFrame
                {
                    public AnonFun16_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun16_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun16_StackFrame currFun = (AnonFun16_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun16_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun16";
                }
            }

            public static AnonFun16_Class AnonFun16 = new AnonFun16_Class();
            public class AnonFun17_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun17_StackFrame : PrtFunStackFrame
                {
                    public AnonFun17_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun17_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun17_StackFrame currFun = (AnonFun17_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun17_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun17";
                }
            }

            public static AnonFun17_Class AnonFun17 = new AnonFun17_Class();
            public class AnonFun18_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun18_StackFrame : PrtFunStackFrame
                {
                    public AnonFun18_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun18_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun18_StackFrame currFun = (AnonFun18_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun18_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun18";
                }
            }

            public static AnonFun18_Class AnonFun18 = new AnonFun18_Class();
            public class AnonFun19_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun19_StackFrame : PrtFunStackFrame
                {
                    public AnonFun19_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun19_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun19_StackFrame currFun = (AnonFun19_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun19_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun19";
                }
            }

            public static AnonFun19_Class AnonFun19 = new AnonFun19_Class();
            public class AnonFun20_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun20_StackFrame : PrtFunStackFrame
                {
                    public AnonFun20_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun20_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun20_StackFrame currFun = (AnonFun20_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun20_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun20";
                }
            }

            public static AnonFun20_Class AnonFun20 = new AnonFun20_Class();
            public class AnonFun21_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun21_StackFrame : PrtFunStackFrame
                {
                    public AnonFun21_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun21_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun21_StackFrame currFun = (AnonFun21_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun21_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun21";
                }
            }

            public static AnonFun21_Class AnonFun21 = new AnonFun21_Class();
            public class AnonFun22_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun22_StackFrame : PrtFunStackFrame
                {
                    public AnonFun22_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun22_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun22_StackFrame currFun = (AnonFun22_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun22_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun22";
                }
            }

            public static AnonFun22_Class AnonFun22 = new AnonFun22_Class();
            public class AnonFun23_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun23_StackFrame : PrtFunStackFrame
                {
                    public AnonFun23_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun23_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_0
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun23_StackFrame currFun = (AnonFun23_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun23_1;
                    }

                    (((PrtMachineValue)((parent).var_timer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_cancelTimer), Events.@null, parent, (PrtMachineValue)((parent).var_timer));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun23_1:
                        ;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun23_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun23";
                }
            }

            public static AnonFun23_Class AnonFun23 = new AnonFun23_Class();
            public class AnonFun24_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun24_StackFrame : PrtFunStackFrame
                {
                    public AnonFun24_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun24_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun24_StackFrame currFun = (AnonFun24_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun24_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun24";
                }
            }

            public static AnonFun24_Class AnonFun24 = new AnonFun24_Class();
            public class AnonFun25_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun25_StackFrame : PrtFunStackFrame
                {
                    public AnonFun25_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun25_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun25_StackFrame currFun = (AnonFun25_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun25_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun25";
                }
            }

            public static AnonFun25_Class AnonFun25 = new AnonFun25_Class();
            public class AnonFun26_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun26_StackFrame : PrtFunStackFrame
                {
                    public AnonFun26_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun26_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun26_StackFrame currFun = (AnonFun26_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun26_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun26";
                }
            }

            public static AnonFun26_Class AnonFun26 = new AnonFun26_Class();
            public class AnonFun27_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun27_StackFrame : PrtFunStackFrame
                {
                    public AnonFun27_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun27_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var__payload_skip
                    {
                        get
                        {
                            return locals[0];
                        }

                        set
                        {
                            locals[0] = value;
                        }
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    PaxosNode parent = (PaxosNode)(_parent);
                    AnonFun27_StackFrame currFun = (AnonFun27_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    parent.PrtFunContReturn((currFun).locals);
                }

                public override List<PrtValue> CreateLocals(params PrtValue[] args)
                {
                    var locals = new List<PrtValue>();
                    foreach (var item in args)
                    {
                        locals.Add(item.Clone());
                    }

                    return locals;
                }

                public override PrtFunStackFrame CreateFunStackFrame(List<PrtValue> locals, int retLoc)
                {
                    return new AnonFun27_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun27";
                }
            }

            public static AnonFun27_Class AnonFun27 = new AnonFun27_Class();
            public class PaxosNode_RunLearner_Class : PrtState
            {
                public PaxosNode_RunLearner_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static PaxosNode_RunLearner_Class PaxosNode_RunLearner;
            public class PaxosNode_ProposeValuePhase2_Class : PrtState
            {
                public PaxosNode_ProposeValuePhase2_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static PaxosNode_ProposeValuePhase2_Class PaxosNode_ProposeValuePhase2;
            public class PaxosNode_ProposeValuePhase1_Class : PrtState
            {
                public PaxosNode_ProposeValuePhase1_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static PaxosNode_ProposeValuePhase1_Class PaxosNode_ProposeValuePhase1;
            public class PaxosNode_PerformOperation_Class : PrtState
            {
                public PaxosNode_PerformOperation_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static PaxosNode_PerformOperation_Class PaxosNode_PerformOperation;
            public class PaxosNode_Init_Class : PrtState
            {
                public PaxosNode_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static PaxosNode_Init_Class PaxosNode_Init;
            static PaxosNode()
            {
                PaxosNode_RunLearner = new PaxosNode_RunLearner_Class("PaxosNode_RunLearner", AnonFun1, AnonFun6, false, StateTemperature.Warm);
                PaxosNode_ProposeValuePhase2 = new PaxosNode_ProposeValuePhase2_Class("PaxosNode_ProposeValuePhase2", AnonFun11, AnonFun22, false, StateTemperature.Warm);
                PaxosNode_ProposeValuePhase1 = new PaxosNode_ProposeValuePhase1_Class("PaxosNode_ProposeValuePhase1", AnonFun10, AnonFun25, false, StateTemperature.Warm);
                PaxosNode_PerformOperation = new PaxosNode_PerformOperation_Class("PaxosNode_PerformOperation", AnonFun15, AnonFun21, false, StateTemperature.Warm);
                PaxosNode_Init = new PaxosNode_Init_Class("PaxosNode_Init", AnonFun12, AnonFun20, false, StateTemperature.Warm);
                PaxosNode_RunLearner.dos.Add(Events.event_accept, PrtFun.IgnoreFun);
                PaxosNode_RunLearner.dos.Add(Events.event_reject, PrtFun.IgnoreFun);
                PaxosNode_RunLearner.dos.Add(Events.event_prepare, PrtFun.IgnoreFun);
                PaxosNode_RunLearner.dos.Add(Events.event_timeout, PrtFun.IgnoreFun);
                PaxosNode_RunLearner.dos.Add(Events.event_accepted, PrtFun.IgnoreFun);
                PaxosNode_RunLearner.dos.Add(Events.event_agree, PrtFun.IgnoreFun);
                PaxosNode_RunLearner.deferredSet.Add(Events.event_newLeader);
                PaxosNode_ProposeValuePhase2.dos.Add(Events.event_accepted, AnonFun5);
                PaxosNode_ProposeValuePhase2.dos.Add(Events.event_agree, PrtFun.IgnoreFun);
                PrtTransition transition_1 = new PrtTransition(AnonFun26, PaxosNode_ProposeValuePhase1, false);
                PaxosNode_ProposeValuePhase2.transitions.Add(Events.event_timeout, transition_1);
                PrtTransition transition_2 = new PrtTransition(AnonFun0, PaxosNode_ProposeValuePhase1, false);
                PaxosNode_ProposeValuePhase2.transitions.Add(Events.event_reject, transition_2);
                PaxosNode_ProposeValuePhase1.dos.Add(Events.event_agree, AnonFun2);
                PaxosNode_ProposeValuePhase1.dos.Add(Events.event_accepted, PrtFun.IgnoreFun);
                PrtTransition transition_3 = new PrtTransition(AnonFun24, PaxosNode_ProposeValuePhase1, false);
                PaxosNode_ProposeValuePhase1.transitions.Add(Events.event_timeout, transition_3);
                PrtTransition transition_4 = new PrtTransition(AnonFun23, PaxosNode_ProposeValuePhase2, false);
                PaxosNode_ProposeValuePhase1.transitions.Add(Events.event_success, transition_4);
                PrtTransition transition_5 = new PrtTransition(AnonFun3, PaxosNode_ProposeValuePhase1, false);
                PaxosNode_ProposeValuePhase1.transitions.Add(Events.event_reject, transition_5);
                PaxosNode_PerformOperation.dos.Add(Events.event_newLeader, AnonFun4);
                PaxosNode_PerformOperation.dos.Add(Events.event_Ping, AnonFun9);
                PaxosNode_PerformOperation.dos.Add(Events.event_accept, AnonFun8);
                PaxosNode_PerformOperation.dos.Add(Events.event_prepare, AnonFun7);
                PaxosNode_PerformOperation.dos.Add(Events.event_update, AnonFun13);
                PaxosNode_PerformOperation.dos.Add(Events.event_timeout, PrtFun.IgnoreFun);
                PaxosNode_PerformOperation.dos.Add(Events.event_accepted, PrtFun.IgnoreFun);
                PaxosNode_PerformOperation.dos.Add(Events.event_agree, PrtFun.IgnoreFun);
                PrtTransition transition_6 = new PrtTransition(PrtFun.IgnoreFun, PaxosNode_RunLearner, true);
                PaxosNode_PerformOperation.transitions.Add(Events.event_chosen, transition_6);
                PrtTransition transition_7 = new PrtTransition(PrtFun.IgnoreFun, PaxosNode_ProposeValuePhase1, true);
                PaxosNode_PerformOperation.transitions.Add(Events.event_goPropose, transition_7);
                PaxosNode_Init.dos.Add(Events.event_allNodes, AnonFun14);
                PaxosNode_Init.deferredSet.Add(Events.event_Ping);
                PrtTransition transition_8 = new PrtTransition(AnonFun19, PaxosNode_PerformOperation, false);
                PaxosNode_Init.transitions.Add(Events.event_local, transition_8);
            }
        }
    }
}

