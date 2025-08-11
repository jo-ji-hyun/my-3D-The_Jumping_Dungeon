using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    // === 아이템 획득시 표시해줄 창 ===
    public Image icon;
    public TextMeshProUGUI displayDescription;

    // === 아이템을 저장할 리스트 ===
    public List<ItemData> inventory = new();

    // === 나타낼 시간 ===
    public Image image;
    public float flashSpeed;

    // === 코루틴 설정 ===
    private Coroutine _coroutine;

    // === 싱글톤 ===
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // === 아이템 획득시 표현 ===
    public void GetItem(ItemData item)
    {
        inventory.Add(item);

        icon.sprite = item.icon;
        displayDescription.text = item.Description;
        displayDescription.gameObject.SetActive(true);
    }

    // === 아이템 사용시 ===
    public void UseItem()
    {
        Flash();

        inventory.Clear();

        icon.sprite = null;
        displayDescription.text = null;
        displayDescription.gameObject.SetActive(false);
    }

    // === 화면 번쩍임 메서드 ===
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

    // === 화면을 번쩍일 코루틴 ===
    private IEnumerator FadeAway()
    {
        flashSpeed = GameManager.Instance.PlayerManager.Player.controller.jumpBoostDuration;

        // === 화면 불투명도 ===
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
