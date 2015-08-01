using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Timer{

    float _resetTime;
    float _durationTime;
    int _maxTicks;
    bool _singleTick;

    public Timer(bool sT, float dT, int mT/*,do method*/) {
        _durationTime = dT;
        _resetTime = _durationTime;
        _singleTick = sT;
        _maxTicks = mT;
    }

    public void RunTimer(){

        if (_durationTime <= 0.0f){
            
            //do method

            //run once or multiple times at
            if (!_singleTick){
                _durationTime = _resetTime;

            }
        }
    }


}
