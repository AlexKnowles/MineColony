using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using MineColony.Game.Systems;
using UnityEditor;

namespace MineColony.Tests.Systems
{
    public class TaskBacklog_Enqueue
    {

        [Test]
        public void FirstTestSimplePasses()
        {

            //TaskBacklog taskBacklog = (TaskBacklog)AssetDatabase.LoadAssetAtPath("/Game/Systems", typeof(TaskBacklog));

            //taskBacklog.TaskCollection 

            //Object task = new Object();


            //taskBacklog.Enqueue(task)
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator FirstTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
        }
    }
}