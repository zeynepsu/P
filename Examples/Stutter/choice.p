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
      if ($)
        send client, WAIT;
      else {
        send client, DONE;
        goto Flood; }}}

  state Flood {
    entry {
      send client, PING;
      goto Flood; }}}

///////////////////////////////////////////////////////////////////////////

machine Client {
  start state Init {
    defer WAIT, PING;
    on DONE goto Consume; }

  state Consume { ignore WAIT, PING; }}
