using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddActor : Method {
    
	public AddActor()
    {
    }

    public override void Do(ref Actor fromActor) : base(ref fromActor)
    {
        // First input is actor blueprint
        // Second input is vector for location


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
            case MethodVariableLocation.CallingActor)
                //if(base.InputLocationNumbers[0] < base.CallingActor)
                break;
            case MethodVariableLocation.Global:
                break;
            case MethodVariableLocation.OtherActor:
                break;
            default:
                break;
        }
    }

}
