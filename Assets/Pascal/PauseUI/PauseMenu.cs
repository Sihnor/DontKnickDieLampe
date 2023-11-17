using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject UIToggel;

    private void Start()
    {
        UIToggel = gameObject.transform.GetChild(0).gameObject;
        UIToggel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.paused = !GameManager.Instance.paused;
        }
        if (GameManager.Instance.paused)
        {
            Pause();
        }
        if (!GameManager.Instance.paused)
        {
            UnPause();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        UIToggel.SetActive(true);
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        UIToggel.SetActive(false);
    }
    public void onReturn()
    {
        GameManager.Instance.paused = false;
    }
    public void onMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void onQuit()
    {
        Application.Quit();
    }
}
