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

    public List<int> EndEvents;             // | actor event |  for starts we constrain event to collision

    public List<List<int>> ActorBlueprints; // |02 05 06| = event 1,2, and 3 has method 2, 5, and 6 attached, respectively (for all events)
                      // Consists of:  (and will be stripped to lengths divisible by their sum)

    public List<int> ActorMethods;          // Specific length (16) - which method to call at event x
    public List<int> ActorVariables;        // Actor variables: 4 bool, 4 float, 4 vector = 16 length
                                            // First of bool is TimerActive, first float is TimerTime, first vector is CanCollideWith (2 others)



    public List<int> ActorCounts;           // in tuples of integers |which_actor number_of_that_actor| x n 
                                            // It will then start from beginning of locations and fill out
                                            // - if there are not enough locations some actors won't be spawned.
                                            // Will be stripped to length of #actors * 2 (also multiples of 2)


    public List<int> Locations;              // tupes of integers |x y| x k
                                             // Stripped to multiples of 2


    public List<List<int>> MethodBlueprints;  
                                            // method_type | 3 vars denoting where inputs come from | 1 var denoting where output  | 1 var for ID of other actor
                                            // | 3 vars denoting where in the array @ input loc, the input comes from | same but for output
                                            // | 3 constants
                                            // Stripped to multiples of 14

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
        int a, b, c;

        // End event
        a = Random.Range(0, GlobalConstants.ActorCountMax);
        b = Random.Range(0, GlobalConstants.MethodCountMax);
        EndEvents.Add(a);
        EndEvents.Add(b);

        // Actor methods
        a = Random.Range(GlobalConstants.ActorCountMin, GlobalConstants.ActorCountMax);
        for (int k = 0; k < a; k++)
        {
            for (int i = 0; i < GlobalConstants.ActorBlueprintEventCount; i++)
            {
                ActorMethods.Add(Random.Range(0, GlobalConstants.ActorBlueprintEventCount - 1));
            }
        }

        // Actor variables
            // bools
        for (int i = 0; i < 4; i++)
        {
            ActorVariables.Add(Random.Range(0, 1));
        }

        // floats
        for (int i = 4; i < 8; i++)
        {
            ActorVariables.Add(Random.Range(0, GlobalConstants.ActorInitialVariableConstraintFloat));
        }
        // vectors
        for (int i = 8; i < GlobalConstants.ActorBlueprintVariableCount; i++)
        {
            ActorVariables.Add(Random.Range(0, GlobalConstants.ActorInitialVariableConstraintVector));
        }

        // Actor counts
            // number of types of actors
        a = Random.Range(GlobalConstants.ActorCountMin, GlobalConstants.ActorCountMax);
        for (int i = 0; i < a; i++)
        {
            // which actor
            b = Random.Range(0, GlobalConstants.ActorCountMax-1);

            // how many of that actor
            c = Random.Range(0, GlobalConstants.MaxInstancesOfAnyActor);

            ActorCounts.Add(b);
            ActorCounts.Add(c);
        }


        // Locations
        a = Random.Range(GlobalConstants.MinInstancesOfActorsTotal, GlobalConstants.MaxInstancesOfActorsTotal);

        for (int i = 0; i < a; i++)
        {
            b = Random.Range(0, GlobalConstants.MapWidth - 1);
            c = Random.Range(0, GlobalConstants.MapHeight - 1);

            Locations.Add(b);
            Locations.Add(c);
        }

        // Methods
        a = Random.Range(GlobalConstants.MethodCountMin, GlobalConstants.MethodCountMax);

        for (int i = 0; i < a; i++)
        {
            List<int> Blueprint = new List<int>(14);

            Blueprint[0] = Random.Range(0, GlobalConstants.MethodNumTypes);                 // Method type
            Blueprint[1] = Random.Range(0, GlobalConstants.MethodInputNumTypes);            // Input from
            Blueprint[2] = Random.Range(0, GlobalConstants.MethodInputNumTypes);
            Blueprint[3] = Random.Range(0, GlobalConstants.MethodInputNumTypes);
            Blueprint[4] = Random.Range(0, GlobalConstants.MethodOutputNumTypes);           // Output to
            Blueprint[5] = Random.Range(0, GlobalConstants.MaxInstancesOfActorsTotal);      // Output to other actor ID
            Blueprint[6] = Random.Range(0, GlobalConstants.ActorNumReadableVariables);      // Which variable is input
            Blueprint[7] = Random.Range(0, GlobalConstants.ActorNumReadableVariables);
            Blueprint[8] = Random.Range(0, GlobalConstants.ActorNumReadableVariables);
            Blueprint[9] = Random.Range(0, GlobalConstants.ActorNumWritableVariables);      // Which variable to output to
            Blueprint[10] = Random.Range(0, GlobalConstants.MethodInitialVariableConstraint);           // Constants
            Blueprint[11] = Random.Range(0, GlobalConstants.MethodInitialVariableConstraint);
            Blueprint[12] = Random.Range(0, GlobalConstants.MethodInitialVariableConstraint);

            MethodBlueprints.Add(Blueprint);
        }


        // Global variables
        // bools
        for (int i = 0; i < 5; i++)
        {
            GlobalVariables.Add(Random.Range(0, 1));
        }
        // floats
        for (int i = 5; i < 10; i++)
        {
            GlobalVariables.Add(Random.Range(0, GlobalConstants.GlobalInitialVariableConstraintFloat));
        }
        // vectors
        for (int i = 10; i < GlobalConstants.GlobalVariablesCount; i+=2)
        {
            GlobalVariables.Add(Random.Range(0, GlobalConstants.GlobalInitialVariableConstraintVector));
            GlobalVariables.Add(Random.Range(0, GlobalConstants.GlobalInitialVariableConstraintVector));
        }
    }

    public void PrintGenome()
    {
        // Print out the genome in a readable format
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
