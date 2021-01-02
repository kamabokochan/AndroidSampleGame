using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemMono : MonoBehaviour
{
  public void Save()
  {
    SaveSystem.instance.UserData.Items = ItemBox.instance.savetest();
    SaveSystem.instance.Save();
  }

  public void Load()
  {
    SaveSystem.instance.Load();
    ItemBox.instance.loadtest();
    Panel1.instance.checkItem();
  }

  public void Reset()
  {
    SaveSystem.instance.Reset();
  }
}
