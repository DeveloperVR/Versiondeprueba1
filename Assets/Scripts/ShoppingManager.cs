using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{
    public static ShoppingManager instance;

    public List<ProductItem> selectedProducts =
        new List<ProductItem>();

    public InventoryUI inventoryUI;

    private void Awake()
    {
        instance = this;
    }

    public void AddProduct(ProductItem product)
    {
        selectedProducts.Add(product);

        inventoryUI.AddIcon(product.productIcon);

        Debug.Log(product.productName + " agregado");
    }
}