//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.34014
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using Assets.Scripts.Functions.PrefabController;
using Functions.PrefabController;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;


namespace AssemblyCSharp
{
		public class CosFunction:IFunction
		{

            

		private float A;

		private float B;

		private float C;

		    private float D;

		    private bool IsNegative;

		public CosFunction ()
				{
				}
		#region implemented abstract members of IFunction

		    public override void Refresh()
		{
			A = Random.Range(1, 9)*(Random.Range (0,1)*2-1);
			B = Random.Range(1, 4)*(Random.Range (0,1)*2-1);
			C = Random.Range(1, 4)*(Random.Range (0,1)*2-1);
			D = Random.Range(1, 9)*(Random.Range (0,1)*2-1);
			IsNegative = Random.Range (0,1) != 0 ? true : false;
		   }

		    public override void DrawGraph (float time)
		{

		}

		    public override void BeginDraw(GameManager gameManager)
		    {
		        var gameObject = FunctionPrefabContainer.instance.CosGameObject;
                var controller = gameObject.GetComponent<CosFunctionController>();//Controllerをかえる
                controller.A = A;//シェーダーに引数を渡す
                controller.C = C;
                controller.B = B;
		        controller.D = D;
		        controller.IsNegative = IsNegative;
		        gameManager.BasicGraphTarget.ChangeGameObject(gameObject);

		    }

		    private float calcFunc(float x)
		    {
		        return (float) (D*Math.Sin(x*A + B) + C);//TODO
		    }

            public override bool IsHit(Vector2 player)
            {
                if (IsNegative)
                {
                    return calcFunc(player.x) > player.y;
                }
                else
                {
                    return calcFunc(player.x) < player.y;
                }
            }

		public override string functionName {
			get {
				return "LinearFunction";
			}
		}

		public override int functionLevel {
			get {
				return 1;
			}
		}

		    public override float waitingTimeInSecound
		    {
		        get { return 3; }
		    }

		    public override void DrawFormula(GameManager gameManager)
		{
			gameManager.BasicFormulaTarget.text = string.Format("y");
			gameManager.BasicFormulaTarget.text += IsNegative ? string.Format ("<") : string.Format (">");
			if (D != 1) 
			{
				if(D != -1)
				{
					gameManager.BasicFormulaTarget.text += string.Format ("{0}", D);
				}
				else
				{
					gameManager.BasicFormulaTarget.text += string.Format ("-");
				}
			}
			
			if (A == 1)
			{
				gameManager.BasicFormulaTarget.text += string.Format ("cos(x");
			}
			else if(A==-1)
			{
				gameManager.BasicFormulaTarget.text += string.Format ("cos(-x");
			}
			else
			{
				gameManager.BasicFormulaTarget.text += string.Format ("cos({0}x",A);
			}
			if (B > 0)
			{
				gameManager.BasicFormulaTarget.text += string.Format ("+{0})", B);
			}
			else if (B < 0)
			{
				gameManager.BasicFormulaTarget.text += string.Format ("{0})", B);
			}
			else
			{
				gameManager.BasicFormulaTarget.text += string.Format (")");
			}
			
			if (C > 0)
			{
				gameManager.BasicFormulaTarget.text += string.Format ("+{0}", C);
			} 
			else if (C < 0)
			{
				gameManager.BasicFormulaTarget.text += string.Format ("{0}", C);
			} 
                //gameManager.BasicFormulaTarget.text = IsNegative ? string.Format("y<cos({0}x+{1})+{2}", A, B, C) : string.Format("y>cos({0}x+{1})+{2}", A, B, C);//TODO
		    }

		    #endregion


		}
}

