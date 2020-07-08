using UnityEngine;

public class WeaponTrajectoryRay : MonoBehaviour
{
    private WeaponTrigger weaponTrigger;
    private WeaponStats weaponStats;
    public float damageInflicted;
    public float range = 100f;

    public GameObject Muzzle;
    public GameObject impactEffect;

    void Awake()
    {
        weaponTrigger = GetComponent<WeaponTrigger>();
        weaponTrigger.Trajectory = CastRay;
        weaponTrigger.Muzzle = Muzzle;
        weaponStats = GetComponent<WeaponStats>();
        damageInflicted = weaponStats.damageInflicted;
    }

    void Update()
    {

    }

    private void CastRay(GameObject Muzzle)
    {
        RaycastHit hit;
        if (Physics.Raycast(Muzzle.transform.position, Muzzle.transform.forward, out hit, range))
        {
            GameObject ImpactO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactO, 2f);

            Target target = hit.transform.GetComponent<Target>();
            DamageTarget(target);
            
        }
    }

    private void DamageTarget(Target target)
    {
        if (target != null)
        {
            target.TakeDamage(damageInflicted);

        }
    }
}
