event WAIT;
event DONE assert 1;
event PING;

machine Main {
	     var clients: (machine, machine, machine);
	     var tmp: machine;
  start state Init {
    entry {
	  tmp = new Client(); clients.0 = tmp;
	  tmp = new Client(); clients.1 = tmp;
	  tmp = new Client(); clients.2 = tmp;
      goto SendPrefix; 
    }
  }

  state SendPrefix {
    entry {
      var i:int;
      i = 0;
      while (i < 3) {
		    send clients.0, WAIT;
		    send clients.1, WAIT;
		    send clients.2, WAIT;
		    i = i + 1;
      }
      send clients.0, DONE;
      send clients.1, DONE;
      send clients.2, DONE;
      goto Flood;
    }
  }

  state Flood {
    entry {
	  send clients.0, PING;
	  send clients.1, PING;
	  send clients.2, PING;
      goto Flood; 
    }
  }
}

///////////////////////////////////////////////////////////////////////////

machine Client {
  start state Init {
    defer WAIT, PING;
    on DONE goto Consume; 
  }

  state Consume { 
		defer WAIT, PING;
  }
}
