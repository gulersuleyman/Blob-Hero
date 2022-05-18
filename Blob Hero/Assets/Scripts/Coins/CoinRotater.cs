using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CoinRotater : MonoBehaviour
{
    float firstPosY;
    void Start()
    {
        firstPosY = transform.position.y;
        RotateCoin();
        transform.DOMoveY(transform.position.y + 5f, 0.25f).OnComplete(() =>
           {
               transform.DOMoveY(firstPosY, 0.25f);
           });
    }
    void RotateCoin()
	{
        transform.DORotate(new Vector3(transform.eulerAngles.x,
            transform.eulerAngles.y + 270, transform.eulerAngles.z), 1f).OnComplete(() =>
                {
                    RotateCoin();
                });
	}
    
}
