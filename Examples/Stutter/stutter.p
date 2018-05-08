// To exhibit stuttering, we construct a client-server scenario, as follows.
// 1. The server sends a sequence of messages matching the regular expression (WAIT^k,DONE,PING^*) , for some constant k.
// 2. The client skips all messages until the first DONE ('defer'), then consumes everything ('ignore').

// For constant 3 below, this protocol generates an abstract-state plateau at k=5
// (but not at k=4, which is where DONE and PING show up for the first time!).
// The global states sets never converge due to flooding.

event WAIT;
event DONE;
event PING;

machine Main {
  var client: machine;

  start state Init {
    entry {
      client = new Client(this);
      goto SendPrefix; }}

  state SendPrefix {
    entry {
      var i:int;
      i = 0;
      while (i < 3) {               // change this constant to create longer plateaus
        send client, WAIT;
        i = i + 1; }
      send client, DONE;
      goto Flood; }}

  state Flood {
    entry {
      send client, PING;
      goto Flood; }}}

machine Client {
  start state Init {
    defer WAIT;
    on DONE goto Consume; }

  state Consume { ignore WAIT, DONE, PING; }}
