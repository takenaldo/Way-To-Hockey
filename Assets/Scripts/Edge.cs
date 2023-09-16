using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    // the rate of degrees this edge will rotate while clicked
    public float rotationDegrees = 180;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
    //        rotateEdge();
        }
    }

    public void rotateEdge()
    {
        Vector3 new_rotation = new Vector3( transform.rotation.x, transform.rotation.y, transform.rotation.z );
        new_rotation.z += rotationDegrees;

        Debug.Log("rot " + new_rotation.z);

        transform.Rotate(new_rotation);

         GameManager.instance.gameFinished = GameManager.instance.isGameFinished();


    }


    private void OnMouseDown()
    {
        Debug.Log("ROTATE");
        rotateEdge();
    }

}
