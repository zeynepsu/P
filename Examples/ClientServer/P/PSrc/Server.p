/*************************************************************
Server receives eRequest event from the client and performs
local computation.  Based on the local computation, server
responds with either eReqSuccessful or eReqFailed.  Server
responds to requests in the order in which they were received.
*************************************************************/

machine ServerMachine
sends eResponse, eProcessReq;
receives eRequest, eReqSuccessful, eReqFailed;
// Every client points to a different server
invariant "(forall (c1 : ClientMachine_ref_t, c2 : ClientMachine_ref_t) :: ClientMachine_instances[c1].server != ClientMachine_instances[c2].server)";
{
  var helper: HelperMachine;
  var id_save : int;
  var source_save: ClientMachine;

  start state Init {
    entry (payload : HelperMachine) {
      helper = payload;
      id_save = 1;
      goto WaitForRequests;
    }
  }

  state WaitForRequests {
    on eRequest do (payload: requestType){
      send helper, eProcessReq, payload.id;
      id_save = payload.id;
      source_save = payload.source;
      goto WaitForResponse;
    }
  }
  state WaitForResponse {
    on eReqSuccessful do {
      send source_save, eResponse, (id = id_save, success = true);
      goto WaitForRequests;
    }
    on eReqFailed do {
      send source_save, eResponse, (id = id_save, success = false);
      goto WaitForRequests;
    }
  }
}

/***************************************************************
The helper machine performs some complex computation and returns
either eReqSuccessful or eReqFailed.
****************************************************************/
machine HelperMachine
sends eReqSuccessful, eReqFailed;
receives eProcessReq;
// Every server points to a different helper
invariant "(forall (c1 : ClientMachine_ref_t, c2 : ClientMachine_ref_t) :: ServerMachine_instances[ClientMachine_instances[c1].server].helper != ServerMachine_instances[ClientMachine_instances[c2].server].helper)";
{
  var server: ServerMachine;
  
  start state Init {
    entry(payload : ServerMachine){
      server = payload;
    }
    on eProcessReq do {
      if($)
      {
        send server, eReqSuccessful;
      }
      else
      {
        send server, eReqFailed;
      }
    }
  }
}
