using System.Net;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class LevelNavigator : MonoBehaviour
{
	[SerializeField] private MovingDagger movingDagger;
	[SerializeField] private BalloonSpawner balloonSpawner;
	[SerializeField] StartDiscipline startDiscipline;
	[SerializeField] private StarsViewer starsViewer;
	[SerializeField] private LevelStatsCreator stats;
	[SerializeField] private IClickStartGame clickStartGame;
	[SerializeField] private LevelProgressInspector levelProgressInspector;
	[SerializeField] private RetentionScript retentionScript;

	private void Awake()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}

	private void Start()
	{
		stats = new LevelStatsCreator(retentionScript.InfiniteProgress);
		levelProgressInspector.SetStartInfo(stats);

		startDiscipline.StartDisciplineRoute(OnDisciplineCompleted, retentionScript);
	}

	public void OnDisciplineCompleted()
	{
		clickStartGame.StartWaitForGame(OnWaitCompleted);
	}

	public void OnWaitCompleted()
	{
		movingDagger.OnePoint += OnePoint;
		movingDagger.EndPoint += EndPoint;
		stats.OnMaxScoreReached += OnMaxScoreReached;

		movingDagger.ActivateDagger(true);
		balloonSpawner.StartBalloonSpawn(true);
	}

	public void OnePoint()
	{
		stats.IncreaseScore(1);
	}

	public void EndPoint()
	{
		movingDagger.OnePoint -= OnePoint;
		movingDagger.EndPoint -= EndPoint;
		stats.OnMaxScoreReached -= OnMaxScoreReached;
		movingDagger.ActivateDagger(false);
		balloonSpawner.StartBalloonSpawn(false);

		starsViewer.ViewStars(0);
	}

	public void OnMaxScoreReached()
	{
		movingDagger.OnePoint -= OnePoint;
		movingDagger.EndPoint -= EndPoint;
		stats.OnMaxScoreReached -= OnMaxScoreReached;
		movingDagger.ActivateDagger(false);
		balloonSpawner.StartBalloonSpawn(false);

		starsViewer.ViewStars(stats.Reward);
		retentionScript.InfiniteProgress++;
		retentionScript.InfiniteDiamonds += stats.Reward;
		retentionScript.Retention();
	}

	private void OnDestroy()
	{
		movingDagger.OnePoint -= OnePoint;
		movingDagger.EndPoint -= EndPoint;
		stats.OnMaxScoreReached -= OnMaxScoreReached;
	}
}
