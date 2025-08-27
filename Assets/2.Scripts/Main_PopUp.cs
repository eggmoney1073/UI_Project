using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Main_PopUp : MonoBehaviour
{
    [SerializeField] GameObject _chest;
    [SerializeField] GameObject _touchScreen;
    [SerializeField] ItemInfo _itemInfo;
    [SerializeField] Image _chest_Image;

    [SerializeField] float _lightingSpeed = 2f;

    [SerializeField] Texture _closedChest;
    [SerializeField] Texture _chestSpecial;
    [SerializeField] Texture _chestNormal;

    bool _isOpened = false;
    int _rate = 1;

    Animator _chest_Animator;
    Material _chest_Material;
    

    enum AnimationTrigger
    {
        Move,
        Open
    }

    public void ChestIn()
    {
        Initialize();
        _chest_Animator.SetTrigger(AnimationTrigger.Move.ToString());
        _touchScreen.SetActive(true);
    }

    public void OpenButton()
    {
        if (_isOpened)
        {
            Destroy(gameObject);
            return;
        }

        _isOpened = true;


        // 1 ~ 10 까지 나오는 난수
        _rate = Random.Range(1, 11);
        Debug.Log("Rate : " + _rate);

        // 7,8,9,10 이면 Special Open
        if (_rate > 6)
        {
            Debug.Log("SpecialOpenButton");
            StartCoroutine(Lighting());
        }
        // 1 ~ 6 이면 Normal Open
        else
        {
            Debug.Log("OpenButton");
            _chest_Animator.SetTrigger(AnimationTrigger.Open.ToString());
            StartCoroutine(OpenChest(_chestNormal));
        }
    }

    IEnumerator OpenChest(Texture texture)
    {
        for (int i = 0; i < 40; i++)
        {
            yield return null;
        }
        _chest_Material.SetFloat("_Brightness", 1f);
        _chest_Material.SetTexture("_MainTexture", texture);

        for (int i = 0; i < 20; i++)
        {
            yield return null;
        }

        _itemInfo.gameObject.SetActive(true);
        _itemInfo.SetItem(_rate);
    }

    IEnumerator Lighting()
    {
        float lightingIndex = 0f;
        while (lightingIndex < 1f)
        {
            lightingIndex += Time.deltaTime * _lightingSpeed;
            _chest_Material.SetFloat("_Effect_Value", lightingIndex);
            yield return null;
        }
        _chest_Animator.SetTrigger(AnimationTrigger.Open.ToString());
        StartCoroutine(OpenChest(_chestSpecial));
    }

    void Initialize()
    {
        _chest_Animator = _chest.GetComponent<Animator>();
        _chest_Material = _chest_Image.material;
        _chest_Material.SetTexture("_MainTexture", _closedChest);
        _chest_Material.SetFloat("_Brightness", 0.01f);

    }
}
