using TMPro;
using UnityEngine;

public class DiaChanger : MonoBehaviour
{
	[SerializeField] private RetentionScript retentionScript;
	[SerializeField] private TMP_Text diaText;

	private void Start()
	{
		diaText.text = retentionScript.InfiniteDiamonds.ToString();
	}

	public void Change()
	{
		diaText.text = retentionScript.InfiniteDiamonds.ToString();
	}
}
