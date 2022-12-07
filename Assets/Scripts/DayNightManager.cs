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
	[Space(10)]
	public float maxIntensity = 2f;
	public float minIntensity = 0f;
	public float minPoint = -0.2f;

	void Start()
	{			
		InvokeRepeating("UpdateCycle", updateRateInSeconds, updateRateInSeconds);
	}
	void UpdateCycle()
	{
		UpdatePosition();
		UpdateFX();

		currentTimeOfDay += ((Time.deltaTime + updateRateInSeconds) / secondsInFullDay) * timeMultiplier;

		if (currentTimeOfDay >= 1)
		{
			currentTimeOfDay = 0;
		}
	}

	void UpdatePosition()
	{
		sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 100, 170, 0);
	}

	void UpdateFX()
	{
		float tRange = 1 - minPoint;
		float dot = Mathf.Clamp01((Vector3.Dot(sun.transform.forward, Vector3.down) - minPoint) / tRange);
		float i = ((maxIntensity - minIntensity) * dot) + minIntensity;
		sun.intensity = i;		
	}
}
