using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Finger = UnityEngine.InputSystem.EnhancedTouch.Finger;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class MovingDagger : MonoBehaviour
{
	[SerializeField] public SpriteRenderer daggerRenderer;
	[SerializeField] public Rigidbody2D daggerRigid;
	[SerializeField] public new Collider2D collider;
	[SerializeField] public GameObject daggerBlowEffect;
	[SerializeField] public float preparationSpeed;
	[SerializeField] public float preparationScreenY;
	[SerializeField] public float startPositionY;
	[SerializeField] public float[] spinSpeeds;
	[SerializeField] public float[] throwSpeeds;
	[SerializeField] public RetentionScript retentionScript;
	[SerializeField] public DeviceEdges deviceEdges;
	[SerializeField] public float multiplierThreshold;
	[SerializeField] public AudioSource source;
	[SerializeField] public float transparentValue;
	private float spinningSpeed;
	private float throwSpeed;
	private bool allowSpin;
	private Vector3 currentRotation;
	private int rotationDirection;
	private bool activated;
	public Action OnePoint;
	public Action EndPoint;

	private void Start()
	{
		spinningSpeed = spinSpeeds[retentionScript.InfiniteSecond ? 1 : 0];
		throwSpeed = throwSpeeds[retentionScript.InfiniteFirst ? 1 : 0];
		currentRotation = transform.eulerAngles;
		collider.enabled = false;
		source.enabled = retentionScript.InfiniteEffects;
		daggerRenderer.color = new Color(1, 1, 1, transparentValue);
		transform.position = new Vector2(0, 2 * deviceEdges.Size.y * startPositionY - deviceEdges.Size.y);
	}

	private void Update()
	{
		if (!allowSpin) return;
		currentRotation.z += rotationDirection * spinningSpeed * Time.deltaTime;
		transform.eulerAngles = currentRotation;
	}

	public void ActivateDagger(bool activateValue)
	{
		if (activateValue)
		{
			Touch.onFingerDown += PrepareDagger;
		}
		else
		{
			Touch.onFingerDown -= PrepareDagger;
			Touch.onFingerDown -= ThrowDagger;
		}
	}

	public void PrepareDagger(Finger finger)
	{
		Touch.onFingerDown -= PrepareDagger;
		rotationDirection = Random.Range(0, 2) == 1 ? 1 : -1;
		allowSpin = true;
		StartCoroutine(Preparation());
	}

	public IEnumerator Preparation()
	{
		Touch.onFingerDown += ThrowDagger;
		var targetDestination = 2 * deviceEdges.Size.y * preparationScreenY - deviceEdges.Size.y;
		float distance = transform.position.y - targetDestination;
		float multiplier = 1f;
		Vector2 currentPosition = transform.position;

		while (transform.position.y > targetDestination)
		{
			currentPosition.y -= preparationSpeed * (multiplier + multiplierThreshold) * Time.deltaTime;
			transform.position = currentPosition;
			multiplier = (-targetDestination + transform.position.y) / distance;
			yield return null;
		}

		transform.position = new Vector2(0, targetDestination);
	}

	public void ThrowDagger(Finger finger)
	{
		StopAllCoroutines();
		Touch.onFingerDown -= ThrowDagger;
		allowSpin = false;
		collider.enabled = true;
		daggerRigid.velocity = transform.up * throwSpeed;
		daggerRenderer.color = new Color(1, 1, 1, 1);
	}

	public void ReturnToInitialPosition()
	{
		daggerRenderer.color = new Color(1, 1, 1, transparentValue);
		allowSpin = false;
		transform.position = new Vector2(0, 2 * deviceEdges.Size.y * startPositionY - deviceEdges.Size.y);
		currentRotation = Vector3.zero;
		transform.eulerAngles = currentRotation;
		daggerRigid.velocity = Vector2.zero;
		Touch.onFingerDown += PrepareDagger;
		collider.enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<SingleEdge>(out SingleEdge edge))
		{
			ReturnToInitialPosition();
			return;
		}

		if (collider.TryGetComponent<MovingBalloon>(out MovingBalloon balloon))
		{
			if (balloon.IsEnemy)
			{
				DestroyPlayer();
			}
			else
			{
				balloon.Pop();
				ReturnToInitialPosition();
				OnePoint?.Invoke();
			}
		}
	}

	public void DestroyPlayer()
	{
		daggerRenderer.enabled = false;
		allowSpin = false;
		daggerRigid.velocity = Vector2.zero;
		Touch.onFingerDown -= PrepareDagger;
		Touch.onFingerDown -= ThrowDagger;
		EndPoint?.Invoke();
		daggerBlowEffect.SetActive(true);
		collider.enabled = false;
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= PrepareDagger;
		Touch.onFingerDown -= ThrowDagger;
	}
}
