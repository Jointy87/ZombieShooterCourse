using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour
{
	//Config parameters
	[SerializeField] float opacityDecay = .2f;

	//Cache
	Image slash;

	//States
	bool isDamaged;

	void Start()
	{
		slash = GetComponentInChildren<Image>();
	}

	void Update()
	{
		if(isDamaged)
		{
			DecayBloodOpacity();
		}
	}

	public void DisplayBlood()
	{
		var imageColor = slash.color;
		imageColor.a = 1;
		slash.color = imageColor;

		slash.enabled = true;
		isDamaged = true;
	}

	private void DecayBloodOpacity()
	{
		var imageColor = slash.color;
		imageColor.a -= opacityDecay * Time.deltaTime;
		slash.color = imageColor;

		if (imageColor.a <= 0)
		{
			slash.enabled = false;
			isDamaged = false;
		}
	}
}
