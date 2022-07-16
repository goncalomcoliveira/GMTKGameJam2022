using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOverride : MonoBehaviour{   
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    public void SetAnimations(AnimatorOverrideController overrideController) {
        anim.runtimeAnimatorController = overrideController;
    }
}
