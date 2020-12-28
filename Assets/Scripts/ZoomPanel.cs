using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomPanel : MonoBehaviour
{
  public static ZoomPanel instance;

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }

  [SerializeField] GameObject panel;
  [SerializeField] Image image;
  public Item zoomItem = null;
  public void ShowPanel()
  {
    zoomItem = ItemBox.instance.GetSelectedItem();
    if (zoomItem != null)
    {
      panel.SetActive(true);
      SetImage();
    }
  }

  public void HidePanel()
  {
    panel.SetActive(false);
  }

  public Item GetZoomItem()
  {
    if (zoomItem == null)
    {
      return null;
    }
    return zoomItem;
  }

  public void SetZoomItem(Item item)
  {
    zoomItem = item;
    SetImage();
  }

  public void SetImage()
  {
    image.sprite = zoomItem.sprite;
  }
}
