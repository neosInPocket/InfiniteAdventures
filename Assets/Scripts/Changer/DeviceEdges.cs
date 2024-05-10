using UnityEngine;

public class DeviceEdges : MonoBehaviour
{
	[SerializeField] private float topCrossing;
	[SerializeField] private SingleEdge[] allEdges;
	public Vector2 Size;

	private void Awake()
	{
		Size = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
		SetAllEdges();
	}

	public void SetAllEdges()
	{
		var size = allEdges[0].Size;

		allEdges[0].transform.position = new Vector2(-Size.x - size / 2, 0);
		allEdges[0].SetSize(new Vector2(size, 2 * Size.y));

		allEdges[1].transform.position = new Vector2(Size.x + size / 2, 0);
		allEdges[1].SetSize(new Vector2(size, 2 * Size.y));

		allEdges[2].transform.position = new Vector2(0, 2 * Size.y * topCrossing - Size.y + size / 2);
		allEdges[2].SetSize(new Vector2(2 * Size.x, size));

		allEdges[3].transform.position = new Vector2(0, -Size.y - size / 2);
		allEdges[3].SetSize(new Vector2(2 * Size.x, size));
	}
}
