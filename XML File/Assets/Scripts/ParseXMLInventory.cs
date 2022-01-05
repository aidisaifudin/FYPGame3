using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using TMPro;


public class ParseXMLInventory : MonoBehaviour
{   public TextAsset scoreDataTextFile;
    public TextMeshProUGUI textDisplay;

    void Start()
    {
        string textData = scoreDataTextFile.text;
        ParseScoreXML(textData);
    }

    void ParseScoreXML(string xmlData)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));

        string xmlPathPattern = "//inventory/food";
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);

        foreach (XmlNode node in myNodeList)
            textDisplay.text += ScoreRecordString(node) + "<br>";
        //Debug.Log(ScoreRecordString(node));

        XmlNodeList item = xmlDoc.GetElementsByTagName("cost");
        textDisplay.text += item[0].Name + ": " + item[0].ChildNodes[0].InnerText;
    }

    string ScoreRecordString(XmlNode node)
    {
        XmlNode playerNode = node.FirstChild;
        XmlNode scoreNode = playerNode.NextSibling;

       

        return "cost = " + playerNode.InnerXml + ", quantity = " + scoreNode.InnerXml;
    }

    string DateString(XmlNode dateNode)
    {
        XmlNode dayNode = dateNode.FirstChild;
        XmlNode monthNode = dayNode.NextSibling;
        XmlNode yearNode = monthNode.NextSibling;

        return dayNode.InnerXml + "/" + monthNode.InnerXml + "/" + yearNode.InnerXml;
    }
   
}
