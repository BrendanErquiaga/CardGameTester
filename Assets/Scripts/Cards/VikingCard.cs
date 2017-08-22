using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class VikingCard : Card
{
    public VikingCardType cardType = VikingCardType.Wealth;
    public int attackValue = 1;
    public int defenseValue = 1;
    public int buildValue = 1;
    public int wealthValue = 0;
    public int wealthRequired = 1;

    public string extraRules = "";

    public override string CardText
    {
        get
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(CardName);
            sb.AppendLine("~~~~~~~~~");

            sb.AppendLine("ATK: " + attackValue);
            sb.AppendLine("DEF: " + defenseValue);
            sb.AppendLine("BLD: " + buildValue);
            if(wealthValue > 0)
            {
                sb.AppendLine("VAL: " + wealthValue);
            }

            if (cardType == VikingCardType.Wealth)
            {
                sb.AppendLine("BLD REQ: " + wealthRequired);
            } else
            {
                sb.AppendLine("VAL REQ: " + wealthRequired);
            }
            
            if(extraRules != "")
            {
                sb.AppendLine(extraRules);
            }           

            return sb.ToString();
        }
    }
}

public enum VikingCardType
{
    Warrior,
    Wealth,
    King
}
