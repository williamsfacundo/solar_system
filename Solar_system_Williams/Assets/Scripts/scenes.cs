using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes : MonoBehaviour
{   
    public void ChangeSceneGame() 
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void ChangeSceneMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
