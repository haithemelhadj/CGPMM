using UnityEngine;
using UnityEngine.UI;

public class CameraQuizManager : MonoBehaviour
{
    public GameObject[] lists;
    public int currentActiveScene=0;

    private void Start()
    {
        ActivateScene(currentActiveScene);
    }

    public void ActivateScene(int scene)
    {
        foreach (GameObject go in lists)
        {
            go.SetActive(false);
        }
        lists[scene].SetActive(true);
        currentActiveScene = scene;
    }

    public Text text;
    public bool answeredCorrect;
    public GameObject highlight;
    public void SelectOption(bool answer)
    {
        highlight.transform.localPosition= this.transform.localPosition;
        highlight.SetActive(true);
        answeredCorrect = answer;

    }

    public void checkAnswer()
    {
        if(answeredCorrect)
        {
            text.text = string.Empty;
            activateNextScene();
        }
        else
        {

            text.text = "wrong";
        }
    }
    public void activateNextScene()
    {
        currentActiveScene++;
        ActivateScene(currentActiveScene);
        answeredCorrect=false;
    }

}
