using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBuilder : MonoBehaviour
{
    public Deck deckToBuild;
    public CardWithCount[] cardsToAdd;    

    private void Start()
    {
        BuildDeck();
        deckToBuild.InstantiateDeck();
    }

    public void BuildDeck()
    {
        for(int i = 0; i < cardsToAdd.Length; i++)
        {
            for(int cardCount = 0; cardCount < cardsToAdd[i].count; cardCount++)
            {
                deckToBuild.cardsInDeck.Add(cardsToAdd[i].card);
            }
        }
    }
}
