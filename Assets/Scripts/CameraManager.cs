using UnityEngine;

public class CameraManager : MonoBehaviour
{
  [SerializeField] GameObject[] panels;
  int currentPanelIndex = 0;
  void Start() {
    // 全て非表示設定にする
    InactivePanel();

    // 0番目のパネルを初期表示とする
    panels[currentPanelIndex].SetActive(true);
  }

  // 回転する前に一度全てのパネルを非表示にする（初期化する）
  public void InactivePanel () {
    for (int i  = 0; i < panels.Length; i++) {
      panels[i].SetActive(false);
    }
  }

  // 左回転の処理
  public void TurnLeft() {
    InactivePanel();
    currentPanelIndex--;
    if (currentPanelIndex < 0) {
      currentPanelIndex = panels.Length -1;
    }
    panels[currentPanelIndex].SetActive(true);
  }

  // 右回転の処理
  public void TurnRight() {
    InactivePanel();
    currentPanelIndex++;
    if (currentPanelIndex >= panels.Length) {
      currentPanelIndex = 0;
    }
    panels[currentPanelIndex].SetActive(true);
  }
}
