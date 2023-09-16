using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeEdge : MonoBehaviour
{
    // the rate of degrees this edge will rotate while clicked
    public float rotationDegrees = 180;

    public int initialQuarter = 2;

    private int activeQuarter = 2;


    public GameObject[] qt;

    // Start is called before the first frame update
    void Start()
    {
        activeQuarter = initialQuarter;
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetMouseButtonDown(0))
        {
    //        rotateEdge();
        }*/
    }

    public void rotateEdge()
    {
        /*Vector3 new_rotation = new Vector3( transform.rotation.x, transform.rotation.y, transform.rotation.z );
        new_rotation.z += rotationDegrees;
        transform.Rotate(new_rotation);

*/


        activeQuarter++;

        if(activeQuarter == 4)
        {
            activeQuarter = 0;
        }

        Debug.Log("==--==> " + activeQuarter);
        for (int i = 0; i < qt.Length; i++)
        {
            if(i == activeQuarter) {
                qt[activeQuarter].SetActive(true);
            }
            else
                qt[i].SetActive(false);
        }



        GameManager.instance.gameFinished = GameManager.instance.isGameFinished();

    }


    private void OnMouseDown()
    {
        Debug.Log("COMPOSITE ROTATE");
        rotateEdge();
    }

}
