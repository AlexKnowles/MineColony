using MineColony.Game.Systems;
using MineColony.Tests.Builders;
using MineColony.Tests.Utilities;
using NUnit.Framework;
using UnityEngine;

namespace MineColony.Tests.Systems
{
    public class TaskBacklog_Enqueue
    {
        [Test]
        public void TaskIsAddedToCollection()
        {
            TaskBacklog taskBacklog = new TaskBacklogBuilder().AddTaskCollection().AddOnTaskEnqueue().Build();

            Object task = new Object();
            taskBacklog.Enqueue(task);

            Assert.AreEqual(1, taskBacklog.TaskCollection.Count);
        }

        [Test]
        public void TaskIsAddedToCollectionWhenNoTriggerIsAttached()
        {
            TaskBacklog taskBacklog = new TaskBacklogBuilder().AddTaskCollection().Build();

            Object task = new Object();
            taskBacklog.Enqueue(task);

            Assert.AreEqual(1, taskBacklog.TaskCollection.Count);
        }

        [Test]
        public void GameEventTriggerFiresOnEnqueue()
        {
            GameEventListenerFacade gameEventListenerFacade = new GameEventListenerFacade();
            TaskBacklog taskBacklog = new TaskBacklogBuilder().AddTaskCollection().AddOnTaskEnqueue(gameEventListenerFacade).Build();

            Object task = new Object();
            taskBacklog.Enqueue(task);

            Assert.IsTrue(gameEventListenerFacade.EventWasRaised);
        }
    }
}