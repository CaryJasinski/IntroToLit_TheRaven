using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public Texture StartMenuTexture;

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), StartMenuTexture);
		if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 + 150, 200, 100), "StartGame"))
		{
			Application.LoadLevel("Game");
		}
	}
}
