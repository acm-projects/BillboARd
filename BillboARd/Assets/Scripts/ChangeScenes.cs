using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeScenes : MonoBehaviour
{
    public Button m_SceneButton; //Array of buttons to be linked to in inspector
    public string m_SceneName;  //Array of names of scenes to change to specified in inspector


    void Start()
    {
        //Call the LoadButton() function when the user clicks this Button
        m_SceneButton.onClick.AddListener(() => LoadButton(m_SceneName));
    }

    void LoadButton(string nextSceneName)
    {
        //Start loading the Scene asynchronously and output the progress bar
        StartCoroutine(LoadScene(nextSceneName));
    }

    IEnumerator LoadScene(string nextSceneName)
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;

        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Activate the Scene
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}