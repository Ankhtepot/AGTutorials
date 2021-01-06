using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingButton : MonoBehaviour
{
   [SerializeField] Animator animator;
   public bool removeAnimatorOnIdle;

   public void RemoveAnimator()
   {
      animator.enabled = !removeAnimatorOnIdle;
   }

   public void RunAnimator(bool removeAnimator)
   {
      removeAnimatorOnIdle = removeAnimator;

      animator.enabled = true;
      animator.SetTrigger("Run");
   }
}
