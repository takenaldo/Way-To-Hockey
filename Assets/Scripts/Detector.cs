using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool connected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ENTER");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        connected = true;
        Debug.Log("STAY");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        connected = false;
        Debug.Log("EXIT");

    }
}
