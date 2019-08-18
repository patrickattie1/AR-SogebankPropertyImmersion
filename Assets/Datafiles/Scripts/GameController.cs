using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
    public void ChangeScene(string name)
    {
        //LoadSceneAsync give a smoother load
        SceneManager.LoadSceneAsync(name);
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void HideObject(string objectName)
        {
        GameObject.Find(objectName).SetActive(false);
        }
}
