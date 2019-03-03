using MineColony.Game.Systems;
using MineColony.TestUtilities.Builders;
using NUnit.Framework;

namespace MineColony.Tests.Systems
{
    public class Tiles_GetValueBasedOnDistance
    {
        [Test]
        public void Distance_One_Value_Positive()
        {
            Tiles tiles = new TilesBuilder().Build();

            float result = tiles.GetValueBasedOnDistance(12.51645f, 1f);
            
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Distance_One_Value_Negative()
        {
            Tiles tiles = new TilesBuilder().Build();

            float result = tiles.GetValueBasedOnDistance(-66.213f, 1f);

            Assert.AreEqual(-67f, result);
        }

        [Test]
        public void Distance_Two_Value_Positive()
        {
            Tiles tiles = new TilesBuilder().Build();

            float result = tiles.GetValueBasedOnDistance(11.05612f, 2f);

            Assert.AreEqual(10, result);
        }

        [Test]
        public void Distance_Two_Value_Negative()
        {
            Tiles tiles = new TilesBuilder().Build();

            float result = tiles.GetValueBasedOnDistance(-31.1223f, 2f);

            Assert.AreEqual(-32f, result);
        }
        
        [Test]
        public void Distance_Half_Value_Positive()
        {
            Tiles tiles = new TilesBuilder().Build();

            float result = tiles.GetValueBasedOnDistance(631.54123f, 0.5f);

            Assert.AreEqual(631.5f, result);
        }

        [Test]
        public void Distance_Half_Value_Negative()
        {
            Tiles tiles = new TilesBuilder().Build();

            float result = tiles.GetValueBasedOnDistance(-865.1223f, 0.5f);

            Assert.AreEqual(-865.5f, result);
        }
    }
}
