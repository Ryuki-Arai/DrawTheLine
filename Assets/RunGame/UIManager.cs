using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider _slider;

    [SerializeField] GameObject _panel;

    // Start is called before the first frame update
    void Start()
    {
        _slider.GetComponent<Slider>();
        _slider.maxValue = GameSystem.Item.Count;
        _panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _slider.maxValue - GameSystem.Item.Count;
        if (GameSystem.Runner.OnGoal)
        {
            _panel.SetActive(true);
        }
    }

    public void OnReroad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
