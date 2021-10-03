using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
   [SerializeField] private string levelString = "0-0";
   [SerializeField] private TextMeshProUGUI buttonText;
   [SerializeField] private TextMeshProUGUI recordText;
   
   public void UpdateDisplay()
   {
      buttonText.text = levelString;
      float recordTime = LevelTimer.GetRecordForLevel(levelString);
      if(recordTime > 0)
      {
         recordText.text = LevelTimer.GetTimeString(recordTime);
         recordText.gameObject.SetActive(true);
      }
      else
         recordText.gameObject.SetActive(false);
   }
   

   public void ButtonClick()
   {
      LevelSelect.Instance.OnButtonClick(levelString);
   }
}
