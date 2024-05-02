using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] textDisplays; // Array of TMP_Text references
    public string receivedText;

    void Start()
    {
        receivedText = PlayerPrefs.GetString("InputFieldText", "");
        UpdateTextDisplays(); // Call UpdateTextDisplays() on Start
    }

    void UpdateTextDisplays()
    {
        // Check if receivedText length matches the number of text displays
        if (receivedText.Length != textDisplays.Length)
        {
            Debug.LogError("Received text length (" + receivedText.Length + ") doesn't match the number of text displays (" + textDisplays.Length + ").");
            return; // Exit if there's a mismatch
        }

        // Iterate through each character and assign it to the corresponding text display
        for (int i = 0; i < receivedText.Length; i++)
        {
            textDisplays[i].text = receivedText[i].ToString();
        }
    }
}
