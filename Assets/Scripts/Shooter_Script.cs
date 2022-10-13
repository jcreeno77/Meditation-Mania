using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Script : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject mainCamera;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(mainCamera.GetComponent<breathScript>().breathReleased == true)
        {
            mainCamera.GetComponent<breathScript>().breathReleased = false;
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.transform.rotation = transform.rotation;
            tempBullet.transform.position = transform.position;
            tempBullet.transform.SetParent(null);
        }
    }
}
