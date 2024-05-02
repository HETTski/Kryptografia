using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputFieldLimiter : MonoBehaviour
{

    public TMP_InputField inputField;

    void Start()
    {
       
        if (inputField != null)
        {
            inputField.onValueChanged.AddListener(OnValueChanged);
        }
        else
        {
            // Handle the case where the TMP_InputField is null (e.g., log a warning)
            Debug.LogError("TMP_InputField not found on this GameObject!");
        }
    }

        void OnValueChanged(string newValue)
    {
        if (newValue.Length > 5)
        {
            // Truncate to 5 characters
            inputField.text = newValue.Substring(0, 5);
        }
    }

    public void LoadNextScene()
    {
        PlayerPrefs.SetString("InputFieldText", inputField.text);
        SceneManager.LoadScene(sceneToLoad); // Use the public variable sceneToLoad
    }

    public string sceneToLoad; // Public variable for scene name
}
