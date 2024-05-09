using UnityEngine;

public class RetentionScript : MonoBehaviour
{
	[SerializeField] private int infiniteProgress;
	[SerializeField] private int infiniteDiamonds;
	[SerializeField] private int infiniteFirst;
	[SerializeField] private int infiniteSecond;
	[SerializeField] private int infiniteEffects;
	[SerializeField] private int infiniteMusic;
	[SerializeField] private int startDiscipline;
	[SerializeField] private bool clearStartPreferences;

	public int InfiniteProgress
	{
		get => infiniteProgress;
		set => infiniteProgress = value;
	}
	public int InfiniteDiamonds
	{
		get => infiniteDiamonds;
		set => infiniteDiamonds = value;
	}
	public bool InfiniteFirst
	{
		get => infiniteFirst == 1;
		set => infiniteFirst = value ? 1 : 0;
	}
	public bool InfiniteSecond
	{
		get => infiniteSecond == 1;
		set => infiniteSecond = value ? 1 : 0;
	}
	public bool InfiniteEffects
	{
		get => infiniteEffects == 1;
		set => infiniteEffects = value ? 1 : 0;
	}
	public bool InfiniteMusic
	{
		get => infiniteMusic == 1;
		set => infiniteMusic = value ? 1 : 0;
	}
	public bool StartDiscipline
	{
		get => startDiscipline == 1;
		set => startDiscipline = value ? 1 : 0;
	}

	private void Awake()
	{
		StartAction(clearStartPreferences);
	}

	public void StartAction(bool clearPreferences)
	{
		if (clearPreferences)
		{
			Retention();
		}
		else
		{
			SerializeLoad();
		}
	}

	public void SerializeLoad()
	{
		infiniteProgress = PlayerPrefs.GetInt(nameof(infiniteProgress), infiniteProgress);
		infiniteDiamonds = PlayerPrefs.GetInt(nameof(infiniteDiamonds), infiniteDiamonds);
		infiniteFirst = PlayerPrefs.GetInt(nameof(infiniteFirst), infiniteFirst);
		infiniteSecond = PlayerPrefs.GetInt(nameof(infiniteSecond), infiniteSecond);
		infiniteEffects = PlayerPrefs.GetInt(nameof(infiniteEffects), infiniteEffects);
		infiniteMusic = PlayerPrefs.GetInt(nameof(infiniteMusic), infiniteMusic);
		startDiscipline = PlayerPrefs.GetInt(nameof(startDiscipline), startDiscipline);
	}

	public void Retention()
	{
		PlayerPrefs.SetInt(nameof(infiniteProgress), infiniteProgress);
		PlayerPrefs.SetInt(nameof(infiniteDiamonds), infiniteDiamonds);
		PlayerPrefs.SetInt(nameof(infiniteFirst), infiniteFirst);
		PlayerPrefs.SetInt(nameof(infiniteSecond), infiniteSecond);
		PlayerPrefs.SetInt(nameof(infiniteEffects), infiniteEffects);
		PlayerPrefs.SetInt(nameof(infiniteMusic), infiniteMusic);
		PlayerPrefs.SetInt(nameof(startDiscipline), startDiscipline);
	}
}
