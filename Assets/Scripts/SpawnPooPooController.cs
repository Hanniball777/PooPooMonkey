using UnityEngine;
using System.Collections;

public class SpawnPooPooController : MonoBehaviour {
    public Transform spawnLocation;
    public GameObject pooPoo;
    public GameObject pooPooClone;
    public Transform character;
    public float maxThrowPower;
    public float chargeRate;


    private float throwPower;

    private float triggerDownTime;
    private float chargeTime;

    private new Rigidbody rigidbody;
    private Vector3 throwDirection;
    
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            triggerDownTime = Time.time;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            chargeTime = Time.time - triggerDownTime;
            throwPower = (chargeRate * chargeTime);
            if (throwPower >= maxThrowPower)
            {
                throwPower = maxThrowPower;
            }
            throwDirection = character.GetComponent<Camera>().transform.forward;
            spawnPooPoo(throwPower);
            triggerDownTime = 0f;
            chargeTime = 0f;
        }
    }


    void spawnPooPoo(float throwPower)
    {
        spawnLocation.transform.position.Set(character.position.x, character.position.y, character.position.z);
        pooPooClone = Instantiate(pooPoo, spawnLocation.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        rigidbody = pooPooClone.GetComponent<Rigidbody>();
        rigidbody.AddForce(throwDirection * throwPower);
    }
}
