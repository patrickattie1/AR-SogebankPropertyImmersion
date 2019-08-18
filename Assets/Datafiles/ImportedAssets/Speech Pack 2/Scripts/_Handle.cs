using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using UnityEngine.Video;
 
//Custom 8


public partial class Wit3D : MonoBehaviour {

	public Text myHandleTextBox;
    private bool actionFound;
	private string theScene;
  

	void showMsg(){
        myHandleTextBox.text = "Désolé, action non disponible pour ce modèle!";
	}

	void Handle (string jsonString) {
 
		if (jsonString != null) {

			RootObject theAction = new RootObject ();
			JsonConvert.PopulateObject (jsonString, theAction);
			//option 1
            if (theAction.entities.jouer != null) {
  					if(theAction._text.Contains("jouer"))
                    {
                    VbButton.instance.video.Play();
                    }
                    else
                    {
                        showMsg();
                    }
 					actionFound = true;
 			}

			//option 2
            if (theAction.entities.arreter != null) {
 					if (theAction._text.Contains ("arreter") || theAction._text.Contains("arrêter"))
                    {
                    VbButton.instance.video.Stop();
                }
                    else
                    {
                        showMsg();
                    }
 					actionFound = true;
 			}

            if (theAction.entities.enlever != null || theAction.entities.replacer != null) {
                     if (theAction._text.Contains ("enlever") || theAction._text.Contains("replacer")) {
                         if (theAction._text.Contains("toit")){
                            HouseScript.instance.ToggleRoof();
                         }else{
                            showMsg();
                         }
 					}
 					actionFound = true;
 			}

 
            if (theAction.entities.montrer != null || theAction.entities.cacher != null) {
                     if (theAction._text.Contains("deuxième étage")){
                            HouseScript.instance.ToggleSecondFloor();
                            Debug.Log("Toggling Second Floor");
                     }
                actionFound = true;
             }
 

            if (theAction.entities.jour != null) {
                if (theAction._text.Contains("jour"))
                {
                    HouseScript.instance.ToggleDayNight();
                    Debug.Log("Toggling Day Night");
                }
                actionFound = true;
            }


            if (theAction.entities.nuit != null) {
                if (theAction._text.Contains("nuit")) {
                    HouseScript.instance.ToggleDayNight();
                    Debug.Log("Toggling Day Night");
                }
                actionFound = true;
            }
 
            if (!actionFound) {
				myHandleTextBox.text = "Requête inconnue, posez la question différemment.";
			}

 		}//END OF IF

 	}//END OF HANDLE VOID

}//END OF CLASS


//Custom 9
public class Play
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Stop
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Remove
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Replace
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Show
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Hide
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class DayTime
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class NightTime
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Jouer {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}
 
public class Arreter {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Enlever {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Replacer {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Montrer {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Cacher {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Jour {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Nuit {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Entities {
    //In English
    //public List<Play> play { get; set; }
	//public List<Stop> stop { get; set; }
	//public List<Remove> remove { get; set; }
	//public List<Replace> replace { get; set; }
    //public List<Show> show { get; set; }
    //public List<Hide> hide { get; set; }
    //public List<Daytime> daytime { get; set; }
    //public List<Nighttime> nighttime { get; set; }
    //In French
    public List<Jouer> jouer { get; set; }
    public List<Arreter> arreter { get; set; }
    public List<Enlever> enlever { get; set; }
    public List<Replacer> replacer { get; set; }
    public List<Montrer> montrer { get; set; }
    public List<Cacher> cacher { get; set; }
    public List<Jour> jour { get; set; }
    public List<Nuit> nuit { get; set; }
}

public class RootObject {
	public string _text { get; set; }
	public Entities entities { get; set; }
	public string msg_id { get; set; }
}