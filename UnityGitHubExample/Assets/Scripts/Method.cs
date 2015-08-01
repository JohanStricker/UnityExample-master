using UnityEngine;
using System.Collections;

enum Affected { CallingActor, Global, OtherActor};

public class Method
{

    // Which to affect
    Affected WhatToAffect;
    Actor AffectedActor;

}
