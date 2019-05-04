using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            ComponentRenderer renderer = new ComponentRenderer();
            renderer.AddVisual(new StaticTexture(9, RenderLayer.DirtBase));

            components.AddComponent(new ComponentSelectable(SelectionType.Tile));
            components.AddComponent(new DropWhenCompletelyHarvested(new List<Item>(), string.Empty, string.Empty));
            components.AddComponent(renderer);
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
            Assert.IsNotNull(unitUnderTest.GetExactComponent<DropWhenCompletelyHarvested>());
            Assert.IsNotNull(unitUnderTest.GetComponent<DropWhenCompletelyHarvested>());
            Assert.IsNotNull(unitUnderTest.GetComponent<ComponentHarvestable>());

            Assert.IsTrue(deserialized.HasComponent<DropWhenCompletelyHarvested>());
            Assert.IsNotNull(deserialized.GetExactComponent<DropWhenCompletelyHarvested>());
            Assert.IsNotNull(deserialized.GetComponent<DropWhenCompletelyHarvested>());
            Assert.IsNotNull(deserialized.GetComponent<ComponentHarvestable>());
            Assert.IsNotNull(deserialized.GetExactComponent<ComponentSelectable>(), "Components didn't serialize properly");
            Assert.IsNotNull(deserialized.GetExactComponent<ComponentRenderer>(), "Components didn't serialize properly");
        }
    }
}