using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VerifyCode : MonoBehaviour
{
    public string code = "1234";
    public InputField inputField;
    public bool codeCorrect;
    public PuzzleManager puzzleManager;

    public bool VerifyTheCode()
    {
        return inputField.text==code;
    }
    public void VerifyACode()
    {
        //codeCorrect= inputField.text==code;
        if(inputField.text==code)
        {
            puzzleManager.GoToLastUi();
        }
    }
}
