using UnityEngine;

public class WeaponAnimator : MonoBehaviour
{
    public Animator Animator;

    public void PlayFiring()
    {
        Animator.SetTrigger("ShootTrigger");
    }
}
