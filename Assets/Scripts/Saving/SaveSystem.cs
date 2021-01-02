using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem
{
    #region Singleton
    public static SaveSystem instance = new SaveSystem();
    public static SaveSystem CombineInstance => instance;
    #endregion

  public SaveSystem() { }
  public string Path => Application.dataPath + "/data.json";
  // private UserData userData = new UserData();

  public UserData UserData { get; private set; }

  public void Save()
  {
    string jsonData = JsonUtility.ToJson(UserData);
    // true: 追記, false: 上書き
    StreamWriter writer = new StreamWriter(Path, false);
    writer.WriteLine(jsonData);
    writer.Flush();
    writer.Close();
    Debug.Log("セーブしました");
  }

  public void Load()
  {
    if (!File.Exists(Path))
    {
      Debug.Log("初回起動");
      UserData = new UserData();
      Save();
      return;
    }

    StreamReader reader = new StreamReader(Path);
    string jsonData = reader.ReadToEnd();
    UserData = JsonUtility.FromJson<UserData>(jsonData);
    reader.Close();
  }

  public void Reset()
  {
    UserData = new UserData();
    Save();
  }
}