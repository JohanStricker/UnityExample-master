using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct BlueprintPseudoEnum
{
    public const int Collision = 0;
    public const int Space = 1;
    // ....
}

public class Genome {

    public List<List<int>> ActorBlueprints; // |02 05 06| = event 1,2, and 3 has method 2, 5, and 6 attached, respectively (for all events
    public List<int> ActorCounts;           // in tuples of integers |which_actor number_of_that_actor| x n 
                                            // It will then start from beginning of locations and fill out
                                            // - if there are not enough locations some actors won't be spawned.

    public List<int> Locations;       // tupes of integers |x y| x k


    public Genome()
    {

    }

    public List<Genome> GenerateOffspring(Genome other)
    {
        // Crossover, mutation

        // First crossover actor blueprints
        //Then do locations
        // ....   we preserve the basic structuring of the gene (if you wish, multiple genes)

        return new List<Genome>();
    }

    
    public void Repair()
    {
        // Do repair functions

        // make sure only even amount of ints in ActorCounts and Locations
        if (ActorCounts.Count % 2 != 0)
        {
            // it is uneven, strip last
            ActorCounts.RemoveAt(ActorCounts.Count - 1);
        }

        if(Locations.Count % 2 != 0)
        {
            // it is uneven, strip last
            Locations.RemoveAt(Locations.Count - 1);
        }
    }
}
