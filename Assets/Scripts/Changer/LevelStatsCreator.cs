using System;
using UnityEngine;

public class LevelStatsCreator
{
	public float CurrentProgress => (float)Score / (float)MaxScore;
	public readonly int CurrentLevel;
	public readonly int Reward;
	public readonly int MaxScore;
	public int Score { get; private set; }
	public Action OnMaxScoreReached { get; set; }
	public Action OnScoreChanged { get; set; }

	public LevelStatsCreator(int level)
	{
		CurrentLevel = level;
		Reward = CreateLevelReward(level);
		MaxScore = CreateLevelMaxProgress(level);
	}

	public int CreateLevelReward(int level)
	{
		return (int)(10f * Mathf.Sqrt(level + 1)); ;
	}

	public int CreateLevelMaxProgress(int level)
	{
		return (int)(3f * Mathf.Sqrt(level + 1)); ;
	}

	public void IncreaseScore(int amount)
	{
		Score += amount;

		if (Score >= MaxScore)
		{
			Score = MaxScore;
			OnMaxScoreReached?.Invoke();
		}

		OnScoreChanged?.Invoke();
	}
}
