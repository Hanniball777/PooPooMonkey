using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SunController : MonoBehaviour {

    public float sunSpeed;
    public Text gameTimeText; 

    private float lastUpdate = 0;       //last value of Time.time
    private System.DateTime clock;     

    public delegate void TimeHasChangedHandler(TimeSpan timeSpan);
    public event TimeHasChangedHandler TimeHasChanged;

    protected void OnTimeHasChanged(TimeSpan timeSpan)
    {
        if (TimeHasChanged != null)
        {
            TimeHasChanged(timeSpan);
        }
    }
    // Use this for initialization
    void Start () {
        clock = new System.DateTime();
        SetTimeTo(8, 0, 0);
        UpdateGameTimeText();
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, sunSpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);

        if (Mathf.Floor(Time.time) > lastUpdate)
        {
            clock = clock.AddMinutes((Mathf.Floor(Time.time) - lastUpdate));
            lastUpdate = Mathf.Floor(Time.time);
            UpdateGameTimeText();
        }
	}

    private void SetTimeTo(int hour, int minute, int second)
    {
        clock = new System.DateTime(clock.Year, clock.Month, clock.Day,
            hour, minute, second);
    }

    public void SubstractTimeOnHit(TimeSpan substractTime)
    {
        DateTime substractedDateTime = new DateTime();
        substractedDateTime = clock.Subtract(substractTime);
        clock = substractedDateTime;
        UpdateGameTimeText();
    }

    public void SetSunPositonBack(int substractTime)
    {
        transform.RotateAround(Vector3.zero, Vector3.left, substractTime);
    }

    private void UpdateGameTimeText()
    {
        gameTimeText.text = "Time: " + clock.ToShortTimeString();
    }

}
