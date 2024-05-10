using Unity.Profiling;
using UnityEngine;

public class SingleEdge : MonoBehaviour
{
	[SerializeField] private float size;
	[SerializeField] private SpriteRenderer spriteRenderer;
	public float Size => size;

	public void SetSize(Vector2 size)
	{
		spriteRenderer.size = size;
	}
}
