using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Dialogue Option",menuName ="DialogueOption")]
public class DialogueOption : DialogueBase
{
 
    [System.Serializable]
    public class Options
    {
        public string buttonName;
    }
    public Options[] optioninfo;
}
