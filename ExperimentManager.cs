using UnityEngine;

// 1) �X�e�b�v��\��enum�i�񋓌^�j
public enum ExperimentStep
{
    IntroText,
    StandardDisplayText,
    StandardDisplay,
    DifferentDisplayText,
    DifferentDisplay,
    Questionnaire,
    End
}

// 2) �����̗�����Ǘ�����N���X
public class ExperimentManager : MonoBehaviour
{
    [Header("UI/Display Objects")]
    [SerializeField] private List<GameObject> uiObjects;

    private int currentIndex = 0;
    // ���ǂ̃X�e�b�v�ɂ��邩

    /* private void Start()
     {

     }*/

    private void ShowUI(int index)
    {
        if (index < 0 || index >= uiObjects.Count)
        {
            Debug.LogWarning($"Invaild index: {index}. Check the UI Objects list");
            return;
        }
        foreach (GameObject obj in uiObjects)
        {
            obj.setAvtive(false);
        }


        uiObjects[index].SetActive(true);
        currentIndex = index;
    }

    public void ShowNextUI()
    {
        int nextIndex = (currentIndex + 1) % uiObjects.Count;
        ShowUI(nextIndex);
    }
    public void ShowPreviousUI()
    {
        int previousIndex = (currentIndex - 1 + uiObjects.Count) % uiObjects.Count; // ���̒l�ɂȂ�Ȃ��悤����
        ShowUI(previousIndex);
    }
   
}
