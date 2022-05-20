using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
	[SerializeField] GameObject restartCanvas;
	public GameObject gameCanvas;
	[SerializeField] GameObject startCanvas;
	[SerializeField] GameObject levelUpCanvas;
	[SerializeField] GameObject continueCanvas;
	public GameObject stopButton;

	GameObject lockImage;
	PlayerCollision _playerCollision;
	private void Awake()
	{
		_playerCollision = FindObjectOfType<PlayerCollision>();
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
		ResetCanvases();
		UnlockSkill("healthSkillImage", 0);
	}
	public void TimeSkill()
	{
		ResetCanvases();
		UnlockSkill("timeSkillImage", 0);
	}
	public void MagneticSkill()
	{
		ResetCanvases();
		UnlockSkill("magneticSkillImage", 0);
	}
	public void SpeedSkill()
	{
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
