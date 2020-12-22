using UnityEngine;

public class PlayUISound : MonoBehaviour
{
    public string eventName = null;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Play()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");

        if (!string.IsNullOrEmpty(eventName))
            AkSoundEngine.PostEvent(eventName, mainCamera);
    }
}
