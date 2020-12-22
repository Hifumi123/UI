using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public string ctrlName = null;

    public Text value;

    private Slider m_Slider;

    void Start()
    {
        m_Slider = GetComponent<Slider>();

        value.text = (m_Slider.value * 100).ToString();
    }

    void Update()
    {
        
    }

    public void Change()
    {
        AkSoundEngine.SetRTPCValue(ctrlName, m_Slider.value * 100);

        value.text = (m_Slider.value * 100).ToString();
    }
}
