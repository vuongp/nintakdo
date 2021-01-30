using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InsertText : MonoBehaviour
{
    public TextMeshPro text;

    [Tooltip("Analyses how many $s are in your sentence. CAREFUL: Will wipe your variables!")]
    public bool button = true;

    [Tooltip("Use the dollar sign ($) to indicate a variable word.")]
    public string textToEnter, newText;

    [Tooltip("Divide the different options using a space, please!")]
    public string[] customVariables;

    // Start is called before the first frame update
    void Start()
    {
        newText = textToEnter;
        ReplaceVariables(textToEnter);
        text.SetText(newText);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnValidate is called when the value in the editor changes
    void OnValidate()
    {
        if (!button) //Push da button
        {
            LookForVariables(textToEnter);
            button = true;
        }
    }

    private void LookForVariables(string textToEnter) //Checks for the number of $ in the string and gives you the correct amount of slots to fill in
    {
        string stripThis = textToEnter;
        int count = 0;
        foreach (char c in stripThis)
        {
            if(c == '$')
            {
                count++;               
            }
        }

        customVariables = new string[count];
    }

    private void ReplaceVariables(string text) //Replaces the $ with a randomly selected variable.
    {
        string[] randomVariables = new string[customVariables.Length];


        for (int i = 0; i < customVariables.Length; i++) //For each $ sign..
        {
            string[] splitSentence = customVariables[i].Split(' '); //Splits the possibilities and turns them into an array

            randomVariables[i] = splitSentence[Random.Range(0, splitSentence.Length)]; //Randomly picks one of the possibilities and assigns it to the randomVariables slot

            newText = ReplaceFirst(newText, "$", randomVariables[i]); //Replaces a $ with the new word.
            
        }
    }

    private string ReplaceFirst(string text, string search, string replace) //Replaces the first occurence of a string with another string.
    {
        int pos = text.IndexOf(search);
        if (pos < 0)
        {
            return text;
        }
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }
}
