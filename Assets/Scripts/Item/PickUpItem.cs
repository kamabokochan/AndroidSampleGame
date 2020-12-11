using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour {
  [SerializeField] Item.Type itemType;
    Item item;

  public void Start() {
    item = ItemBoxManager.instance.hogehoge(itemType);
  }
  public void OnClickItem() {
    ItemBoxManager.instance.SetItem(item);
    // アイテムをゲットしたので非表示にする
    gameObject.SetActive(false);
  }
}
