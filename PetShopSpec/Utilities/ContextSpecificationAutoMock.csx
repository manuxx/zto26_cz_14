// Decompiled with JetBrains decompiler
// Type: GII.Commons.Testing.NUnit.ContextSpecificationAutoMock`1
// Assembly: GII.Commons.Testing.NUnit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 68E33DF6-59FA-4709-BE98-7C418210CFB9
// Assembly location: C:\pg\zto\lab_sol\lab_behav_sol_old\TDDLab2.Tests\bin\Debug\GII.Commons.Testing.NUnit.dll


using Moq;
using NUnit.Framework;
using Moq.AutoMock;

namespace GII.Commons.Testing.NUnit
{
    [TestFixture]
    public abstract class ContextSpecificationAutoMock<SystemUnderTest> :
      ContextSpecification<SystemUnderTest> where SystemUnderTest : class
    {
        // protected MockRepository mocks;
        protected AutoMocker container;
        // protected MockRepository Mocks => this.mocks;
        
        protected override SystemUnderTest create_sut() => this.container.CreateInstance<SystemUnderTest>();

        protected void InitializeContainer()
        {
            // this.mocks = new MockRepository();
            this.container = new AutoMocker();
            // this.container.DefaultMockingStrategy = (IMockingStrategy)new ReplayedDynamicMockingStrategy((IAutoMockingRepository)this.container);
            // this.container.Initialize();
            // ServiceLocator.SetLocatorProvider((ServiceLocatorProvider)(() => (IServiceLocator)new WindsorServiceLocator((IWindsorContainer)this.container)));
        }

        public override void setup()
        {
            this.InitializeContainer();
            base.setup();
        }

        public override void teardown()
        {
            base.teardown();
            this.DisposeContainer();
        }

        private void DisposeContainer()
        {
            this.container = null;
            // this.mocks = (MockRepository)null;
        }

        protected Mock<InterfaceType> Dependency<InterfaceType>() where InterfaceType : class
        {
            InterfaceType mock = this.container.Get<InterfaceType>();
            try
            {
                // if (!this.Mocks.IsInReplayMode((object)mock))
                //     this.Mocks.Replay((object)mock);
            }
            catch
            {
            }
            return Moq.Mock.Get(mock);
        }

        //public void ProvideAnImplementationOf<Interface, Implementation>() => this.container.Use<Interface>(typeof(Implementation).FullName, typeof(Interface), typeof(Implementation));

        public void ProvideAnImplementationOf<Interface>(Interface instance) => this.container.Use<Interface>(instance);
    }
}
