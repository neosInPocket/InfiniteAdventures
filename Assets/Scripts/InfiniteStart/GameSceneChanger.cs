using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneChanger : MonoBehaviour
{
    public void MainChanger()
    {
        SceneManager.LoadScene("InfiniteChanger");
    }
}
