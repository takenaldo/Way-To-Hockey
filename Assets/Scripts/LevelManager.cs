using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public Sprite keySprite;

    public int test_level = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (test_level > 0)
            PlayerPrefs.SetInt(Helper.USER_LEVEL, test_level);
        Debug.Log("USER LEVEL " + Helper.getUserLevel());
        for (int i = 0; i < 9; i++)
        {
            if(i+1 > Helper.getUserLevel())
            {
                levels[i].GetComponent<Image>().sprite = keySprite;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
