using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] Transform _goal;
    [SerializeField] GameObject _pausePanel;
    [SerializeField] GameObject _crearPanel;

    [SerializeField] string _title;
     // Start is called before the first frame update
    void Start()
    {
        _slider.GetComponent<Slider>();
        _slider.maxValue = Vector2.Distance(GameSystem.Runner[0].transform.position,_goal.position);
        _pausePanel.SetActive(false);
        _crearPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSystem.Runner.Count > 0)_slider.value = _slider.maxValue - Vector2.Distance(GameSystem.Runner[0].transform.position, _goal.position);
        _crearPanel.SetActive(GoalCheck());
    }

    bool GoalCheck()
    {
        foreach(var go in GameSystem.Runner)
        {
            if (!go.OnGoal)
            {
                return false;
            }
        }
        return true;
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
        GameSystem.Instance.RemoveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackTitle()
    {
        Time.timeScale = 1f;
        if (GameSystem.Runner.Count <= 0) GameSystem.Instance.LevelUP();
        GameSystem.Instance.RemoveData();
        SceneManager.LoadScene(_title);
    }
}
