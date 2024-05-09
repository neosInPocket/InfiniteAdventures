using UnityEngine;

public class CasesContainer : MonoBehaviour
{
	[SerializeField] private UpgradeCase[] cases;
	[SerializeField] private DiaChanger[] changers;

	private void Start()
	{
		for (int i = 0; i < cases.Length; i++)
		{
			cases[i].InitializeCase(this);
		}

		RefreshAllInformation();
	}

	public void RefreshAllInformation()
	{
		for (int i = 0; i < cases.Length; i++)
		{
			cases[i].SetCaseInfo();
		}

		for (int i = 0; i < changers.Length; i++)
		{
			changers[i].Change();
		}
	}
}
