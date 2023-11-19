using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void OnLevelWasLoaded(int _level)
    {
        if (_level == 2)
        {
            SpawnManager.Instance.SpawnPlayer();
            SpawnManager.Instance.SpawnKeys();
        }
    }
    #region MainMenu
    public void OnStart()
    {
        SceneManager.LoadScene(2);
    }
    public void OnSettings()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
    #endregion

    #region SettingsMenu
    public void OnBack()
    {
        SceneManager.LoadScene(0);
    }

    public void SetXSlider(Slider _slider)
    {
        _slider.value = GameManager.Instance.xSensitivity;
    }

    public void SetYSlider(Slider _slider)
    {
        _slider.value = GameManager.Instance.ySensitivity;
    }

    public void OnXSliderChange(float _value)
    {
        GameManager.Instance.xSensitivity = _value;
    }
    public void OnYSliderChange(float _value)
    {
        GameManager.Instance.ySensitivity = _value;
    }
    #endregion
}
