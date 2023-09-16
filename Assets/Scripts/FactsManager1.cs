using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FactsManager1 : MonoBehaviour
{
    public GameObject[] levels;
    public Sprite keySprite;

    public GameObject factObject;

    public GameObject dialogFact;

    public Sprite[] en_sprites;
    public Sprite[] ru_sprites;

    // Start is called before the first frame update
    void Start()
    {
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


    public void setFactSprite(Sprite factSprite)
    {
        factObject.GetComponent<Image>().sprite = factSprite;
    }

    public void setFact(int lvl)
    {
        int local_id = PlayerPrefs.GetInt(Helper.LANGUAGE, 0);

        if(local_id == 0)
            factObject.GetComponent<Image>().sprite = en_sprites[lvl -1];
        else
            factObject.GetComponent<Image>().sprite = ru_sprites[lvl - 1];
    }


    public void setFactSpriteWithLocale(Sprite[] factSprites)
    {
        int local_id = PlayerPrefs.GetInt(Helper.LANGUAGE, 0);
        if (local_id == 0)
            factObject.GetComponent<Image>().sprite = factSprites[local_id];

    }

    public void disable(GameObject go)
    {
        dialogFact.SetActive(false);
    }

    public void enable(int clickedLevel)
    {
//        if (gameObject.GetComponent<Image>().sprite != keySprite) {
            if(clickedLevel <= Helper.getUserLevel())
                dialogFact.SetActive(true);
 //       }
    }
}
