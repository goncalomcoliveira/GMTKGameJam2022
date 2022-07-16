using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFace : MonoBehaviour{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    [SerializeField] private AnimatorOverrider overrider;

    public void Set(int value) {
        if (value >= 0 && value < overrideControllers.Length) 
            overrider.SetAnimations(overrideControllers[value]);
    }    
}

