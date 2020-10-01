/* This file implements various test-drivers and also provides the various test-cases that are model-checked by the P Checker*/


/*
This machine creates the 2 participants, 1 coordinator, and 2 clients 
*/
machine TestDriver0 
sends ;
receives ;
{
	start state Init {
		entry {
			var coord : Coordinator;
			var participants: seq[Participant];
			var i : int;
			while (i < 2) {
				participants += (i, new Participant());
				i = i + 1;
			}
			coord = new Coordinator(participants);
			new Client(coord);
			new Client(coord);
		}
	}
}

/*
This machine creates the 2 participants, 1 coordinator, 1 Failure injector, and 2 clients 
*/
machine TestDriver1 
sends ;
receives ;
{
	start state Init {
		entry {
			var coord : Coordinator;
			var participants: seq[Participant];
			var i: int;
			while (i < 2) {
				participants += (i, new Participant());
				i = i + 1;
			}
			coord = new Coordinator(participants);
			new FailureInjector(participants);
			new Client(coord);
			new Client(coord);
		}
	}
}

/* 
The failure injector machine randomly selects a participant machine and enqueues a special event "halt"
On dequeueing a halt event, the P machine destroyes itself safely. 
This is one way of modeling node failures in P.
Note that as the model-checker explores all possible interleavings. The failure injecture is exhaustive and can add a failure at all possible interleaving points.
*/
machine FailureInjector 
sends halt;
receives ;
{
	start state Init {
		entry (participants: seq[Participant]){
			var i : int;
			i = 0;
			while(i< sizeof(participants))
			{
				if($)
				{
					send participants[i], halt;
				}
				i = i + 1;
			}		
		}
	}
}
