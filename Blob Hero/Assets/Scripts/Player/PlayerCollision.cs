using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
	[SerializeField] GameObject outOfIslandCanvas;
	[SerializeField] GameObject levelUpCanvas;
	[SerializeField] GameObject canvas;
	[SerializeField] Image bar;
	[SerializeField] Text levelIndexText;

	public bool outOfIsland;
	public bool stopActiver;

	int levelIndex;
	int chapterIndex;

	float fillAmount;
	public float decreaseFillAmount;

	GameCanvasUI _experiences;
	Animator enemyAnim;
	AnimationController _animationController;
	UIManager _UImanager;
	
	private void Awake()
	{
		levelIndex = 1;
		chapterIndex = 1;
		_animationController = GetComponent<AnimationController>();
		_experiences = FindObjectOfType<GameCanvasUI>();
		_UImanager = FindObjectOfType<UIManager>();
		GameManager.Instance.GameStart();

	}
	private void OnEnable()
	{
		_animationController = GetComponent<AnimationController>();
		_experiences = FindObjectOfType<GameCanvasUI>();
	}
	private void Start()
	{
		decreaseFillAmount = 0.05f;
		fillAmount = 1;
		
	}

	private void Update()
	{
		canvas.transform.LookAt(Camera.main.transform.position);
		if(outOfIsland && !GameManager.Instance.isDead)
		{
			DecreaseFillAmount(0.001f);
		}
	}

	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			DecreaseFillAmount(decreaseFillAmount);
			other.gameObject.GetComponent<EnemyController>().follow = false;
			Destroy(other.gameObject, 1f);
		}
		if (other.gameObject.CompareTag("Spear"))
		{
			DecreaseFillAmount(decreaseFillAmount);
			enemyAnim= other.gameObject.GetComponentInChildren<Animator>();
			other.gameObject.GetComponent<EnemyController>().follow = false;
			enemyAnim.SetBool("isSpear", true);
			
		}
		if(other.gameObject.CompareTag("Coin"))
		{
			
			if(!GameManager.Instance.isCanon)
			{
				if (levelIndex == 1)
				{
					_experiences.levelBar.fillAmount += 0.05f;
				}
				if (levelIndex == 2)
				{
					_experiences.levelBar.fillAmount += 0.025f;
				}
				else
				{
					_experiences.levelBar.fillAmount += 0.02f;
				}

				if (_experiences.levelBar.fillAmount > 0.98f)
				{
					GameManager.Instance.LevelCompleted();
					levelIndex++;
					_experiences.levelText.text = "LEVEL " + levelIndex;
					_experiences.levelBar.fillAmount = 0;
					_experiences.chapterBar.fillAmount += 0.05f;
					if (_experiences.chapterBar.fillAmount >= 0.98)
					{
						chapterIndex++;
						_experiences.chapterBar.fillAmount = 0;
						_experiences.chapterText.text = "CHAPTER " + chapterIndex;
					}
					levelUpCanvas.gameObject.SetActive(true);
					_UImanager.stopButton.gameObject.SetActive(false);
					levelIndexText.text = levelIndex.ToString();
					stopActiver = true;
					Time.timeScale = 0;

				}
			}
			
			Destroy(other.gameObject);
		}
		if(other.gameObject.CompareTag("Island"))
		{
			outOfIsland = false;
			outOfIslandCanvas.gameObject.SetActive(false);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			
			other.gameObject.GetComponent<EnemyController>().follow = true;
			
		}
		if (other.gameObject.CompareTag("Spear"))
		{
			
			other.gameObject.GetComponent<EnemyController>().follow = true;
			
		}
		if(other.gameObject.CompareTag("Island") && !GameManager.Instance.isCanon)
		{
			outOfIsland = true;
			outOfIslandCanvas.gameObject.SetActive(true);
		}
	}

	void DecreaseFillAmount(float decreaseValue)
	{
		fillAmount -= decreaseValue;
		bar.fillAmount = fillAmount;
		if (fillAmount <= 0.06f)
		{
			GameManager.Instance.isDead = true;
			fillAmount = 0;
			bar.fillAmount = fillAmount;
			_animationController.DeathAnimation(true);
			canvas.gameObject.SetActive(false);
			_UImanager.OpenRestartCanvas();
			stopActiver = true;
			StartCoroutine(StopGame());
			GameManager.Instance.LevelFailed();
		}
		
		
	}

	IEnumerator StopGame()
	{
		yield return new WaitForSeconds(0.8f);
		
	}
}
