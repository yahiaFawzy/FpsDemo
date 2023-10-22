using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager instance;
    public ImagesResources imagesResources;
    public InventoryDataBase inventoryDataBase; 

    private void Awake()
    {
        instance = this;
    }
}
