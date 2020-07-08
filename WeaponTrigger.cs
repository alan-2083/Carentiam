using System;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    private WeaponAnimator weaponAnimator;
    private WeaponParticles weaponParticles;

    private WeaponAmmo weaponAmmo;

    private enum FireMode
    {
        FullAuto,
        SemiAuto,
    }
    [SerializeField]
    private FireMode fireMode = 0;


    public string triggerButton = "Fire1";
    public float fireRate = 1.5f;

    private float nextTimeToFire = 0f;

    [HideInInspector]
    public GameObject Muzzle=null;
    public Action<GameObject> Trajectory = delegate { };

    void Awake()
    {
        weaponAmmo = GetComponent<WeaponAmmo>();
        weaponAnimator = GetComponent<WeaponAnimator>();
        weaponParticles = GetComponent<WeaponParticles>();
    }

    void Update()
    {
        if (fireMode.ToString() == "FullAuto")
            ShootFullAuto();
        else if (fireMode.ToString() == "SemiAuto")
            ShootSemiAuto();
    }

    private void ShootFullAuto()
    {
        if (Input.GetButton(triggerButton) && Time.time >= nextTimeToFire && weaponAmmo.clipCurrent > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            Trajectory(Muzzle);
        }
    }

    private void ShootSemiAuto()
    {
        if (Input.GetButtonDown(triggerButton) && Time.time >= nextTimeToFire && weaponAmmo.clipCurrent > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            Trajectory(Muzzle);
        }
    }

    private void Shoot()
    {
        weaponAmmo.clipCurrent--;
        weaponAnimator.PlayFiring();
        //weaponParticles.particleSystemMuzzleFire.Play();
        weaponParticles.MuzzleLight();
    }
}
