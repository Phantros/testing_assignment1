using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerManagerVariablesTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        Assert.AreEqual(PlayerManager.Lives, 3);
        Assert.AreEqual(PlayerManager.Score, 0);
        Assert.AreEqual(PlayerManager.Distance, 0);
    }
}
