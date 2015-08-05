using UnityEngine;
using System.Collections;

public class EndGame : Method {

    public override void Do(Actor fromActor)
    {
        base.Do(fromActor);
        GMgr.EndGame();
    }

}
