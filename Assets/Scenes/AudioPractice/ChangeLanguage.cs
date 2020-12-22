using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguage : MonoBehaviour
{
    private Dropdown m_Dropdown;

    private bool m_NeedLoadBank = false;

    private float timer = 0;

    void Start()
    {
        m_Dropdown = GetComponent<Dropdown>();

        Change();
    }

    void Update()
    {
        if (m_NeedLoadBank)
        {
            //延迟0.3秒生效。
            if (timer >= 0.3)
            {
                AkBankManager.LoadBank("UI", false, false);

                m_NeedLoadBank = false;
            }
            else
                timer += Time.deltaTime;
        }
    }

    public void Change()
    {
        AkBankManager.UnloadBank("UI");

        AkSoundEngine.SetCurrentLanguage(m_Dropdown.options[m_Dropdown.value].text);

        m_NeedLoadBank = true;

        timer = 0;
    }
}
