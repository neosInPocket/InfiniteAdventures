using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsController : MonoBehaviour
{
	[SerializeField] private List<Sprite> activated;
	[SerializeField] private Image effect;
	[SerializeField] private Image music;
	public MainTuner mainTuner;

	private void Start()
	{
		mainTuner = GameObject.FindWithTag("mainTuner").GetComponent<MainTuner>();

		music.sprite = activated[mainTuner.retentionScript.InfiniteMusic ? 1 : 0];
		effect.sprite = activated[mainTuner.retentionScript.InfiniteEffects ? 1 : 0];
	}

	public void SetMusicAppearance()
	{
		var enabled = mainTuner.TuneMusic();
		music.sprite = activated[enabled ? 1 : 0];
	}

	public void SetEffectsAppearance()
	{
		var enabled = mainTuner.TuneEffects();
		effect.sprite = activated[enabled ? 1 : 0];
	}
}
