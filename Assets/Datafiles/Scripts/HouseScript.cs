using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    public GameObject theRoof;
    public GameObject [] secondFloor;
    public GameObject [] theLights;
    public GameObject directionalLight;
    public GameObject[] photos;

    public static HouseScript instance;

    private bool daytime    = true;
    private int  photoIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ToggleRoof()
    {
        if (theRoof.activeInHierarchy)
        {
            theRoof.SetActive(false);
        }
        else
        {
            theRoof.SetActive(true);
        }
    }

    public void ToggleSecondFloor()
    {
        //ToggleRoof();
        for (int i = 0; i < secondFloor.Length; i++)
        {
            if (secondFloor[i].activeInHierarchy)
            {
                secondFloor[i].SetActive(false);
            }
            else
            {
                secondFloor[i].SetActive(true);
            }
        }
    }

    public void ToggleDayNight()
    {
        if (daytime)
        {
            directionalLight.GetComponent<Light>().color = new Color32(34,48,178,255);
            for (int i = 0; i < theLights.Length; i++)
            {
                if (theLights[i].activeInHierarchy)
                { 
                    theLights[i].SetActive(true);
                }
            }
            daytime = false;
        }
        else
        {
            directionalLight.GetComponent<Light>().color = new Color32(255, 255, 255, 255);
            directionalLight.SetActive(true);
            for (int i = 0; i < theLights.Length; i++)
            {
                if (theLights[i].activeInHierarchy)
                {
                    theLights[i].SetActive(false);
                }
            }
            daytime = true;
        }
    }

    public void TogglePhotos()
    {
        //Initially, make all pics invisible
        for (int i = 0; i < photos.Length; i++)
        {
            photos[i].SetActive(false);
        }

        //Make only current pic visible
        if (photoIndex < photos.Length)
        {
            photos[photoIndex].SetActive(true);
            photoIndex += 1;
        }
        else
        {
            photoIndex = 0;
        }
    }
}
