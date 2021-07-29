using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_scene : MonoBehaviour
{
    public void change_scene(string Scene_name)
    {
        SceneManager.LoadScene(Scene_name);
    }
}
