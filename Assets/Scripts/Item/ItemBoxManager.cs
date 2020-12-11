using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxManager : MonoBehaviour {
  public static ItemBoxManager instance;

  private void Awake() {
    if (instance == null) {
      instance = this;
    }
  }

  [SerializeField] ItemListTable itemListTable;

  Item item;
  [SerializeField] Image image;

  public void SetItem(Item item) {
    this.item = item;
    image.sprite = item.sprite;
  }

  public Item hogehoge(Item.Type type) {
    foreach (Item item in itemListTable.itemList) {
      if (item.type == type) {
        return item;
      }
    }
    return null;
  }
}
