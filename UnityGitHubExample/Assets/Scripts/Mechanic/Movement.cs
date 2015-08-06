using UnityEngine;
using System.Collections;


public struct MovementDirection
{
    public const int N = 0;
    public const int NE = 1;
    public const int E = 2;
    public const int SE = 3;
    public const int S = 4;
    public const int SW = 5;
    public const int W = 6;
    public const int NW = 7;
}

public class Movement : Method {

    public Movement()
    {

        Type = MethodType.Movement;
    }

    public override void Do(Actor fromActor, int _eventType)
    {
        base.Do(fromActor, _eventType);


        float dir = -1;

        switch (InputLocations[0])
        {
            case MethodVariableLocation.Constants:
                if (InputLocationNumbers[0] > 0 && InputLocationNumbers[0] < Constants.Count)
                {
                    dir = Constants[InputLocationNumbers[0]];
                }
                break;
            case MethodVariableLocation.CallingActor:
                if(InputLocationNumbers[0] > 0 && InputLocationNumbers[0] < GlobalConstants.ActorNumReadableVariables)
                {
                    dir = fromActor.FVariables[InputLocationNumbers[0]];
                }
                break;
            case MethodVariableLocation.Global:
                if (InputLocationNumbers[0] > 0 && InputLocationNumbers[0] < GlobalConstants.GlobalNumReadableVariables)
                {
                    dir = GMgr.FVariables[InputLocationNumbers[0]];
                }
                break;
            default:
                break;
        }

        // Common sense movement if from human input
        switch (_eventType)
        {
            case ActorEvent.KeyW:
                dir = MovementDirection.N;
                break;
            case ActorEvent.KeyA:
                dir = MovementDirection.W;
                break;
            case ActorEvent.KeyS:
                dir = MovementDirection.S;
                break;
            case ActorEvent.KeyD:
                dir = MovementDirection.E;
                break;
            default:
                // Do nothing
                break;
        }

        Debug.Log(string.Format("Movement/Do: Moving actor #{0} in direction {1}", fromActor.ID, dir));

        GMgr.MoveActor(fromActor.ID, dir);
    }

}
