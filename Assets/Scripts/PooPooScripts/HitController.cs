using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HitController : MonoBehaviour {
    public Text hitCounterText;
    public new string CompareTag;
    public GameObject sunInput;
    public int hitResetTimeValueInMinutes;

    private SunController sun;
    private int hitCounter;
    TimeSpan hitResetTime;

    // Use this for initialization
    void Start () {
        hitCounter = 0;
        hitResetTime = new TimeSpan(0, hitResetTimeValueInMinutes,0);
        SetCounterText();

        sun = (SunController)GameObject.Find(sunInput.name).GetComponent("SunController");
        sun.TimeHasChanged += new SunController.TimeHasChangedHandler(TimeHasChanged);
	}

    void TimeHasChanged(TimeSpan timeSpan)
    {
        sun.SubstractTimeOnHit(timeSpan);
        sun.SetSunPositonBack(timeSpan.Minutes);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(CompareTag))
        {
            //TempImp
            this.gameObject.SetActive(false);
            hitCounter++;
            SetCounterText();
            TimeHasChanged(hitResetTime);
        }
    }

    void SetCounterText()
    {
        hitCounterText.text = "Points: " + hitCounter.ToString();
    }
}
