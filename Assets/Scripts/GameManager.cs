using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //    public GameObject[] detectors;
    public List<GameObject> detectors;
    public GameObject holder;
    public float margin = 0.1f;
    public bool gameFinished = false;
    public int current_level = 1;
    public static int LANGUAGE_EN = 0;
    public static int LANGUAGE_RU = 1;
    public int levels = 9;

    public GameObject dialogFact;
    public Sprite[] factSpriteForLevel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
       // setDetectors();
        isGameFinished();
        Debug.Log("CURREnt lvl " + current_level);

        List<GameObject> ds = new List<GameObject>(GameObject.FindGameObjectsWithTag("detector"));

        foreach (GameObject item in ds)
        {
            item.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }

    }


    // Update is called once per frame
    void Update()
    {

        if (gameFinished && !dialogFact.activeSelf)
        {
            dialogFact.SetActive(true);
            int local_id = PlayerPrefs.GetInt(Helper.LANGUAGE, 0);
            dialogFact.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = factSpriteForLevel[local_id];

            if(current_level+1 > Helper.getUserLevel())
            {
                Helper.updateLevel();
            }

        }

    }

    private void setDetectors()
    {
        detectors = new List<GameObject>( GameObject.FindGameObjectsWithTag("detector"));
/*        for (int i = 0; i < holder.transform.childCount; i++)
        {
            GameObject piece = holder.transform.GetChild(i).transform.gameObject;

            for (int j = 0; j < piece.transform.childCount; j++)
            {
                GameObject detector = holder.transform.GetChild(i).transform.gameObject; ;
                detectors.Add(detector);
            }

        }*/

        Debug.Log(detectors.Count + " detectors Found");

    }


    public bool isGameFinished()
    {
        detectors = new List<GameObject>(GameObject.FindGameObjectsWithTag("detector"));

        for (int i = 0; i < detectors.Count; i++)
        {
            if (!detectors[i].activeInHierarchy)
                continue;
            bool no_near_obj = true;
            for (int j = 0; j < detectors.Count; j++)
            {
                GameObject detector1 = detectors[i];
                GameObject detector2 = detectors[j];

                if (i == j)
                    continue;

                if (detector1.transform.parent.gameObject == detector2.transform.parent.gameObject)
                    continue;

                if (!detector1.activeInHierarchy || !detector2.activeInHierarchy)
                    continue;

                float distance = Vector2.Distance(detector1.transform.position, detector2.transform.position);
//                Debug.Log("Comparing:  "+ detector1.transform.parent.name+"/" + detectors[i].name + " to  "+ detectors[j].transform.parent.name + "/"+ detectors[j].name + " : " + distance);
                //                Debug.Log("To: " + detectors[j].transform.position);
//                Debug.Log("Distance: "+distance);
                if(distance < margin)
                {
                    no_near_obj = false;
  //                  Debug.Log("near found");
                }

            }

            if (no_near_obj)
            {
    //            Debug.Log("Not found for  " +detectors[i].name);

      //          Debug.Log("NO Game Over");
                return false;
            }
        }
        return true;

    }

}
