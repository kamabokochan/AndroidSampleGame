using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour {
  // どこでも実行できるやつ
  public static ItemBox instance;
  [SerializeField] Slot[] slots;
  [SerializeField] ItemListTable itemListTable;
  Item item;

  [SerializeField] Slot selectedSlot = null;

  // Startより実行タイミングが早い
  private void Awake() {
    if (instance == null) {
      instance = this;
      // 子供のslotを自動的に取得する
      slots = GetComponentsInChildren<Slot>();
    }
  }

  public void SetItem(Item item) {
    foreach (Slot slot in slots) {
      if (slot.isEmpty()) {
        slot.SetItem(item);
        break;
      }
    }
  }

  // データベースにタイプが一致するアイテムがあれば返却する
  public Item checkItemInTable(Item.Type type) {
    foreach (Item item in itemListTable.itemList) {
      if (item.type == type) {
        return item;
      }
    }
    return null;
  }

  public void OnSelectSlot(int position) {
    foreach (Slot slot in slots) {
      slot.HideBGPanel();
    }
    if (slots[position].OnSelected()) {
      selectedSlot = slots[position];
    }
  }

  public bool TryUseItem(Item.Type type) {
    if (selectedSlot == null) {
      return false;
    }
    if (selectedSlot.GetItem().type == type) {
      selectedSlot.SetItem(null);
      selectedSlot.HideBGPanel();
      selectedSlot = null;
      return true;
    }
    return false;
  }
}
