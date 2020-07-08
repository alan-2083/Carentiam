using UnityEngine;

public class WeaponParticles : MonoBehaviour
{
    public ParticleSystem particleSystemMuzzleFire;
    public ParticleSystem particleSystemWeaponReloading;
    //public GameObject Muzzle;
    //public GameObject MuzzleLightObject;
    public float muzzleFireTime = 0.2f;

    public void MuzzleLight()
    {
        //MuzzleLightObject.SetActive(true);
        particleSystemMuzzleFire.Play();
    }

    public void WeaponReloadingParticles()
    {
        if( particleSystemWeaponReloading.isPlaying == false)
        particleSystemWeaponReloading.Play();
    }
}
