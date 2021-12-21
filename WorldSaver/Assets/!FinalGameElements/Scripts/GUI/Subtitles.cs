using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Subtitles : MonoBehaviour
{
    public TMP_Text text; // reference to the subtitle text
    void Start()
    {
        StartCoroutine(TheSequenceNew()); // starting the coroutine at start
    }

   IEnumerator TheSequenceNew() // Changing each text with a certain delay used in the intro cutscene
   {
        yield return new WaitForSeconds(10);
        text.text = "Ahoy Seasavers and welcome aboard SS Olga!";
        yield return new WaitForSeconds(4);
        text.text = "You have been chosen to help save the seas from the overflow of plastic";
        yield return new WaitForSeconds(5);
        text.text = "If you’re up for the task let me show you the ropes";
        yield return new WaitForSeconds(4);
        text.text = "You are each given command of your own boat";
        yield return new WaitForSeconds(3);
        text.text = "which is connected by a special plastic-collecting rope";
        yield return new WaitForSeconds(4);
        text.text = "You must then navigate around the oceans";
        yield return new WaitForSeconds(3);
        text.text = "collecting as much plastic as you can";
        yield return new WaitForSeconds(3);
        text.text = "before you run out of fuel";
        yield return new WaitForSeconds(2);
        text.text = "Each time you have gathered 10 pieces of plastic";
        yield return new WaitForSeconds(4);
        text.text = "bring it back to my ship and I will store it in a container for you";
        yield return new WaitForSeconds(3);
        text.text = "But be careful mateys";
        yield return new WaitForSeconds(1);
        text.text = "if you sail too far away from each other the rope will snap";
        yield return new WaitForSeconds(4);
        text.text = "you will have to come back to me to get it fixed";
        yield return new WaitForSeconds(4);
        text.text = "before you can collect more plastic";
        yield return new WaitForSeconds(2);
        text.text = "And if you see any animals trapped in a garbage patch";
        yield return new WaitForSeconds(3);
        text.text = "be sure to help them by collecting the plastic around them";
        yield return new WaitForSeconds(3);
        text.text = "they might reward you for your help";
        yield return new WaitForSeconds(3);
        text.text = "Best of luck on your adventure sailors!";
        yield return new WaitForSeconds(4);
        text.text = "";
   }
}
