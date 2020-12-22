using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Camera mainCamera;

    public PostProcessVolume postProcessVolume;

    public Canvas inputUI;

    public Canvas settingUI;

    public Toggle[] toggles;

    void Start()
    {
        inputUI.enabled = true;
        settingUI.enabled = false;
    }

    void Update()
    {
        
    }

    public void ShowSetting()
    {
        if (!settingUI.enabled)
            settingUI.enabled = true;

        if (inputUI.enabled)
            inputUI.enabled = false;
    }

    public void CloseSetting()
    {
        if (settingUI.enabled)
            settingUI.enabled = false;

        if (!inputUI.enabled)
            inputUI.enabled = true;
    }

    public void TurnOnAll()
    {
        for (int i = 0; i < toggles.Length; i++)
            toggles[i].isOn = true;

        PostProcessLayer layer = mainCamera.GetComponent<PostProcessLayer>();
        layer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;

        postProcessVolume.isGlobal = true;
    }

    public void TurnOffAll()
    {
        for (int i = 0; i < toggles.Length; i++)
            toggles[i].isOn = false;

        PostProcessLayer layer = mainCamera.GetComponent<PostProcessLayer>();
        layer.antialiasingMode = PostProcessLayer.Antialiasing.None;

        postProcessVolume.isGlobal = false;
    }

    public void ChangeFXAA()
    {
        PostProcessLayer layer = mainCamera.GetComponent<PostProcessLayer>();

        if (layer.antialiasingMode == PostProcessLayer.Antialiasing.FastApproximateAntialiasing)
            layer.antialiasingMode = PostProcessLayer.Antialiasing.None;
        else
            layer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
    }

    private void ChangeEffect(int index)
    {
        if (postProcessVolume.profile.settings[index].enabled)
            postProcessVolume.profile.settings[index].enabled.value = false;
        else
            postProcessVolume.profile.settings[index].enabled.value = true;
    }

    public void ChangeColorGrading()
    {
        ChangeEffect(0);
    }

    public void ChangeBloom()
    {
        ChangeEffect(1);
    }

    public void ChangeAmbientOcclusion()
    {
        ChangeEffect(2);
    }

    public void ChangeVignette()
    {
        ChangeEffect(3);
    }

    public void ChangeLensDistortion()
    {
        ChangeEffect(4);
    }

    public void ChangeFog()
    {
        if (RenderSettings.fog)
            RenderSettings.fog = false;
        else
            RenderSettings.fog = true;
    }
}
