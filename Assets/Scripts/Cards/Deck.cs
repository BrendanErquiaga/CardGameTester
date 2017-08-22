using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public string deckName = "Deck";
    public List<Card> cardsInDeck;

    public bool reshuffleWhenEmpty = true;
    private List<Card> originalList;

    public void InstantiateDeck()
    {
        ShuffleDeck();
        originalList = new List<Card>(cardsInDeck);
    }

    public void ShuffleDeck()
    {
        cardsInDeck.Shuffle();
    }

    public Card GetNextCard()
    {
        Card tempCard = cardsInDeck[0];

        cardsInDeck.RemoveAt(0);

        if(cardsInDeck.Count <= 0) {
            Reshuffle();
        }

        return tempCard;
    }    

    public void Reshuffle()
    {
        cardsInDeck = new List<Card>(originalList);
        ShuffleDeck();
    }
}
