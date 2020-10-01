/**************************************************************************
Client sends multiple eRequest events to the server and waits for response.
Server responds with eResponse event for each eRequest event.
The responses must be in the same order as the requests being sent.
**************************************************************************/

machine ClientMachine
sends eRequest;
receives eResponse;
// The client's last_id is less than the client's server's id_save
invariant "(forall (c : ClientMachine_ref_t) :: ClientMachine_instances[c].last_id < ServerMachine_instances[ClientMachine_instances[c].server].id_save)";
// The client's last_id is less than the client's next_id
invariant "(forall (c : ClientMachine_ref_t) :: ClientMachine_instances[c].last_id < ClientMachine_instances[c].next_id)";

// If the client is receiving a response, then the ID of the response is greater than the client's last_id
invariant "(forall (c : ClientMachine_ref_t, p : eResponse_t) :: 
            ClientMachine_eResponse_in[c][p] > 0 ==> p.id > ClientMachine_instances[c].last_id)";
// If the server is sending a response to the client, then the ID of the response is greater than the client's last_id
invariant "(forall (c : ClientMachine_ref_t, p : eResponse_t) :: 
            ServerMachine_eResponse_to_ClientMachine[ClientMachine_instances[c].server][c][p] > 0 
                ==> p.id > ClientMachine_instances[c].last_id)";
// If the client is sending a request to the server, then the ID of the request is greater than the client's last_id
invariant "(forall (c : ClientMachine_ref_t, p : eRequest_t) :: 
            ClientMachine_eRequest_to_ServerMachine[c][ClientMachine_instances[c].server][p] > 0 
                ==> p.id > ClientMachine_instances[c].last_id)";
// If the client's server is receiving a request, then the ID of the request is greater than the client's last_id
invariant "(forall (c : ClientMachine_ref_t, p : eRequest_t) :: 
            ServerMachine_eRequest_in[ClientMachine_instances[c].server][p] > 0 
                ==> p.id > ClientMachine_instances[c].last_id)";
// If the server is sending a request to the helper, then the ID of the request is greater than the client's last_id
invariant "(forall (c : ClientMachine_ref_t, p : eProcessReq_t) :: 
            ServerMachine_eProcessReq_to_HelperMachine[ClientMachine_instances[c].server][ServerMachine_instances[ClientMachine_instances[c].server].helper][p] > 0 
                ==> p > ClientMachine_instances[c].last_id)";
// If the helper is receiving a request, then the ID of the response is greater than the client's last_id
invariant "(forall (c : ClientMachine_ref_t, p : eProcessReq_t) :: 
            HelperMachine_eProcessReq_in[ServerMachine_instances[ClientMachine_instances[c].server].helper][p] > 0 
                ==> p > ClientMachine_instances[c].last_id)";

// The client never receives duplicate responses
invariant "(forall (c : ClientMachine_ref_t, p : eResponse_t) :: 
            ClientMachine_eResponse_in[c][p] > 0 ==> ClientMachine_eResponse_in[c][p] == 1)";
// The server never sends duplicate responses to the client
invariant "(forall (c : ClientMachine_ref_t, p : eResponse_t) :: 
            ServerMachine_eResponse_to_ClientMachine[ClientMachine_instances[c].server][c][p] > 0 
                ==> ServerMachine_eResponse_to_ClientMachine[ClientMachine_instances[c].server][c][p] == 1)";
// The client never sends duplicate requests to the server
invariant "(forall (c : ClientMachine_ref_t, p : eRequest_t) :: 
            ClientMachine_eRequest_to_ServerMachine[c][ClientMachine_instances[c].server][p] > 0 
                ==> ClientMachine_eRequest_to_ServerMachine[c][ClientMachine_instances[c].server][p] == 1)";
// The server never receives duplicate requests
invariant "(forall (c : ClientMachine_ref_t, p : eRequest_t) :: 
            ServerMachine_eRequest_in[ClientMachine_instances[c].server][p] > 0 
                ==> ServerMachine_eRequest_in[ClientMachine_instances[c].server][p] == 1)";
// The server never sends duplicate requests to its helper
invariant "(forall (c : ClientMachine_ref_t, p : eProcessReq_t) :: 
            ServerMachine_eProcessReq_to_HelperMachine[ClientMachine_instances[c].server][ServerMachine_instances[ClientMachine_instances[c].server].helper][p] > 0 
                ==> ServerMachine_eProcessReq_to_HelperMachine[ClientMachine_instances[c].server][ServerMachine_instances[ClientMachine_instances[c].server].helper][p] == 1)";
// The helper never receives duplicate requests
invariant "(forall (c : ClientMachine_ref_t, p : eProcessReq_t) :: 
            HelperMachine_eProcessReq_in[ServerMachine_instances[ClientMachine_instances[c].server].helper][p] > 0 
                ==> HelperMachine_eProcessReq_in[ServerMachine_instances[ClientMachine_instances[c].server].helper][p] == 1)";

// There is only one response going to the client at a time
invariant "(forall (c : ClientMachine_ref_t, p1 : eResponse_t, p2 : eResponse_t) :: ServerMachine_eResponse_to_ClientMachine[ClientMachine_instances[c].server][c][p1] > 0 
    ==> ServerMachine_eResponse_to_ClientMachine[ClientMachine_instances[c].server][c][p2] == 0)";
// There is only one response coming into the client at a time
invariant "(forall (c : ClientMachine_ref_t, p1 : eResponse_t, p2 : eResponse_t) :: ClientMachine_eResponse_in[c][p1] > 0 
    ==> ClientMachine_eResponse_in[c][p2] == 0)";
// There is only one request going to the server at a time
invariant "(forall (c : ClientMachine_ref_t, p1 : eRequest_t, p2 : eRequest_t) :: ClientMachine_eRequest_to_ServerMachine[c][ClientMachine_instances[c].server][p1] > 0 
    ==> ClientMachine_eRequest_to_ServerMachine[c][ClientMachine_instances[c].server][p2] == 0)";
// There is only one request coming into the server at a time
invariant "(forall (c : ClientMachine_ref_t, p1 : eRequest_t, p2 : eRequest_t) :: ServerMachine_eRequest_in[ClientMachine_instances[c].server][p1] > 0 
    ==> ServerMachine_eRequest_in[ClientMachine_instances[c].server][p2] == 0)";
// There is only one request going to the helper at a time
invariant "(forall (c : ClientMachine_ref_t, p1 : eProcessReq_t, p2 : eProcessReq_t) :: ServerMachine_eProcessReq_to_HelperMachine[ClientMachine_instances[c].server][ServerMachine_instances[ClientMachine_instances[c].server].helper][p1] > 0 
    ==> ServerMachine_eProcessReq_to_HelperMachine[ClientMachine_instances[c].server][ServerMachine_instances[ClientMachine_instances[c].server].helper][p2] == 0)";
// There is only one request coming into the helper at a time
invariant "(forall (c : ClientMachine_ref_t, p1 : eProcessReq_t, p2 : eProcessReq_t) :: HelperMachine_eProcessReq_in[ServerMachine_instances[ClientMachine_instances[c].server].helper][p1] > 0 
    ==> HelperMachine_eProcessReq_in[ServerMachine_instances[ClientMachine_instances[c].server].helper][p2] == 0)";

// There is never a response on the way to the client and one already arrived at the client (responses aren't duplicated)
invariant "(forall (c : ClientMachine_ref_t, p : eResponse_t) :: 
            ClientMachine_eResponse_in[c][p] == 0 || ServerMachine_eResponse_to_ClientMachine[ClientMachine_instances[c].server][c][p] == 0)";
invariant "(forall (c : ClientMachine_ref_t, p : eRequest_t) :: 
            ClientMachine_eRequest_to_ServerMachine[c][ClientMachine_instances[c].server][p] == 0 || ServerMachine_eRequest_in[ClientMachine_instances[c].server][p] == 0)";
// There is never a request on the way to the helper and one already arrived at the helper (requests aren't duplicated)
invariant "(forall (c : ClientMachine_ref_t, p : eProcessReq_t) :: 
            ServerMachine_eProcessReq_to_HelperMachine[ClientMachine_instances[c].server][ServerMachine_instances[ClientMachine_instances[c].server].helper][p] == 0 || HelperMachine_eProcessReq_in[ServerMachine_instances[ClientMachine_instances[c].server].helper][p] == 0)";

// The helper machine is never receiving a request and answering a request at the same time
invariant "(forall (c : ClientMachine_ref_t, p : eProcessReq_t) :: 
            HelperMachine_eProcessReq_in[ServerMachine_instances[ClientMachine_instances[c].server].helper][p] == 0 || HelperMachine_eReqFailed_to_ServerMachine[ServerMachine_instances[ClientMachine_instances[c].server].helper][ClientMachine_instances[c].server] == 0)";
invariant "(forall (c : ClientMachine_ref_t, p : eProcessReq_t) :: 
            HelperMachine_eProcessReq_in[ServerMachine_instances[ClientMachine_instances[c].server].helper][p] == 0 || HelperMachine_eReqSuccessful_to_ServerMachine[ServerMachine_instances[ClientMachine_instances[c].server].helper][ClientMachine_instances[c].server] == 0)";

{
  var server : ServerMachine;
  var next_id : int;
  var last_id: int;

  start state Init {
    entry (payload : ServerMachine)
    {
      next_id = 1;
      last_id = 0;
      server = payload;
      goto StartPumpingRequests;
    }
  }

  state StartPumpingRequests {
    entry {
      send server, eRequest, (source = this, id = next_id);
      next_id = next_id + 1;
    }
    
    on eResponse do (payload: responseType){
        assert(payload.id > last_id);
        last_id = payload.id;
    }
  }
}
