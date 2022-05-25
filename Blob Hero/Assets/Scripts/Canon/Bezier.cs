using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Bezier : MonoBehaviour
{
    public bool leftBezier;
    public bool rightBezier;

    public List<GameObject> bezierPointListObjects;
    public LineRenderer lineRenderer;

    


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
    }

    private void Update()
    {
        


        SetBezier();
    }

    public void SetBezier()
    {
        for (float i = 0; i < 100; i++)
        {
            float k = i / 100;
            Vector3 m_positionLinePoint = bezierPointListObjects[0].transform.position * Mathf.Pow((1 - k), 3) +
                                          bezierPointListObjects[1].transform.position * Mathf.Pow((1 - k), 2) * k * 3 +
                                          3 * (1 - k) * k * k * bezierPointListObjects[2].transform.position
                                          + k * k * k * bezierPointListObjects[3].transform.position;
            lineRenderer.SetPosition((int)i, m_positionLinePoint);
        }
    }
}
