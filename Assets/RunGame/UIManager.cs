using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        _slider.GetComponent<Slider>();
        _slider.maxValue = GameSystem.Item.Count;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _slider.maxValue - GameSystem.Item.Count;
    }
}
