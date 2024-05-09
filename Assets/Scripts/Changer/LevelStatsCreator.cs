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
		return 10;
	}

	public int CreateLevelMaxProgress(int level)
	{
		return 10;
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
