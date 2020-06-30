using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleGameScript : MonoBehaviour
{
    public double currency1;
    public string currency1Name = "Coins";
    public string currency1NameSingular = "Coin";
    public Text currency1Text;

    public double clickValue;
    public Text clickValueText;

    public double clickUpgradeLevel;
    public double clickUpgradeCost;
    public double clickUpgradeCostMultiplier;
    public double clickUpgradePower;
    public Text clickUpgradeText;
    public string clickUpgradeCostString;
    public string upgrade1Name = "UPGRADE1";

    public double productionUpgrade1Level;
    public double productionUpgrade1Cost;
    public double productionUpgrade1CostMultiplier;
    public double productionUpgrade1Power;
    public Text productionUpgrade1Text;
    public string productionUpgrade1CostString;

    public double productionUpgrade1DoublerLevel;
    public double productionUpgrade1DoublerCost;
    public double productionUpgrade1DoublerCostMultiplier;
    public Text productionUpgrade1DoublerText;

    public double currency1PerSecond;
    public Text currency1PerSecondText;

    public double timeElapsed;
    public Text timeElapsedText;

    PassiveUpgrade Upg = new PassiveUpgrade();

    void Start()
    {
        load();
        productionUpgrade1Power = 1;
        productionUpgrade1CostMultiplier = 1.07;
        productionUpgrade1Cost = 20 * System.Math.Pow(productionUpgrade1CostMultiplier, productionUpgrade1Level);
        productionUpgrade1DoublerCost = 150 * System.Math.Pow(productionUpgrade1DoublerCostMultiplier, productionUpgrade1DoublerLevel);
        currency1PerSecond = (productionUpgrade1Level * productionUpgrade1Power * (productionUpgrade1DoublerLevel + 1));
        clickUpgradePower = 1;
        clickUpgradeCostMultiplier = 1.07;
        clickUpgradeCost = 10 * System.Math.Pow(clickUpgradeCostMultiplier, clickUpgradeLevel);
        clickValue = 1 + (1 * clickUpgradeLevel * clickUpgradePower);

        //for debugging
        currency1 = 9999999999999998;

    }

    void load()
    {
        currency1 = double.Parse(PlayerPrefs.GetString("currency1", "0"));

        clickUpgradeLevel = double.Parse(PlayerPrefs.GetString("clickUpgradeLevel", "0"));

        productionUpgrade1Level = double.Parse(PlayerPrefs.GetString("productionUpgrade1Level", "0"));

        productionUpgrade1DoublerLevel = double.Parse(PlayerPrefs.GetString("productionUpgrade1DoublerLevel", "0"));


        //debugging of class-based upgrades
        Upg.cost = 11;
        Upg.power = 1;
        Upg.level = 0;

    }


    void Update()
    {
        //Text//////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        
        //Currency 1 Text//
        if(currency1>999)
        {
            var exponentCurrency = System.Math.Floor(System.Math.Log10(System.Math.Abs(currency1)));
            var mantissaCurrency = (currency1 / System.Math.Pow(10, exponentCurrency));
            currency1Text.text = mantissaCurrency.ToString("F2") + "e" + exponentCurrency + " " + currency1Name;
        }
        else
        currency1Text.text = currency1.ToString("F0") + currency1Name;

        //Currency 1 Per Second Text//
        if (currency1PerSecond > 999)
        {
            var exponentCurrencyPerSecond = System.Math.Floor(System.Math.Log10(System.Math.Abs(currency1PerSecond)));
            var mantissaCurrencyPerSecond = (currency1PerSecond / System.Math.Pow(10, exponentCurrencyPerSecond));
            currency1PerSecondText.text = mantissaCurrencyPerSecond.ToString("F2") + "e" + exponentCurrencyPerSecond + "\n" + currency1Name + "/s";
        }
        else
            currency1PerSecondText.text = currency1PerSecond.ToString("F0") + "\n" + currency1Name + "/s";

        //Click Value Text//
        if (currency1PerSecond > 999)
        {
            var exponentClickValue = System.Math.Floor(System.Math.Log10(System.Math.Abs(clickValue)));
            var mantissaClickValue = (clickValue / System.Math.Pow(10, exponentClickValue));
            clickValueText.text = mantissaClickValue.ToString("F2") + "e" + exponentClickValue + " " + currency1Name + "/s";
        }
        else if (clickValue >1)
            clickValueText.text = "+ " + clickValue.ToString("F0") + " " + currency1Name;
        else
            clickValueText.text = "+ " + clickValue.ToString("F0") + " " + currency1NameSingular;

        //Click Upgrade Cost Text//
        if (clickUpgradeCost > 999)
        {
            var exponentClickUpgradeCost = System.Math.Floor(System.Math.Log10(System.Math.Abs(clickUpgradeCost)));
            var mantissaClickUpgradeCost = (clickUpgradeCost / System.Math.Pow(10, exponentClickUpgradeCost));
            clickUpgradeCostString = mantissaClickUpgradeCost.ToString("F2") + "e" + exponentClickUpgradeCost;
        }
        else
            clickUpgradeCostString = clickUpgradeCost.ToString("F0");

            //Click Power Upgrade Text//
            if (clickUpgradePower>999)
               {
            var exponentClickUpgradePower = System.Math.Floor(System.Math.Log10(System.Math.Abs(clickUpgradePower)));
            var mantissaClickUpgradePower = (clickUpgradePower / System.Math.Pow(10, exponentClickUpgradePower));
            clickUpgradeText.text = mantissaClickUpgradePower.ToString("F2") + "e" + exponentClickUpgradePower + " Click Power\nCost: " + clickUpgradeCostString + " " + currency1Name + "/s";
               }
        else
            clickUpgradeText.text = "Click Upgrade\n+" + clickUpgradePower + " Click Power\nCost: " + clickUpgradeCostString + " " + currency1Name + "/s";

        //Production Upgrade 1 Cost Text//
        if (productionUpgrade1Cost > 999)
        {
            var exponentProductionUpgradeCost = System.Math.Floor(System.Math.Log10(System.Math.Abs(productionUpgrade1Cost)));
            var mantissaProductionUpgradeCost = (productionUpgrade1Cost / System.Math.Pow(10, exponentProductionUpgradeCost));
            productionUpgrade1CostString = mantissaProductionUpgradeCost.ToString("F2") + "e" + exponentProductionUpgradeCost;
        }
        else
            productionUpgrade1CostString = clickUpgradeCost.ToString("F0");

        //Production Upgrade 1 Power Text//
        if (productionUpgrade1Power>999)
        {
            var exponentProductionUpgrade1Power = System.Math.Floor(System.Math.Log10(System.Math.Abs(productionUpgrade1Power)));
            var mantissaProductionUpgrade1Power = (productionUpgrade1Power / System.Math.Pow(10, exponentProductionUpgrade1Power));
            productionUpgrade1Text.text = mantissaProductionUpgrade1Power.ToString("F2") + "e" + exponentProductionUpgrade1Power + " Click Power\nCost: " + productionUpgrade1CostString + " " + currency1Name + "/s";
        }
        else
        productionUpgrade1Text.text = upgrade1Name + "\n+" + productionUpgrade1Power + " " + currency1Name + "/second\nCost: " + productionUpgrade1Cost.ToString("F0") + " " + currency1Name;
        
        //Production Upgrade 1 Doubler Text//
        if(productionUpgrade1DoublerCost>999)
        {
            var exponentProductionUpgrade1Doubler = System.Math.Floor(System.Math.Log10(System.Math.Abs(productionUpgrade1DoublerCost)));
            var mantissaProductionUpgrade1Doubler = (productionUpgrade1DoublerCost / System.Math.Pow(10, exponentProductionUpgrade1Doubler));
            productionUpgrade1DoublerText.text = mantissaProductionUpgrade1Doubler.ToString("F2") + "e" + exponentProductionUpgrade1Doubler + " Click Power\nCost: " + productionUpgrade1DoublerCost + " " + currency1Name + "/s";
        }
        productionUpgrade1DoublerText.text = "Double "+ currency1Name + "/s from\n" + upgrade1Name + "\nCost: " + productionUpgrade1DoublerCost.ToString("F0") + " " + currency1Name;

        //class-based generated description (not working atm)
        Upg.TextDescription(currency1Name);

        ///////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////

        //Time-dependant mechanics
        currency1 += currency1PerSecond * Time.deltaTime;
        timeElapsed += 1 * Time.deltaTime;
    }

    //Click Button
    public void ClickButton()
    {
        currency1 += clickValue;
    }

    //Click Upgrade Button
    public void ClickUpgradeButton()
    {
        if (currency1 >= clickUpgradeCost)
        {
            currency1 -= clickUpgradeCost;
            clickUpgradeLevel++;
            clickValue += clickUpgradePower;
            clickUpgradeCost *= 1.07;
        }
    }

    //Production Upgrade 1 Button
    public void ProductionUpgrade1Button()
    {
        if (currency1 >= productionUpgrade1Cost)
        {
            currency1 -= productionUpgrade1Cost;
            productionUpgrade1Level++;
            currency1PerSecond += productionUpgrade1Power;
            productionUpgrade1Cost *= 1.07;
        }
    }

    //Double Production Upgrade 1 Button
    public void ProductionUpgrade1DoublerButton()
    {
        if (currency1 >= productionUpgrade1DoublerCost)
        {
            currency1 -= productionUpgrade1DoublerCost;
            currency1PerSecond += productionUpgrade1Level * productionUpgrade1Power;
            productionUpgrade1Power *= 2;
            productionUpgrade1DoublerCost *= 3;
            productionUpgrade1DoublerLevel++;
        }
    }

    //procedural button (not working atm)
    public void Upg.canAfford(currency1, currency1PerSecond);
}
