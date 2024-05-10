using System.Collections;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
	[SerializeField] private MovingBalloon prefab;
	[SerializeField] private Vector2 differentTimes;
	[SerializeField] private DeviceEdges deviceEdges;
	[SerializeField] private RetentionScript retentionScript;

	public void StartBalloonSpawn(bool value)
	{
		if (value)
		{
			StartCoroutine(BalloonSpawn());
		}
		else
		{
			StopAllCoroutines();
		}
	}

	public IEnumerator BalloonSpawn()
	{
		var spawnPosition = new Vector2(0, deviceEdges.Size.y);
		var instance = Instantiate(prefab, spawnPosition, Quaternion.identity, transform);
		instance.SetAllInformation(deviceEdges);
		instance.source.enabled = retentionScript.InfiniteEffects;
		yield return new WaitForSeconds(Random.Range(differentTimes.x, differentTimes.y));
		StartCoroutine(BalloonSpawn());
	}
}
