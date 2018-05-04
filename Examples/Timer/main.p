machine Main
{
  var timer: machine;
  start state Init
  {
    entry
    {
      timer = CreateTimer(this);
      goto GetInput;
    }
  }

  state GetInput
  {
    entry
    {
      if ($)
        goto PrintHello;
      else
        goto Stop;
    }
  }

  state PrintHello {
    entry
    {
      StartTimer(timer, 100);
    }

    on TIMEOUT goto GetInput with
    {
      print "Hello\n";
    }
  }

  state Stop
  {
  }
}
