using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddActor : Method {
    
	public AddActor()
    {
    }

    public override void Do(ref Actor fromActor)
    {
        // First input is actor blueprint
        // Second input is vector for location
        base.Do(ref fromActor);

        int BlueprintToSpawn;
        List<int> Blueprint;
        Vector2 Loc;

        switch (base.InputLocations[0])
        {
            case MethodVariableLocation.Constants:
                if (base.InputLocationNumbers[0] < base.Constants.Count)
                {
                    BlueprintToSpawn = (int) base.Constants[base.InputLocationNumbers[0]];
                }
                break;
            case MethodVariableLocation.CallingActor:
                if(base.InputLocationNumbers[0] < base.CallingActor.FVariables.Count)
                {
                    BlueprintToSpawn = (int)base.CallingActor.FVariables[base.InputLocationNumbers[0]];
                }
                break;
            case MethodVariableLocation.Global:
                if (base.InputLocationNumbers[0] < GMgr.FVariables.Count)
                {
                    BlueprintToSpawn = (int)GMgr.FVariables[base.InputLocationNumbers[0]];
                }
                break;
            case MethodVariableLocation.OtherActor:

                break;
            default:
                break;
        }
    }

}
