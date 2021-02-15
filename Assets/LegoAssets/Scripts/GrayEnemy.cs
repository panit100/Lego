using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayEnemy : EnemyController
{
    public override void PrintWelcomeText()
    {
        base.PrintWelcomeText();
        Debug.Log("Gray Enemy");
    }
    protected override void ChangeColor(MeshRenderer meshRenderer)
    {
        meshRenderer.material.color = Color.gray;
    }
    protected override void ChangeScale(float size){
		Vector3 scaleChange = new Vector3(size,size,size);
		transform.localScale += scaleChange;
	}
}
