using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsGame.Classes;

namespace WinFormsGameTestProject
{
    [TestClass]
    public class WorldTest
    {
        private Settings _settings = new Settings(200, 200, 930, 930, 30);
        Level _levelField = new Level(new Settings(200, 200, 930, 930, 30), 1);

        [TestMethod]
        public void LevelTests()
        {
            //var world = new World(new Settings(200,200,930,930,30));
            var level = new Level(_settings, 1);

            Assert.IsNotNull(level.Player, "Player not initialized");
            Assert.IsNotNull(level.Enemies, "Enemies not initialized");
            Assert.IsNull(level.Enemies.Find(x => x.Location == level.Player.Location), "Enemy and player share location");
            Assert.IsFalse(level.Enemies.First().Location == level.Enemies.Last().Location, "Test bad news");

            var badNews = false;

            foreach (var enemy in level.Enemies)
            {
                if (level.Enemies.Exists(x => x != enemy && x.Location == enemy.Location))
                    badNews = true;
            }

            Assert.IsFalse(badNews, "Duplicate locations in enemies.");        
        }

        [TestMethod]
        public void LevelPlayerGetPerformance()
        {
            Assert.IsNotNull(_levelField.Player);
        }

        [TestMethod]
        public void LevelEnemiesGetPerformance()
        {
            Assert.IsNotNull(_levelField.Enemies);
        }
    }
}
