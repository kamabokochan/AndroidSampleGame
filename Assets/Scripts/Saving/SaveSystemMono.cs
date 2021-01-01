using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemMono : MonoBehaviour
{
  public void Save()
  {
    SaveSystem.instance.UserData.UserName = "aaa";
    SaveSystem.instance.Save();
  }

  public void Load()
  {
    SaveSystem.instance.Load();
  }
}
