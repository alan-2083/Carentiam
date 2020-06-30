using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveUpgrade
{
    public int level;
    public double cost;
    public double power;
    public double costMultiplier = 1.07;
    public Text description;

    public void CanAfford(double currency, double currencyPerSecond)
    {
        if (currency >= cost)
        {
            currency -= cost;
            level++;
            currencyPerSecond += power;
            cost *= costMultiplier;
        }
    }

    public void TextDescription(string CurrencyName)
    {
        description.text = "Production Upgrade\n+" + power.ToString("F0") + " " + CurrencyName  + 
            "/second\nCost: " + cost + " " + CurrencyName;
    }
}
