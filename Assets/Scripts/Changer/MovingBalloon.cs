using System.Collections;
using UnityEngine;

public class MovingBalloon : MonoBehaviour
{
	[SerializeField] private new SpriteRenderer renderer;
	[SerializeField] private Rigidbody2D newRigid;
	[SerializeField] private Vector2 differentScales;
	[SerializeField] private Vector2 differentYSpeeds;
	[SerializeField] private Vector2 differentAmplitudes;
	[SerializeField] private Vector2 differentFreqs;
	[SerializeField] private Sprite enemySprite;
	[SerializeField] private GameObject balloonPop;
	[SerializeField] private new Collider2D collider;
	[SerializeField] private AudioSource audioSource;
	public AudioSource source => audioSource;
	private float speedY;
	private float amplitude;
	private float freq;

	public bool IsEnemy { get; set; }
	private Vector2 currentPosition;
	private float currentTime;
	private bool allowed;

	public void SetAllInformation(DeviceEdges deviceEdges)
	{
		if (Random.Range(0, 1f) < 0.2f)
		{
			IsEnemy = true;
			renderer.sprite = enemySprite;
		}

		var randomScale = Random.Range(differentScales.x, differentScales.y);
		renderer.size = new Vector2(randomScale, randomScale);

		speedY = Random.Range(differentYSpeeds.x, differentYSpeeds.y);
		amplitude = Random.Range(differentAmplitudes.x, differentAmplitudes.y) * deviceEdges.Size.x;
		freq = Random.Range(differentFreqs.x, differentFreqs.y);

		currentPosition = transform.position;
		currentTime = Random.Range(0, 2 * Mathf.PI);
		allowed = true;
	}

	private void Update()
	{
		if (!allowed) return;
		currentPosition.x = 2 * amplitude * Mathf.Sin(currentTime * freq);
		currentPosition.y -= speedY * Time.deltaTime;
		currentTime += Time.deltaTime;
		transform.position = currentPosition;
	}

	public void Pop()
	{
		StartCoroutine(BalloonPop());
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<SingleEdge>(out SingleEdge edge))
		{
			if (edge.transform.position.y > 0) return;
			Pop();
		}
	}

	public IEnumerator BalloonPop()
	{
		renderer.enabled = false;
		collider.enabled = false;
		allowed = false;
		newRigid.velocity = Vector2.zero;
		balloonPop.SetActive(true);
		yield return new WaitForSeconds(1);
		Destroy(gameObject);
	}
}
