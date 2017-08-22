using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Card card;
    public TextMeshPro textMeshPro;

    private void OnGUI()
    {
        if(card.CardText != textMeshPro.text)
        {
            textMeshPro.text = card.CardText;
        }
    }
}
