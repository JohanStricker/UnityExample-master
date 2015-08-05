using UnityEngine;
using System.Collections;

public sealed class GlobalConstants {
    private static readonly GlobalConstants instance = new GlobalConstants();

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static GlobalConstants()
    {
    }

    private GlobalConstants()
    {
    }

    public static GlobalConstants Instance
    {
        get
        {
            return instance;
        }
    }


    public const float FloatComparisonDifference = 0.000001f;



    // Genome Stuff
    public const int MapWidth = 48;
    public const int MapHeight = 34;

    public const int ActorCountMin = 1;
    public const int ActorCountMax = 10;

    public const int ActorBlueprintEventCount = 16;
    public const int ActorBlueprintVariableCount = 16;
    public const int ActorNumReadableVariables = 5;
    public const int ActorNumWritableVariables = 4;

    public const int ActorInitialVariableConstraintFloat = 50;
    public const int ActorInitialVariableConstraintVector = 50;

    public const int MethodCountMin = 1;
    public const int MethodCountMax = 10;
    public const int MethodNumTypes = 3;
    public const int MethodInputNumTypes = 3;
    public const int MethodOutputNumTypes = 3;
    public const int MethodConstantCount = 3;

    public const int MethodInitialVariableConstraint = 50;


    public const int MaxInstancesOfAnyActor = 20;
    public const int MinInstancesOfActorsTotal = 3;
    public const int MaxInstancesOfActorsTotal = 100;

    public const int GlobalVariablesCount = 20; // 5 float, 5 bool, 5 vector
    public const int GlobalInitialVariableConstraintFloat = 50;
    public const int GlobalInitialVariableConstraintVector = 50;
    public const int GlobalNumReadableVariables = 5;

}
