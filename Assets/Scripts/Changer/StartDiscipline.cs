using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class StartDiscipline : MonoBehaviour
{
	[SerializeField] public TMP_Text disciplineText;
	[SerializeField] public Animator gamePointer;

	public Action OnDisciplinePassed;

	private void Awake()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}

	public void StartDisciplineRoute(Action onPassed, RetentionScript retentionScript)
	{
		if (!retentionScript.StartDiscipline)
		{
			onPassed();
			return;
		}
		else
		{
			retentionScript.StartDiscipline = false;
			retentionScript.Retention();
		}

		gameObject.SetActive(true);
		OnDisciplinePassed = onPassed;
		Touch.onFingerDown += SpaceNinja;
		disciplineText.text = "WELCOME TO INFINITE ADVENTURES!";
	}

	private void SpaceNinja(Finger finger)
	{
		Touch.onFingerDown -= SpaceNinja;
		Touch.onFingerDown += DaggerFly;
		disciplineText.text = "BECOME A REAL SPACE NINJA! TO DO THIS, YOU SHOULD LEARN HOW TO HANDLE YOUR DAGGER";
		gamePointer.SetTrigger("newForm");
	}

	public void DaggerFly(Finger finger)
	{
		Touch.onFingerDown -= DaggerFly;
		Touch.onFingerDown += BushAsteroids;
		disciplineText.text = "IF YOU PRESS THE SCREEN, THE DAGGER WILL FLY DOWN AND START ROTATING. CAPTURE THE MOMENT AND PRESS THE SCREEN AGAIN TO MAKE IT FLY IN THE RIGHT DIRECTION!";
		gamePointer.SetTrigger("newForm");
	}

	public void BushAsteroids(Finger finger)
	{
		Touch.onFingerDown -= BushAsteroids;
		Touch.onFingerDown += PassTheLevelAsteroids;
		disciplineText.text = "WHAT IS IT FOR? IT'S SIMPLE - BUSH THE ASTEROIDS FLYING FROM FROM ABOVE WITH YOUR DAGGER TO PASS THE LEVEL";
		gamePointer.SetTrigger("newForm");
	}

	public void PassTheLevelAsteroids(Finger finger)
	{
		Touch.onFingerDown -= PassTheLevelAsteroids;
		Touch.onFingerDown += GoodLuck;
		disciplineText.text = "DESTROY THE REQUIRED NUMBER OF ASTEROIDS TO PASS THE LEVEL AND RECEIVE THE HIGH REWARD!";
		gamePointer.SetTrigger("newForm");
	}

	public void GoodLuck(Finger finger)
	{
		Touch.onFingerDown -= GoodLuck;
		Touch.onFingerDown += DisciplineCompleted;
		disciplineText.text = "GOOD LUCK!";
		gamePointer.SetTrigger("newForm");
	}

	public void DisciplineCompleted(Finger finger)
	{
		OnDisciplinePassed?.Invoke();
		gameObject.SetActive(false);
		UnSubscrubeFromAllPaths();
	}

	public void UnSubscrubeFromAllPaths()
	{
		Touch.onFingerDown -= SpaceNinja;
		Touch.onFingerDown -= DaggerFly;
		Touch.onFingerDown -= BushAsteroids;
		Touch.onFingerDown -= PassTheLevelAsteroids;
		Touch.onFingerDown -= GoodLuck;
		Touch.onFingerDown -= DisciplineCompleted;
	}

	private void OnDestroy()
	{
		UnSubscrubeFromAllPaths();
	}
}
