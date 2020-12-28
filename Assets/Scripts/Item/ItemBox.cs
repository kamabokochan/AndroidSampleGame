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

    // まず空にする
    selectedSlot = null;

    if (slots[position].OnSelected())
    {
      selectedSlot = slots[position];
    }

    if (selectedSlot == null)
    {
      return;
    }

    Item.Type selectedSlotType = selectedSlot.GetItem().type;

    if (ZoomPanel.instance == null)
    {
      return;
    }

    Item.Type zoomItemType = ZoomPanel.instance.GetZoomItem().type;

    if (zoomItemType == Item.Type.Milk && selectedSlotType == Item.Type.Storoberry)
    {
      foreach (Slot slot in slots)
      {
        if (slot.GetItem().type == Item.Type.Milk)
        {
          foreach (Item item in itemListTable.itemList)
          {
            if (item.type == Item.Type.StoroberryMilk)
            {
              slot.SetItem(item);
              ZoomPanel.instance.SetZoomItem(item);
              selectedSlot.SetItem(null);

              // TODO 修正
              foreach (Slot slot1 in slots)
              {
                slot1.HideBGPanel();
                if (slot1.GetItem() == null)
                {
                  continue;
                }
                else if (slot1.GetItem().type == Item.Type.StoroberryMilk)
                {
                  if (slot1.OnSelected())
                  {
                    selectedSlot = slot1;
                  }
                }
              }
              break;
            }
          }
          break;
        }
      }
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

  public Item GetSelectedItem()
  {
    if (selectedSlot == null)
    {
      return null;
    }
    return selectedSlot.GetItem();
  }
}
