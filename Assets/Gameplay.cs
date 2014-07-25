using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

	public float HealthMax;
	public float HealthCurrent;
	public float Damage;
	public float Time;
	public string ShowHealth
	{
		get {return string.Format("{0} / {1}", HealthCurrent, HealthMax);}
	}
	public float UIWidth;
	public float HealthBarWidthInPercent
	{
		get 
		{	
			if (HealthCurrent <= 0f) return 0f;
			else return HealthCurrent / HealthMax * UIWidth;
		}
	}
	public float Healing;

	// Use this for initialization
	void Start () {
		InvokeRepeating("DamageChar", 0f, Time);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void DamageChar () {
		HealthCurrent -= Damage;
		HealthCurrent = Sanitize(HealthCurrent, HealthMax);
	}

	public void HealChar () {
		HealthCurrent += Healing;
		HealthCurrent = Sanitize(HealthCurrent, HealthMax);
	}
		
	public float Sanitize (float oldValue, float cap) {
		float newValue;
		newValue = Mathf.Clamp(oldValue, 0f, cap);
		return newValue;
	}
}
