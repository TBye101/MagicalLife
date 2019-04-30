using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Mod;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Tiles;
using MagicalLifeServer;
using MagicalLifeServer.Load;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace MagicalLifeAPITest.Components
{
    [TestClass]
    public class HasComponentsTests
    {
        private bool Initialized { get; set; } = false;

        [TestInitialize]
        public void TestInitialize()
        {
            if (!this.Initialized)
            {
                MasterLog.Initialize();
                Loader load = new Loader();
                string msg = string.Empty;
                SettingsManager.Initialize();
                FileSystemManager.Initialize();
                load.LoadAll(ref msg, new List<IGameLoader>()
                    {
                        new ProtoTypeLoader(),
                        new ProtoManager(),
                    });
                this.Initialized = true;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            MasterLog.Close();
        }

        private HasComponents CreateHasComponents()
        {
            HasComponents components = new HasComponents(true);
            components.AddComponent(new ComponentSelectable(SelectionType.Tile));
            components.AddComponent(new DropWhenCompletelyHarvested(new List<Item>(), string.Empty, string.Empty));
            return components;
        }

        [TestMethod]
        public void GetExactComponent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            HasComponents unitUnderTest = this.CreateHasComponents();

            // Act
            ComponentSelectable result = unitUnderTest.GetExactComponent<ComponentSelectable>();
            ComponentHarvestable result2 = unitUnderTest.GetExactComponent<ComponentHarvestable>();
            DropWhenCompletelyHarvested result3 = unitUnderTest.GetExactComponent<DropWhenCompletelyHarvested>();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result2);
            Assert.IsNotNull(result3);
        }

        [TestMethod]
        public void GetComponent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            HasComponents unitUnderTest = this.CreateHasComponents();

            // Act
            ComponentSelectable result = unitUnderTest.GetComponent<ComponentSelectable>();
            ComponentHarvestable result2 = unitUnderTest.GetComponent<ComponentHarvestable>();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result2);
        }

        [TestMethod]
        public void AddComponent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            HasComponents unitUnderTest = this.CreateHasComponents();
            ComponentSelectable selectable = new ComponentSelectable(SelectionType.Tile);
            DropWhenCompletelyHarvested component = new DropWhenCompletelyHarvested(new List<Item>(), "", "");

            // Act
            unitUnderTest.ClearComponents();
            unitUnderTest.AddComponent(component);

            // Assert
            Assert.IsTrue(unitUnderTest.HasComponent<DropWhenCompletelyHarvested>());
            Assert.IsTrue(unitUnderTest.GetExactComponent<DropWhenCompletelyHarvested>() != null);
            Assert.IsTrue(unitUnderTest.GetComponent<DropWhenCompletelyHarvested>() != null);
            Assert.IsTrue(unitUnderTest.GetComponent<ComponentHarvestable>() != null);
        }

        [TestMethod]
        public void HasComponent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            HasComponents unitUnderTest = this.CreateHasComponents();

            // Act
            bool result = unitUnderTest.HasComponent<ComponentHarvestable>();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestHasComponentSerialization()
        {
            // Arrange
            HasComponents unitUnderTest = this.CreateHasComponents();

            // Act
            byte[] data = ProtoUtil.Serialize(unitUnderTest);

            Assert.IsNotNull(data, "Serialization failed");

            HasComponents deserialized = ProtoUtil.Deserialize<HasComponents>(data);

            // Assert
            Assert.IsNotNull(deserialized, "Deserialization failed");

            Assert.IsTrue(unitUnderTest.HasComponent<DropWhenCompletelyHarvested>());
            Assert.IsTrue(unitUnderTest.GetExactComponent<DropWhenCompletelyHarvested>() != null);
            Assert.IsTrue(unitUnderTest.GetComponent<DropWhenCompletelyHarvested>() != null);
            Assert.IsTrue(unitUnderTest.GetComponent<ComponentHarvestable>() != null);

            Assert.IsTrue(deserialized.HasComponent<DropWhenCompletelyHarvested>());
            Assert.IsTrue(deserialized.GetExactComponent<DropWhenCompletelyHarvested>() != null);
            Assert.IsTrue(deserialized.GetComponent<DropWhenCompletelyHarvested>() != null);
            Assert.IsTrue(deserialized.GetComponent<ComponentHarvestable>() != null);
        }
    }
}
