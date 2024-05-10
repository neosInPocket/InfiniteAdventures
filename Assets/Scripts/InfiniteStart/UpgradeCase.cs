using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCase : MonoBehaviour
{
	[SerializeField] private Button mainButton;
	[SerializeField] private TMP_Text mainCostText;
	[SerializeField] private TMP_Text normalText;
	[SerializeField] private GameObject restrictedText;
	[SerializeField] private int mainCost;
	[SerializeField] private int uprgradeCoreIndex;
	[SerializeField] private RetentionScript retentionScript;
	private CasesContainer casesContainer;

	private void Start()
	{
		mainButton.onClick.AddListener(MainPurchase);
		SetCaseInfo();
	}

	public void InitializeCase(CasesContainer container)
	{
		casesContainer = container;
	}

	public void SetCaseInfo()
	{
		mainCostText.text = mainCost.ToString();

		bool bought = uprgradeCoreIndex == 0 ? retentionScript.InfiniteFirst : retentionScript.InfiniteSecond;

		if (bought)
		{
			normalText.text = "PURCHASED";
			normalText.gameObject.SetActive(true);
			normalText.color = Color.green;
			restrictedText.gameObject.SetActive(false);
			mainButton.interactable = false;
		}
		else
		{
			if (retentionScript.InfiniteDiamonds >= mainCost)
			{
				normalText.text = "PURCHASE";
				normalText.gameObject.SetActive(true);
				restrictedText.gameObject.SetActive(false);
				mainButton.interactable = true;
				normalText.color = Color.white;
			}
			else
			{
				normalText.gameObject.SetActive(false);
				restrictedText.gameObject.SetActive(true);
				mainButton.interactable = false;
			}
		}
	}

	public void MainPurchase()
	{
		retentionScript.InfiniteDiamonds -= mainCost;
		if (uprgradeCoreIndex == 0)
		{
			retentionScript.InfiniteFirst = true;
		}
		else
		{
			retentionScript.InfiniteSecond = true;
		}

		retentionScript.Retention();
		casesContainer.RefreshAllInformation();
	}
}
