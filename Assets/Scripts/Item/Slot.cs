using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour　{
  Item item;
  [SerializeField] Image image;
  [SerializeField] GameObject backgroundPanel;

  public void Start() {
    backgroundPanel.SetActive(false);
  }

  public bool isEmpty() {
    // クラスメンバのitemにアイテムが格納されているかどうかをチェックする
    return item == null;
  }

  // 画像をスロットに表示する
  public void SetItem(Item item)　{
    this.item = item;
    if (item == null) {
      image.sprite = null;
    } else {
      image.sprite = item.sprite;
    }
  }

  public Item GetItem() {
    return item;
  }

  public bool isSelected() {
    if (isEmpty()) {
      return false;
    }

    OnSelected();
    return true;
  }

  public void OnSelected()
  {
    backgroundPanel.SetActive(true);
  }

  public void HideBGPanel() {
    backgroundPanel.SetActive(false);
  }
}
