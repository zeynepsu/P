event ACK;

machine Main
{

  start state Init
  {
    on ACK goto Init;
    on null do { assert (false); } // do we ever get here? if yes, the "on ACK" is non-blocking
  }

}

