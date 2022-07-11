using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider _slider;

    [SerializeField] GameObject _pausePanel;
    [SerializeField] GameObject _crearPanel;

    [SerializeField] string _title;
     // Start is called before the first frame update
    void Start()
    {
        _slider.GetComponent<Slider>();
        _slider.maxValue = GameSystem.Item.Count;
        _pausePanel.SetActive(false);
        _crearPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _slider.maxValue - GameSystem.Item.Count;
        if (GameSystem.Runner.OnGoal)
        {
            _crearPanel.SetActive(true);
        }
    }

    public void OnPause()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
    }

    public void OnRestart()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
    }

    public void OnReroad()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_title);
    }
}
