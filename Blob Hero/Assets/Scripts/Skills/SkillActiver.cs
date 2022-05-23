using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillActiver : MonoBehaviour
{

    public float decreaseTimeValue;

    [SerializeField] GameObject skill;
    [SerializeField] Image timerImage;
    [SerializeField] float timeBoundary;



    

    LockControl _lock;
    PlayerCollision _playercollision;
    void Awake()
    {
        decreaseTimeValue = 0;
        _lock = GetComponent<LockControl>();
        _playercollision = FindObjectOfType<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_lock.unLocked && !_playercollision.stopActiver && !skill.gameObject.activeSelf)
		{
         
            timerImage.fillAmount -= 1/(timeBoundary-decreaseTimeValue)*Time.deltaTime;
            if (timerImage.fillAmount<=0)
			{
                skill.gameObject.SetActive(true);
                timerImage.fillAmount = 1;
			}
            
		}
    }
}
