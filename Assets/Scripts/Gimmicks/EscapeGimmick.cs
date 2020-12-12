using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeGimmick : MonoBehaviour {
  // 鍵を洗濯した状態でクリックしたらドアが開く

  [SerializeField] Item.Type item;
  [SerializeField] GameObject openDoor;
  public void OnClickDoor() {
    bool clear = ItemBox.instance.TryUseItem(item);
    if (clear) {
      
      gameObject.SetActive(false);
      openDoor.SetActive(true);
    }
  }
}
