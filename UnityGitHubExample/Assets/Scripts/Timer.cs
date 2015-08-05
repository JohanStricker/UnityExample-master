using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Timer{

    float savedTime;
    float totalTime;

    // time in desired seconds
    public Timer(float tempTotalTime) {
        totalTime = tempTotalTime;
    }

    public void Start(){
        savedTime = Time.time;   
    }

    public bool isfinished() {
        float passedTime = Time.time - savedTime;
        if (passedTime > totalTime){
            return true;
        }else{
            return false;
        }
    }
}
