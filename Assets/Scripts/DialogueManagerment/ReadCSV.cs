using UnityEngine;
using System;

public class ReadCSV : MonoBehaviour
{
    public TextAsset staticData;

    [System.Serializable]
    public class structuredDataRow
    {
        public string[] parameter;
    }

    [System.Serializable]
    public class structuredDataList
    {
        public structuredDataRow[] rows;
    }

    public structuredDataList myStructuredData = new structuredDataList();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        readCSV();
    }


    void readCSV()
    {
        string[] totalRows = staticData.text.Split("\n");
        int numColumns = totalRows[0].Split("|").Length;

        myStructuredData.rows = new structuredDataRow[totalRows.Length];
        for (int i=0; i< totalRows.Length; i++)
        {
            myStructuredData.rows[i] = new structuredDataRow();
            myStructuredData.rows[i].parameter = new string[numColumns];
        }
        
        for (int i=0; i< totalRows.Length-1; i++)
        {
            for (int j=0; j< numColumns; j++)
            {
                myStructuredData.rows[i].parameter[j] = totalRows[i].Split("|")[j];
            }
        }
    }
}
