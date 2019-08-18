using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class VbButton : MonoBehaviour, IVirtualButtonEventHandler
{
    //An array to reuse the same script and apply multiple virtual buttons without much modification
    public GameObject[] myButtons;

    public GameObject confirmPanel;
    public GameObject videoPlane;
    private bool isVideoPlaying = false;
    public VideoPlayer video;
    public static VbButton instance;

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
        for (int i = 0; i < myButtons.Length; i++)
        {
            //Have we pressed or released the button?
            myButtons[i].GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        }
        video = videoPlane.GetComponent<VideoPlayer>();
        video.playOnAwake = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.name == "VirtualButtonT3")
        {
            confirmPanel.SetActive(true);
        }

        //if (vb.name == "VirtualButtonT1Start" && isVideoPlaying == false)
        //{
        //    Debug.Log("xxxxxxxxxxxxxxxxxxxxxx");
        //    video.Play();
        //    isVideoPlaying = true;
        //}

        //if (vb.name == "VirtualButtonT1Stop" && isVideoPlaying == true)
        //{
        //    Debug.Log("yyyyyyyyyyyyyyyyyyyyyyyy");
        //    video.Stop();
        //    isVideoPlaying = false;
        //}

        if (vb.name == "VirtualButtonToggleRoof")
        {
            //vb.gameObject.SetActive(false);
            //myButtons[4].SetActive(true);
            HouseScript.instance.ToggleRoof();
        }
        
        if (vb.name == "VirtualButtonToggleSecondFloor")
        {
            //vb.gameObject.SetActive(false);
            //myButtons[6].SetActive(true);
            HouseScript.instance.ToggleSecondFloor();
        }
        
        if (vb.name == "VirtualButtonToggleDayNight")
        {
            //vb.gameObject.SetActive(false);
            //myButtons[8].SetActive(true);
            HouseScript.instance.ToggleDayNight();
        }

        if (vb.name == "VirtualButtonTogglePhotos")
        {
            //vb.gameObject.SetActive(false);
            //myButtons[8].SetActive(true);
            HouseScript.instance.TogglePhotos();
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }

}
