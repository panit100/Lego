using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : EnemyController
{
    public override void PrintWelcomeText()
    {
        Debug.Log("Red Enemy");
        Item item = new Item();
        int p = item.getPrice();
        Debug.Log("Price = " + p);
    }
    protected override void ChangeColor(MeshRenderer meshRenderer)
    {
        meshRenderer.material.color = Color.red;

    }
    protected override void ChangeScale(float size){
		Vector3 scaleChange = new Vector3(size,size,size);
		transform.localScale += scaleChange;
	}	
}

class Item{
    int price = 10;

    public int getPrice(){
        return price;
    }
}
