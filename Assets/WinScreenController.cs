using System.Collections;
using System.Collections.Generic;
using ImportedTools;
using UnityEngine;

public class WinScreenController : Singleton<WinScreenController>
{
   [SerializeField] private GameObject winScreen;

   public void ShowWin()
   {
      winScreen.SetActive(true);
   }
}
