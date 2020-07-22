using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public class Currency
    {
        public string currencyName = "currencyname";
        public double currencyAmount;

        public Currency(string name, double amount)
        {
            currencyName = name;
            currencyAmount = amount;
        }
    }

    public Currency currency1 = new Currency("Money", 5);
    public Currency currency2 = new Currency("Weapon Parts", 0);
    public Currency currency10 = new Currency("Prestige", 0);

    public class Upgrade
    {
        public string UpgradeName = "upgradename";
        public double UpgradeLevel;
        public double UpgradePower = 1;
        public double UpgradeCost = 25;
        public double UpgradeCostMultiplier = 1.07;

        public Upgrade(string upgradeName)
        {
            UpgradeName = upgradeName;
        }

        public Upgrade(string upgradeName, double upgradeLevel, double upgradePower, double upgradeCost, double upgradeCostMultiplier)
        {
            UpgradeName = upgradeName;
            UpgradeLevel = upgradeLevel;
            UpgradePower = upgradePower;
            UpgradeCost = upgradeCost;
            UpgradeCostMultiplier = upgradeCostMultiplier;
        }
    }

    public Upgrade clickUpgrade = new Upgrade("Click Upgrade", 1, 1, 10, 1.07);
    public Upgrade productionUpgrade1 = new Upgrade("Production Upgrade 1");
    public Upgrade productionUpgrade2 = new Upgrade("Production Upgrade 2", 0, 5, 300, 1.07);

    public TextMeshProUGUI currency1DisplayText;
    public TextMeshProUGUI currency2DisplayText;
    

    void Start()
    {
        
    }

    void Update()
    {
        currency1.currencyAmount += productionUpgrade1.UpgradeLevel * productionUpgrade1.UpgradePower;
        currency1.currencyAmount += productionUpgrade2.UpgradeLevel * productionUpgrade2.UpgradePower;
        currency1DisplayText.text = currency1.currencyName + ": " + currency1.currencyAmount;
        currency2DisplayText.text = currency2.currencyName + ": " + currency2.currencyAmount;
    }

    void OnSpendWeaponParts()
    {
        //currency2.currencyAmount -= SpendPartsCost;
        //RollForNewWeapon();

    }
}
