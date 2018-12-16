using MineColony.Game.Systems;
using MineColony.TestUtilities.Builders;
using NUnit.Framework;
using UnityEngine;

namespace MineColony.Tests.Systems
{
    public class TaskBacklog_Dequeue
    {
        [Test]
        public void TaskIsRemovedFromBacklog()
        {
            Task existingTask = new TaskBuilder().AddName("Task1").Build();
            TaskBacklog taskBacklog = new TaskBacklogBuilder().AddTaskCollection(existingTask).Build();

            Object dequeuedTask = taskBacklog.Dequeue();

            Assert.AreEqual(0, taskBacklog.TaskCollection.Count);
            Assert.AreEqual("Task1", dequeuedTask.name);
        }

        [Test]
        public void FirstTaskInCollectionIsRemoved()
        {
            Task existingTask1 = new TaskBuilder().AddName("Task123").Build();
            Task existingTask2 = new TaskBuilder().AddName("Task2").Build();
            Task existingTask3 = new TaskBuilder().AddName("Task3").Build();
            Task existingTask4 = new TaskBuilder().AddName("Task4").Build();
            TaskBacklog taskBacklog = new TaskBacklogBuilder().AddTaskCollection(existingTask1, existingTask2, existingTask3, existingTask4).Build();

            Object dequeuedTask = taskBacklog.Dequeue();

            Assert.AreEqual(3, taskBacklog.TaskCollection.Count);
            Assert.AreEqual("Task123", dequeuedTask.name);
        }

        [Test]
        public void NullReturnedWhenCollectionIsEmpty()
        {
            TaskBacklog taskBacklog = new TaskBacklogBuilder().AddTaskCollection().Build();

            Task dequeuedTask = taskBacklog.Dequeue();

            Assert.AreEqual(null, dequeuedTask);
        }
    }
}
