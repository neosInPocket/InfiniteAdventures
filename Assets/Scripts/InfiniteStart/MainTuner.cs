using System.Linq;
using UnityEngine;

public class MainTuner : MonoBehaviour
{
	[SerializeField] public AudioSource tunerHolder;
	[SerializeField] public RetentionScript retentionScript;

	private void Awake()
	{
		var tuner = GameObject.FindObjectOfType<MainTuner>();

		MainTuner[] tuners = FindObjectsByType<MainTuner>(sortMode: FindObjectsSortMode.None);
		var findLength = tuners.Length == 1;

		if (findLength)
		{
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			var foundTuner = tuners.FirstOrDefault(x => x.gameObject.scene.name != "DontDestroyOnLoad");
			Destroy(foundTuner.gameObject);
		}
	}

	private void Start()
	{
		tunerHolder.volume = retentionScript.InfiniteMusic ? 1f : 0f;
	}

	public bool TuneMusic()
	{
		bool alreadyEnabled = tunerHolder.volume > 0f;
		if (alreadyEnabled)
		{
			tunerHolder.volume = 0f;
		}
		else
		{
			tunerHolder.volume = 1f;
		}

		retentionScript.InfiniteMusic = !alreadyEnabled;
		retentionScript.Retention();

		return !alreadyEnabled;
	}

	public bool TuneEffects()
	{
		bool alreadyEnabled = retentionScript.InfiniteEffects;

		retentionScript.InfiniteEffects = !alreadyEnabled;
		retentionScript.Retention();

		return !alreadyEnabled;
	}
}
