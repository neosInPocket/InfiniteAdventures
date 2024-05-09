using UnityEngine;

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

	private void Start()
	{
		stats = new LevelStatsCreator(retentionScript.InfiniteProgress);
		levelProgressInspector.SetStartInfo(stats);

		startDiscipline.StartDisciplineRoute(OnDisciplineCompleted, retentionScript);
	}

	public void OnDisciplineCompleted()
	{

	}
}
