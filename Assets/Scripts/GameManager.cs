using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string BOBBER = "Bobber";

    public Fish[] fishes;
    public GameObject bobber;
    private bool isFishing;
    private bool onHook;
    private bool readyFishing;
    private Fish caughtFish;

    public UIManager uiManager;

    void Start()
    {
        SetFishingState(true, false, false);
        caughtFish = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyFishing)
        {
            StartFishing();
        }

        if (isFishing)
        {
            EncounterWithFish();
        }

        if (onHook)
        {
            CatchFish();
        }
    }

    private void StartFishing()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(bobber, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                SetFishingState(false, true, false);
            }
        }
    }

    private void EncounterWithFish()
    {
        while (caughtFish == null) {
            int index = Random.Range(0, fishes.Length);
            float catchRate = GetCatchRate(fishes[index]);
            float rand = Random.value * 100;

            if (rand < catchRate)
            {
                caughtFish = fishes[index];
                StartCoroutine(WaitForFish());
            }
        }
    }

    private void CatchFish()
    {
        GameObject.FindGameObjectWithTag(BOBBER).GetComponent<Bobber>().Shake();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == BOBBER) {
                    uiManager.ShowResultScreen(caughtFish);
                    SetFishingState(false, false, false);
                }
            }
        }
    }

    private void SetFishingState(bool ready, bool fishing, bool hook)
    {
        readyFishing = ready;
        isFishing = fishing;
        onHook = hook;
    }

    private float GetCatchRate(Fish fish)
    {
        switch (fish.rarity)
        {
            case Fish.Rarity.Common: return 100f;
            case Fish.Rarity.Uncommon: return 40f;
            case Fish.Rarity.Rare: return 13.3f;
            case Fish.Rarity.Epic: return 6.7f;
            case Fish.Rarity.Legendary: return 1.9f;
            case Fish.Rarity.Mythical: return 0.1f;
            default: return 50f;
        }
    }

    IEnumerator WaitForFish() {
        yield return new WaitForSeconds(Random.value * 3f);
        SetFishingState(false, false, true);
    }
}
