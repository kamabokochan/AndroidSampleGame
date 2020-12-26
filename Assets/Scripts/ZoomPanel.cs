using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomPanel : MonoBehaviour
{
  [SerializeField] GameObject panel;
  [SerializeField] Image image;

  public void ShowPanel()
  {
    Item item = ItemBox.instance.GetSelectedItem();
    if (item != null)
    {
      panel.SetActive(true);
      image.sprite = item.sprite;
    }
  }

  public void HidePanel()
  {
    panel.SetActive(false);
  }
}
