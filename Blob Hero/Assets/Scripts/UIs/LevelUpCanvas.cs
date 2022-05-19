using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpCanvas : MonoBehaviour
{
	[SerializeField] GameObject[] skills;
    [SerializeField] GameObject[] skillButtonPrefabs;
	[SerializeField] Transform left, middle, right;
	private void OnEnable()
	{
		int buttonCount = 0;
		for (int i = 0; i < 8; i++)
		{
			if(!skills[i].gameObject.GetComponent<LockControl>().unLocked && buttonCount<3)
			{
				skillButtonPrefabs[i].gameObject.SetActive(true);
				if (buttonCount == 0)
					skillButtonPrefabs[i].transform.position = left.position;
				if (buttonCount == 1)
					skillButtonPrefabs[i].transform.position = middle.position;
				if (buttonCount == 2)
					skillButtonPrefabs[i].transform.position = right.position;

				buttonCount++;
			}
			if(buttonCount==2 && !skillButtonPrefabs[i].gameObject.activeSelf)
			{
				skillButtonPrefabs[i].gameObject.SetActive(true);
				skillButtonPrefabs[i].transform.position = right.position;
			}
		}
		for (int i = 4; i < 8; i++)
		{
			if (buttonCount == 2 && !skillButtonPrefabs[i].gameObject.activeSelf)
			{
				skillButtonPrefabs[i].gameObject.SetActive(true);
				skillButtonPrefabs[i].transform.position = right.position;
				buttonCount++;
			}
			if (buttonCount == 1 && !skillButtonPrefabs[i].gameObject.activeSelf)
			{
				skillButtonPrefabs[i].gameObject.SetActive(true);
				skillButtonPrefabs[i].transform.position = middle.position;
				buttonCount++;
			}
			if (buttonCount == 0 && !skillButtonPrefabs[i].gameObject.activeSelf)
			{
				skillButtonPrefabs[i].gameObject.SetActive(true);
				skillButtonPrefabs[i].transform.position = left.position;
				buttonCount++;
			}

		}
	}
}
