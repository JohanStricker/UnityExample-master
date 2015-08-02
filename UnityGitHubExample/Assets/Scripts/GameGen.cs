using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class GameGen  {

    public GameManager GMgr;

    private static readonly GameGen instance = new GameGen();

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static GameGen()
    {
    }

    private GameGen()
    {
    }

    public static GameGen Instance
    {
        get
        {
            return instance;
        }
    }

    public void GenerateGame(Genome g)
    {
        Debug.Log("GameGen/Generate Game: Generating Game");
        // Generate game from genome

        // Add Actors
        foreach (List<int> blueprint in g.ActorBlueprints)
        {
            GMgr.ActorBlueprints.Add(blueprint);
        }
        Debug.Log("GameGen/GenerateGame: Blueprints added to GameManager");


        // Make ActorCounts of each (as long as we have more locations to add to)
        int locIter = 0;

        for (int i = 0; i < g.ActorCounts.Count; i += 2)
        {
            // How many of which actor
            int whichActor = g.ActorCounts[i];
            int Count = g.ActorCounts[i + 1];

            for (int o = 0; o < Count;  o++)
            {
                // If we have more locations (we take 2 ints from Locations each time, x and y) add it
                if (locIter < g.Locations.Count-1)
                {
                    Vector2 pos = new Vector2((float)g.Locations[locIter], (float)g.Locations[locIter+1]);
                    GMgr.AddActor(whichActor, pos);

                    locIter += 2;
                }
            }
        }
        Debug.Log("GameGen/GenerateGame: Actors added to GameManager");
    }
}
