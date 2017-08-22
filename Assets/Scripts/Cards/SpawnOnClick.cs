using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnClick : MonoBehaviour
{
    public Deck deck;
    public Vector3 positionOffset = new Vector3(0, -1, 0);

    private void OnMouseUp()
    {
        SpawnCard();
    }

    private void SpawnCard()
    {
        GameObject nextCard = deck.GetNextCard().gameObject;

        Vector3 spawnPosition = deck.transform.position + positionOffset;
        GameObject instantiatedObject = GameObject.Instantiate(nextCard, spawnPosition, nextCard.transform.rotation, deck.transform);
    }
}
