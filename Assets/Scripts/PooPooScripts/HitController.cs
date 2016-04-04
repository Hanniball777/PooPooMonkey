using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitController : MonoBehaviour {
    public Text hitCounterText;
    public new string CompareTag;

    private int hitCounter;
	// Use this for initialization
	void Start () {
        hitCounter = 0;
        SetCounterText();
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
        }
    }

    void SetCounterText()
    {
        hitCounterText.text = "Counter: " + hitCounter.ToString();
    }
}
