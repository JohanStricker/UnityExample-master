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

    // Control debugging
    public const bool DebugFluents = true;
    public const bool DebugMechanics = true;
}
