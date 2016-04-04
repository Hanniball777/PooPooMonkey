using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour {
    public Transform spawnLocation;
    public GameObject pooPoo;
    public GameObject pooPooClone;
    public Transform character;
    public float maxChargePower;
    public float chargeRate;
    public Text chargePowerText; 

    private float triggerDownTime;
    private float chargePower;
    private float chargeTime;
    private float tempChargePower;
    private float tempChargeTime;

    private new Rigidbody rigidbody;
    private Vector3 throwDirection;
    
    void Start()
    {
        ResetValues();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            triggerDownTime = Time.time;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            chargeTime = Time.time - triggerDownTime;
            chargePower = (chargeRate * chargeTime);
            if (chargePower >= maxChargePower)
            {
                chargePower = maxChargePower;
            }
            throwDirection = character.GetComponent<Camera>().transform.forward;
            spawnPooPoo(chargePower);

            ResetValues();
            SetChargePowerText();
        }

        if (triggerDownTime != 0f)
        {
            tempChargeTime = Time.time - triggerDownTime;
            tempChargePower = (chargeRate * tempChargeTime);
            if (tempChargePower >= maxChargePower)
            {
                tempChargePower = maxChargePower;
            }
            SetChargePowerText();
            tempChargePower = 0f;
        }
    }


    void spawnPooPoo(float chargePower)
    {
        spawnLocation.transform.position.Set(character.position.x, character.position.y, character.position.z);
        pooPooClone = Instantiate(pooPoo, spawnLocation.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        rigidbody = pooPooClone.GetComponent<Rigidbody>();
        rigidbody.AddForce(throwDirection * chargePower);
    }

    void ResetValues()
    {
        triggerDownTime = 0f;
        chargeTime = 0f;
        tempChargeTime = 0f;
        tempChargePower = 0f;
    }

    void SetChargePowerText()
    {
        tempChargePower = Mathf.Floor(tempChargePower);
        chargePowerText.text = "Power: " + tempChargePower.ToString();
    }
}
