using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    SwipeEffect swipeEffect;
    SecondCard secondCard;

    public void LikeButtonPressed()
    {
        SwipeEffect currentBio = GameObject.FindObjectOfType<SwipeEffect>();
        swipeEffect = currentBio.gameObject.GetComponent<SwipeEffect>();

        SecondCard secondBio = GameObject.FindObjectOfType<SecondCard>();
        secondCard = secondBio.gameObject.GetComponent<SecondCard>();

        swipeEffect._swipeLeft = false;
        swipeEffect.likeObject.SetActive(true);
        swipeEffect.MoveOut();
        secondCard.SizeUp();
    }

    public void NopeButtonPressed()
    {
        SwipeEffect currentBio = GameObject.FindObjectOfType<SwipeEffect>();
        swipeEffect = currentBio.gameObject.GetComponent<SwipeEffect>();

        SecondCard secondBio = GameObject.FindObjectOfType<SecondCard>();
        secondCard = secondBio.gameObject.GetComponent<SecondCard>();

        swipeEffect._swipeLeft = true;
        swipeEffect.nopeObject.SetActive(true);
        swipeEffect.MoveOut();
        secondCard.SizeUp();

    }
    
}
