using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;
using ElephantSDK;
public class GameManager : MonoBehaviour
{
    public bool isDead;
    
    public float levelExperience;
    public float chapterExperience;

    public static GameManager Instance { get; private set; }

    

    private void Awake()
    {
        GameAnalytics.Initialize();
        Time.timeScale = 0f;
        
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
    public void GameStart()
	{
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, PlayerPrefs.GetInt("level").ToString());
        Elephant.LevelStarted(PlayerPrefs.GetInt("level"));
    }
    public void LevelCompleted()
	{
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, PlayerPrefs.GetInt("level").ToString());
        Elephant.LevelCompleted(PlayerPrefs.GetInt("level"));
    }
    public void LevelFailed()
	{
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, PlayerPrefs.GetInt("level").ToString());
        Elephant.LevelFailed(PlayerPrefs.GetInt("level"));
    }
   
    
}
