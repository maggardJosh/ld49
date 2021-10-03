﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CutoutMaskUI : Image
{
   public override Material materialForRendering
   {
      get
      {
         var material = new Material(base.materialForRendering);
         material.SetInt("_StencilComp", (int) CompareFunction.NotEqual);
         return material;
      }
   }
}
