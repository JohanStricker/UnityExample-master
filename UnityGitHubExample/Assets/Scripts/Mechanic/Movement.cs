using UnityEngine;
using System.Collections;

public class Movement : Method {

    public override void Do(Actor fromActor)
    {
        base.Do(fromActor);

        Vector2 Direction = new Vector2() ;

        if (fromActor.HasInput == true)
        {
            Direction = fromActor.UserMoveDir;
            GMgr.MoveActor(fromActor.ID, Direction);
        }
    }

}
