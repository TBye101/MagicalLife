using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Base;
using System;
using System.Collections.Generic;
using Xunit;

namespace MagicalLifeAPITest.Components
{
    public class HasComponentsTests : IDisposable
    {
        private bool Initialized { get; set; }


        public HasComponentsTests()
        {
            if (!this.Initialized)
            {
                MasterLog.Initialize();
                Loader load = new Loader();
                string msg = string.Empty;
                SettingsManager.Initialize();
                FileSystemManager.Initialize();
                load.LoadAll(ref msg, new List<IGameLoader>
                    {
                        new ProtoTypeLoader(),
                        new ProtoManager(),
                    });
                this.Initialized = true;
            }
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

        [Fact]
        public void GetExactComponent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            HasComponents unitUnderTest = this.CreateHasComponents();

            // Act
            ComponentSelectable result = unitUnderTest.GetExactComponent<ComponentSelectable>();
            ComponentHarvestable result2 = unitUnderTest.GetExactComponent<ComponentHarvestable>();
            DropWhenCompletelyHarvested result3 = unitUnderTest.GetExactComponent<DropWhenCompletelyHarvested>();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result2);
            Assert.NotNull(result3);
        }

        [Fact]
        public void GetComponent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            HasComponents unitUnderTest = this.CreateHasComponents();

            // Act
            ComponentSelectable result = unitUnderTest.GetComponent<ComponentSelectable>();
            ComponentHarvestable result2 = unitUnderTest.GetComponent<ComponentHarvestable>();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result2);
        }

        [Fact]
        public void AddComponent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            HasComponents unitUnderTest = this.CreateHasComponents();
            DropWhenCompletelyHarvested component = new DropWhenCompletelyHarvested(new List<Item>(), "", "");

            // Act
            unitUnderTest.ClearComponents();
            unitUnderTest.AddComponent(component);

            // Assert
            Assert.True(unitUnderTest.HasComponent<DropWhenCompletelyHarvested>());
            Assert.True(unitUnderTest.GetExactComponent<DropWhenCompletelyHarvested>() != null);
            Assert.True(unitUnderTest.GetComponent<DropWhenCompletelyHarvested>() != null);
            Assert.True(unitUnderTest.GetComponent<ComponentHarvestable>() != null);
        }

        [Fact]
        public void HasComponent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            HasComponents unitUnderTest = this.CreateHasComponents();

            // Act
            bool result = unitUnderTest.HasComponent<ComponentHarvestable>();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TestHasComponentSerialization()
        {
            // Arrange
            HasComponents unitUnderTest = this.CreateHasComponents();

            // Act
            byte[] data = ProtoUtil.Serialize(unitUnderTest);

            Assert.NotNull(data);

            HasComponents deserialized = ProtoUtil.Deserialize<HasComponents>(data);

            // Assert
            Assert.NotNull(deserialized);

            Assert.True(unitUnderTest.HasComponent<DropWhenCompletelyHarvested>());
            Assert.NotNull(unitUnderTest.GetExactComponent<DropWhenCompletelyHarvested>());
            Assert.NotNull(unitUnderTest.GetComponent<DropWhenCompletelyHarvested>());
            Assert.NotNull(unitUnderTest.GetComponent<ComponentHarvestable>());

            Assert.True(deserialized.HasComponent<DropWhenCompletelyHarvested>());
            Assert.NotNull(deserialized.GetExactComponent<DropWhenCompletelyHarvested>());
            Assert.NotNull(deserialized.GetComponent<DropWhenCompletelyHarvested>());
            Assert.NotNull(deserialized.GetComponent<ComponentHarvestable>());
            Assert.NotNull(deserialized.GetExactComponent<ComponentSelectable>());
            Assert.NotNull(deserialized.GetExactComponent<ComponentRenderer>());
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    MasterLog.Close();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
         ~HasComponentsTests()
         {
           // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
           Dispose(false);
         }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}