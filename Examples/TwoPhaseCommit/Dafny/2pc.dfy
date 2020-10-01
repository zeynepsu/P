
type Key = nat
type Value = nat
type Transaction(==)

datatype CState = WaitForTransactions | WaitForPrepareResponses


// verified calculations (calc statement)

// verification corner video (bright shirt)

// asserts are line inline lemmas

// Traits when different kinds of participants?
// or label?

// assert <condition> by {<proof>}  

// power user: different styles of proofs

class Participant {
    // out
    var ePrepareSuccess : multiset<Transaction>;
    var ePrepareFailed : multiset<Transaction>;
    // in
    var ePrepare : multiset<Transaction>;
    var eGlobalCommit : multiset<Transaction>;
    var eGlobalAbort : multiset<Transaction>;

    var kvstores : map<Key, Value>; // p's kvstore

    // pass in param to methods that has full set?
    // 
}


class Driver {
    var state : CState;
    var participants : set<Participant>;
    const payload : map<Transaction, (Key, Value)>

    // PARTICIPANT ACTIONS
    method on_prepare(p : Participant, trans : Transaction)
        modifies this, participants
        requires Inv(trans, participants);
        ensures Inv(trans, participants);
        requires p.ePrepare[trans] > 0;
        requires p in participants;
    {
        p.ePrepare := p.ePrepare - multiset{trans};
        if (*) {
            p.ePrepareSuccess := p.ePrepareSuccess + multiset{trans};
        } else {
            p.ePrepareFailed := p.ePrepareFailed + multiset{trans};
        }
    }

    method on_commit(p : Participant, trans : Transaction)
        modifies this, participants
        requires Inv(trans, participants);
        ensures Inv(trans, participants);
        requires p.eGlobalCommit[trans] > 0;
        requires p in participants;
    {
        p.eGlobalCommit := p.eGlobalCommit - multiset{trans};
        var (k, v) := payload[trans];
        p.kvstores := p.kvstores[k := v];
    }

    method on_abort(p : Participant, trans : Transaction)
        modifies this, participants
        requires Inv(trans, participants);
        ensures Inv(trans, participants);
        requires p.eGlobalAbort[trans] > 0;
        requires p in participants;
    {
        p.eGlobalAbort := p.eGlobalAbort - multiset{trans};
    }

    // COORDINATOR ACTIONS
    method on_transaction(trans : Transaction)
        modifies this, participants
        requires Inv(trans, participants);
        ensures Inv(trans, participants);
        requires forall q, t :: (q in participants) ==> q.eGlobalCommit[t] == 0;
        requires forall q, t :: (q in participants) ==> q.eGlobalAbort[t] == 0;
        requires forall q, t :: (q in participants) ==> q.ePrepare[t] == 0;
        requires forall q, t :: (q in participants) ==> q.ePrepareFailed[t] == 0;
        requires forall q, t :: (q in participants) ==> q.ePrepareSuccess[t] == 0;

        ensures forall q, t :: (q in participants) ==> q.eGlobalCommit[t] == 0;
        ensures forall q, t :: (q in participants) ==> q.eGlobalAbort[t] == 0;
        ensures forall q, t :: (q in participants) ==> (q.ePrepare[t] == 0 || (t == trans && q.ePrepare[trans] == 1));
        ensures forall q, t :: (q in participants) ==> q.ePrepareFailed[t] == 0;
        ensures forall q, t :: (q in participants) ==> q.ePrepareSuccess[t] == 0;
        requires state == WaitForTransactions;
    {
        var todo : set<Participant> := participants;
        participants := {};
        while todo != {}
            invariant forall q, t :: (q in todo) ==> q.eGlobalCommit[t] == 0;
            invariant forall q, t :: (q in todo) ==> q.eGlobalAbort[t] == 0;
            invariant forall q, t :: (q in todo) ==> q.ePrepare[t] == 0;
            invariant forall q, t :: (q in todo) ==> q.ePrepareFailed[t] == 0;
            invariant forall q, t :: (q in todo) ==> q.ePrepareSuccess[t] == 0;
            invariant forall q, t :: (q in participants) ==> q.eGlobalCommit[t] == 0;
            invariant forall q, t :: (q in participants) ==> q.eGlobalAbort[t] == 0;
            invariant forall q, t :: (q in participants) ==> (q.ePrepare[t] == 0 || (t == trans && q.ePrepare[trans] == 1));
            invariant forall q, t :: (q in participants) ==> q.ePrepareFailed[t] == 0;
            invariant forall q, t :: (q in participants) ==> q.ePrepareSuccess[t] == 0;
            invariant InvNoState(trans, participants + todo);
            decreases todo;
        {
            var y :| y in todo;
            y.ePrepare := y.ePrepare + multiset{trans};
            todo := todo - { y };
            participants := participants + { y };
        }
        state := WaitForPrepareResponses;
    }


    method on_failed(q : Participant, trans : Transaction)
        modifies this, participants
        requires Inv(trans, participants);
        ensures Inv(trans, participants);
        requires q in participants && q.ePrepareFailed[trans] > 0;
        requires state == WaitForPrepareResponses;
    {
        forall (y | y in participants) {
            y.eGlobalAbort := y.eGlobalAbort + multiset{trans};
        }
        forall (y | y in participants) {
            y.ePrepare := y.ePrepare - multiset{trans};
        }
        forall (y | y in participants) {
            y.ePrepareFailed := y.ePrepareFailed - multiset{trans};
        }
        forall (y | y in participants) {
            y.ePrepareSuccess := y.ePrepareSuccess - multiset{trans};
        }

        state := WaitForTransactions;
    }

    method on_success(q : Participant, trans : Transaction)
        modifies this, participants
        requires Inv(trans, participants);
        ensures Inv(trans, participants);
        requires q in participants && q.ePrepareSuccess[trans] > 0;
        requires state == WaitForPrepareResponses;
    {        
        if (forall q :: q in participants ==> q.ePrepareSuccess[trans] > 0) {       
            forall (y | y in participants) {
                y.eGlobalCommit := y.eGlobalCommit + multiset{trans};
            }
            forall (y | y in participants) {
                y.ePrepare := y.ePrepare - multiset{trans};
            }
            forall (y | y in participants) {
                y.ePrepareFailed := y.ePrepareFailed - multiset{trans};
            }
            forall (y | y in participants) {
                y.ePrepareSuccess := y.ePrepareSuccess - multiset{trans};
            }
            //replace with forall statement (in par)
                // restriction: 1 assignment statement in body 
                // 4 forall statements?
                // look in Dafny test suite (lines with forall but not ::)

            // Dafny power user series of notes (link in chat)

            state := WaitForTransactions;
        }
    }

    predicate InvNoState(current : Transaction, nodes : set<Participant>) 
        reads this, nodes
    {
        // only ever one of ePrepareSuccess, ePrepareFailed and ePrepare
        && (forall i, t :: (i in nodes) ==> (i.ePrepareSuccess[t] == 0 || i.ePrepareFailed[t] == 0))
        && (forall i, t :: (i in nodes) ==> (i.ePrepare[t] == 0 || i.ePrepareFailed[t] == 0))
        && (forall i, t :: (i in nodes) ==> (i.ePrepareSuccess[t] == 0 || i.ePrepare[t] == 0))

        // only ever one
        && (forall i, t :: (i in nodes) ==> i.ePrepare[t] > 0 ==> (i.ePrepare[t] == 1))
        && (forall i, t :: (i in nodes) ==> i.ePrepareSuccess[t] > 0 ==> (i.ePrepareSuccess[t] == 1))
        && (forall i, t :: (i in nodes) ==> i.ePrepareFailed[t] > 0 ==> (i.ePrepareFailed[t] == 1))
        && (forall i, t :: (i in nodes) ==> i.eGlobalAbort[t] > 0 ==> (i.eGlobalAbort[t] == 1))
        && (forall i, t :: (i in nodes) ==> i.eGlobalCommit[t] > 0 ==> (i.eGlobalCommit[t] == 1))

        // all transactions in payload
        && (forall t :: t in payload)

        // invariant one_GlobalCommit_overall: 
        && (forall n : Participant, t1 : Transaction, t2: Transaction :: (n in nodes) ==> (n.eGlobalCommit[t1] > 0 ==> (t1 != t2 ==> n.eGlobalCommit[t2] == 0)))
        // invariant one_GlobalAbort_overall: 
        && (forall n : Participant, t1 : Transaction, t2: Transaction :: (n in nodes) ==> (n.eGlobalAbort[t1] > 0 ==> (t1 != t2 ==> n.eGlobalAbort[t2] == 0)))
        // invariant one_Prepare_overall: 
        && (forall n : Participant, t1 : Transaction, t2: Transaction :: (n in nodes) ==> (n.ePrepare[t1] > 0 ==> (t1 != t2 ==> n.ePrepare[t2] == 0)))

        // invariant everything_false_except_current: 
        && (forall n1 : Participant, t : Transaction :: (n1 in nodes) ==> (t != current ==> (t !in n1.eGlobalCommit && t !in n1.eGlobalAbort && t !in n1.ePrepare && t !in n1.ePrepareSuccess && t !in n1.ePrepareFailed)))

        // eGlobalCommit_means_everyone_eGlobalCommit_or_eGlobalCommited
        && (forall n1 : Participant, n2 : Participant, t : Transaction :: (n1 in nodes && n2 in nodes) 
            ==> ((n1.eGlobalCommit[t] > 0)
                ==> (n2.eGlobalCommit[t] > 0 || (payload[t].0 in n2.kvstores && n2.kvstores[payload[t].0] == payload[t].1))))

        // // no_lonely_kvstore
        // && (forall n1 : Participant,  n2 : Participant, k1 : Key :: (n1 in nodes && n2 in nodes) 
        //     ==> (k1 in n1.kvstores ==> (k1 in n2.kvstores ==> n1.kvstores[k1] == n2.kvstores[k1])))
        && (forall n1 : Participant,  n2 : Participant, k1 : Key :: (n1 in nodes && n2 in nodes) 
            ==> ((k1 in n1.kvstores && k1 !in n2.kvstores) ==> k1 == payload[current].0))

        // MAIN INVARIANT
        && (forall n1 : Participant, n2 : Participant, k : Key :: (n1 in nodes && n2 in nodes && k != payload[current].0)
            ==> ((k in n1.kvstores && k in n2.kvstores && n1.kvstores[k] == n2.kvstores[k]) || (k !in n1.kvstores && k !in n2.kvstores)))
    }

    predicate InvState(current : Transaction, nodes : set<Participant>) 
        reads this, nodes
    {
        // invariant GlobalCommit_means_WaitForTransactions: 
        && ((exists n : Participant, t : Transaction :: (n in nodes) && (n.eGlobalCommit[t] > 0 || n.eGlobalAbort[t] > 0)) ==> state == WaitForTransactions)
        // invariant Prepare_means_WaitForPrepareResponses: 
        && ((exists n : Participant, t : Transaction :: (n in nodes) && (n.ePrepare[t] > 0 || n.ePrepareFailed[t] > 0 || n.ePrepareSuccess[t] > 0)) ==> state == WaitForPrepareResponses)
    }

    predicate Inv(current : Transaction, nodes : set<Participant>)
        reads this, nodes
    {
        && InvNoState(current, nodes) 
        && InvState(current, nodes)
    }
}