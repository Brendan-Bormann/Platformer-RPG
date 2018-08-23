using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject combatText;

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
}
