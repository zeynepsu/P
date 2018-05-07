event ACK;

machine Main
{
  var noop: machine;

  start state Init
  {
    entry
    {
      noop = new Noop(this);
      goto Check;
    }
  }

  state Check
  {
    on ACK goto Stop;
    on null do { assert (false); } // do we ever get here? if yes, the "on ACK" is non-blocking
  }

  state Stop {}
}

machine Noop { start state Init {} }
