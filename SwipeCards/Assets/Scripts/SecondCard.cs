using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCard : MonoBehaviour
{
    private SwipeEffect _swipeEffect;
    private GameObject _FirstCard;


    private void Start()
    {
        _swipeEffect = FindObjectOfType<SwipeEffect>();
        _FirstCard = _swipeEffect.gameObject;
        _swipeEffect.cardMoved+=CardMovedFront;

        transform.localScale = new Vector3(x: 0.8f, y: 0.8f, z: 0.8f);
    }

    private void Update()
    {
        float distanceMoved = _FirstCard.transform.localPosition.x;
        if (Mathf.Abs(distanceMoved) > 0)
        {
            float step = Mathf.SmoothStep(from: 0.8f, to: 1, t: Mathf.Abs(distanceMoved) / (Screen.width / 2));
            transform.localScale = new Vector3(x: step, y: step, z: step);
        }

    }

    public void SizeUp()
    { 
        transform.localScale = new Vector3(x: 1, y: 1, z: 1);
    }

    void CardMovedFront()
    {
        gameObject.AddComponent<SwipeEffect>();
        Destroy(obj:this);
    }
}
