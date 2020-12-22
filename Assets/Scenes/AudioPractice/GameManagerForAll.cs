using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerForAll : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadMainScene()
    {
        AkSoundEngine.StopAll();

        SceneManager.LoadScene(0);
    }

    public void Load2DSoundScene()
    {
        AkSoundEngine.StopAll();

        SceneManager.LoadScene(1);
    }

    public void Load3DSoundScene()
    {
        AkSoundEngine.StopAll();

        SceneManager.LoadScene(2);
    }

    public void LoadPostProcessingAndFogScene()
    {
        AkSoundEngine.StopAll();

        SceneManager.LoadScene(3);
    }

    public void LoadVideoScene()
    {
        AkSoundEngine.StopAll();

        SceneManager.LoadScene(4);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
