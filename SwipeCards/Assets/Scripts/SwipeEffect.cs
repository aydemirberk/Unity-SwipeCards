using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeEffect : MonoBehaviour, IDragHandler, IBeginDragHandler,IEndDragHandler
{
    private Vector3 _initialPosition;
    private float _distanceMoved;
    public bool _swipeLeft;
    Transform nopeImage;
    Transform likeImage;

    public GameObject likeObject;
    public GameObject nopeObject;

    public event Action cardMoved;



    private void Start()
    {
        nopeImage = transform.Find("nope");
        likeImage = transform.Find("like");

        likeObject = likeImage.gameObject;
        nopeObject = nopeImage.gameObject;

        _initialPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData )
    {
        transform.localPosition = new Vector2(x: transform.localPosition.x + eventData.delta.x, y: transform.localPosition.y);

        if (transform.localPosition.x - _initialPosition.x > 0)
        {
            transform.localEulerAngles = new Vector3(x: 0, y: 0, z: Mathf.LerpAngle(a: 0, 30,
                t:(_initialPosition.x+transform.localPosition.x)/(Screen.width/2)));
            likeObject.SetActive(true);

            if (nopeObject.activeInHierarchy == true)
                nopeObject.SetActive(false);

        }

        else
        {
            transform.localEulerAngles = new Vector3(x: 0, y: 0, z: Mathf.LerpAngle(a: 0, -30,
                t: (_initialPosition.x - transform.localPosition.x) / (Screen.width / 2)));
            nopeObject.SetActive(true);

            if (likeObject.activeInHierarchy == true)
                likeObject.SetActive(false);
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = transform.localPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _distanceMoved = Mathf.Abs(f: transform.localPosition.x - _initialPosition.x);
        if (_distanceMoved < 0.4 * Screen.width)
        {
            transform.localPosition = _initialPosition;
            transform.localEulerAngles = Vector3.zero;
            nopeObject.SetActive(false);
            likeObject.SetActive(false);

        }

        else
        {
            MoveOut();
        }
        
    }

    public void MoveOut()
    {
        if (transform.localPosition.x > _initialPosition.x)
        {
            _swipeLeft = false;
            
        }
        else if(transform.localPosition.x < _initialPosition.x)
        {
            _swipeLeft = true;
            
        }

        StartCoroutine(routine: MovedCard());
        cardMoved?.Invoke();
    }

    private IEnumerator MovedCard()
    {
        float time = 0;
        while (GetComponent<Image>().color != new Color(r: 1, g: 1, b: 1, a: 0))
        {
            time += Time.deltaTime;

            if (_swipeLeft)
            {
                transform.localEulerAngles = new Vector3(x: 0, y: 0, z: Mathf.LerpAngle(a: 0, -30,
                t: (_initialPosition.x - transform.localPosition.x) / (Screen.width / 2)));

                transform.localPosition = new Vector3(x: Mathf.SmoothStep(from: transform.localPosition.x,
                    to: transform.localPosition.x - Screen.width, t:time), transform.localPosition.y, z: 0);
            }
            else
            {
                transform.localEulerAngles = new Vector3(x: 0, y: 0, z: Mathf.LerpAngle(a: 0, 30,
                t: (_initialPosition.x + transform.localPosition.x) / (Screen.width / 2)));

                transform.localPosition = new Vector3(x: Mathf.SmoothStep(from: transform.localPosition.x,
                    to: transform.localPosition.x + Screen.width, t:time), transform.localPosition.y, z: 0);

            }

            GetComponent<Image>().color = new Color(r: 1, g: 1, b: 1, a: Mathf.SmoothStep(from: 1, to: 0, t: 4 * time));
            yield return null;
        }

        Destroy(gameObject);
        
    }
}
