using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public GameObject Lightning;
	public int Timer = 15;
	private Light m_FlashLight;
	private Light m_lightning;
	public int randTimer;
	public float randWait;
	void Start () {
		Transform FlashLight = transform.FindChild("FlashLight");
		m_FlashLight = FlashLight.GetComponent<Light>();
		m_lightning = Lightning.GetComponent<Light>();
		StartCoroutine(LoopLightning());
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.F))
			ToggleFlashLight();
	}

	void FixedUpdate ()
	{
		if(Timer > 0)
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
}
