using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject combatText;
	[SerializeField] private GameObject gameMenu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCombatText(Vector3 location, int damage, Color myColor, bool isCrit)
    {
        GameObject hitText = Instantiate(combatText, new Vector3(location.x, location.y, location.z + 1), new Quaternion(0, 0, 0, 0)) as GameObject;
        CombatText script = hitText.GetComponent<CombatText>();
        script.init(damage, myColor, isCrit);
    }

	public void SpawnText(Vector3 location, string message , Color myColor)
    {
        GameObject hitText = Instantiate(combatText, new Vector3(location.x, location.y, location.z + 1), new Quaternion(0, 0, 0, 0)) as GameObject;
        CombatText script = hitText.GetComponent<CombatText>();
        script.initText(message, myColor);
    }

	public void DisplayGameMenu(string menu)
	{

		Text menuTitle = gameMenu.GetComponentInChildren<Text>();

		if (menu == "combat")
		{
			gameMenu.SetActive(!gameMenu.activeSelf);
			menuTitle.text = "Combat";
		}
		if (menu == "spells")
		{
			gameMenu.SetActive(!gameMenu.activeSelf);
			menuTitle.text = "Spells";
		}
		if (menu == "stats")
		{
			gameMenu.SetActive(!gameMenu.activeSelf);
			menuTitle.text = "Stats";
		}
		if (menu == "money")
		{
			gameMenu.SetActive(!gameMenu.activeSelf);
			menuTitle.text = "Money";
		}
	}

	public void HideGameMenu()
	{
		gameMenu.SetActive(false);
	}
}
