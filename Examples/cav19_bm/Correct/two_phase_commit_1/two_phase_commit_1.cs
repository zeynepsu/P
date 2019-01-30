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
            public static PrtEventValue event_REQ_REPLICA;
            public static PrtEventValue event_RESP_REPLICA_COMMIT;
            public static PrtEventValue event_RESP_REPLICA_ABORT;
            public static PrtEventValue event_GLOBAL_ABORT;
            public static PrtEventValue event_GLOBAL_COMMIT;
            public static PrtEventValue event_WRITE_REQ;
            public static PrtEventValue event_WRITE_FAIL;
            public static PrtEventValue event_WRITE_SUCCESS;
            public static PrtEventValue event_READ_REQ_REPLICA;
            public static PrtEventValue event_READ_REQ;
            public static PrtEventValue event_READ_FAIL;
            public static PrtEventValue event_READ_SUCCESS;
            public static PrtEventValue event_REP_READ_FAIL;
            public static PrtEventValue event_REP_READ_SUCCESS;
            public static PrtEventValue event_Unit;
            public static PrtEventValue event_Timeout;
            public static PrtEventValue event_StartTimer;
            public static PrtEventValue event_CancelTimer;
            public static PrtEventValue event_CancelTimerFailure;
            public static PrtEventValue event_CancelTimerSuccess;
            public static PrtEventValue event_announce_WRITE_SUCCESS;
            public static PrtEventValue event_announce_WRITE_FAILURE;
            public static PrtEventValue event_announce_READ_SUCCESS;
            public static PrtEventValue event_announce_READ_FAILURE;
            public static PrtEventValue event_announce_UPDATE;
            public static PrtEventValue event_goEnd;
            public static PrtEventValue event_final;
            public static void Events_two_phase_commit_1()
            {
                event_REQ_REPLICA = new PrtEventValue(new PrtEvent("REQ_REPLICA", Types.type_4_14592104, PrtEvent.DefaultMaxInstances, false));
                event_RESP_REPLICA_COMMIT = new PrtEventValue(new PrtEvent("RESP_REPLICA_COMMIT", Types.type_2_14592104, PrtEvent.DefaultMaxInstances, false));
                event_RESP_REPLICA_ABORT = new PrtEventValue(new PrtEvent("RESP_REPLICA_ABORT", Types.type_2_14592104, PrtEvent.DefaultMaxInstances, false));
                event_GLOBAL_ABORT = new PrtEventValue(new PrtEvent("GLOBAL_ABORT", Types.type_2_14592104, PrtEvent.DefaultMaxInstances, false));
                event_GLOBAL_COMMIT = new PrtEventValue(new PrtEvent("GLOBAL_COMMIT", Types.type_2_14592104, PrtEvent.DefaultMaxInstances, false));
                event_WRITE_REQ = new PrtEventValue(new PrtEvent("WRITE_REQ", Types.type_3_14592104, PrtEvent.DefaultMaxInstances, false));
                event_WRITE_FAIL = new PrtEventValue(new PrtEvent("WRITE_FAIL", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
                event_WRITE_SUCCESS = new PrtEventValue(new PrtEvent("WRITE_SUCCESS", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
                event_READ_REQ_REPLICA = new PrtEventValue(new PrtEvent("READ_REQ_REPLICA", Types.type_2_14592104, PrtEvent.DefaultMaxInstances, false));
                event_READ_REQ = new PrtEventValue(new PrtEvent("READ_REQ", Types.type_8_14592104, PrtEvent.DefaultMaxInstances, false));
                event_READ_FAIL = new PrtEventValue(new PrtEvent("READ_FAIL", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
                event_READ_SUCCESS = new PrtEventValue(new PrtEvent("READ_SUCCESS", Types.type_2_14592104, PrtEvent.DefaultMaxInstances, false));
                event_REP_READ_FAIL = new PrtEventValue(new PrtEvent("REP_READ_FAIL", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
                event_REP_READ_SUCCESS = new PrtEventValue(new PrtEvent("REP_READ_SUCCESS", Types.type_2_14592104, PrtEvent.DefaultMaxInstances, false));
                event_Unit = new PrtEventValue(new PrtEvent("Unit", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
                event_Timeout = new PrtEventValue(new PrtEvent("Timeout", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
                event_StartTimer = new PrtEventValue(new PrtEvent("StartTimer", Types.type_2_14592104, PrtEvent.DefaultMaxInstances, false));
                event_CancelTimer = new PrtEventValue(new PrtEvent("CancelTimer", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
                event_CancelTimerFailure = new PrtEventValue(new PrtEvent("CancelTimerFailure", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
                event_CancelTimerSuccess = new PrtEventValue(new PrtEvent("CancelTimerSuccess", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
                event_announce_WRITE_SUCCESS = new PrtEventValue(new PrtEvent("announce_WRITE_SUCCESS", Types.type_1_14592104, PrtEvent.DefaultMaxInstances, false));
                event_announce_WRITE_FAILURE = new PrtEventValue(new PrtEvent("announce_WRITE_FAILURE", Types.type_1_14592104, PrtEvent.DefaultMaxInstances, false));
                event_announce_READ_SUCCESS = new PrtEventValue(new PrtEvent("announce_READ_SUCCESS", Types.type_1_14592104, PrtEvent.DefaultMaxInstances, false));
                event_announce_READ_FAILURE = new PrtEventValue(new PrtEvent("announce_READ_FAILURE", Types.type_Replica, PrtEvent.DefaultMaxInstances, false));
                event_announce_UPDATE = new PrtEventValue(new PrtEvent("announce_UPDATE", Types.type_1_14592104, PrtEvent.DefaultMaxInstances, false));
                event_goEnd = new PrtEventValue(new PrtEvent("goEnd", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
                event_final = new PrtEventValue(new PrtEvent("final", Types.type_14_14592104, PrtEvent.DefaultMaxInstances, false));
            }
        }

        public partial class Types
        {
            public static PrtType type_Replica;
            public static PrtType type_2_14592104;
            public static PrtType type_1_14592104;
            public static PrtType type_3_14592104;
            public static PrtType type_4_14592104;
            public static PrtType type_6_14592104;
            public static PrtType type_5_14592104;
            public static PrtType type_7_14592104;
            public static PrtType type_8_14592104;
            public static PrtType type_9_14592104;
            public static PrtType type_10_14592104;
            public static PrtType type_11_14592104;
            public static PrtType type_12_14592104;
            public static PrtType type_13_14592104;
            public static PrtType type_14_14592104;
            public static PrtType type_Timer;
            public static PrtType type_Main;
            public static PrtType type_Client;
            public static PrtType type_Coordinator;
            static public void Types_two_phase_commit_1()
            {
                Types.type_Replica = new PrtMachineType();
                Types.type_2_14592104 = new PrtIntType();
                Types.type_1_14592104 = new PrtNamedTupleType(new object[]{"m", Types.type_Replica, "key", Types.type_2_14592104, "val", Types.type_2_14592104});
                Types.type_3_14592104 = new PrtNamedTupleType(new object[]{"client", Types.type_Replica, "key", Types.type_2_14592104, "val", Types.type_2_14592104});
                Types.type_4_14592104 = new PrtNamedTupleType(new object[]{"seqNum", Types.type_2_14592104, "key", Types.type_2_14592104, "val", Types.type_2_14592104});
                Types.type_6_14592104 = new PrtBoolType();
                Types.type_5_14592104 = new PrtTupleType(new PrtType[]{Types.type_6_14592104, Types.type_2_14592104});
                Types.type_7_14592104 = new PrtTupleType(new PrtType[]{Types.type_Replica, Types.type_2_14592104});
                Types.type_8_14592104 = new PrtNamedTupleType(new object[]{"client", Types.type_Replica, "key", Types.type_2_14592104});
                Types.type_9_14592104 = new PrtSeqType(Types.type_Replica);
                Types.type_10_14592104 = new PrtAnyType();
                Types.type_11_14592104 = new PrtMapType(Types.type_2_14592104, Types.type_2_14592104);
                Types.type_12_14592104 = new PrtTupleType(new PrtType[]{Types.type_2_14592104, Types.type_Replica});
                Types.type_13_14592104 = new PrtEventType();
                Types.type_14_14592104 = new PrtNullType();
                Types.type_Timer = Types.type_Replica;
                Types.type_Main = Types.type_Replica;
                Types.type_Client = Types.type_Replica;
                Types.type_Coordinator = Types.type_Replica;
            }
        }

        public static PrtImplMachine CreateMachine_Main(StateImpl application, PrtValue payload)
        {
            var machine = new Main(application, PrtImplMachine.DefaultMaxBufferSize, false);
            ((machine).self).permissions = null;
            (machine).sends = null;
            (machine).currentPayload = payload;
            return machine;
        }

        public static PrtImplMachine CreateMachine_Client(StateImpl application, PrtValue payload)
        {
            var machine = new Client(application, PrtImplMachine.DefaultMaxBufferSize, false);
            ((machine).self).permissions = null;
            (machine).sends = null;
            (machine).currentPayload = payload;
            return machine;
        }

        public static PrtImplMachine CreateMachine_Coordinator(StateImpl application, PrtValue payload)
        {
            var machine = new Coordinator(application, PrtImplMachine.DefaultMaxBufferSize, false);
            ((machine).self).permissions = null;
            (machine).sends = null;
            (machine).currentPayload = payload;
            return machine;
        }

        public static PrtImplMachine CreateMachine_Replica(StateImpl application, PrtValue payload)
        {
            var machine = new Replica(application, PrtImplMachine.DefaultMaxBufferSize, false);
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

        public class Main : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return Main_Init;
                }
            }

            public PrtValue var_c2
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

            public PrtValue var_c1
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

            public PrtValue var_coordinator
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
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Replica));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Replica));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Replica));
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
                    }

                    (parent).var_coordinator = (application).CreateInterface(parent, "Coordinator", new PrtIntValue(2));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 1);
                    return;
                    AnonFun1_1:
                        ;
                    (parent).var_c1 = (application).CreateInterface(parent, "Client", new PrtTupleValue((parent).var_coordinator, new PrtIntValue(100)));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 2);
                    return;
                    AnonFun1_2:
                        ;
                    (parent).var_c2 = (application).CreateInterface(parent, "Client", new PrtTupleValue((parent).var_coordinator, new PrtIntValue(200)));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 3);
                    return;
                    AnonFun1_3:
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

        public class Client : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return Client_Init;
                }
            }

            public PrtValue var_counter
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

            public PrtValue var_mydata
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

            public PrtValue var_coordinator
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
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Replica));
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
                    AnonFun6_StackFrame currFun = (AnonFun6_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_coordinator = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone()).Clone();
                    (parent).var_mydata = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone()).Clone();
                    (parent).var_counter = (new PrtIntValue(0)).Clone();
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(272,4,272,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Unit)).evt).name);
                    (parent).currentTrigger = Events.event_Unit;
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
                    Client parent = (Client)(_parent);
                    AnonFun7_StackFrame currFun = (AnonFun7_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun7_1;
                    }

                    (parent).var_mydata = (new PrtIntValue(((PrtIntValue)((parent).var_mydata)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    (parent).var_counter = (new PrtIntValue(((PrtIntValue)((parent).var_counter)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_counter).Equals(new PrtIntValue(3))))).bl)
                        goto AnonFun7_if_0_else;
                    if (!!(Events.event_goEnd).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(283,5,283,10): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_goEnd)).evt).name);
                    (parent).currentTrigger = Events.event_goEnd;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto AnonFun7_if_0_end;
                    AnonFun7_if_0_else:
                        ;
                    AnonFun7_if_0_end:
                        ;
                    (((PrtMachineValue)((parent).var_coordinator)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_WRITE_REQ), new PrtNamedTupleValue(Types.type_3_14592104, parent.self, (parent).var_mydata, (parent).var_mydata), parent, (PrtMachineValue)((parent).var_coordinator));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun7_1:
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
                    Client parent = (Client)(_parent);
                    AnonFun9_StackFrame currFun = (AnonFun9_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun9_1;
                    }

                    (((PrtMachineValue)((parent).var_coordinator)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_READ_REQ), new PrtNamedTupleValue(Types.type_8_14592104, parent.self, (parent).var_mydata), parent, (PrtMachineValue)((parent).var_coordinator));
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
                    AnonFun14_StackFrame currFun = (AnonFun14_StackFrame)(parent.PrtPopFunStackFrame());
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
                    Client parent = (Client)(_parent);
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
                    Client parent = (Client)(_parent);
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
            public class Client_DoRead_Class : PrtState
            {
                public Client_DoRead_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Client_DoRead_Class Client_DoRead;
            public class Client_DoWrite_Class : PrtState
            {
                public Client_DoWrite_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Client_DoWrite_Class Client_DoWrite;
            public class Client_Init_Class : PrtState
            {
                public Client_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Client_Init_Class Client_Init;
            public class Client_End_Class : PrtState
            {
                public Client_End_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Client_End_Class Client_End;
            static Client()
            {
                Client_DoRead = new Client_DoRead_Class("Client_DoRead", AnonFun9, AnonFun8, false, StateTemperature.Warm);
                Client_DoWrite = new Client_DoWrite_Class("Client_DoWrite", AnonFun7, AnonFun10, false, StateTemperature.Warm);
                Client_Init = new Client_Init_Class("Client_Init", AnonFun6, AnonFun1, false, StateTemperature.Warm);
                Client_End = new Client_End_Class("Client_End", AnonFun4, AnonFun5, false, StateTemperature.Warm);
                PrtTransition transition_1 = new PrtTransition(AnonFun12, Client_DoWrite, false);
                Client_DoRead.transitions.Add(Events.event_READ_SUCCESS, transition_1);
                PrtTransition transition_2 = new PrtTransition(AnonFun11, Client_DoWrite, false);
                Client_DoRead.transitions.Add(Events.event_READ_FAIL, transition_2);
                PrtTransition transition_3 = new PrtTransition(AnonFun13, Client_End, false);
                Client_DoWrite.transitions.Add(Events.event_goEnd, transition_3);
                PrtTransition transition_4 = new PrtTransition(AnonFun3, Client_DoRead, false);
                Client_DoWrite.transitions.Add(Events.event_WRITE_SUCCESS, transition_4);
                PrtTransition transition_5 = new PrtTransition(AnonFun2, Client_DoRead, false);
                Client_DoWrite.transitions.Add(Events.event_WRITE_FAIL, transition_5);
                PrtTransition transition_6 = new PrtTransition(AnonFun0, Client_DoWrite, false);
                Client_Init.transitions.Add(Events.event_Unit, transition_6);
            }
        }

        public class Coordinator : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return Coordinator_Init;
                }
            }

            public PrtValue var_readResult
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

            public PrtValue var_key
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

            public PrtValue var_client
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

            public PrtValue var_timer
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

            public PrtValue var_currSeqNum
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

            public PrtValue var_replica
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

            public PrtValue var_pendingWriteReq
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

            public PrtValue var_i
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

            public PrtValue var_numReplicas
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

            public PrtValue var_replicas
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

            public PrtValue var_dataValues
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

            public override PrtImplMachine MakeSkeleton()
            {
                return new Coordinator();
            }

            public override int NextInstanceNumber(StateImpl app)
            {
                return app.NextMachineInstanceNumber(this.GetType());
            }

            public override string Name
            {
                get
                {
                    return "Coordinator";
                }
            }

            public Coordinator(): base ()
            {
            }

            public Coordinator(StateImpl app, int maxB, bool assume): base (app, maxB, assume)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_5_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Replica));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Replica));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Replica));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_3_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_9_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_11_14592104));
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
                    Coordinator parent = (Coordinator)(_parent);
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
            public class DoWrite_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class DoWrite_StackFrame : PrtFunStackFrame
                {
                    public DoWrite_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public DoWrite_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_pendingWriteReq
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
                    Coordinator parent = (Coordinator)(_parent);
                    DoWrite_StackFrame currFun = (DoWrite_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto DoWrite_1;
                        case 2:
                            goto DoWrite_2;
                    }

                    (parent).var_currSeqNum = (new PrtIntValue(((PrtIntValue)((parent).var_currSeqNum)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    (parent).var_i = (new PrtIntValue(0)).Clone();
                    DoWrite_loop_start_0:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((parent).var_i)).nt < ((PrtIntValue)(new PrtIntValue(((parent).var_replicas).Size()))).nt))).bl)
                        goto DoWrite_loop_end_0;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_replicas)).Lookup((parent).var_i)).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_REQ_REPLICA), new PrtNamedTupleValue(Types.type_4_14592104, (parent).var_currSeqNum, (((PrtTupleValue)((currFun).var_pendingWriteReq)).fieldValues[1]).Clone(), (((PrtTupleValue)((currFun).var_pendingWriteReq)).fieldValues[2]).Clone()), parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_replicas)).Lookup((parent).var_i)).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    DoWrite_1:
                        ;
                    (parent).var_i = (new PrtIntValue(((PrtIntValue)((parent).var_i)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto DoWrite_loop_start_0;
                    DoWrite_loop_end_0:
                        ;
                    (((PrtMachineValue)((parent).var_timer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_StartTimer), new PrtIntValue(100), parent, (PrtMachineValue)((parent).var_timer));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    DoWrite_2:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(193,3,193,8): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Unit)).evt).name);
                    (parent).currentTrigger = Events.event_Unit;
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
                    return new DoWrite_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "DoWrite";
                }
            }

            public static DoWrite_Class DoWrite = new DoWrite_Class();
            public class DoGlobalAbort_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class DoGlobalAbort_StackFrame : PrtFunStackFrame
                {
                    public DoGlobalAbort_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public DoGlobalAbort_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Coordinator parent = (Coordinator)(_parent);
                    DoGlobalAbort_StackFrame currFun = (DoGlobalAbort_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto DoGlobalAbort_1;
                        case 2:
                            goto DoGlobalAbort_2;
                    }

                    (parent).var_i = (new PrtIntValue(0)).Clone();
                    DoGlobalAbort_loop_start_0:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((parent).var_i)).nt < ((PrtIntValue)(new PrtIntValue(((parent).var_replicas).Size()))).nt))).bl)
                        goto DoGlobalAbort_loop_end_0;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_replicas)).Lookup((parent).var_i)).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_GLOBAL_ABORT), (parent).var_currSeqNum, parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_replicas)).Lookup((parent).var_i)).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    DoGlobalAbort_1:
                        ;
                    (parent).var_i = (new PrtIntValue(((PrtIntValue)((parent).var_i)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto DoGlobalAbort_loop_start_0;
                    DoGlobalAbort_loop_end_0:
                        ;
                    (((PrtMachineValue)((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_WRITE_FAIL), Events.@null, parent, (PrtMachineValue)((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    DoGlobalAbort_2:
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
                    return new DoGlobalAbort_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "DoGlobalAbort";
                }
            }

            public static DoGlobalAbort_Class DoGlobalAbort = new DoGlobalAbort_Class();
            public class HandleAbort_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class HandleAbort_StackFrame : PrtFunStackFrame
                {
                    public HandleAbort_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public HandleAbort_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
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
                    Coordinator parent = (Coordinator)(_parent);
                    HandleAbort_StackFrame currFun = (HandleAbort_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto HandleAbort_1;
                        case 2:
                            goto HandleAbort_2;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_currSeqNum).Equals((currFun).var_payload)))).bl)
                        goto HandleAbort_if_0_else;
                    (parent).PrtPushFunStackFrame(DoGlobalAbort, (DoGlobalAbort).CreateLocals());
                    HandleAbort_1:
                        ;
                    (DoGlobalAbort).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    (((PrtMachineValue)((parent).var_timer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_CancelTimer), Events.@null, parent, (PrtMachineValue)((parent).var_timer));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    HandleAbort_2:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(243,4,243,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Unit)).evt).name);
                    (parent).currentTrigger = Events.event_Unit;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto HandleAbort_if_0_end;
                    HandleAbort_if_0_else:
                        ;
                    HandleAbort_if_0_end:
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
                    return new HandleAbort_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "HandleAbort";
                }
            }

            public static HandleAbort_Class HandleAbort = new HandleAbort_Class();
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun5_StackFrame currFun = (AnonFun5_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun5_1;
                        case 2:
                            goto AnonFun5_2;
                        case 3:
                            goto AnonFun5_3;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_i).Equals(new PrtIntValue(0))))).bl)
                        goto AnonFun5_if_0_else;
                    AnonFun5_loop_start_0:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((parent).var_i)).nt < ((PrtIntValue)(new PrtIntValue(((parent).var_replicas).Size()))).nt))).bl)
                        goto AnonFun5_loop_end_0;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_replicas)).Lookup((parent).var_i)).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_GLOBAL_COMMIT), (parent).var_currSeqNum, parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_replicas)).Lookup((parent).var_i)).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun5_1:
                        ;
                    (parent).var_i = (new PrtIntValue(((PrtIntValue)((parent).var_i)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto AnonFun5_loop_start_0;
                    AnonFun5_loop_end_0:
                        ;
                    ((PrtMapValue)((parent).var_dataValues)).Update((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[1]).Clone(), ((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[2]).Clone()).Clone());
                    (((PrtMachineValue)((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_WRITE_SUCCESS), Events.@null, parent, (PrtMachineValue)((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    AnonFun5_2:
                        ;
                    (((PrtMachineValue)((parent).var_timer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_CancelTimer), Events.@null, parent, (PrtMachineValue)((parent).var_timer));
                    (parent).PrtFunContSend(this, (currFun).locals, 3);
                    return;
                    AnonFun5_3:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(223,5,223,10): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Unit)).evt).name);
                    (parent).currentTrigger = Events.event_Unit;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto AnonFun5_if_0_end;
                    AnonFun5_if_0_else:
                        ;
                    AnonFun5_if_0_end:
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun6_StackFrame currFun = (AnonFun6_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun6_1;
                    }

                    (((PrtMachineValue)((parent).var_client)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_READ_FAIL), Events.@null, parent, (PrtMachineValue)((parent).var_client));
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun7_StackFrame currFun = (AnonFun7_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun7_1;
                    }

                    (((PrtMachineValue)((parent).var_client)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_READ_SUCCESS), (currFun).var_payload, parent, (PrtMachineValue)((parent).var_client));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun7_1:
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun8_StackFrame currFun = (AnonFun8_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun8_1;
                        case 2:
                            goto AnonFun8_2;
                    }

                    (parent).var_numReplicas = ((currFun).var_payload).Clone();
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((parent).var_numReplicas)).nt > ((PrtIntValue)(new PrtIntValue(0))).nt))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(139,4,139,10): error PC1001: Assert failed");
                    (parent).var_i = (new PrtIntValue(0)).Clone();
                    AnonFun8_loop_start_0:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((parent).var_i)).nt < ((PrtIntValue)((parent).var_numReplicas)).nt))).bl)
                        goto AnonFun8_loop_end_0;
                    (parent).var_replica = (application).CreateInterface(parent, "Replica", parent.self);
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 1);
                    return;
                    AnonFun8_1:
                        ;
                    ((PrtSeqValue)((parent).var_replicas)).Insert(((PrtTupleValue)(new PrtTupleValue((parent).var_i, (parent).var_replica))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue((parent).var_i, (parent).var_replica))).fieldValues[1]);
                    (parent).var_i = (new PrtIntValue(((PrtIntValue)((parent).var_i)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto AnonFun8_loop_start_0;
                    AnonFun8_loop_end_0:
                        ;
                    (parent).var_currSeqNum = (new PrtIntValue(0)).Clone();
                    (parent).var_timer = (application).CreateInterface(parent, "Timer", parent.self);
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 2);
                    return;
                    AnonFun8_2:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(149,4,149,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Unit)).evt).name);
                    (parent).currentTrigger = Events.event_Unit;
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun14_StackFrame currFun = (AnonFun14_StackFrame)(parent.PrtPopFunStackFrame());
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun15_StackFrame currFun = (AnonFun15_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_currSeqNum).Equals((currFun).var_payload)))).bl)
                        goto AnonFun15_if_0_else;
                    (parent).var_i = (new PrtIntValue(((PrtIntValue)((parent).var_i)).nt - ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto AnonFun15_if_0_end;
                    AnonFun15_if_0_else:
                        ;
                    AnonFun15_if_0_end:
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

                    public PrtValue var_payload1
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun16_StackFrame currFun = (AnonFun16_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_readResult = (new PrtTupleValue(new PrtBoolValue(false), (currFun).var_payload1)).Clone();
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

                    public PrtValue var__payload_1
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun17_StackFrame currFun = (AnonFun17_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_readResult = (new PrtTupleValue(new PrtBoolValue(true), new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt))).Clone();
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun18_StackFrame currFun = (AnonFun18_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun18_1;
                        case 2:
                            goto AnonFun18_2;
                        case 3:
                            goto AnonFun18_3;
                        case 4:
                            goto AnonFun18_4;
                        case 5:
                            goto AnonFun18_5;
                        case 6:
                            goto AnonFun18_6;
                    }

                    (parent).var_client = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone()).Clone();
                    (parent).var_key = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone()).Clone();
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto AnonFun18_if_0_else;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_replicas)).Lookup(new PrtIntValue(0))).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_READ_REQ_REPLICA), (parent).var_key, parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_replicas)).Lookup(new PrtIntValue(0))).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun18_1:
                        ;
                    goto AnonFun18_if_0_end;
                    AnonFun18_if_0_else:
                        ;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_replicas)).Lookup(new PrtIntValue(((PrtIntValue)(new PrtIntValue(((parent).var_replicas).Size()))).nt - ((PrtIntValue)(new PrtIntValue(1))).nt))).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_READ_REQ_REPLICA), (parent).var_key, parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_replicas)).Lookup(new PrtIntValue(((PrtIntValue)(new PrtIntValue(((parent).var_replicas).Size()))).nt - ((PrtIntValue)(new PrtIntValue(1))).nt))).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    AnonFun18_2:
                        ;
                    AnonFun18_if_0_end:
                        ;
                    (((PrtImplMachine)(parent)).receiveSet).Add(Events.event_REP_READ_SUCCESS);
                    (((PrtImplMachine)(parent)).receiveSet).Add(Events.event_REP_READ_FAIL);
                    (parent).PrtFunContReceive(this, (currFun).locals, 3);
                    return;
                    AnonFun18_3:
                        ;
                    if (((parent).currentTrigger).Equals(Events.event_REP_READ_SUCCESS))
                    {
                        (currFun).locals[1] = ((parent).currentPayload).Clone();
                        (parent).PrtPushFunStackFrame(AnonFun16, (currFun).locals);
                        goto AnonFun18_5;
                    }

                    if (((parent).currentTrigger).Equals(Events.event_REP_READ_FAIL))
                    {
                        (currFun).locals[1] = ((parent).currentPayload).Clone();
                        (parent).PrtPushFunStackFrame(AnonFun17, (currFun).locals);
                        goto AnonFun18_6;
                    }

                    if (!false)
                        throw new PrtAssertFailureException("Internal error");
                    AnonFun18_5:
                        ;
                    (AnonFun16).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                        goto AnonFun18_4;
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 5);
                        return;
                    }

                    AnonFun18_6:
                        ;
                    (AnonFun17).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                        goto AnonFun18_4;
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 6);
                        return;
                    }

                    AnonFun18_4:
                        ;
                    if (!((PrtBoolValue)((((PrtTupleValue)((parent).var_readResult)).fieldValues[0]).Clone())).bl)
                        goto AnonFun18_if_1_else;
                    if (!!(Events.event_READ_FAIL).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(169,5,169,10): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_READ_FAIL)).evt).name);
                    (parent).currentTrigger = Events.event_READ_FAIL;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto AnonFun18_if_1_end;
                    AnonFun18_if_1_else:
                        ;
                    if (!!(Events.event_READ_SUCCESS).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(171,5,171,10): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_READ_SUCCESS)).evt).name);
                    (parent).currentTrigger = Events.event_READ_SUCCESS;
                    (parent).currentPayload = (((PrtTupleValue)((parent).var_readResult)).fieldValues[1]).Clone();
                    (parent).PrtFunContRaise();
                    return;
                    AnonFun18_if_1_end:
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

                    (locals).Add(PrtValue.@null);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun20_StackFrame currFun = (AnonFun20_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun20_1;
                    }

                    (parent).PrtPushFunStackFrame(HandleAbort, (HandleAbort).CreateLocals((currFun).var_payload));
                    AnonFun20_1:
                        ;
                    (HandleAbort).Execute(application, parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun22_StackFrame currFun = (AnonFun22_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun22_1;
                    }

                    (parent).PrtPushFunStackFrame(DoWrite, (DoWrite).CreateLocals((currFun).var_payload));
                    AnonFun22_1:
                        ;
                    (DoWrite).Execute(application, parent);
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun23_StackFrame currFun = (AnonFun23_StackFrame)(parent.PrtPopFunStackFrame());
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
                    Coordinator parent = (Coordinator)(_parent);
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
            public class AnonFun28_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun28_StackFrame : PrtFunStackFrame
                {
                    public AnonFun28_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun28_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun28_StackFrame currFun = (AnonFun28_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun28_1;
                    }

                    (parent).PrtPushFunStackFrame(DoGlobalAbort, (DoGlobalAbort).CreateLocals());
                    AnonFun28_1:
                        ;
                    (DoGlobalAbort).Execute(application, parent);
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
                    return new AnonFun28_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun28";
                }
            }

            public static AnonFun28_Class AnonFun28 = new AnonFun28_Class();
            public class AnonFun29_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return true;
                    }
                }

                internal class AnonFun29_StackFrame : PrtFunStackFrame
                {
                    public AnonFun29_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public AnonFun29_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
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
                    Coordinator parent = (Coordinator)(_parent);
                    AnonFun29_StackFrame currFun = (AnonFun29_StackFrame)(parent.PrtPopFunStackFrame());
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
                    return new AnonFun29_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "AnonFun29";
                }
            }

            public static AnonFun29_Class AnonFun29 = new AnonFun29_Class();
            public class Coordinator_WaitForTimeout_Class : PrtState
            {
                public Coordinator_WaitForTimeout_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Coordinator_WaitForTimeout_Class Coordinator_WaitForTimeout;
            public class Coordinator_WaitForCancelTimerResponse_Class : PrtState
            {
                public Coordinator_WaitForCancelTimerResponse_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Coordinator_WaitForCancelTimerResponse_Class Coordinator_WaitForCancelTimerResponse;
            public class Coordinator_CountVote_Class : PrtState
            {
                public Coordinator_CountVote_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Coordinator_CountVote_Class Coordinator_CountVote;
            public class Coordinator_Loop_Class : PrtState
            {
                public Coordinator_Loop_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Coordinator_Loop_Class Coordinator_Loop;
            public class Coordinator_DoRead_Class : PrtState
            {
                public Coordinator_DoRead_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Coordinator_DoRead_Class Coordinator_DoRead;
            public class Coordinator_Init_Class : PrtState
            {
                public Coordinator_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Coordinator_Init_Class Coordinator_Init;
            static Coordinator()
            {
                Coordinator_WaitForTimeout = new Coordinator_WaitForTimeout_Class("Coordinator_WaitForTimeout", AnonFun2, AnonFun3, false, StateTemperature.Warm);
                Coordinator_WaitForCancelTimerResponse = new Coordinator_WaitForCancelTimerResponse_Class("Coordinator_WaitForCancelTimerResponse", AnonFun26, AnonFun25, false, StateTemperature.Warm);
                Coordinator_CountVote = new Coordinator_CountVote_Class("Coordinator_CountVote", AnonFun5, AnonFun11, false, StateTemperature.Warm);
                Coordinator_Loop = new Coordinator_Loop_Class("Coordinator_Loop", AnonFun13, AnonFun14, false, StateTemperature.Warm);
                Coordinator_DoRead = new Coordinator_DoRead_Class("Coordinator_DoRead", AnonFun18, AnonFun23, false, StateTemperature.Warm);
                Coordinator_Init = new Coordinator_Init_Class("Coordinator_Init", AnonFun8, AnonFun12, false, StateTemperature.Warm);
                Coordinator_WaitForTimeout.dos.Add(Events.event_RESP_REPLICA_ABORT, PrtFun.IgnoreFun);
                Coordinator_WaitForTimeout.dos.Add(Events.event_RESP_REPLICA_COMMIT, PrtFun.IgnoreFun);
                Coordinator_WaitForTimeout.deferredSet.Add(Events.event_READ_REQ);
                Coordinator_WaitForTimeout.deferredSet.Add(Events.event_WRITE_REQ);
                PrtTransition transition_1 = new PrtTransition(AnonFun1, Coordinator_Loop, false);
                Coordinator_WaitForTimeout.transitions.Add(Events.event_Timeout, transition_1);
                Coordinator_WaitForCancelTimerResponse.dos.Add(Events.event_RESP_REPLICA_ABORT, PrtFun.IgnoreFun);
                Coordinator_WaitForCancelTimerResponse.dos.Add(Events.event_RESP_REPLICA_COMMIT, PrtFun.IgnoreFun);
                Coordinator_WaitForCancelTimerResponse.deferredSet.Add(Events.event_READ_REQ);
                Coordinator_WaitForCancelTimerResponse.deferredSet.Add(Events.event_WRITE_REQ);
                PrtTransition transition_2 = new PrtTransition(AnonFun27, Coordinator_WaitForTimeout, false);
                Coordinator_WaitForCancelTimerResponse.transitions.Add(Events.event_CancelTimerFailure, transition_2);
                PrtTransition transition_3 = new PrtTransition(AnonFun24, Coordinator_Loop, false);
                Coordinator_WaitForCancelTimerResponse.transitions.Add(Events.event_CancelTimerSuccess, transition_3);
                PrtTransition transition_4 = new PrtTransition(AnonFun24, Coordinator_Loop, false);
                Coordinator_WaitForCancelTimerResponse.transitions.Add(Events.event_Timeout, transition_4);
                Coordinator_CountVote.dos.Add(Events.event_RESP_REPLICA_ABORT, AnonFun20);
                Coordinator_CountVote.deferredSet.Add(Events.event_READ_REQ);
                Coordinator_CountVote.deferredSet.Add(Events.event_WRITE_REQ);
                PrtTransition transition_5 = new PrtTransition(AnonFun29, Coordinator_WaitForCancelTimerResponse, false);
                Coordinator_CountVote.transitions.Add(Events.event_Unit, transition_5);
                PrtTransition transition_6 = new PrtTransition(AnonFun28, Coordinator_Loop, false);
                Coordinator_CountVote.transitions.Add(Events.event_Timeout, transition_6);
                PrtTransition transition_7 = new PrtTransition(AnonFun15, Coordinator_CountVote, false);
                Coordinator_CountVote.transitions.Add(Events.event_RESP_REPLICA_COMMIT, transition_7);
                Coordinator_Loop.dos.Add(Events.event_RESP_REPLICA_ABORT, PrtFun.IgnoreFun);
                Coordinator_Loop.dos.Add(Events.event_RESP_REPLICA_COMMIT, PrtFun.IgnoreFun);
                Coordinator_Loop.dos.Add(Events.event_WRITE_REQ, AnonFun22);
                PrtTransition transition_8 = new PrtTransition(AnonFun21, Coordinator_DoRead, false);
                Coordinator_Loop.transitions.Add(Events.event_READ_REQ, transition_8);
                PrtTransition transition_9 = new PrtTransition(AnonFun4, Coordinator_CountVote, false);
                Coordinator_Loop.transitions.Add(Events.event_Unit, transition_9);
                PrtTransition transition_10 = new PrtTransition(AnonFun7, Coordinator_Loop, false);
                Coordinator_DoRead.transitions.Add(Events.event_READ_SUCCESS, transition_10);
                PrtTransition transition_11 = new PrtTransition(AnonFun6, Coordinator_Loop, false);
                Coordinator_DoRead.transitions.Add(Events.event_READ_FAIL, transition_11);
                PrtTransition transition_12 = new PrtTransition(AnonFun0, Coordinator_Loop, false);
                Coordinator_Init.transitions.Add(Events.event_Unit, transition_12);
            }
        }

        public class Replica : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return Replica_Init;
                }
            }

            public PrtValue var_shouldCommit
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

            public PrtValue var_lastSeqNum
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

            public PrtValue var_pendingWriteReq
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

            public PrtValue var_dataValues
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

            public PrtValue var_coordinator
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
                return new Replica();
            }

            public override int NextInstanceNumber(StateImpl app)
            {
                return app.NextMachineInstanceNumber(this.GetType());
            }

            public override string Name
            {
                get
                {
                    return "Replica";
                }
            }

            public Replica(): base ()
            {
            }

            public Replica(StateImpl app, int maxB, bool assume): base (app, maxB, assume)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_6_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_4_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_11_14592104));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Replica));
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
                    Replica parent = (Replica)(_parent);
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
            public class ShouldCommitWrite_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class ShouldCommitWrite_StackFrame : PrtFunStackFrame
                {
                    public ShouldCommitWrite_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public ShouldCommitWrite_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    Replica parent = (Replica)(_parent);
                    ShouldCommitWrite_StackFrame currFun = (ShouldCommitWrite_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).PrtFunContReturnVal(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))), (currFun).locals);
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
                    return new ShouldCommitWrite_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "ShouldCommitWrite";
                }
            }

            public static ShouldCommitWrite_Class ShouldCommitWrite = new ShouldCommitWrite_Class();
            public class HandleReqReplica_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class HandleReqReplica_StackFrame : PrtFunStackFrame
                {
                    public HandleReqReplica_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public HandleReqReplica_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
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
                    Replica parent = (Replica)(_parent);
                    HandleReqReplica_StackFrame currFun = (HandleReqReplica_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto HandleReqReplica_1;
                        case 2:
                            goto HandleReqReplica_2;
                        case 3:
                            goto HandleReqReplica_3;
                    }

                    (parent).var_pendingWriteReq = ((currFun).var_payload).Clone();
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone())).nt > ((PrtIntValue)((parent).var_lastSeqNum)).nt))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(84,3,84,9): error PC1001: Assert failed");
                    (parent).PrtPushFunStackFrame(ShouldCommitWrite, (ShouldCommitWrite).CreateLocals());
                    HandleReqReplica_1:
                        ;
                    (ShouldCommitWrite).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                        (parent).var_shouldCommit = ((parent).continuation).retVal;
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    if (!((PrtBoolValue)((parent).var_shouldCommit)).bl)
                        goto HandleReqReplica_if_0_else;
                    (((PrtMachineValue)((parent).var_coordinator)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_RESP_REPLICA_COMMIT), (((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone(), parent, (PrtMachineValue)((parent).var_coordinator));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    HandleReqReplica_2:
                        ;
                    goto HandleReqReplica_if_0_end;
                    HandleReqReplica_if_0_else:
                        ;
                    (((PrtMachineValue)((parent).var_coordinator)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_RESP_REPLICA_ABORT), (((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone(), parent, (PrtMachineValue)((parent).var_coordinator));
                    (parent).PrtFunContSend(this, (currFun).locals, 3);
                    return;
                    HandleReqReplica_3:
                        ;
                    HandleReqReplica_if_0_end:
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
                    return new HandleReqReplica_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "HandleReqReplica";
                }
            }

            public static HandleReqReplica_Class HandleReqReplica = new HandleReqReplica_Class();
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
                    Replica parent = (Replica)(_parent);
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
                    Replica parent = (Replica)(_parent);
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
                    Replica parent = (Replica)(_parent);
                    AnonFun2_StackFrame currFun = (AnonFun2_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_coordinator = ((currFun).var_payload).Clone();
                    (parent).var_lastSeqNum = (new PrtIntValue(0)).Clone();
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(77,4,77,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Unit)).evt).name);
                    (parent).currentTrigger = Events.event_Unit;
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
                    Replica parent = (Replica)(_parent);
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
                    Replica parent = (Replica)(_parent);
                    AnonFun4_StackFrame currFun = (AnonFun4_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone())).nt >= ((PrtIntValue)((currFun).var_payload)).nt))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(96,4,96,10): error PC1001: Assert failed");
                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone()).Equals((currFun).var_payload)))).bl)
                        goto AnonFun4_if_0_else;
                    (parent).var_lastSeqNum = ((currFun).var_payload).Clone();
                    goto AnonFun4_if_0_end;
                    AnonFun4_if_0_else:
                        ;
                    AnonFun4_if_0_end:
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
                    Replica parent = (Replica)(_parent);
                    AnonFun5_StackFrame currFun = (AnonFun5_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone())).nt >= ((PrtIntValue)((currFun).var_payload)).nt))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(102,4,102,10): error PC1001: Assert failed");
                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[0]).Clone()).Equals((currFun).var_payload)))).bl)
                        goto AnonFun5_if_1_else;
                    ((PrtMapValue)((parent).var_dataValues)).Update((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[1]).Clone(), ((((PrtTupleValue)((parent).var_pendingWriteReq)).fieldValues[2]).Clone()).Clone());
                    (parent).var_lastSeqNum = ((currFun).var_payload).Clone();
                    goto AnonFun5_if_1_end;
                    AnonFun5_if_1_else:
                        ;
                    AnonFun5_if_1_end:
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
                    Replica parent = (Replica)(_parent);
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
                    Replica parent = (Replica)(_parent);
                    AnonFun7_StackFrame currFun = (AnonFun7_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun7_1;
                        case 2:
                            goto AnonFun7_2;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtMapValue)((parent).var_dataValues)).Contains((currFun).var_payload)))).bl)
                        goto AnonFun7_if_1_else;
                    (((PrtMachineValue)((parent).var_coordinator)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_REP_READ_SUCCESS), (((PrtMapValue)((parent).var_dataValues)).Lookup((currFun).var_payload)).Clone(), parent, (PrtMachineValue)((parent).var_coordinator));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun7_1:
                        ;
                    goto AnonFun7_if_1_end;
                    AnonFun7_if_1_else:
                        ;
                    (((PrtMachineValue)((parent).var_coordinator)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_REP_READ_FAIL), Events.@null, parent, (PrtMachineValue)((parent).var_coordinator));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    AnonFun7_2:
                        ;
                    AnonFun7_if_1_end:
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
                    Replica parent = (Replica)(_parent);
                    AnonFun8_StackFrame currFun = (AnonFun8_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun8_1;
                    }

                    (parent).PrtPushFunStackFrame(HandleReqReplica, (HandleReqReplica).CreateLocals((currFun).var_payload));
                    AnonFun8_1:
                        ;
                    (HandleReqReplica).Execute(application, parent);
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
                    Replica parent = (Replica)(_parent);
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
            public class Replica_Loop_Class : PrtState
            {
                public Replica_Loop_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Replica_Loop_Class Replica_Loop;
            public class Replica_Init_Class : PrtState
            {
                public Replica_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Replica_Init_Class Replica_Init;
            static Replica()
            {
                Replica_Loop = new Replica_Loop_Class("Replica_Loop", AnonFun6, AnonFun9, false, StateTemperature.Warm);
                Replica_Init = new Replica_Init_Class("Replica_Init", AnonFun2, AnonFun1, false, StateTemperature.Warm);
                Replica_Loop.dos.Add(Events.event_READ_REQ_REPLICA, AnonFun7);
                Replica_Loop.dos.Add(Events.event_REQ_REPLICA, AnonFun8);
                Replica_Loop.dos.Add(Events.event_GLOBAL_COMMIT, AnonFun5);
                Replica_Loop.dos.Add(Events.event_GLOBAL_ABORT, AnonFun4);
                PrtTransition transition_1 = new PrtTransition(AnonFun0, Replica_Loop, false);
                Replica_Init.transitions.Add(Events.event_Unit, transition_1);
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

            public PrtValue var_target
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
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Replica));
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
                    AnonFun0_StackFrame currFun = (AnonFun0_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun0_1;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto AnonFun0_if_0_else;
                    (((PrtMachineValue)((parent).var_target)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Timeout), Events.@null, parent, (PrtMachineValue)((parent).var_target));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun0_1:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(51,5,51,10): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Unit)).evt).name);
                    (parent).currentTrigger = Events.event_Unit;
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
                    AnonFun6_StackFrame currFun = (AnonFun6_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_target = ((currFun).var_payload).Clone();
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\two_phase_commit_1\\\\two_phase_commit_1.p(37,4,37,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Unit)).evt).name);
                    (parent).currentTrigger = Events.event_Unit;
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
                    Timer parent = (Timer)(_parent);
                    AnonFun7_StackFrame currFun = (AnonFun7_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun7_1;
                        case 2:
                            goto AnonFun7_2;
                        case 3:
                            goto AnonFun7_3;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto AnonFun7_if_2_else;
                    (((PrtMachineValue)((parent).var_target)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_CancelTimerFailure), Events.@null, parent, (PrtMachineValue)((parent).var_target));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun7_1:
                        ;
                    (((PrtMachineValue)((parent).var_target)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Timeout), Events.@null, parent, (PrtMachineValue)((parent).var_target));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    AnonFun7_2:
                        ;
                    goto AnonFun7_if_2_end;
                    AnonFun7_if_2_else:
                        ;
                    (((PrtMachineValue)((parent).var_target)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_CancelTimerSuccess), Events.@null, parent, (PrtMachineValue)((parent).var_target));
                    (parent).PrtFunContSend(this, (currFun).locals, 3);
                    return;
                    AnonFun7_3:
                        ;
                    AnonFun7_if_2_end:
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
            public class Timer_Loop_Class : PrtState
            {
                public Timer_Loop_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Timer_Loop_Class Timer_Loop;
            public class Timer_TimerStarted_Class : PrtState
            {
                public Timer_TimerStarted_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Timer_TimerStarted_Class Timer_TimerStarted;
            public class Timer_Init_Class : PrtState
            {
                public Timer_Init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Timer_Init_Class Timer_Init;
            static Timer()
            {
                Timer_Loop = new Timer_Loop_Class("Timer_Loop", AnonFun10, AnonFun11, false, StateTemperature.Warm);
                Timer_TimerStarted = new Timer_TimerStarted_Class("Timer_TimerStarted", AnonFun0, AnonFun5, false, StateTemperature.Warm);
                Timer_Init = new Timer_Init_Class("Timer_Init", AnonFun6, AnonFun1, false, StateTemperature.Warm);
                Timer_Loop.dos.Add(Events.event_CancelTimer, PrtFun.IgnoreFun);
                PrtTransition transition_1 = new PrtTransition(AnonFun4, Timer_TimerStarted, false);
                Timer_Loop.transitions.Add(Events.event_StartTimer, transition_1);
                PrtTransition transition_2 = new PrtTransition(AnonFun7, Timer_Loop, false);
                Timer_TimerStarted.transitions.Add(Events.event_CancelTimer, transition_2);
                PrtTransition transition_3 = new PrtTransition(AnonFun3, Timer_Loop, false);
                Timer_TimerStarted.transitions.Add(Events.event_Unit, transition_3);
                PrtTransition transition_4 = new PrtTransition(AnonFun2, Timer_Loop, false);
                Timer_Init.transitions.Add(Events.event_Unit, transition_4);
            }
        }
    }
}
