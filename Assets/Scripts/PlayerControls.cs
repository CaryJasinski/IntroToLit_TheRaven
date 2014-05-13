using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public GameObject Lightning;
	public int Timer = 15;
	private Light m_FlashLight;
	private Light m_lightning;
	public int randTimer;
	public float randWait;
	public bool tutorialOn = true;
	
	public AudioSource voiceOver;

	void Start () {
		Transform FlashLight = transform.FindChild("Main Camera").transform.FindChild("Flashlight");
		m_FlashLight = FlashLight.GetComponent<Light>();
		m_lightning = Lightning.GetComponent<Light>();
		voiceOver = GetComponent<AudioSource>();
		StartCoroutine(LoopLightning());
		StartCoroutine(EndGame());
		Screen.showCursor = false;
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			ToggleFlashLight();
			tutorialOn = false;
		}
		if(Input.GetKeyDown(KeyCode.Equals))
		{
			if(voiceOver.volume < 1 )
				voiceOver.volume += 0.05f;
		}
		if(Input.GetKeyDown(KeyCode.Minus))
		{
			if(voiceOver.volume > 0)
				voiceOver.volume -= 0.05f;
		}
		if(Input.GetKeyDown(KeyCode.M))
		{
			if(voiceOver.mute == true)
				voiceOver.mute = false;
			else
				voiceOver.mute = true;
		}
		if(Input.GetKeyDown(KeyCode.BackQuote))
		{
			if(Screen.showCursor == true)
				Screen.showCursor = false;
			else
				Screen.showCursor = true;
		}
		if(Timer > 0 )
		{
			Timer--;
			ToggleLightning();
		}
		else
		{
			m_lightning.enabled = false;
		}
	}
	
	IEnumerator LoopLightning()
	{
		randTimer = Random.Range(10, 40);
		Timer = randTimer;
		randWait = Random.Range(5, 20);
		yield return new WaitForSeconds(randWait);
		StartCoroutine(LoopLightning());
	}
	IEnumerator EndGame()
	{
		yield return new WaitForSeconds(295);
		Application.LoadLevel("StartMenu");
	}
	void ToggleLightning()
	{
		if(m_lightning.enabled == true)
			m_lightning.enabled = false;
		else 
			m_lightning.enabled = true;
	}
	void ToggleFlashLight()
	{
		if(m_FlashLight.enabled == true)
			m_FlashLight.enabled = false;
		else
			m_FlashLight.enabled = true;
	}
	void OnGUI()
	{
		if(tutorialOn)
		{
			GUI.TextArea(new Rect(Screen.width/2 - 100, Screen.height/2 + 100, 200, 25), "Press [F] to toggle the Flashlight");
		}
	}
}
