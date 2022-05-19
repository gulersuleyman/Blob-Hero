using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillActiver : MonoBehaviour
{

    [SerializeField] GameObject skill;
    [SerializeField] Image timerImage;
    [SerializeField] float timeBoundary;

    

    LockControl _lock;
    PlayerCollision _playercollision;
    void Awake()
    {
        _lock = GetComponent<LockControl>();
        _playercollision = FindObjectOfType<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_lock.unLocked && !_playercollision.stopActiver && !skill.gameObject.activeSelf)
		{
         
            timerImage.fillAmount -= 1/timeBoundary*Time.deltaTime;
            if (timerImage.fillAmount<=0)
			{
                skill.gameObject.SetActive(true);
                timerImage.fillAmount = 1;
			}
            
		}
    }
}
