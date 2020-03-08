using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text shortDescText;
    [SerializeField] private Text sellPriceText;
    [SerializeField] private Text rarityText;
    [SerializeField] private GameObject resultMenu;
    [SerializeField] private GameObject summaryMenu;

    public void ShowResultScreen(Fish fish) {
        nameText.text = fish.name;
        shortDescText.text = "Description: " + fish.description;
        sellPriceText.text = "Sell Price: " + fish.sellPrice;
        rarityText.text = "Rarity: " + fish.rarity.ToString();
        summaryMenu.GetComponent<Image>().sprite = fish.picture;
        resultMenu.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
