using UnityEngine;

public class PlayerPrefsCharacterSaver : MonoBehaviour
{
    public KingdomData kingdomData;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveKingdom(kingdomData, 0);

        if (Input.GetKeyDown(KeyCode.L))
            kingdomData = LoadKingdom(0);
    }

    static void SaveKingdom(KingdomData data, int fileNumber)
    {
        PlayerPrefs.SetString("kingdom_Name" + fileNumber, data.kingdomName);
        PlayerPrefs.Save();
    }

    static KingdomData LoadKingdom(int fileNumber)
    {
        KingdomData LoadedKingdom = new KingdomData();
        LoadedKingdom.kingdomName = PlayerPrefs.GetString("characterName_CharacterSlot" + fileNumber);

        return LoadedKingdom;
    }
}