using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddActor : Method {
    
	public AddActor()
    {
    }

    public override void Do(Actor fromActor, int _eventType)
    {
        // First input is actor blueprint
        // Second input is vector for location
        // Third input is the other actor 
        base.Do(fromActor, _eventType);

        int BlueprintToSpawn = -1;
        Vector2 Loc = new Vector2();


        // Get which actor should be spawned
        switch (base.InputLocations[0])
        {
            case MethodVariableLocation.Constants:
                if (InputLocationNumbers[0] < Constants.Count)
                {
                    BlueprintToSpawn = (int) Constants[InputLocationNumbers[0]];
                }
                break;
            case MethodVariableLocation.CallingActor:
                if(InputLocationNumbers[0] < fromActor.FVariables.Count)
                {
                    BlueprintToSpawn = (int)fromActor.FVariables[InputLocationNumbers[0]];
                }
                break;
            case MethodVariableLocation.Global:
                if (InputLocationNumbers[0] < GMgr.FVariables.Count)
                {
                    BlueprintToSpawn = (int)GMgr.FVariables[InputLocationNumbers[0]];
                }
                break;
            default:
                base.TimesInvalidInputLocationChosen++;
                return;
                break;
        }

        switch (InputLocations[1])
        {
            case MethodVariableLocation.Constants:
                if(Constants.Count > 0)
                {
                    // Get location from 3 float variables in method constants. Cycle through, so inputlocations[1] decides first, the
                      //  next is at inputlocations[1] + 1   and then we use modulus, in case we go out of bounds
                    Loc = new Vector2(Constants[InputLocationNumbers[1] % GlobalConstants.MethodConstantCount],
                                        Constants[(InputLocationNumbers[1]+1) % GlobalConstants.MethodConstantCount]);
                }
                break;

            case MethodVariableLocation.CallingActor:
                if(InputLocationNumbers[1] < fromActor.VVariables.Count)
                {
                    Loc = fromActor.VVariables[InputLocationNumbers[1]];
                }
                break;

            case MethodVariableLocation.Global:
                if(InputLocationNumbers[1] < GMgr.VVariables.Count)
                {
                    Loc = GMgr.VVariables[InputLocationNumbers[1]];
                }
                break;

            default:
                base.TimesInvalidInputLocationChosen++;
                return;
                break;

        }
        
        GMgr.AddActor(BlueprintToSpawn, Loc);
    }

}
