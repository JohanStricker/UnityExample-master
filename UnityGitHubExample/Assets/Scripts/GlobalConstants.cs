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
    public const int ActorCountMin = 1;
    public const int ActorCountMax = 10;

    public const int ActorBlueprintEventCount = 16;
    public const int ActorBlueprintVariableCount = 12;

    public const int GlobalVariablesCount = 20; // 5 float, 5 bool, 5 vector
}
