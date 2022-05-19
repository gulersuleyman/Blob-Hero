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

    void Awake()
    {
        _lock = GetComponent<LockControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_lock.unLocked)
		{
            timerImage.fillAmount -= 0.001f;
            if(timerImage.fillAmount<=0)
			{
                skill.gameObject.SetActive(true);
                timerImage.fillAmount = 1;
			}
		}
    }
}
