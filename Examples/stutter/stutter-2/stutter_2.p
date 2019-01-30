event WAIT;
event DONE assert 1;
event PING;

machine Main {
	     var client0: machine;
	     var client1: machine;
  start state Init {
    entry {
	  client0 = new Client();
	  client1 = new Client();
      goto SendPrefix; 
    }
  }

  state SendPrefix {
    entry {
      var i:int;
      i = 0;
      while (i < 3) {
		    send client0, WAIT;
		    send client1, WAIT;
		    i = i + 1;
      }
      send client0, DONE;
      send client1, DONE;
      goto Flood;
    }
  }

  state Flood {
    entry {
	  send client0, PING;
	  send client1, PING;
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
