using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillActiver : MonoBehaviour
{
    public bool isField;
    public float decreaseTimeValue;

    [SerializeField] GameObject skill;
    [SerializeField] Image timerImage;
    [SerializeField] float timeBoundary;



    

    LockControl _lock;
    PlayerCollision _playercollision;
    AnimationController _animationController;
    void Awake()
    {
        decreaseTimeValue = 0;
        _lock = GetComponent<LockControl>();
        _playercollision = FindObjectOfType<PlayerCollision>();
        _animationController = FindObjectOfType<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isField)
		{
            if (_lock.unLocked && !_playercollision.stopActiver && !skill.gameObject.activeSelf)
            {

                timerImage.fillAmount -= 1 / (timeBoundary - decreaseTimeValue) * Time.deltaTime;
                if (timerImage.fillAmount <= 0)
                {
                    skill.gameObject.SetActive(true);
                    timerImage.fillAmount = 1;
                }

            }
        }
        else
		{
            if (_lock.unLocked && !_playercollision.stopActiver && !skill.gameObject.activeSelf)
            {

                timerImage.fillAmount -= 1 / (timeBoundary - decreaseTimeValue) * Time.deltaTime;
                if (timerImage.fillAmount <= 0)
                {
                    _animationController.ThrowAnimation(true);
                    timerImage.fillAmount = 1;
                }

            }
            
		}
        
    }
}
