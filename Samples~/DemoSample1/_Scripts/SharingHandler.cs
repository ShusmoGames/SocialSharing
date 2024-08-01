using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SharingHandler : MonoBehaviour
{
    [SerializeField] private Toggle toggle1;
    [SerializeField] private Sprite sprite1;

    [Space]

    [SerializeField] private Toggle toggle2;
    [SerializeField] private Sprite sprite2;
    
    [Space]

    [SerializeField] private Toggle toggle3;
    [SerializeField] private Sprite sprite3;

    [Space]

    [SerializeField] private TMP_InputField inputField;

    [Space]

    [SerializeField] private TMP_Text resultText;

    public void Share()
    {
        ShusmoAPI.SocialSharing.Share
            (
                text: inputField.text,
                image: (toggle1.isOn) ? sprite1
                : (toggle2.isOn) ? sprite2
                : (toggle3.isOn) ? sprite3
                : null,
                callback: ShowResult
            );
    }

    private void ShowResult(string result) => resultText.text = result;
}
