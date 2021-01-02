using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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

  public void SetItem(Item item)
  {
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

  public void OnSelectSlot(int position)
  {
    // スロットの選択状態を全て解除
    foreach (Slot slot in slots) {
      slot.HideBGPanel();
    }

    // まず空にする
    selectedSlot = null;

    if (slots[position].isSelected())
    {
      selectedSlot = slots[position];
    }
    else
    {
      // selectedSlotがnullのままだったら処理終了
      return;
    }

    // ミルクとイチゴを混ぜる
    MixStoroberryAndMilk();
  }

  public void MixStoroberryAndMilk()
  {
    if (ZoomPanel.instance != null)
    {
      Item.Type selectedSlotType = selectedSlot.GetItem().type;
      Item.Type zoomItemType = ZoomPanel.instance.GetZoomItem().type;
      if (zoomItemType == Item.Type.Milk && selectedSlotType == Item.Type.Storoberry)
      {
        foreach (Slot slot in slots)
        {
          // 選択状態解除
          slot.HideBGPanel();
          // 空のスロットはcontinueする
          if (slot.GetItem() == null)
          {
            continue;
          }
          // ミルクのスロットだったらイチゴミルクを代入する
          if (slot.GetItem().type == Item.Type.Milk)
          {
            foreach (Item item in itemListTable.itemList)
            {
              if (item.type == Item.Type.StoroberryMilk)
              {
                slot.SetItem(item);
                ZoomPanel.instance.SetZoomItem(item);
                selectedSlot.SetItem(null);

                // TODO あとで整理する
                // usedItemに追加
                string[] array = { };
                string[] hoge = { "Milk", "Storoberry" };
                foreach (string fuga in hoge)
                {
                  array = array.Concat(new string[] { fuga }).ToArray();
                }
                SaveSystem.instance.UserData.usedItem = array;
                SaveSystem.instance.Save();
                break;
              }
            }
          }
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
  public string[] savetest()
  {
    string[] array = { };
    foreach (Slot slot in slots)
    {
      if (slot.GetItem() == null)
      {
        continue;
      }
      string type = slot.GetItem().type.ToString();
      Debug.Log(type);
      array = array.Concat(new string[] { type }).ToArray();
    }
    return array;
  }

  public void loadtest()
  {
    foreach (string aaa in SaveSystem.instance.UserData.Items)
    {
      foreach (Item item in itemListTable.itemList)
      {
        if (item.type.ToString() == aaa)
        {
          SetItem(item);
        }
      }
    }
  }
}
