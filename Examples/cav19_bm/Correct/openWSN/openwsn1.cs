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
            public static PrtEventValue event_newSlot;
            public static PrtEventValue event_endSlot;
            public static PrtEventValue event_Local;
            public static PrtEventValue event_TxDone;
            public static PrtEventValue event_Tx;
            public static PrtEventValue event_Rx;
            public static PrtEventValue event_Sleep;
            public static PrtEventValue event_Data;
            public static PrtEventValue event_Ack;
            public static PrtEventValue event_Initialize;
            public static void Events_openwsn1()
            {
                event_newSlot = new PrtEventValue(new PrtEvent("newSlot", Types.type_1_969060819, 1, false));
                event_endSlot = new PrtEventValue(new PrtEvent("endSlot", Types.type_9_969060819, PrtEvent.DefaultMaxInstances, false));
                event_Local = new PrtEventValue(new PrtEvent("Local", Types.type_9_969060819, PrtEvent.DefaultMaxInstances, false));
                event_TxDone = new PrtEventValue(new PrtEvent("TxDone", Types.type_9_969060819, PrtEvent.DefaultMaxInstances, false));
                event_Tx = new PrtEventValue(new PrtEvent("Tx", Types.type_9_969060819, PrtEvent.DefaultMaxInstances, false));
                event_Rx = new PrtEventValue(new PrtEvent("Rx", Types.type_9_969060819, PrtEvent.DefaultMaxInstances, false));
                event_Sleep = new PrtEventValue(new PrtEvent("Sleep", Types.type_9_969060819, PrtEvent.DefaultMaxInstances, false));
                event_Data = new PrtEventValue(new PrtEvent("Data", Types.type_6_969060819, 4, false));
                event_Ack = new PrtEventValue(new PrtEvent("Ack", Types.type_6_969060819, 1, false));
                event_Initialize = new PrtEventValue(new PrtEvent("Initialize", Types.type_4_969060819, 1, false));
            }
        }

        public partial class Types
        {
            public static PrtType type_OpenWSN_Mote;
            public static PrtType type_2_969060819;
            public static PrtType type_3_969060819;
            public static PrtType type_1_969060819;
            public static PrtType type_5_969060819;
            public static PrtType type_4_969060819;
            public static PrtType type_7_969060819;
            public static PrtType type_6_969060819;
            public static PrtType type_9_969060819;
            public static PrtType type_8_969060819;
            public static PrtType type_10_969060819;
            public static PrtType type_12_969060819;
            public static PrtType type_11_969060819;
            public static PrtType type_13_969060819;
            public static PrtType type_SlotTimerMachine;
            public static PrtType type_Main;
            static public void Types_openwsn1()
            {
                Types.type_OpenWSN_Mote = new PrtMachineType();
                Types.type_2_969060819 = new PrtBoolType();
                Types.type_3_969060819 = new PrtTupleType(new PrtType[]{Types.type_OpenWSN_Mote, Types.type_OpenWSN_Mote});
                Types.type_1_969060819 = new PrtTupleType(new PrtType[]{Types.type_2_969060819, Types.type_3_969060819});
                Types.type_5_969060819 = new PrtSeqType(Types.type_OpenWSN_Mote);
                Types.type_4_969060819 = new PrtTupleType(new PrtType[]{Types.type_OpenWSN_Mote, Types.type_5_969060819});
                Types.type_7_969060819 = new PrtIntType();
                Types.type_6_969060819 = new PrtTupleType(new PrtType[]{Types.type_OpenWSN_Mote, Types.type_7_969060819});
                Types.type_9_969060819 = new PrtNullType();
                Types.type_8_969060819 = new PrtTupleType(new PrtType[]{Types.type_9_969060819, Types.type_7_969060819});
                Types.type_10_969060819 = new PrtTupleType(new PrtType[]{Types.type_7_969060819, Types.type_OpenWSN_Mote});
                Types.type_12_969060819 = new PrtTupleType(new PrtType[]{Types.type_9_969060819, Types.type_9_969060819});
                Types.type_11_969060819 = new PrtTupleType(new PrtType[]{Types.type_2_969060819, Types.type_12_969060819});
                Types.type_13_969060819 = new PrtEventType();
                Types.type_SlotTimerMachine = Types.type_OpenWSN_Mote;
                Types.type_Main = Types.type_OpenWSN_Mote;
            }
        }

        public static PrtImplMachine CreateMachine_SlotTimerMachine(StateImpl application, PrtValue payload)
        {
            var machine = new SlotTimerMachine(application, PrtImplMachine.DefaultMaxBufferSize, false);
            ((machine).self).permissions = null;
            (machine).sends = null;
            (machine).currentPayload = payload;
            return machine;
        }

        public static PrtImplMachine CreateMachine_OpenWSN_Mote(StateImpl application, PrtValue payload)
        {
            var machine = new OpenWSN_Mote(application, PrtImplMachine.DefaultMaxBufferSize, false);
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

        public class SlotTimerMachine : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return SlotTimerMachine_init;
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

            public PrtValue var_i
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

            public PrtValue var_AllMotes
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
                return new SlotTimerMachine();
            }

            public override int NextInstanceNumber(StateImpl app)
            {
                return app.NextMachineInstanceNumber(this.GetType());
            }

            public override string Name
            {
                get
                {
                    return "SlotTimerMachine";
                }
            }

            public SlotTimerMachine(): base ()
            {
            }

            public SlotTimerMachine(StateImpl app, int maxB, bool assume): base (app, maxB, assume)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_7_969060819));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_7_969060819));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_5_969060819));
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
                    SlotTimerMachine parent = (SlotTimerMachine)(_parent);
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
            public class increaseCounter_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class increaseCounter_StackFrame : PrtFunStackFrame
                {
                    public increaseCounter_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public increaseCounter_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    SlotTimerMachine parent = (SlotTimerMachine)(_parent);
                    increaseCounter_StackFrame currFun = (increaseCounter_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_counter = (new PrtIntValue(((PrtIntValue)((parent).var_counter)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_counter).Equals(new PrtIntValue(((parent).var_AllMotes).Size()))))).bl)
                        goto increaseCounter_if_0_else;
                    (parent).var_counter = (new PrtIntValue(0)).Clone();
                    if (!!(Events.event_Local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(284,4,284,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Local)).evt).name);
                    (parent).currentTrigger = Events.event_Local;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto increaseCounter_if_0_end;
                    increaseCounter_if_0_else:
                        ;
                    increaseCounter_if_0_end:
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
                    return new increaseCounter_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "increaseCounter";
                }
            }

            public static increaseCounter_Class increaseCounter = new increaseCounter_Class();
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
                    SlotTimerMachine parent = (SlotTimerMachine)(_parent);
                    AnonFun0_StackFrame currFun = (AnonFun0_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun0_1;
                    }

                    (parent).var_i = (new PrtIntValue(((PrtIntValue)(new PrtIntValue(((parent).var_AllMotes).Size()))).nt - ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    AnonFun0_loop_start_0:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((parent).var_i)).nt >= ((PrtIntValue)(new PrtIntValue(0))).nt))).bl)
                        goto AnonFun0_loop_end_0;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_AllMotes)).Lookup((parent).var_i)).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_newSlot), new PrtTupleValue(new PrtBoolValue(true), new PrtTupleValue(Events.@null, Events.@null)), parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_AllMotes)).Lookup((parent).var_i)).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun0_1:
                        ;
                    (parent).var_i = (new PrtIntValue(((PrtIntValue)((parent).var_i)).nt - ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto AnonFun0_loop_start_0;
                    AnonFun0_loop_end_0:
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
                    SlotTimerMachine parent = (SlotTimerMachine)(_parent);
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
                    SlotTimerMachine parent = (SlotTimerMachine)(_parent);
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
                    SlotTimerMachine parent = (SlotTimerMachine)(_parent);
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
                    SlotTimerMachine parent = (SlotTimerMachine)(_parent);
                    AnonFun4_StackFrame currFun = (AnonFun4_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_counter = (new PrtIntValue(0)).Clone();
                    (parent).var_AllMotes = ((currFun).var_payload).Clone();
                    if (!!(Events.event_Local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(261,4,261,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Local)).evt).name);
                    (parent).currentTrigger = Events.event_Local;
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
                    SlotTimerMachine parent = (SlotTimerMachine)(_parent);
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
                    SlotTimerMachine parent = (SlotTimerMachine)(_parent);
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
                    SlotTimerMachine parent = (SlotTimerMachine)(_parent);
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
            public class SlotTimerMachine_SendNewSlot_Class : PrtState
            {
                public SlotTimerMachine_SendNewSlot_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static SlotTimerMachine_SendNewSlot_Class SlotTimerMachine_SendNewSlot;
            public class SlotTimerMachine_init_Class : PrtState
            {
                public SlotTimerMachine_init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static SlotTimerMachine_init_Class SlotTimerMachine_init;
            static SlotTimerMachine()
            {
                SlotTimerMachine_SendNewSlot = new SlotTimerMachine_SendNewSlot_Class("SlotTimerMachine_SendNewSlot", AnonFun0, AnonFun1, false, StateTemperature.Warm);
                SlotTimerMachine_init = new SlotTimerMachine_init_Class("SlotTimerMachine_init", AnonFun4, AnonFun7, false, StateTemperature.Warm);
                SlotTimerMachine_SendNewSlot.dos.Add(Events.event_endSlot, increaseCounter);
                PrtTransition transition_1 = new PrtTransition(AnonFun5, SlotTimerMachine_SendNewSlot, false);
                SlotTimerMachine_SendNewSlot.transitions.Add(Events.event_Local, transition_1);
                PrtTransition transition_2 = new PrtTransition(AnonFun6, SlotTimerMachine_SendNewSlot, false);
                SlotTimerMachine_init.transitions.Add(Events.event_Local, transition_2);
            }
        }

        public class OpenWSN_Mote : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return OpenWSN_Mote_init_mote;
                }
            }

            public PrtValue var_i
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

            public PrtValue var_slotTimer
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

            public PrtValue var_currentSlot
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

            public PrtValue var_lastSynched
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

            public PrtValue var_myTimeParent
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

            public PrtValue var_myNeighbours
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

            public PrtValue var_check
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

            public PrtValue var_temp
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

            public PrtValue var_myRank
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

            public override PrtImplMachine MakeSkeleton()
            {
                return new OpenWSN_Mote();
            }

            public override int NextInstanceNumber(StateImpl app)
            {
                return app.NextMachineInstanceNumber(this.GetType());
            }

            public override string Name
            {
                get
                {
                    return "OpenWSN_Mote";
                }
            }

            public OpenWSN_Mote(): base ()
            {
            }

            public OpenWSN_Mote(StateImpl app, int maxB, bool assume): base (app, maxB, assume)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_7_969060819));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_OpenWSN_Mote));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_1_969060819));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_7_969060819));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_6_969060819));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_5_969060819));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_969060819));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_7_969060819));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_7_969060819));
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
            public class CSMA_CA_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class CSMA_CA_StackFrame : PrtFunStackFrame
                {
                    public CSMA_CA_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public CSMA_CA_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    CSMA_CA_StackFrame currFun = (CSMA_CA_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto CSMA_CA_if_0_else;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(true), (currFun).locals);
                    return;
                    goto CSMA_CA_if_0_end;
                    CSMA_CA_if_0_else:
                        ;
                    (parent).PrtFunContReturnVal(new PrtBoolValue(false), (currFun).locals);
                    return;
                    CSMA_CA_if_0_end:
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
                    return new CSMA_CA_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "CSMA_CA";
                }
            }

            public static CSMA_CA_Class CSMA_CA = new CSMA_CA_Class();
            public class TransmitData_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class TransmitData_StackFrame : PrtFunStackFrame
                {
                    public TransmitData_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public TransmitData_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_target
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    TransmitData_StackFrame currFun = (TransmitData_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto TransmitData_1;
                        case 2:
                            goto TransmitData_2;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((currFun).var_target).Equals(Events.@null)))).bl)
                        goto TransmitData_if_1_else;
                    (parent).var_i = (new PrtIntValue(((PrtIntValue)(new PrtIntValue(((parent).var_myNeighbours).Size()))).nt - ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    TransmitData_loop_start_0:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((parent).var_i)).nt >= ((PrtIntValue)(new PrtIntValue(0))).nt))).bl)
                        goto TransmitData_loop_end_0;
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto TransmitData_if_0_else;
                    (((PrtMachineValue)((((PrtSeqValue)((parent).var_myNeighbours)).Lookup((parent).var_i)).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Data), new PrtTupleValue(parent.self, (parent).var_myRank), parent, (PrtMachineValue)((((PrtSeqValue)((parent).var_myNeighbours)).Lookup((parent).var_i)).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    TransmitData_1:
                        ;
                    (parent).PrtFunContReturn((currFun).locals);
                    return;
                    goto TransmitData_if_0_end;
                    TransmitData_if_0_else:
                        ;
                    (parent).var_i = (new PrtIntValue(((PrtIntValue)((parent).var_i)).nt - ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    TransmitData_if_0_end:
                        ;
                    goto TransmitData_loop_start_0;
                    TransmitData_loop_end_0:
                        ;
                    goto TransmitData_if_1_end;
                    TransmitData_if_1_else:
                        ;
                    (((PrtMachineValue)((currFun).var_target)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Data), new PrtTupleValue(parent.self, (parent).var_myRank), parent, (PrtMachineValue)((currFun).var_target));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    TransmitData_2:
                        ;
                    TransmitData_if_1_end:
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
                    return new TransmitData_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "TransmitData";
                }
            }

            public static TransmitData_Class TransmitData = new TransmitData_Class();
            public class OperationTxorRxorSleep_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class OperationTxorRxorSleep_StackFrame : PrtFunStackFrame
                {
                    public OperationTxorRxorSleep_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public OperationTxorRxorSleep_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }
                }

                public override void Execute(StateImpl application, PrtMachine _parent)
                {
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    OperationTxorRxorSleep_StackFrame currFun = (OperationTxorRxorSleep_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto OperationTxorRxorSleep_if_1_else;
                    (parent).PrtFunContReturnVal(new PrtIntValue(0), (currFun).locals);
                    return;
                    goto OperationTxorRxorSleep_if_1_end;
                    OperationTxorRxorSleep_if_1_else:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto OperationTxorRxorSleep_if_0_else;
                    (parent).PrtFunContReturnVal(new PrtIntValue(1), (currFun).locals);
                    return;
                    goto OperationTxorRxorSleep_if_0_end;
                    OperationTxorRxorSleep_if_0_else:
                        ;
                    (parent).PrtFunContReturnVal(new PrtIntValue(2), (currFun).locals);
                    return;
                    OperationTxorRxorSleep_if_0_end:
                        ;
                    OperationTxorRxorSleep_if_1_end:
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
                    return new OperationTxorRxorSleep_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "OperationTxorRxorSleep";
                }
            }

            public static OperationTxorRxorSleep_Class OperationTxorRxorSleep = new OperationTxorRxorSleep_Class();
            public class CheckOperationTobePerfomed_Class : PrtFun
            {
                public override bool IsAnonFun
                {
                    get
                    {
                        return false;
                    }
                }

                internal class CheckOperationTobePerfomed_StackFrame : PrtFunStackFrame
                {
                    public CheckOperationTobePerfomed_StackFrame(PrtFun fun, List<PrtValue> _locals): base (fun, _locals)
                    {
                    }

                    public CheckOperationTobePerfomed_StackFrame(PrtFun fun, List<PrtValue> _locals, int retLocation): base (fun, _locals, retLocation)
                    {
                    }

                    public override PrtFunStackFrame Clone()
                    {
                        return base.Clone();
                    }

                    public PrtValue var_currentSlot
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    CheckOperationTobePerfomed_StackFrame currFun = (CheckOperationTobePerfomed_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto CheckOperationTobePerfomed_1;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(!((parent).var_myRank).Equals(new PrtIntValue(0))))).bl)
                        goto CheckOperationTobePerfomed_if_0_else;
                    (parent).var_lastSynched = (new PrtIntValue(((PrtIntValue)((parent).var_lastSynched)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    goto CheckOperationTobePerfomed_if_0_end;
                    CheckOperationTobePerfomed_if_0_else:
                        ;
                    CheckOperationTobePerfomed_if_0_end:
                        ;
                    (parent).PrtPushFunStackFrame(OperationTxorRxorSleep, (OperationTxorRxorSleep).CreateLocals());
                    CheckOperationTobePerfomed_1:
                        ;
                    (OperationTxorRxorSleep).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                        (parent).var_temp = ((parent).continuation).retVal;
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_temp).Equals(new PrtIntValue(0))))).bl)
                        goto CheckOperationTobePerfomed_if_1_else;
                    if (!!(Events.event_Tx).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(115,4,115,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Tx)).evt).name);
                    (parent).currentTrigger = Events.event_Tx;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto CheckOperationTobePerfomed_if_1_end;
                    CheckOperationTobePerfomed_if_1_else:
                        ;
                    CheckOperationTobePerfomed_if_1_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_temp).Equals(new PrtIntValue(1))))).bl)
                        goto CheckOperationTobePerfomed_if_2_else;
                    if (!!(Events.event_Rx).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(117,4,117,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Rx)).evt).name);
                    (parent).currentTrigger = Events.event_Rx;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto CheckOperationTobePerfomed_if_2_end;
                    CheckOperationTobePerfomed_if_2_else:
                        ;
                    CheckOperationTobePerfomed_if_2_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_temp).Equals(new PrtIntValue(2))))).bl)
                        goto CheckOperationTobePerfomed_if_3_else;
                    if (!!(Events.event_Sleep).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(119,4,119,9): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Sleep)).evt).name);
                    (parent).currentTrigger = Events.event_Sleep;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto CheckOperationTobePerfomed_if_3_end;
                    CheckOperationTobePerfomed_if_3_else:
                        ;
                    CheckOperationTobePerfomed_if_3_end:
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
                    return new CheckOperationTobePerfomed_StackFrame(this, locals, retLoc);
                }

                public override string ToString()
                {
                    return "CheckOperationTobePerfomed";
                }
            }

            public static CheckOperationTobePerfomed_Class CheckOperationTobePerfomed = new CheckOperationTobePerfomed_Class();
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    AnonFun4_StackFrame currFun = (AnonFun4_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun4_1;
                    }

                    (parent).PrtPushFunStackFrame(CheckOperationTobePerfomed, (CheckOperationTobePerfomed).CreateLocals((currFun).var_payload));
                    AnonFun4_1:
                        ;
                    (CheckOperationTobePerfomed).Execute(application, parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    AnonFun5_StackFrame currFun = (AnonFun5_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_myRank = ((currFun).var_payload).Clone();
                    (parent).var_myTimeParent = (new PrtTupleValue(Events.@null, new PrtIntValue(10000))).Clone();
                    (parent).var_lastSynched = (new PrtIntValue(0)).Clone();
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    AnonFun12_StackFrame currFun = (AnonFun12_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun12_1;
                        case 2:
                            goto AnonFun12_2;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((parent).var_myTimeParent)).fieldValues[1]).Clone())).nt > ((PrtIntValue)((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone())).nt))).bl)
                        goto AnonFun12_if_0_else;
                    (parent).var_myTimeParent = ((currFun).var_payload).Clone();
                    goto AnonFun12_if_0_end;
                    AnonFun12_if_0_else:
                        ;
                    AnonFun12_if_0_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone()).Equals((((PrtTupleValue)((parent).var_myTimeParent)).fieldValues[0]).Clone())))).bl)
                        goto AnonFun12_if_1_else;
                    (parent).var_lastSynched = (new PrtIntValue(0)).Clone();
                    goto AnonFun12_if_1_end;
                    AnonFun12_if_1_else:
                        ;
                    AnonFun12_if_1_end:
                        ;
                    (((PrtMachineValue)((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone())).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Ack), new PrtTupleValue(parent.self, (parent).var_myRank), parent, (PrtMachineValue)((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone()));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun12_1:
                        ;
                    (((PrtMachineValue)((parent).var_slotTimer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_endSlot), Events.@null, parent, (PrtMachineValue)((parent).var_slotTimer));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    AnonFun12_2:
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    AnonFun13_StackFrame currFun = (AnonFun13_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun13_1;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtIntValue)((((PrtTupleValue)((parent).var_myTimeParent)).fieldValues[1]).Clone())).nt > ((PrtIntValue)((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone())).nt))).bl)
                        goto AnonFun13_if_0_else;
                    (parent).var_myTimeParent = ((currFun).var_payload).Clone();
                    goto AnonFun13_if_0_end;
                    AnonFun13_if_0_else:
                        ;
                    AnonFun13_if_0_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone()).Equals((((PrtTupleValue)((parent).var_myTimeParent)).fieldValues[0]).Clone())))).bl)
                        goto AnonFun13_if_1_else;
                    (parent).var_lastSynched = (new PrtIntValue(0)).Clone();
                    goto AnonFun13_if_1_end;
                    AnonFun13_if_1_else:
                        ;
                    AnonFun13_if_1_end:
                        ;
                    (((PrtMachineValue)((parent).var_slotTimer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_endSlot), Events.@null, parent, (PrtMachineValue)((parent).var_slotTimer));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun13_1:
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    AnonFun14_StackFrame currFun = (AnonFun14_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun14_1;
                        case 2:
                            goto AnonFun14_2;
                        case 3:
                            goto AnonFun14_3;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)((((PrtTupleValue)((parent).var_currentSlot)).fieldValues[0]).Clone())).bl))).bl)
                        goto AnonFun14_if_2_else;
                    if (!((PrtBoolValue)(new PrtBoolValue(((((PrtTupleValue)((((PrtTupleValue)((parent).var_currentSlot)).fieldValues[1]).Clone())).fieldValues[0]).Clone()).Equals(parent.self)))).bl)
                        goto AnonFun14_if_0_else;
                    (parent).PrtPushFunStackFrame(TransmitData, (TransmitData).CreateLocals((((PrtTupleValue)((((PrtTupleValue)((parent).var_currentSlot)).fieldValues[1]).Clone())).fieldValues[1]).Clone()));
                    AnonFun14_1:
                        ;
                    (TransmitData).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 1);
                        return;
                    }

                    if (!!(Events.event_TxDone).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(180,6,180,11): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_TxDone)).evt).name);
                    (parent).currentTrigger = Events.event_TxDone;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto AnonFun14_if_0_end;
                    AnonFun14_if_0_else:
                        ;
                    if (!!(Events.event_Local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(184,6,184,11): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Local)).evt).name);
                    (parent).currentTrigger = Events.event_Local;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    AnonFun14_if_0_end:
                        ;
                    goto AnonFun14_if_2_end;
                    AnonFun14_if_2_else:
                        ;
                    (parent).PrtPushFunStackFrame(CSMA_CA, (CSMA_CA).CreateLocals());
                    AnonFun14_2:
                        ;
                    (CSMA_CA).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                        (parent).var_check = ((parent).continuation).retVal;
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 2);
                        return;
                    }

                    if (!((PrtBoolValue)((parent).var_check)).bl)
                        goto AnonFun14_if_1_else;
                    (parent).PrtPushFunStackFrame(TransmitData, (TransmitData).CreateLocals(Events.@null));
                    AnonFun14_3:
                        ;
                    (TransmitData).Execute(application, parent);
                    if (((parent).continuation).reason == PrtContinuationReason.Return)
                    {
                    }
                    else
                    {
                        (parent).PrtPushFunStackFrame((currFun).fun, (currFun).locals, 3);
                        return;
                    }

                    if (!!(Events.event_TxDone).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(194,6,194,11): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_TxDone)).evt).name);
                    (parent).currentTrigger = Events.event_TxDone;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto AnonFun14_if_1_end;
                    AnonFun14_if_1_else:
                        ;
                    if (!!(Events.event_Local).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(198,6,198,11): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Local)).evt).name);
                    (parent).currentTrigger = Events.event_Local;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    AnonFun14_if_1_end:
                        ;
                    AnonFun14_if_2_end:
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    AnonFun16_StackFrame currFun = (AnonFun16_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun16_1;
                    }

                    (((PrtMachineValue)((parent).var_slotTimer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_endSlot), Events.@null, parent, (PrtMachineValue)((parent).var_slotTimer));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun16_1:
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    AnonFun19_StackFrame currFun = (AnonFun19_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun19_1;
                    }

                    (((PrtMachineValue)((parent).var_slotTimer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_endSlot), Events.@null, parent, (PrtMachineValue)((parent).var_slotTimer));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun19_1:
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    AnonFun21_StackFrame currFun = (AnonFun21_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun21_1;
                    }

                    (((PrtMachineValue)((parent).var_slotTimer)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_endSlot), Events.@null, parent, (PrtMachineValue)((parent).var_slotTimer));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun21_1:
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
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
                    OpenWSN_Mote parent = (OpenWSN_Mote)(_parent);
                    AnonFun23_StackFrame currFun = (AnonFun23_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_slotTimer = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[0]).Clone()).Clone();
                    (parent).var_myNeighbours = ((((PrtTupleValue)((currFun).var_payload)).fieldValues[1]).Clone()).Clone();
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
            public class OpenWSN_Mote_WaitForAck_Class : PrtState
            {
                public OpenWSN_Mote_WaitForAck_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static OpenWSN_Mote_WaitForAck_Class OpenWSN_Mote_WaitForAck;
            public class OpenWSN_Mote_WaitForNewSlot_Class : PrtState
            {
                public OpenWSN_Mote_WaitForNewSlot_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static OpenWSN_Mote_WaitForNewSlot_Class OpenWSN_Mote_WaitForNewSlot;
            public class OpenWSN_Mote_init_mote_Class : PrtState
            {
                public OpenWSN_Mote_init_mote_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static OpenWSN_Mote_init_mote_Class OpenWSN_Mote_init_mote;
            public class OpenWSN_Mote_DataReceptionMode_Class : PrtState
            {
                public OpenWSN_Mote_DataReceptionMode_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static OpenWSN_Mote_DataReceptionMode_Class OpenWSN_Mote_DataReceptionMode;
            public class OpenWSN_Mote_DataTransmissionMode_Class : PrtState
            {
                public OpenWSN_Mote_DataTransmissionMode_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static OpenWSN_Mote_DataTransmissionMode_Class OpenWSN_Mote_DataTransmissionMode;
            static OpenWSN_Mote()
            {
                OpenWSN_Mote_WaitForAck = new OpenWSN_Mote_WaitForAck_Class("OpenWSN_Mote_WaitForAck", AnonFun0, AnonFun1, true, StateTemperature.Warm);
                OpenWSN_Mote_WaitForNewSlot = new OpenWSN_Mote_WaitForNewSlot_Class("OpenWSN_Mote_WaitForNewSlot", AnonFun2, AnonFun3, false, StateTemperature.Warm);
                OpenWSN_Mote_init_mote = new OpenWSN_Mote_init_mote_Class("OpenWSN_Mote_init_mote", AnonFun5, AnonFun6, false, StateTemperature.Warm);
                OpenWSN_Mote_DataReceptionMode = new OpenWSN_Mote_DataReceptionMode_Class("OpenWSN_Mote_DataReceptionMode", AnonFun18, AnonFun17, false, StateTemperature.Warm);
                OpenWSN_Mote_DataTransmissionMode = new OpenWSN_Mote_DataTransmissionMode_Class("OpenWSN_Mote_DataTransmissionMode", AnonFun14, AnonFun15, false, StateTemperature.Warm);
                OpenWSN_Mote_WaitForAck.dos.Add(Events.event_Data, PrtFun.IgnoreFun);
                PrtTransition transition_1 = new PrtTransition(AnonFun19, OpenWSN_Mote_WaitForNewSlot, false);
                OpenWSN_Mote_WaitForAck.transitions.Add(Events.@null, transition_1);
                PrtTransition transition_2 = new PrtTransition(AnonFun13, OpenWSN_Mote_WaitForNewSlot, false);
                OpenWSN_Mote_WaitForAck.transitions.Add(Events.event_Ack, transition_2);
                OpenWSN_Mote_WaitForNewSlot.dos.Add(Events.event_newSlot, AnonFun4);
                OpenWSN_Mote_WaitForNewSlot.dos.Add(Events.event_Ack, PrtFun.IgnoreFun);
                OpenWSN_Mote_WaitForNewSlot.dos.Add(Events.event_Data, PrtFun.IgnoreFun);
                PrtTransition transition_3 = new PrtTransition(AnonFun21, OpenWSN_Mote_WaitForNewSlot, false);
                OpenWSN_Mote_WaitForNewSlot.transitions.Add(Events.event_Sleep, transition_3);
                PrtTransition transition_4 = new PrtTransition(AnonFun20, OpenWSN_Mote_DataReceptionMode, false);
                OpenWSN_Mote_WaitForNewSlot.transitions.Add(Events.event_Rx, transition_4);
                PrtTransition transition_5 = new PrtTransition(AnonFun22, OpenWSN_Mote_DataTransmissionMode, false);
                OpenWSN_Mote_WaitForNewSlot.transitions.Add(Events.event_Tx, transition_5);
                OpenWSN_Mote_init_mote.dos.Add(Events.event_Data, PrtFun.IgnoreFun);
                OpenWSN_Mote_init_mote.deferredSet.Add(Events.event_newSlot);
                PrtTransition transition_6 = new PrtTransition(AnonFun23, OpenWSN_Mote_WaitForNewSlot, false);
                OpenWSN_Mote_init_mote.transitions.Add(Events.event_Initialize, transition_6);
                PrtTransition transition_7 = new PrtTransition(AnonFun12, OpenWSN_Mote_WaitForNewSlot, false);
                OpenWSN_Mote_DataReceptionMode.transitions.Add(Events.event_Data, transition_7);
                PrtTransition transition_8 = new PrtTransition(AnonFun11, OpenWSN_Mote_WaitForAck, false);
                OpenWSN_Mote_DataTransmissionMode.transitions.Add(Events.event_TxDone, transition_8);
                PrtTransition transition_9 = new PrtTransition(AnonFun16, OpenWSN_Mote_WaitForNewSlot, false);
                OpenWSN_Mote_DataTransmissionMode.transitions.Add(Events.event_Local, transition_9);
            }
        }

        public class Main : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return Main_init;
                }
            }

            public PrtValue var_slotT
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

            public PrtValue var_templ
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

            public PrtValue var_N4
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

            public PrtValue var_N3
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

            public PrtValue var_N2
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

            public PrtValue var_N1
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
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_OpenWSN_Mote));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_5_969060819));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_OpenWSN_Mote));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_OpenWSN_Mote));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_OpenWSN_Mote));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_OpenWSN_Mote));
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
                    Main parent = (Main)(_parent);
                    AnonFun2_StackFrame currFun = (AnonFun2_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun2_1;
                        case 2:
                            goto AnonFun2_2;
                        case 3:
                            goto AnonFun2_3;
                        case 4:
                            goto AnonFun2_4;
                        case 5:
                            goto AnonFun2_5;
                        case 6:
                            goto AnonFun2_6;
                        case 7:
                            goto AnonFun2_7;
                        case 8:
                            goto AnonFun2_8;
                        case 9:
                            goto AnonFun2_9;
                    }

                    (parent).var_N1 = (application).CreateInterface(parent, "OpenWSN_Mote", new PrtIntValue(0));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 1);
                    return;
                    AnonFun2_1:
                        ;
                    (parent).var_N2 = (application).CreateInterface(parent, "OpenWSN_Mote", new PrtIntValue(1));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 2);
                    return;
                    AnonFun2_2:
                        ;
                    (parent).var_N3 = (application).CreateInterface(parent, "OpenWSN_Mote", new PrtIntValue(2));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 3);
                    return;
                    AnonFun2_3:
                        ;
                    (parent).var_N4 = (application).CreateInterface(parent, "OpenWSN_Mote", new PrtIntValue(1));
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 4);
                    return;
                    AnonFun2_4:
                        ;
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N1))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N1))).fieldValues[1]);
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N2))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N2))).fieldValues[1]);
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N3))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N3))).fieldValues[1]);
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N4))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N4))).fieldValues[1]);
                    (parent).var_slotT = (application).CreateInterface(parent, "SlotTimerMachine", (parent).var_templ);
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 5);
                    return;
                    AnonFun2_5:
                        ;
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    if (!((PrtBoolValue)(new PrtBoolValue((new PrtIntValue(((parent).var_templ).Size())).Equals(new PrtIntValue(0))))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(56,52,56,58): error PC1001: Assert failed");
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N2))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N2))).fieldValues[1]);
                    (((PrtMachineValue)((parent).var_N1)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Initialize), new PrtTupleValue((parent).var_slotT, (parent).var_templ), parent, (PrtMachineValue)((parent).var_N1));
                    (parent).PrtFunContSend(this, (currFun).locals, 6);
                    return;
                    AnonFun2_6:
                        ;
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    if (!((PrtBoolValue)(new PrtBoolValue((new PrtIntValue(((parent).var_templ).Size())).Equals(new PrtIntValue(0))))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(60,16,60,22): error PC1001: Assert failed");
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N1))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N1))).fieldValues[1]);
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N3))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N3))).fieldValues[1]);
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N4))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N4))).fieldValues[1]);
                    (((PrtMachineValue)((parent).var_N2)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Initialize), new PrtTupleValue((parent).var_slotT, (parent).var_templ), parent, (PrtMachineValue)((parent).var_N2));
                    (parent).PrtFunContSend(this, (currFun).locals, 7);
                    return;
                    AnonFun2_7:
                        ;
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    if (!((PrtBoolValue)(new PrtBoolValue((new PrtIntValue(((parent).var_templ).Size())).Equals(new PrtIntValue(0))))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(63,40,63,46): error PC1001: Assert failed");
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N2))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N2))).fieldValues[1]);
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N4))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N4))).fieldValues[1]);
                    (((PrtMachineValue)((parent).var_N3)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Initialize), new PrtTupleValue((parent).var_slotT, (parent).var_templ), parent, (PrtMachineValue)((parent).var_N3));
                    (parent).PrtFunContSend(this, (currFun).locals, 8);
                    return;
                    AnonFun2_8:
                        ;
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    if (!((PrtBoolValue)(new PrtBoolValue((new PrtIntValue(((parent).var_templ).Size())).Equals(new PrtIntValue(0))))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(66,28,66,34): error PC1001: Assert failed");
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N2))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N2))).fieldValues[1]);
                    ((PrtSeqValue)((parent).var_templ)).Insert(((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N3))).fieldValues[0], ((PrtTupleValue)(new PrtTupleValue(new PrtIntValue(0), (parent).var_N3))).fieldValues[1]);
                    (((PrtMachineValue)((parent).var_N4)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Initialize), new PrtTupleValue((parent).var_slotT, (parent).var_templ), parent, (PrtMachineValue)((parent).var_N4));
                    (parent).PrtFunContSend(this, (currFun).locals, 9);
                    return;
                    AnonFun2_9:
                        ;
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    ((PrtSeqValue)((parent).var_templ)).Remove(new PrtIntValue(0));
                    if (!((PrtBoolValue)(new PrtBoolValue((new PrtIntValue(((parent).var_templ).Size())).Equals(new PrtIntValue(0))))).bl)
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\correct\\\\openwsn1\\\\openwsn1.p(69,28,69,34): error PC1001: Assert failed");
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
            public class Main_init_Class : PrtState
            {
                public Main_init_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Main_init_Class Main_init;
            static Main()
            {
                Main_init = new Main_init_Class("Main_init", AnonFun2, AnonFun1, false, StateTemperature.Warm);
            }
        }
    }
}
