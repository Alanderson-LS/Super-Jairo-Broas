using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JairoAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    public void PlayAnimation(string name) {
        playerAnimator.Play(name);
    }
}
