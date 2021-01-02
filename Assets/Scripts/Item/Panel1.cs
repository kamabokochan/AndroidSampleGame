using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel1 : MonoBehaviour
{
  public static Panel1 instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    //   // 子供のslotを自動的に取得する
    //   slots = GetComponentsInChildren<Slot>();
    }
  }
  [SerializeField] GameObject[] items;
//   [SerializeField] Item.Type type;

  public void checkItem()
  {
    foreach (string aaa in SaveSystem.instance.UserData.Items)
    {
      foreach (GameObject item in items)
      {
        if (aaa == item.name)
        {
          item.SetActive(false);
        }
      }
    }
    foreach (string bbb in SaveSystem.instance.UserData.usedItem)
    {
      foreach (GameObject item in items)
      {
        if (bbb == item.name)
        {
          item.SetActive(false);
        }
      }
    }
  }
}
