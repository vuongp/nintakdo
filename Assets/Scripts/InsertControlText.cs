using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InsertControlText : InsertText
{
    public FirstPersonController player;
    public enum ReplaceKey { SPRINT, JUMP };
    public ReplaceKey replaceKey;
    public KeyCode controlToReplace;
    public ColliderContainer[] triggerBoxes;

    public void Update()
    {
        foreach (ColliderContainer collider in triggerBoxes)
        {
            if(collider.playerInside)
            {
                if(replaceKey == ReplaceKey.SPRINT)
                {
                    player.ChangeRun(controlToReplace);
                    collider.playerInside = false;
                }
                if(replaceKey == ReplaceKey.JUMP)
                {
                    player.ChangeJump(controlToReplace);
                    collider.playerInside = false;
                }
            }

            if(collider.playerLeft)
            {
                if (replaceKey == ReplaceKey.SPRINT)
                {
                    player.ChangeRun(player.run);
                    collider.playerLeft = false;
                }
                if (replaceKey == ReplaceKey.JUMP)
                {
                    player.ChangeJump(player.jump);
                    collider.playerLeft = false;
                }
            }
        }
    }
    public override void ReplaceVariables(string text) //Replaces the $ with a randomly selected variable.
    {
        string[] randomVariables = new string[customVariables.Length];


        for (int i = 0; i < customVariables.Length; i++) //For each $ sign..
        {
            string[] splitSentence = customVariables[i].Split(' '); //Splits the possibilities and turns them into an array

            randomVariables[i] = splitSentence[Random.Range(0, splitSentence.Length)]; //Randomly picks one of the possibilities and assigns it to the randomVariables slot


            newText = ReplaceFirst(newText, "$", randomVariables[i]); //Replaces a $ with the new word.
            controlToReplace = (KeyCode)System.Enum.Parse(typeof(KeyCode), randomVariables[i]);
        }
    }
        
}
