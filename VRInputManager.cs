using UnityEngine;

public class VRInputManager : MonoBehaviour
{
    [SerializeField] private ExperimentManager experimentManager;

    private void Update()
    {
        // この例は Oculus Integration の場合
        // OVRInput.Button.One = Aボタン等
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            experimentManager.ShowNextUI();
        }

        if (OVRInput.GetDown(OVRInput.Button.two))
        {
            experimentManager.ShowPreviousUI();
        }
    }
}
