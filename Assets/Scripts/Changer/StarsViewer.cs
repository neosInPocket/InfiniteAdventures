using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarsViewer : MonoBehaviour
{
	[SerializeField] private TMP_Text activeText;
	[SerializeField] private TMP_Text rewardedNumber;
	[SerializeField] private TMP_Text nextText;
	[SerializeField] private Button menuNavigator;
	[SerializeField] private Button nextNavigator;
	[SerializeField] private Image starsImage;
	[SerializeField] private Sprite winSprite;
	[SerializeField] private Sprite loseSprite;

	private void Start()
	{
		nextNavigator.onClick.AddListener(LoadNextNumber);
		menuNavigator.onClick.AddListener(LoadLevelNumber);
	}

	public void ViewStars(int rewarded)
	{
		gameObject.SetActive(true);

		if (rewarded > 0)
		{
			activeText.text = "COMPLETED!";
			nextText.text = "NEXT";
			starsImage.sprite = winSprite;
		}
		else
		{
			activeText.text = "YOU LOSE";
			nextText.text = "RETRY";
			starsImage.sprite = loseSprite;
		}

		rewardedNumber.text = rewarded.ToString();
	}

	public void LoadLevelNumber()
	{
		SceneManager.LoadScene("InfiniteStart");
	}

	public void LoadNextNumber()
	{
		SceneManager.LoadScene("InfiniteChanger");
	}
}
