using UnityEngine;
using System.Collections;

public class RemoveActor : Method {
    
    public override void Do(Actor fromActor, int _eventType)
    {
        base.Do(fromActor, _eventType);
        // GameManager.Instance.RemoveActor(ref a);
        int whichActor = 0;


         // Remove Actor N given by method inputs

        // Get which actor should be removed
        switch (base.InputLocations[0])
        {
            case MethodVariableLocation.Constants:
                if (InputLocationNumbers[0] < Constants.Count)
                {
                    whichActor = (int)Constants[InputLocationNumbers[0]];
                }
                break;
            case MethodVariableLocation.CallingActor:
                if (InputLocationNumbers[0] < fromActor.FVariables.Count)
                {
                    whichActor = (int)fromActor.FVariables[InputLocationNumbers[0]];
                }
                break;
            case MethodVariableLocation.Global:
                if (InputLocationNumbers[0] < GMgr.FVariables.Count)
                {
                    whichActor = (int)GMgr.FVariables[InputLocationNumbers[0]];
                }
                break;
            default:
                base.TimesInvalidInputLocationChosen++;
                return;
                break;
        }


        // If output location is specified, this rules over previous (ie. calling removes the calling actor, other or global removes by id)6U4Rlbgrdutuieklhrvtuelfiunvbdrn
        
        if(whichActor >= 0 && whichActor < GMgr.Actors.Count)
        {
            // Remove that actor
            GMgr.RemoveActor(whichActor);
        }
        else
        {
            TimesNonExistantActorReferenced++;
        }

    }
}
