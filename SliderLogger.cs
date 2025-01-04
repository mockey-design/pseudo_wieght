using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SliderLogger : MonoBehaviour
{
    [SerializeField] private Slider slider; // スライダーの参照
    [SerializeField] private Button logButton; // ログを出力するボタン
    private string directoryPath = @"C:\Users\Motoki_Kagami\interaction_toolkit"; // 指定された保存先
    private string filePath;

    private void Start()
    {
        // 保存先ファイルパスを指定
        filePath = Path.Combine(directoryPath, "SliderLog.csv");

        // ディレクトリが存在しない場合は作成
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

        // CSVファイルにヘッダーを書き込む（初回のみ）
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

        // ボタンのイベント登録
        if (logButton != null)
        {
            logButton.onClick.AddListener(OnLogButtonClicked);
        }
        else
        {
            Debug.LogError("Log Button is not assigned in the Inspector.");
        }

        // スライダーの確認
        if (slider == null)
        {
            Debug.LogError("Slider is not assigned in the Inspector.");
        }
    }

    private void OnLogButtonClicked()
    {
        if (slider != null)
        {
            // スライダーの現在値を取得
            float sliderValue = slider.value;

            // 現在の日時を取得
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // ログをコンソールに出力
            Debug.Log($"{timestamp}, Slider Value: {sliderValue}");

            // CSVにログを書き込む
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
            // CSV形式でログを書き込む
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
        // ボタンのイベントリスナーを解除（メモリリーク防止）
        if (logButton != null)
        {
            logButton.onClick.RemoveListener(OnLogButtonClicked);
        }
    }
}
