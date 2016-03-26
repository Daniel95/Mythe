using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAndroid : MonoBehaviour
{
    [SerializeField]
    private string sceneOnBackButton;
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneOnBackButton);
        }

    }
}
