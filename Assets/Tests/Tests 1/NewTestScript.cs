using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewScriptTest
{
    [UnityTest]
    public IEnumerator PipeDeletionTest()
    {
        // Create a new GameObject and add the PipeMoveScript component to it
        GameObject pipeObject = new GameObject();
        PipeMoveScript pipeScript = pipeObject.AddComponent<PipeMoveScript>();

        // Set the initial position of the pipe
        pipeObject.transform.position = new Vector3(-50, 0, 0);

        // Simulate a frame update
        yield return new WaitForEndOfFrame();

        // Assert that the pipe should be destroyed
        Assert.IsTrue(pipeObject == null);
    }
}
