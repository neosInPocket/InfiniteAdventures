using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsViewer : MonoBehaviour
{
	public void LoadLevelNumber()
	{
		SceneManager.LoadScene("InfiniteStart");
	}

	public void LoadNextNumber()
	{
		SceneManager.LoadScene("InfiniteChanger");
	}
}
