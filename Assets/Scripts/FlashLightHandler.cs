using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightHandler : MonoBehaviour
{
	//Config parameter
	[SerializeField] float intensityDecay = .1f;
	[SerializeField] float angleDecay = .5f;
	[SerializeField] float minAngle = 20f;

	//Cache
	Light flashLight;
	float intensityAtStart;
	float angleAtStart;

	void Start()
	{
		flashLight = GetComponent<Light>();
		intensityAtStart = flashLight.intensity;
		angleAtStart = flashLight.spotAngle;
	}

	void Update()
	{
		DecayAngle();
		DecayIntensity();
	}

	private void DecayIntensity()
	{
		flashLight.intensity -= intensityDecay * Time.deltaTime;
	}

	private void DecayAngle()
	{
		if (flashLight.spotAngle <= minAngle)
		{ return; }
		else
		{
			flashLight.spotAngle -= angleDecay * Time.deltaTime;
		}
	}

	public void RestoreToFull()
	{
		flashLight.spotAngle = angleAtStart;
		flashLight.intensity = intensityAtStart;
	}
}
