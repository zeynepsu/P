// To exhibit stuttering, we construct a client-server scenario, as follows.
// 1. The server sends a sequence of messages matching the regular expression (WAIT^k,DONE,PING^*) , for some constant k.
// 2. The client skips all messages until the first DONE ('defer'), then consumes everything ('ignore').

// For constant 3 below, this protocol generates an abstract-state plateau at k=5
// (but not at k=4, which is where DONE and PING show up for the first time!).
// The global states sets never converge due to flooding.

enum Global { ZERO=0, X=3 } // for some reason, at least one enum element must be numbered 0

event WAIT;
event DONE;
event PING;

machine Main {
  var client: machine;

  start state Init {
    entry {
      client = new Client();
      goto SendPrefix; }}

  state SendPrefix {
    entry {
      var i:int;
      i = 0;
      while (i < X) {
        send client, WAIT;
        i = i + 1; }
      send client, DONE;
      goto Flood; }}

  state Flood {
    entry {
      send client, PING;
      goto Flood; }}}               // without this goto, machine Flood terminates

///////////////////////////////////////////////////////////////////////////

machine Client {
  start state Init {
    defer WAIT, PING;
    on DONE goto Consume; }

  state Consume { ignore WAIT, PING; }}
