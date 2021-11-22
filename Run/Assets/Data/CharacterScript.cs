using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="DataCharacter", menuName = "character")]
public class CharacterScript : ScriptableObject
{
    public List<GameObject> Character;
    public List<Avatar> avtChar;
    public List<Image> iconChar;

    void Start()
    {
        GameObject obj = Resources.Load<GameObject>("Character/Diona");
        Character.Add(Instantiate(obj));
    }


}
