using UnityEngine;

public class CubeManagerScript : MonoBehaviour
{

    public string key = "52314";
    public string receivedText;

    public int ob1;
    public int ob2;
    public int ob3;
    public int ob4;
    public int ob5;

    public GameObject[] objects;
    public int currentIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        receivedText = PlayerPrefs.GetString("InputFieldText", "");
        UpdateKey(); // Call UpdateKey() on Start for immediate update
        AssignToObjects();
        SetTags();
        currentIndex = objects.Length -1;
    }

    void UpdateKey()
    {
        if (receivedText.Length != 5)
        {
            Debug.LogError("Received text length (" + receivedText.Length + ") must be 5 digits.");
            return; // Exit if length is incorrect
        }

        string newKey = "";
        for (int i = 0; i < receivedText.Length; i++)
        {
            char currentChar = receivedText[i];

            int newValue = 0;
            int asciiValue = (int)currentChar;
            Debug.Log(asciiValue);
            if (asciiValue == 100)
            {
                newValue = 9;
            }
            else if (asciiValue > 100)
            {
                newValue = (asciiValue) / 100;
            }
            else
            {
                newValue = (asciiValue) / 10; // Subtract '0' for ASCII offset and divide
            }

            newKey += newValue.ToString();
            Debug.Log(newKey);
        }
        key = newKey;
    }

    void AssignToObjects()
    {
        for (int i = 0; i < key.Length; i++)
        {
            // Conversion of character from key array to int
            int value = int.Parse(key[i].ToString());
            // Set the value of ob variables based on the index i
            GetType().GetField("ob" + (i + 1)).SetValue(this, value);
        }
    }

    void SetTags()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == objects.Length - 1)
            {
                objects[i].tag = "destructable";
            }
            else
            {
                objects[i].tag = "not_destructable";
            }
        }
    }

    // Function to destroy the current destructible object and set the next object to be destructible
    public void DestroyNextObject()
    {
        if (currentIndex >= 0) { 

            // Move to the next object
            currentIndex--;

        // If there are more objects, set the next object to be destructible
        if (currentIndex < objects.Length)
        {
            // If the current object is not the last one, set the tag of the next object to "destructable"
            objects[currentIndex].tag = "destructable";
        }
        else if (currentIndex == objects.Length)
        {
            // If the current object is the last one, set the tag of the previous object to "destructable"
            if (currentIndex > 0)
            {
                objects[currentIndex - 1].tag = "destructable";
            }
        }
    }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
