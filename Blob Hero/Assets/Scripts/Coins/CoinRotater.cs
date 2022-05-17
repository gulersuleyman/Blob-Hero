using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CoinRotater : MonoBehaviour
{
    
    void Start()
    {
        RotateCoin();
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
