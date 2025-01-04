using UnityEngine;

public class VRInputManager : MonoBehaviour
{
    [SerializeField] private ExperimentManager experimentManager;

    private void Update()
    {
        // ���̗�� Oculus Integration �̏ꍇ
        // OVRInput.Button.One = A�{�^����
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
