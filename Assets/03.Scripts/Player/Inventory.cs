using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    // === ������ ȹ��� ǥ������ â ===
    public Image icon;
    public TextMeshProUGUI displayDescription;

    // === �������� ������ ����Ʈ ===
    public List<ItemData> inventory = new();

    // === ��Ÿ�� �ð� ===
    public Image image;
    public float flashSpeed;

    // === �ڷ�ƾ ���� ===
    private Coroutine _coroutine;

    // === �̱��� ===
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // === ������ ȹ��� ǥ�� ===
    public void GetItem(ItemData item)
    {
        inventory.Add(item);

        icon.sprite = item.icon;
        displayDescription.text = item.Description;
        displayDescription.gameObject.SetActive(true);
    }

    // === ������ ���� ===
    public void UseItem()
    {
        Flash();

        inventory.Clear();

        icon.sprite = null;
        displayDescription.text = null;
        displayDescription.gameObject.SetActive(false);
    }

    // === ȭ�� ��½�� �޼��� ===
    void Flash()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        image.enabled = true;
        image.color = new Color(0, 0, 1f);
        _coroutine = StartCoroutine(FadeAway());
    }

    // === ȭ���� ��½�� �ڷ�ƾ ===
    private IEnumerator FadeAway()
    {
        flashSpeed = GameManager.Instance.PlayerManager.Player.controller.jumpBoostDuration;

        // === ȭ�� ������ ===
        float startAlpa = 0.3f;
        float a = startAlpa;

        while (a > 0)
        {
            a -= (startAlpa / flashSpeed) * Time.deltaTime;
            image.color = new Color(0, 0, 1f, a);
            yield return null;
        }

        yield return new WaitForSeconds(flashSpeed);

        image.enabled = false;
    }
}
