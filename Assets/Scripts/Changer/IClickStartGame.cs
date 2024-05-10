using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Finger = UnityEngine.InputSystem.EnhancedTouch.Finger;
using System;

public class IClickStartGame : MonoBehaviour
{
	private Action waitEndAction;

	public void StartWaitForGame(Action onWaitEndAction)
	{
		Touch.onFingerDown += OnWaitEnd;
		waitEndAction = onWaitEndAction;
		gameObject.SetActive(true);
	}

	private void OnWaitEnd(Finger finger)
	{
		Touch.onFingerDown -= OnWaitEnd;
		waitEndAction();
		gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= OnWaitEnd;
	}
}
