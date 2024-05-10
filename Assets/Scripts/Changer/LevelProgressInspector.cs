using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressInspector : MonoBehaviour
{
	[SerializeField] private TMP_Text numericProgress;
	[SerializeField] private TMP_Text levelReward;
	[SerializeField] private TMP_Text levelNumber;
	[SerializeField] private Image lineProgress;
	private LevelStatsCreator levelStatsCreator;

	public void SetStartInfo(LevelStatsCreator levelStatsCreator)
	{
		this.levelStatsCreator = levelStatsCreator;
		levelStatsCreator.OnScoreChanged += SetInfo;
		levelNumber.text = $"LEVEL {levelStatsCreator.CurrentLevel} PROGRESS";
		levelReward.text = levelStatsCreator.Reward.ToString();
		SetInfo();
	}

	public void SetInfo()
	{
		numericProgress.text = $"{levelStatsCreator.Score}/{levelStatsCreator.MaxScore}";
		lineProgress.fillAmount = levelStatsCreator.CurrentProgress;
	}

	private void OnDestroy()
	{
		levelStatsCreator.OnScoreChanged -= SetInfo;
	}
}
