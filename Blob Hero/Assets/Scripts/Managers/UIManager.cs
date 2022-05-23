using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
	[SerializeField] float decreaseTimeValue;
	[SerializeField] float moveSpeedIncreaseValue;
	[HideInInspector]
	public float moveSpeedIncreaser;
	[SerializeField] float coinDistanceIncreaser;
	[SerializeField] GameObject restartCanvas;
	public GameObject gameCanvas;
	[SerializeField] GameObject startCanvas;
	[SerializeField] GameObject levelUpCanvas;
	[SerializeField] GameObject continueCanvas;
	public GameObject stopButton;


	public Vector3 coinDistance = Vector3.zero;


	GameObject lockImage;
	PlayerCollision _playerCollision;
	SkillActiver[] _skillActivers;
	private void Awake()
	{
		_playerCollision = FindObjectOfType<PlayerCollision>();
		_skillActivers = FindObjectsOfType<SkillActiver>();
		coinDistanceIncreaser = 0.003f;
		moveSpeedIncreaser = 0;
		moveSpeedIncreaseValue = 0;
		decreaseTimeValue = 0;
	}
	public void FireGun()
	{
		ResetCanvases();
		UnlockSkill("fireSkillImage",1);
	}
	public void Lightning()
	{
		ResetCanvases();
		UnlockSkill("electricSkillImage",1);

	}
	public void TripleRocket()
	{
		ResetCanvases();
		UnlockSkill("tripleSkillImage",1);
	}
	public void CircleSkill()
	{
		ResetCanvases();
		UnlockSkill("circleSkillImage",1);
	}
	public void HealthSkill()
	{
		_playerCollision.decreaseFillAmount -= 0.005f;
		ResetCanvases();
		UnlockSkill("healthSkillImage", 0);
	}
	public void TimeSkill()
	{
		foreach (var skill in _skillActivers)
		{
			skill.decreaseTimeValue += decreaseTimeValue;
		}
		ResetCanvases();
		UnlockSkill("timeSkillImage", 0);
	}
	public void MagneticSkill()
	{
		coinDistance += new Vector3(coinDistanceIncreaser, coinDistanceIncreaser, coinDistanceIncreaser);
		ResetCanvases();
		UnlockSkill("magneticSkillImage", 0);
	}
	public void SpeedSkill()
	{
		moveSpeedIncreaser += moveSpeedIncreaseValue;
		ResetCanvases();
		UnlockSkill("speedSkillImage", 0);
	}
	void ResetCanvases()
	{
		gameCanvas.gameObject.SetActive(true);
		startCanvas.gameObject.SetActive(false);
		levelUpCanvas.gameObject.SetActive(false);
		_playerCollision.stopActiver = false;
		stopButton.gameObject.SetActive(true);
		Time.timeScale = 1f;
	}
	void UnlockSkill(string _str,int childIndex)
	{
		lockImage = GameObject.Find(_str).gameObject.transform.GetChild(childIndex).gameObject;
		GameObject.Find(_str).gameObject.GetComponent<LockControl>().unLocked = true;
		lockImage.gameObject.SetActive(false);
	}
	public void StopGame()
	{
		continueCanvas.gameObject.SetActive(true);
		stopButton.gameObject.SetActive(false);
		Time.timeScale = 0;
	}
	public void ContinueGame()
	{
		Time.timeScale = 1f;
		stopButton.gameObject.SetActive(true);
		continueCanvas.gameObject.SetActive(false);
	}
	public void OpenRestartCanvas()
	{
		stopButton.gameObject.SetActive(false);
		restartCanvas.gameObject.SetActive(true);
		gameCanvas.gameObject.SetActive(false);
	}
	public void lateOpen()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
