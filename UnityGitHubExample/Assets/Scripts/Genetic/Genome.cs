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
    public int GenomeSeed;

    public List<List<int>> ActorBlueprints; // |02 05 06| = event 1,2, and 3 has method 2, 5, and 6 attached, respectively (for all events)
                      // Consists of:  (and will be stripped to lengths divisible by their sum)

    public List<int> ActorMethods;          // Specific length (16) - which method to call at event x
    public List<int> ActorVariables;        // Actor variables: 3 bool, 3 float, 3 vector = 12 length



    public List<int> ActorCounts;           // in tuples of integers |which_actor number_of_that_actor| x n 
                                            // It will then start from beginning of locations and fill out
                                            // - if there are not enough locations some actors won't be spawned.
                                            // Will be stripped to length of #actors * 2 (also multiples of 2)


    public List<int> Locations;              // tupes of integers |x y| x k
                                             // Stripped to multiples of 2


    public List<int> Methods;               // method_type | 3 vars denoting where inputs come from | 1 var denoting where output  | 1 var for ID of other actor
                                            // | 3 vars denoting where in the array @ input loc, the input comes from | same but for output
                                            // | 3 constants
                                            // Stripped to multiples of 12

    public List<int> GlobalVariables;       // Global variables: 5 bool, 5 float, 5 vector = 20 length (all initiated as floats though)
                                            // Remaining variables if length is less than 20 will just be nulled


    public List<int> CompleteGenome
    {           // Do we need this?
        get
        {
            return CompleteGenome;
        }
    }

    public Genome()
    {

    }

    public void Initiate(int seed)
    {
        // Initiate genome with randomized values
        GenomeSeed = seed;
        Random.seed = seed;

        // Make x number of actors
        int x = Random.Range(GlobalConstants.ActorCountMin, GlobalConstants.ActorCountMax);
        for (int k = 0; k < x; k++)
        {
            for (int i = 0; i < GlobalConstants.ActorBlueprintEventCount; i++)
            {
                ActorMethods.Add(Random.Range(0, GlobalConstants.ActorBlueprintEventCount - 1));
            }
        }
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
