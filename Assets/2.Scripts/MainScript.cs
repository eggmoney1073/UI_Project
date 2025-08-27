using UnityEngine;

public class MainScript : SingletonGameobject<MainScript>
{
    [SerializeField] GameObject _popupPrefab;
    [SerializeField] GameObject _popupCanvas;
    
    Main_PopUp _popUp;

    public void GetButton()
    {        
        Debug.Log("GetButton");
        
        GameObject popup = Instantiate(_popupPrefab, _popupCanvas.transform);
        _popUp = popup.GetComponent<Main_PopUp>();
        _popUp.ChestIn();
    }
}
