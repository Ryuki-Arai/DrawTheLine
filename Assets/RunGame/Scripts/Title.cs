using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] string scene;
    public void OnStart()
    {
        SceneManager.LoadScene(scene);
    }
}
