using UnityEngine;
using System.Collections;

public class EndGame : Method {

    public override void Do(Actor fromActor, int _eventType)
    {
        base.Do(fromActor, _eventType);
        GMgr.EndGame();
    }

}
