
type Key = nat
type Value = nat
type Transaction = nat

datatype CState = WaitForTransactions | WaitForPrepareResponses

class Driver {

    var ePrepareSuccess : array<multiset<Transaction>>;
    var ePrepareFailed : array<multiset<Transaction>>;
    // in
    var ePrepare : array<multiset<Transaction>>;
    var eGlobalCommit : array<multiset<Transaction>>;
    var eGlobalAbort : array<multiset<Transaction>>;

    var kvstores : array<map<Key, Value>>; // p's kvstore


    var state : CState;
    var payload : map<Transaction, (Key, Value)>

    // PARTICIPANT ACTIONS
    method on_prepare(id : nat, trans : Transaction)
        modifies ePrepare, ePrepareFailed, ePrepareSuccess
        requires Invariant(id, trans);
        ensures Invariant(id, trans);
        requires ePrepare[id][trans] > 0;
    {
        ePrepare[id] := ePrepare[id] - multiset{trans};
        if (*) {
            assert ePrepareFailed[id][trans] == 0;
            ePrepareSuccess[id] := ePrepareSuccess[id] + multiset{trans};
            assert ePrepareFailed[id][trans] == 0;
        } else {
            assert ePrepareSuccess[id][trans] == 0;
            ePrepareFailed[id] := ePrepareFailed[id] + multiset{trans};
            assert ePrepareSuccess[id][trans] == 0;
        }
    }

    method on_commit(id : nat, trans : Transaction)
        modifies eGlobalCommit, kvstores
        requires Invariant(id, trans);
        ensures Invariant(id, trans);
        requires eGlobalCommit[id][trans] > 0;
    {
        eGlobalCommit[id] := eGlobalCommit[id] - multiset{trans};
        var (k, v) := payload[trans];
        kvstores[id] := kvstores[id][k := v];
    }

    method on_abort(id : nat, trans : Transaction)
        modifies eGlobalAbort
        requires Invariant(id, trans);
        ensures Invariant(id, trans);
        requires eGlobalCommit[id][trans] > 0;
    {
        eGlobalAbort[id] := eGlobalAbort[id] - multiset{trans};
    }

    // COORDINATOR ACTIONS
    // method on_transaction(trans : Transaction)
    //     modifies this
    //     requires Invariant(0, trans);
    //     ensures Invariant(0, trans);
    //     requires forall i : nat :: i < kvstores.Length ==> eGlobalCommit[i][trans] == 0;
    //     requires forall i : nat :: i < kvstores.Length ==> eGlobalAbort[i][trans] == 0;
    //     requires forall i : nat :: i < kvstores.Length ==> ePrepare[i][trans] == 0;
    //     requires forall i : nat :: i < kvstores.Length ==> ePrepareFailed[i][trans] == 0;
    //     requires forall i : nat :: i < kvstores.Length ==> ePrepareSuccess[i][trans] == 0;
    //     requires state == WaitForTransactions;
    // {
    //     var i := 0;
    //     while i < kvstores.Length
    //         modifies this;
    //         invariant i <= ePrepare.Length;
    //         invariant forall j : nat :: j < i ==> Invariant(j, trans);
    //         invariant forall j : nat :: j < ePrepareSuccess.Length ==> ePrepareSuccess[j][trans] == 0;
    //         invariant forall j : nat :: j < ePrepareFailed.Length ==> ePrepareFailed[j][trans] == 0;
    //         invariant forall j : nat :: j < i ==> ePrepare[j][trans] == 1;
    //         invariant forall j : nat :: (j >= i && j < ePrepare.Length) ==> ePrepare[j][trans] == 0;
    //         decreases kvstores.Length - i;
    //     {
    //         ePrepare[i] := ePrepare[i] + multiset{trans};
    //         i := i + 1;
    //     }
    //     state := WaitForPrepareResponses;
    // }

    predicate Invariant(id : nat, trans : Transaction) 
        reads this, ePrepare, ePrepareSuccess, ePrepareFailed
    {
        && ePrepare.Length == ePrepareFailed.Length
        && ePrepare.Length == ePrepareSuccess.Length
        && ePrepare.Length == eGlobalAbort.Length
        && ePrepare.Length == eGlobalCommit.Length
        && ePrepare.Length == kvstores.Length

        && id < ePrepare.Length
        && trans in payload

        // only ever one of ePrepareSuccess, ePrepareFailed and ePrepare
        && (forall i : nat :: i < kvstores.Length ==> (ePrepareSuccess[i][trans] == 0 || ePrepareFailed[i][trans] == 0))
        && (forall i : nat :: i < kvstores.Length ==> (ePrepare[i][trans] == 0 || ePrepareFailed[i][trans] == 0))
        && (forall i : nat :: i < kvstores.Length ==> (ePrepareSuccess[i][trans] == 0 || ePrepare[i][trans] == 0))

        // only ever one
        && (forall i : nat :: i < kvstores.Length ==> ePrepare[i][trans] > 0 ==> (ePrepare[i][trans] == 1))
        && (forall i : nat :: i < kvstores.Length ==> ePrepareSuccess[i][trans] > 0 ==> (ePrepareSuccess[i][trans] == 1))
        && (forall i : nat :: i < kvstores.Length ==> ePrepareFailed[i][trans] > 0 ==> (ePrepareFailed[i][trans] == 1))
    }
}