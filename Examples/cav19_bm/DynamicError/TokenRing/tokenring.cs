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
            public static PrtEventValue event_Empty;
            public static PrtEventValue event_Unit;
            public static PrtEventValue event_Sending;
            public static PrtEventValue event_Done;
            public static PrtEventValue event_Next;
            public static PrtEventValue event_Send;
            public static PrtEventValue event_Ready;
            public static void Events_tokenring()
            {
                event_Empty = new PrtEventValue(new PrtEvent("Empty", Types.type_4_1012985913, 1, false));
                event_Unit = new PrtEventValue(new PrtEvent("Unit", Types.type_4_1012985913, 0, false));
                event_Sending = new PrtEventValue(new PrtEvent("Sending", Types.type_Main, PrtEvent.DefaultMaxInstances, false));
                event_Done = new PrtEventValue(new PrtEvent("Done", Types.type_Main, PrtEvent.DefaultMaxInstances, false));
                event_Next = new PrtEventValue(new PrtEvent("Next", Types.type_Main, PrtEvent.DefaultMaxInstances, false));
                event_Send = new PrtEventValue(new PrtEvent("Send", Types.type_Main, PrtEvent.DefaultMaxInstances, false));
                event_Ready = new PrtEventValue(new PrtEvent("Ready", Types.type_4_1012985913, PrtEvent.DefaultMaxInstances, false));
            }
        }

        public partial class Types
        {
            public static PrtType type_Main;
            public static PrtType type_1_1012985913;
            public static PrtType type_2_1012985913;
            public static PrtType type_3_1012985913;
            public static PrtType type_4_1012985913;
            public static PrtType type_Node;
            static public void Types_tokenring()
            {
                Types.type_Main = new PrtMachineType();
                Types.type_1_1012985913 = new PrtEventType();
                Types.type_2_1012985913 = new PrtIntType();
                Types.type_3_1012985913 = new PrtBoolType();
                Types.type_4_1012985913 = new PrtNullType();
                Types.type_Node = Types.type_Main;
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

        public static PrtImplMachine CreateMachine_Node(StateImpl application, PrtValue payload)
        {
            var machine = new Node(application, 100, true);
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
                    return Main_Boot_Main_Ring4;
                }
            }

            public PrtValue var_RandDst
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

            public PrtValue var_RandSrc
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

            public PrtValue var_Rand2
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

            public PrtValue var_Rand1
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

            public PrtValue var_ReadyCount
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

            public PrtValue var_N4
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

            public PrtValue var_N3
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

            public PrtValue var_N2
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

            public PrtValue var_N1
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
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Main));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Main));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_3_1012985913));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_3_1012985913));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_2_1012985913));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Main));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Main));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Main));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Main));
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
                    Main parent = (Main)(_parent);
                    AnonFun0_StackFrame currFun = (AnonFun0_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun0_1;
                        case 2:
                            goto AnonFun0_2;
                        case 3:
                            goto AnonFun0_3;
                        case 4:
                            goto AnonFun0_4;
                        case 5:
                            goto AnonFun0_5;
                        case 6:
                            goto AnonFun0_6;
                        case 7:
                            goto AnonFun0_7;
                        case 8:
                            goto AnonFun0_8;
                    }

                    (parent).var_N1 = (application).CreateInterface(parent, "Node", parent.self);
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 1);
                    return;
                    AnonFun0_1:
                        ;
                    (parent).var_N2 = (application).CreateInterface(parent, "Node", parent.self);
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 2);
                    return;
                    AnonFun0_2:
                        ;
                    (parent).var_N3 = (application).CreateInterface(parent, "Node", parent.self);
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 3);
                    return;
                    AnonFun0_3:
                        ;
                    (parent).var_N4 = (application).CreateInterface(parent, "Node", parent.self);
                    (parent).PrtFunContNewMachine(this, (currFun).locals, 4);
                    return;
                    AnonFun0_4:
                        ;
                    (((PrtMachineValue)((parent).var_N1)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Next), (parent).var_N2, parent, (PrtMachineValue)((parent).var_N1));
                    (parent).PrtFunContSend(this, (currFun).locals, 5);
                    return;
                    AnonFun0_5:
                        ;
                    (((PrtMachineValue)((parent).var_N2)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Next), (parent).var_N3, parent, (PrtMachineValue)((parent).var_N2));
                    (parent).PrtFunContSend(this, (currFun).locals, 6);
                    return;
                    AnonFun0_6:
                        ;
                    (((PrtMachineValue)((parent).var_N3)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Next), (parent).var_N4, parent, (PrtMachineValue)((parent).var_N3));
                    (parent).PrtFunContSend(this, (currFun).locals, 7);
                    return;
                    AnonFun0_7:
                        ;
                    (((PrtMachineValue)((parent).var_N4)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Next), (parent).var_N1, parent, (PrtMachineValue)((parent).var_N4));
                    (parent).PrtFunContSend(this, (currFun).locals, 8);
                    return;
                    AnonFun0_8:
                        ;
                    (parent).var_ReadyCount = (new PrtIntValue(-((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\dynamicerror\\\\tokenring\\\\tokenring.p(112,9,112,14): error PC1001: Raised event must be non-null");
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
                    Main parent = (Main)(_parent);
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
                    Main parent = (Main)(_parent);
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
                    Main parent = (Main)(_parent);
                    AnonFun5_StackFrame currFun = (AnonFun5_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun5_1;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto AnonFun5_if_0_else;
                    (parent).var_Rand1 = (new PrtBoolValue(true)).Clone();
                    goto AnonFun5_if_0_end;
                    AnonFun5_if_0_else:
                        ;
                    (parent).var_Rand1 = (new PrtBoolValue(false)).Clone();
                    AnonFun5_if_0_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto AnonFun5_if_1_else;
                    (parent).var_Rand2 = (new PrtBoolValue(true)).Clone();
                    goto AnonFun5_if_1_end;
                    AnonFun5_if_1_else:
                        ;
                    (parent).var_Rand2 = (new PrtBoolValue(false)).Clone();
                    AnonFun5_if_1_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)((parent).var_Rand1)).bl))).bl && ((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)((parent).var_Rand2)).bl))).bl))).bl)
                        goto AnonFun5_if_2_else;
                    (parent).var_RandSrc = ((parent).var_N1).Clone();
                    goto AnonFun5_if_2_end;
                    AnonFun5_if_2_else:
                        ;
                    AnonFun5_if_2_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)((parent).var_Rand1)).bl))).bl && ((PrtBoolValue)((parent).var_Rand2)).bl))).bl)
                        goto AnonFun5_if_3_else;
                    (parent).var_RandSrc = ((parent).var_N2).Clone();
                    goto AnonFun5_if_3_end;
                    AnonFun5_if_3_else:
                        ;
                    AnonFun5_if_3_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtBoolValue)((parent).var_Rand1)).bl && ((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)((parent).var_Rand2)).bl))).bl))).bl)
                        goto AnonFun5_if_4_else;
                    (parent).var_RandSrc = ((parent).var_N3).Clone();
                    goto AnonFun5_if_4_end;
                    AnonFun5_if_4_else:
                        ;
                    (parent).var_RandSrc = ((parent).var_N4).Clone();
                    AnonFun5_if_4_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto AnonFun5_if_5_else;
                    (parent).var_Rand1 = (new PrtBoolValue(true)).Clone();
                    goto AnonFun5_if_5_end;
                    AnonFun5_if_5_else:
                        ;
                    (parent).var_Rand1 = (new PrtBoolValue(false)).Clone();
                    AnonFun5_if_5_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue((application).GetSelectedChoiceValue((PrtImplMachine)(parent))))).bl)
                        goto AnonFun5_if_6_else;
                    (parent).var_Rand2 = (new PrtBoolValue(true)).Clone();
                    goto AnonFun5_if_6_end;
                    AnonFun5_if_6_else:
                        ;
                    (parent).var_Rand2 = (new PrtBoolValue(false)).Clone();
                    AnonFun5_if_6_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)((parent).var_Rand1)).bl))).bl && ((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)((parent).var_Rand2)).bl))).bl))).bl)
                        goto AnonFun5_if_7_else;
                    (parent).var_RandDst = ((parent).var_N1).Clone();
                    goto AnonFun5_if_7_end;
                    AnonFun5_if_7_else:
                        ;
                    AnonFun5_if_7_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)((parent).var_Rand1)).bl))).bl && ((PrtBoolValue)((parent).var_Rand2)).bl))).bl)
                        goto AnonFun5_if_8_else;
                    (parent).var_RandDst = ((parent).var_N2).Clone();
                    goto AnonFun5_if_8_end;
                    AnonFun5_if_8_else:
                        ;
                    AnonFun5_if_8_end:
                        ;
                    if (!((PrtBoolValue)(new PrtBoolValue(((PrtBoolValue)((parent).var_Rand1)).bl && ((PrtBoolValue)(new PrtBoolValue(!((PrtBoolValue)((parent).var_Rand2)).bl))).bl))).bl)
                        goto AnonFun5_if_9_else;
                    (parent).var_RandDst = ((parent).var_N3).Clone();
                    goto AnonFun5_if_9_end;
                    AnonFun5_if_9_else:
                        ;
                    (parent).var_RandDst = ((parent).var_N4).Clone();
                    AnonFun5_if_9_end:
                        ;
                    (((PrtMachineValue)((parent).var_RandSrc)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Send), (parent).var_RandDst, parent, (PrtMachineValue)((parent).var_RandSrc));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun5_1:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\dynamicerror\\\\tokenring\\\\tokenring.p(167,17,167,22): error PC1001: Raised event must be non-null");
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
                    Main parent = (Main)(_parent);
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
                    Main parent = (Main)(_parent);
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
                    Main parent = (Main)(_parent);
                    AnonFun8_StackFrame currFun = (AnonFun8_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_ReadyCount = (new PrtIntValue(((PrtIntValue)((parent).var_ReadyCount)).nt + ((PrtIntValue)(new PrtIntValue(1))).nt)).Clone();
                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_ReadyCount).Equals(new PrtIntValue(4))))).bl)
                        goto AnonFun8_if_0_else;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\dynamicerror\\\\tokenring\\\\tokenring.p(123,11,123,16): error PC1001: Raised event must be non-null");
                    (application).TraceLine("<RaiseLog> Machine {0}-{1} raised Event {2}", (parent).Name, (parent).instanceNumber, (((PrtEventValue)(Events.event_Unit)).evt).name);
                    (parent).currentTrigger = Events.event_Unit;
                    (parent).currentPayload = Events.@null;
                    (parent).PrtFunContRaise();
                    return;
                    goto AnonFun8_if_0_end;
                    AnonFun8_if_0_else:
                        ;
                    AnonFun8_if_0_end:
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
                    Main parent = (Main)(_parent);
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
                    Main parent = (Main)(_parent);
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
                    Main parent = (Main)(_parent);
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
                    Main parent = (Main)(_parent);
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
            public class Main_Boot_Main_Ring4_Class : PrtState
            {
                public Main_Boot_Main_Ring4_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Main_Boot_Main_Ring4_Class Main_Boot_Main_Ring4;
            public class Main_RandomComm_Main_Ring4_Class : PrtState
            {
                public Main_RandomComm_Main_Ring4_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Main_RandomComm_Main_Ring4_Class Main_RandomComm_Main_Ring4;
            public class Main_Stabilize_Main_Ring4_Class : PrtState
            {
                public Main_Stabilize_Main_Ring4_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Main_Stabilize_Main_Ring4_Class Main_Stabilize_Main_Ring4;
            static Main()
            {
                Main_Boot_Main_Ring4 = new Main_Boot_Main_Ring4_Class("Main_Boot_Main_Ring4", AnonFun0, AnonFun1, false, StateTemperature.Warm);
                Main_RandomComm_Main_Ring4 = new Main_RandomComm_Main_Ring4_Class("Main_RandomComm_Main_Ring4", AnonFun5, AnonFun6, false, StateTemperature.Warm);
                Main_Stabilize_Main_Ring4 = new Main_Stabilize_Main_Ring4_Class("Main_Stabilize_Main_Ring4", AnonFun8, AnonFun9, false, StateTemperature.Warm);
                Main_Boot_Main_Ring4.deferredSet.Add(Events.event_Ready);
                PrtTransition transition_1 = new PrtTransition(AnonFun12, Main_Stabilize_Main_Ring4, false);
                Main_Boot_Main_Ring4.transitions.Add(Events.event_Unit, transition_1);
                PrtTransition transition_2 = new PrtTransition(AnonFun7, Main_RandomComm_Main_Ring4, false);
                Main_RandomComm_Main_Ring4.transitions.Add(Events.event_Unit, transition_2);
                PrtTransition transition_3 = new PrtTransition(AnonFun10, Main_RandomComm_Main_Ring4, false);
                Main_Stabilize_Main_Ring4.transitions.Add(Events.event_Unit, transition_3);
                PrtTransition transition_4 = new PrtTransition(AnonFun11, Main_Stabilize_Main_Ring4, false);
                Main_Stabilize_Main_Ring4.transitions.Add(Events.event_Ready, transition_4);
            }
        }

        public class Node : PrtImplMachine
        {
            public override PrtState StartState
            {
                get
                {
                    return Node_Init_Main_Node;
                }
            }

            public PrtValue var_MyRing
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

            public PrtValue var_NextMachine
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

            public PrtValue var_IsSending
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
                return new Node();
            }

            public override int NextInstanceNumber(StateImpl app)
            {
                return app.NextMachineInstanceNumber(this.GetType());
            }

            public override string Name
            {
                get
                {
                    return "Node";
                }
            }

            public Node(): base ()
            {
            }

            public Node(StateImpl app, int maxB, bool assume): base (app, maxB, assume)
            {
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Main));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_Main));
                (fields).Add(PrtValue.PrtMkDefaultValue(Types.type_3_1012985913));
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
                    AnonFun6_StackFrame currFun = (AnonFun6_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun6_1;
                    }

                    (((PrtMachineValue)((parent).var_NextMachine)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Empty), Events.@null, parent, (PrtMachineValue)((parent).var_NextMachine));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun6_1:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\dynamicerror\\\\tokenring\\\\tokenring.p(48,9,48,14): error PC1001: Raised event must be non-null");
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
                    Node parent = (Node)(_parent);
                    AnonFun7_StackFrame currFun = (AnonFun7_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun7_1;
                    }

                    (parent).var_IsSending = (new PrtBoolValue(true)).Clone();
                    (((PrtMachineValue)((parent).var_NextMachine)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Sending), (currFun).var_payload, parent, (PrtMachineValue)((parent).var_NextMachine));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun7_1:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\dynamicerror\\\\tokenring\\\\tokenring.p(58,9,58,14): error PC1001: Raised event must be non-null");
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
                    AnonFun14_StackFrame currFun = (AnonFun14_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    (parent).var_MyRing = ((currFun).var_payload).Clone();
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
                    AnonFun17_StackFrame currFun = (AnonFun17_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun17_1;
                    }

                    (parent).var_NextMachine = ((currFun).var_payload).Clone();
                    (((PrtMachineValue)((parent).var_MyRing)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Ready), Events.@null, parent, (PrtMachineValue)((parent).var_MyRing));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun17_1:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\dynamicerror\\\\tokenring\\\\tokenring.p(39,9,39,14): error PC1001: Raised event must be non-null");
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
                    Node parent = (Node)(_parent);
                    AnonFun18_StackFrame currFun = (AnonFun18_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun18_1;
                        case 2:
                            goto AnonFun18_2;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((parent).var_IsSending).Equals(new PrtBoolValue(true))))).bl)
                        goto AnonFun18_if_0_else;
                    (((PrtMachineValue)((parent).var_NextMachine)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Empty), Events.@null, parent, (PrtMachineValue)((parent).var_NextMachine));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun18_1:
                        ;
                    goto AnonFun18_if_0_end;
                    AnonFun18_if_0_else:
                        ;
                    (((PrtMachineValue)((parent).var_NextMachine)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Done), (currFun).var_payload, parent, (PrtMachineValue)((parent).var_NextMachine));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    AnonFun18_2:
                        ;
                    AnonFun18_if_0_end:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\dynamicerror\\\\tokenring\\\\tokenring.p(82,9,82,14): error PC1001: Raised event must be non-null");
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
                    Node parent = (Node)(_parent);
                    AnonFun19_StackFrame currFun = (AnonFun19_StackFrame)(parent.PrtPopFunStackFrame());
                    PrtValue swap;
                    switch ((currFun).returnToLocation)
                    {
                        case 1:
                            goto AnonFun19_1;
                        case 2:
                            goto AnonFun19_2;
                    }

                    if (!((PrtBoolValue)(new PrtBoolValue(((currFun).var_payload).Equals(parent.self)))).bl)
                        goto AnonFun19_if_0_else;
                    (((PrtMachineValue)((parent).var_NextMachine)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Done), parent.self, parent, (PrtMachineValue)((parent).var_NextMachine));
                    (parent).PrtFunContSend(this, (currFun).locals, 1);
                    return;
                    AnonFun19_1:
                        ;
                    goto AnonFun19_if_0_end;
                    AnonFun19_if_0_else:
                        ;
                    (((PrtMachineValue)((parent).var_NextMachine)).mach).PrtEnqueueEvent((PrtEventValue)(Events.event_Sending), (currFun).var_payload, parent, (PrtMachineValue)((parent).var_NextMachine));
                    (parent).PrtFunContSend(this, (currFun).locals, 2);
                    return;
                    AnonFun19_2:
                        ;
                    AnonFun19_if_0_end:
                        ;
                    if (!!(Events.event_Unit).Equals(Events.@null))
                        throw new PrtAssertFailureException("c:\\\\users\\\\peizu\\\\gitroot\\\\p\\\\examples\\\\dynamicerror\\\\tokenring\\\\tokenring.p(70,9,70,14): error PC1001: Raised event must be non-null");
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
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
                    Node parent = (Node)(_parent);
                    AnonFun28_StackFrame currFun = (AnonFun28_StackFrame)(parent.PrtPopFunStackFrame());
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
                    Node parent = (Node)(_parent);
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
            public class Node_StopSending_Main_Node_Class : PrtState
            {
                public Node_StopSending_Main_Node_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Node_StopSending_Main_Node_Class Node_StopSending_Main_Node;
            public class Node_KeepSending_Main_Node_Class : PrtState
            {
                public Node_KeepSending_Main_Node_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Node_KeepSending_Main_Node_Class Node_KeepSending_Main_Node;
            public class Node_StartSending_Main_Node_Class : PrtState
            {
                public Node_StartSending_Main_Node_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Node_StartSending_Main_Node_Class Node_StartSending_Main_Node;
            public class Node_SendEmpty_Main_Node_Class : PrtState
            {
                public Node_SendEmpty_Main_Node_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Node_SendEmpty_Main_Node_Class Node_SendEmpty_Main_Node;
            public class Node_SetNext_Main_Node_Class : PrtState
            {
                public Node_SetNext_Main_Node_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Node_SetNext_Main_Node_Class Node_SetNext_Main_Node;
            public class Node_Wait_Main_Node_Class : PrtState
            {
                public Node_Wait_Main_Node_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Node_Wait_Main_Node_Class Node_Wait_Main_Node;
            public class Node_Init_Main_Node_Class : PrtState
            {
                public Node_Init_Main_Node_Class(string name, PrtFun entryFun, PrtFun exitFun, bool hasNullTransition, StateTemperature temperature): base (name, entryFun, exitFun, hasNullTransition, temperature)
                {
                }
            }

            public static Node_Init_Main_Node_Class Node_Init_Main_Node;
            static Node()
            {
                Node_StopSending_Main_Node = new Node_StopSending_Main_Node_Class("Node_StopSending_Main_Node", AnonFun18, AnonFun28, false, StateTemperature.Warm);
                Node_KeepSending_Main_Node = new Node_KeepSending_Main_Node_Class("Node_KeepSending_Main_Node", AnonFun19, AnonFun21, false, StateTemperature.Warm);
                Node_StartSending_Main_Node = new Node_StartSending_Main_Node_Class("Node_StartSending_Main_Node", AnonFun7, AnonFun8, false, StateTemperature.Warm);
                Node_SendEmpty_Main_Node = new Node_SendEmpty_Main_Node_Class("Node_SendEmpty_Main_Node", AnonFun6, AnonFun10, false, StateTemperature.Warm);
                Node_SetNext_Main_Node = new Node_SetNext_Main_Node_Class("Node_SetNext_Main_Node", AnonFun17, AnonFun23, false, StateTemperature.Warm);
                Node_Wait_Main_Node = new Node_Wait_Main_Node_Class("Node_Wait_Main_Node", AnonFun29, AnonFun27, false, StateTemperature.Warm);
                Node_Init_Main_Node = new Node_Init_Main_Node_Class("Node_Init_Main_Node", AnonFun14, AnonFun15, false, StateTemperature.Warm);
                PrtTransition transition_1 = new PrtTransition(AnonFun26, Node_Wait_Main_Node, false);
                Node_StopSending_Main_Node.transitions.Add(Events.event_Unit, transition_1);
                PrtTransition transition_2 = new PrtTransition(AnonFun20, Node_Wait_Main_Node, false);
                Node_KeepSending_Main_Node.transitions.Add(Events.event_Unit, transition_2);
                PrtTransition transition_3 = new PrtTransition(AnonFun11, Node_Wait_Main_Node, false);
                Node_StartSending_Main_Node.transitions.Add(Events.event_Unit, transition_3);
                PrtTransition transition_4 = new PrtTransition(AnonFun9, Node_Wait_Main_Node, false);
                Node_SendEmpty_Main_Node.transitions.Add(Events.event_Unit, transition_4);
                PrtTransition transition_5 = new PrtTransition(AnonFun22, Node_Wait_Main_Node, false);
                Node_SetNext_Main_Node.transitions.Add(Events.event_Unit, transition_5);
                PrtTransition transition_6 = new PrtTransition(AnonFun25, Node_StopSending_Main_Node, false);
                Node_Wait_Main_Node.transitions.Add(Events.event_Done, transition_6);
                PrtTransition transition_7 = new PrtTransition(AnonFun24, Node_KeepSending_Main_Node, false);
                Node_Wait_Main_Node.transitions.Add(Events.event_Sending, transition_7);
                PrtTransition transition_8 = new PrtTransition(AnonFun13, Node_StartSending_Main_Node, false);
                Node_Wait_Main_Node.transitions.Add(Events.event_Send, transition_8);
                PrtTransition transition_9 = new PrtTransition(AnonFun12, Node_SendEmpty_Main_Node, false);
                Node_Wait_Main_Node.transitions.Add(Events.event_Empty, transition_9);
                PrtTransition transition_10 = new PrtTransition(AnonFun16, Node_SetNext_Main_Node, false);
                Node_Init_Main_Node.transitions.Add(Events.event_Next, transition_10);
            }
        }
    }
}
