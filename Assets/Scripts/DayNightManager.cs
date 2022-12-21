using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
	public Light sun;
	public float secondsInFullDay = 120f;
	public float updateRateInSeconds = 5f;
	[Range(0, 1)]
	public float currentTimeOfDay = 0.5f;
	public float timeMultiplier = 1f;

	void Start()
	{			
		InvokeRepeating("UpdateCycle", updateRateInSeconds, updateRateInSeconds);
	}
	void UpdateCycle()
	{
		UpdatePosition();
		
		currentTimeOfDay += ((Time.deltaTime + updateRateInSeconds) / secondsInFullDay) * timeMultiplier;

		if (currentTimeOfDay >= 1)
		{
			currentTimeOfDay = 0;
		}	
	}

	void UpdatePosition()
	{
		sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, -30, 0);
	}

}
