using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private string cardName;

    public string CardName
    {
        get
        {
            return cardName;
        }

        set
        {
            cardName = value;
        }
    }

    public virtual string CardText
    {
        get
        {
            return CardName;
        }
    }
}

[System.Serializable]
public class CardWithCount
{
    public Card card;
    public int count = 1;
}
