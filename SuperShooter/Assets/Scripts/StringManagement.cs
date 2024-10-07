using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class StringManagement : MonoBehaviour
{
    // using string.Format can replace just replace placeholders in string and save memory.
    // StringBuilder will be concatenated in a list instead of using +.
    string name = "John";
    string score = "100";
    string template = "{0} has won {1} points";
    // Start is called before the first frame update
    void Start()
    {
        print(string.Format(template, name, score)); // John has won 100 points
        print($"{name} has won {score} points");

        StringBuilder builder = new StringBuilder();
        builder.Append("My ");
        builder.Append("name ");
        builder.Append("is ");
        builder.Append("Neo. ");
        print(builder.ToString()); // My name is Neo.

    }

    // Update is called once per frame
    void Update()
    {

    }
}
