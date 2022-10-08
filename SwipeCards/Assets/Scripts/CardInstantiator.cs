using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInstantiator : MonoBehaviour
{

    public GameObject[] cardPrefabs;
    int cardCount;

    private void Start()
    {
        cardCount = 0;
    }

    void InstantiateCard()
    {

        if (cardCount >= cardPrefabs.Length)
        {
            cardCount = 0;
        }
        else
        {
            GameObject newCard = Instantiate(cardPrefabs[cardCount], transform, worldPositionStays: false);
            newCard.transform.SetAsFirstSibling();

            cardCount++;
        }

    }

    private void Update()
    {
        if (transform.childCount <2)
        {
            InstantiateCard();
        }
    }
}
