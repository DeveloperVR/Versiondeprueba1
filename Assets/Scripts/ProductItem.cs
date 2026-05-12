using UnityEngine;

public class ProductItem : MonoBehaviour
{
    [Header("Información")]
    public string productName;

    public Sprite productIcon;

    private bool alreadySelected = false;

    public void SelectProduct()
    {
        if (alreadySelected)
            return;

        alreadySelected = true;

        ShoppingManager.instance.AddProduct(this);

        Debug.Log(productName + " agregado");
    }
}