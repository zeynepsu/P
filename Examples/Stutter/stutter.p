// To exhibit stuttering, we construct a client-server scenario, as follows.

// 1. The client, upon receiving any message, simply consumes it and HALTS the server.
// 2. The server forever sends messages with payload 4,4,6,4,4,6,... .

// This scheme ensures that payload 6 can appear in the client's queue ONLY
// if the server sends 4,4,6 without any dequeue by the client: any dequeue
// will halt the server.
// As a consequence, if the queue bound is k=2, payload 6 will never appear in
// the client's queue, but it will appear for k=3. This creates a
// stuttering effect for k = 1,2.

event PING:int;

machine Main
{
  var client: machine;
  var modThree: int;

  start state Init
  {
    entry
    {
      client = new Client(this);
      modThree = 0;
      goto Spam;
    }
  }

  state Spam
  {
    on null do
    {
      if (modThree == 0)
      {
        send client, PING, 4;
        modThree = 1;
      }
      else if (modThree == 1)
      {
        send client, PING, 4;
        modThree = 2;
      }
      else
      {
        send client, PING, 6;
        modThree = 0;
      }

      goto Spam;

    }
  }
}

machine Client
{
  var server: machine;

  start state Init
  {
    entry(payload: machine)
    {
      server = payload;
      goto Receive;
    }
  }

  state Receive
  {
    on PING goto Receive with { send server, halt; }
  }
}
