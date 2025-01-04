using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SliderLogger : MonoBehaviour
{
    [SerializeField] private Slider slider; // �X���C�_�[�̎Q��
    [SerializeField] private Button logButton; // ���O���o�͂���{�^��
    private string directoryPath = @"C:\Users\Motoki_Kagami\interaction_toolkit"; // �w�肳�ꂽ�ۑ���
    private string filePath;

    private void Start()
    {
        // �ۑ���t�@�C���p�X���w��
        filePath = Path.Combine(directoryPath, "SliderLog.csv");

        // �f�B���N�g�������݂��Ȃ��ꍇ�͍쐬
        if (!Directory.Exists(directoryPath))
        {
            try
            {
                Directory.CreateDirectory(directoryPath);
                Debug.Log("Directory created: " + directoryPath);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to create directory: {ex.Message}");
                return;
            }
        }

        // CSV�t�@�C���Ƀw�b�_�[���������ށi����̂݁j
        if (!File.Exists(filePath))
        {
            try
            {
                File.AppendAllText(filePath, "Timestamp,SliderValue\n", Encoding.UTF8);
                Debug.Log("Header written to CSV file.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to write header to CSV: {ex.Message}");
            }
        }

        // �{�^���̃C�x���g�o�^
        if (logButton != null)
        {
            logButton.onClick.AddListener(OnLogButtonClicked);
        }
        else
        {
            Debug.LogError("Log Button is not assigned in the Inspector.");
        }

        // �X���C�_�[�̊m�F
        if (slider == null)
        {
            Debug.LogError("Slider is not assigned in the Inspector.");
        }
    }

    private void OnLogButtonClicked()
    {
        if (slider != null)
        {
            // �X���C�_�[�̌��ݒl���擾
            float sliderValue = slider.value;

            // ���݂̓������擾
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // ���O���R���\�[���ɏo��
            Debug.Log($"{timestamp}, Slider Value: {sliderValue}");

            // CSV�Ƀ��O����������
            WriteToCsv(timestamp, sliderValue);
        }
        else
        {
            Debug.LogError("Slider is not assigned.");
        }
    }

    private void WriteToCsv(string timestamp, float value)
    {
        try
        {
            // CSV�`���Ń��O����������
            string logEntry = $"{timestamp},{value}\n";
            File.AppendAllText(filePath, logEntry, Encoding.UTF8);

            Debug.Log($"Log written to: {filePath}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to write to CSV: {ex.Message}");
        }
    }

    private void OnDestroy()
    {
        // �{�^���̃C�x���g���X�i�[�������i���������[�N�h�~�j
        if (logButton != null)
        {
            logButton.onClick.RemoveListener(OnLogButtonClicked);
        }
    }
}
