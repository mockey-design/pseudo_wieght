using UnityEngine;

public class VRInputManager : MonoBehaviour
{
    [SerializeField] private ExperimentManager experimentManager;

    private void Update()
    {
        // Ç±ÇÃó·ÇÕ Oculus Integration ÇÃèÍçá
        // OVRInput.Button.One = AÉ{É^Éììô
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
