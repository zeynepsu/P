// from client to timer
event START: int;

// from timer to client
event TIMEOUT: machine;

// Interface functions provided by the timer machine
fun CreateTimer(owner: machine): machine {
  var m: machine;
  m = new Timer(owner);
  return m;
}

fun StartTimer(timer: machine, time: int) {
  send timer, START, time;
}

machine Timer
receives START;
sends TIMEOUT;
{
  var client: machine;

  start state Init {
    entry (payload: machine) {
      client = payload;
      goto WaitForReq;
    }
  }

  state WaitForReq {
    on START goto WaitForTimeout;
  }

  state WaitForTimeout {
    ignore START;
    on null goto WaitForReq with
    {
      send client, TIMEOUT, this;
    }
  }
}
