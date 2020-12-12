using System;
using UnityEngine;

[Serializable]
public class Item {
    public enum Type {
        Key,
        Ball
    }

    // 種類
    public Type type;
    // 画像
    public Sprite sprite;
}
