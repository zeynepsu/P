pragma solidity ^0.4.24;
// TODO: PEvent null
// TODO: PEvent halt
// TODO: Interface DAO
contract DAO_1
{
    // Adding event type
    struct DAO_1_Event
    {
        int TypeId;
        int v_0;
        int v_0;
        address v_0;
    }
    // Adding inbox for the contract
    mapping (uint => Event) private inbox;
    uint private first = 1;
    uint private last = 0;
    bool private IsRunning = false;
    enum State
    {
        DAO_S1,
        DAO_S2,
        DAO_S3,
        Sys_Error_State
    }
    State private ContractCurrentState = State.DAO_S1;
    function Withdraw(int amount) private
    {
    }
    function Deposit(int amount_1) private
    {
    }
    function Transfer () public payable
    {
    }
    // Enqueue in the inbox
    function enqueue (Event e) private
    {
        last += 1;
        inbox[last] = e;
    }
    // Dequeue from the inbox
    function dequeue () private returns (Event e)
    {
        data = inbox[first];
        delete inbox[first];
        first += 1;
    }
    // Scheduler
    function scheduler (Event ev)  public
    {
        State memory prevContractState = ContractCurrentState;
        if(!IsRunning)
        {
            IsRunning = true;
            // Perform state change for type with id 0
            if(e.typeId == 0)
            {
                if(prevContractState == State.DAO_S2)
                {
                    ContractCurrentState = State.DAO_S1;
                }
                if(prevContractState == State.DAO_S3)
                {
                    ContractCurrentState = State.DAO_S2;
                }
                // Invoke handler for state and type with id 0
                if(prevContractState == State.DAO_S1)
                {
                    Withdraw(v_0);
                }
                if(prevContractState == State.DAO_S3)
                {
                    Withdraw(v_0);
                }
            }
            // Perform state change for type with id 1
            if(e.typeId == 1)
            {
                // Invoke handler for state and type with id 1
                if(prevContractState == State.DAO_S3)
                {
                    Deposit(v_0);
                }
            }
            // Perform state change for type with id 2
            if(e.typeId == 2)
            {
                // Invoke handler for state and type with id 2
            }
        }
        else
        {
            enqueue(e);
        }
    }
}
// TODO: Implementation DefaultImpl
