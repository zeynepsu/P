/* 
This file declares all the events used for communication between various machines in the two phase commit protocol
*/ 

// events for communication between the coordinator and the participants
event ePrepare: tPrepareForTrans;
event ePrepareSuccess: int;
event ePrepareFailed: int;
event eGlobalAbort: int;
event eGlobalCommit: int;
event eWriteTransaction : tWriteTransaction;
event eWriteTransFailed;
event eWriteTransSuccess;
event eReadTransaction : tReadTransaction;
event eReadTransFailed;
event eReadTransSuccess: int;

// events for communication with the timer machine
event eTimeOut;
event eStartTimer: int;
event eCancelTimer;
event eCancelTimerFailed;
event eCancelTimerSuccess;

// events used for communication with the specification monitors
event eMonitor_LocalCommit: (participant:Participant, transId: int);
event eMonitor_AtomicityInitialize: int;

/* User defined types */
type tWriteTransaction = (client:Client, key:int, val:int);
type tReadTransaction = (client:Client, key:int);
type tPrepareForTrans = (coordinator: Coordinator, transId:int, key:int, val:int);