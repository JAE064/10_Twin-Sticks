using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording;

    private float initialFixedDelta;
    private bool isPaused;
	
    void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);
        isPaused = false;
        initialFixedDelta = Time.fixedDeltaTime;
    }

	// Update is called once per frame
	void Update ()
    {
        recordGame();
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    private void recordGame()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }
    }

    void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = initialFixedDelta;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
            isPaused = true;
        }
        
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}
