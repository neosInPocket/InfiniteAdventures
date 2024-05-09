using TMPro;
using UnityEngine;

public class InfiniteCurrentLevel : MonoBehaviour
{
    [SerializeField] private RetentionScript retentionScript;
    [SerializeField] private TMP_Text level;

    private void Start()
    {
        level.text = $"current level: {retentionScript.InfiniteProgress}";
    }

    public void Change()
    {
        level.text = $"current level: {retentionScript.InfiniteProgress}";
    }
}
