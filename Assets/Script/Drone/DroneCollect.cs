using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DroneCollect : MonoBehaviour
{
    int resourceGain,totalNumberOfResource;
    public Text resourceGainText;
    public string pickUpTag;
    public double force; 
    public float timer;
    public double defaultPickUpDuration;
    public double affectRate;

    // Start is called before the first frame update

    void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag==pickUpTag)
        {
            //Here should make the drone to stop 
            gameObject.GetComponent<DroneMove>().isCollecting = true;
            timer+=Time.deltaTime;
            float seconds=timer % 60;

            if(seconds> (defaultPickUpDuration-force))
            {   
                double realDuration=defaultPickUpDuration-(force*affectRate);
                Debug.Log("Successful PickUp duration:"+realDuration);
                Destroy(other.gameObject);
                resourceGain++;
                resourceGainText.text= resourceGain +" / "+ totalNumberOfResource;
                timer=0;
                // make the drone move again to next waypoint
                gameObject.GetComponent<DroneMove>().isCollecting = false;
            }

        }
    }
     void Start()
    {
        GameObject[] resources;
        resources=GameObject.FindGameObjectsWithTag(pickUpTag);
        totalNumberOfResource=resources.Length;
        resourceGain=0;
        resourceGainText.text= resourceGain +" / "+ totalNumberOfResource;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

  
}
