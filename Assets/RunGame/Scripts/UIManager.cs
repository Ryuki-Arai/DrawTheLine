using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] TMP_Text _text;
    [SerializeField] Transform _goal;
    [SerializeField] GameObject _pausePanel;
    [SerializeField] GameObject _crearPanel;

    [SerializeField] string _title;
     // Start is called before the first frame update
    void Start()
    {
        _slider.GetComponent<Slider>();
        _text.GetComponent<TMP_Text>();
        _slider.maxValue = Vector2.Distance(GameSystem.ChildRunner[0].transform.position,_goal.position);
        _pausePanel.SetActive(false);
        _crearPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSystem.Runner)_slider.value = _slider.maxValue - Vector2.Distance(GameSystem.Runner.transform.position, _goal.position);
        _text.text = $"${ GameSystem.Instance.Coin.ToString("N0")}";
        _crearPanel.SetActive(GoalCheck());
    }

    bool GoalCheck()
    {
        foreach(var go in GameSystem.ChildRunner)
        {
            if (!go.OnGoal)
            {
                return false && GameSystem.Runner.OnGoal;
            }
        }
        return true && GameSystem.Runner.OnGoal;
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
        if (GameSystem.ChildRunner.Count <= 0) GameSystem.Instance.LevelUP();
        GameSystem.Instance.RemoveData();
        SceneManager.LoadScene(_title);
    }
}
