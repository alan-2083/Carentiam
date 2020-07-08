using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponAmmo : MonoBehaviour
{

    public string ammoName = "AC Shells";
    public int ammoMax = 200;
    public int ammoCurrent = 0;
    public int clipMax = 20;
    public int clipCurrent = 1;

    private float reloadingProgress;
    public float reloadTime = 5f;
    public TextMeshProUGUI reloadingText;
    public Image reticleImage;
    public Color reloadingColor = new Color(1f, 0.3f, 0f, 1);
    public Color notReloadingColor = new Color(0f, 1f, 0.4f, 1);

    private WeaponParticles weaponParticles;

    void Awake()
    {
        ammoCurrent = ammoMax;
        clipCurrent = clipMax;
        reticleImage.color = notReloadingColor;
        reloadingText.text = "";
        weaponParticles = GetComponent<WeaponParticles>();
    }

    void Update()
    {
        if (clipCurrent == 0)
        Reloading();
    }

    private void Reloading()
    {
        if (reloadingProgress < reloadTime)
        {
            StillReloading();
        }
        else
        {
            FinishReloading();
        }
    }

    private void StillReloading()
    {
        reloadingProgress += Time.deltaTime;
        reloadingText.text = "RELOADING " + (((reloadingProgress * 100) / reloadTime)).ToString("F0") + "%";
        //reloadingText.color = reloadingColor;
        reticleImage.color = reloadingColor;
        weaponParticles.WeaponReloadingParticles();
    }

    private void FinishReloading()
    {
        reloadingText.text = "";
        reloadingProgress = 0f;
        reticleImage.color = notReloadingColor;
        if (ammoCurrent > clipMax)
        {
            clipCurrent = clipMax;
            ammoCurrent -= clipMax;
        }
        else
        {
            clipCurrent += ammoCurrent;
            ammoCurrent = 0;
        }
    }
}
