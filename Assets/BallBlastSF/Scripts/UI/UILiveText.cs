using TMPro;
using UnityEngine;

public class UILiveText : MonoBehaviour
{
    [SerializeField] private Live live;
    [SerializeField] private TextMeshProUGUI liveText;
    [SerializeField] private string markLiveText;

    private void FixedUpdate()
    {
        liveText.text = live.CurrentLive + " " + markLiveText;
    }
}
