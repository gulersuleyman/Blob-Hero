using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float levelExperience;
    public float chapterExperience;

    public static GameManager Instance { get; private set; }



    private void Awake()
    {
        SingletonThisGameObject();
    }
    public void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
