using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PipeMoveScriptPlayModeTest
{
    [UnityTest]
    public IEnumerator PipeDeletionTest()
    {
        GameObject pipeObject = new GameObject();
        PipeMoveScript pipeScript = pipeObject.AddComponent<PipeMoveScript>();

        // Set the initial position of the pipe to a value beyond the deadZone
        pipeObject.transform.position = new Vector3(-50, 0, 0);

        // Simulate the behavior by waiting for a frame update
        yield return null;

        // Assert that the pipe should be destroyed
        Assert.IsTrue(pipeObject == null);
    }
}
