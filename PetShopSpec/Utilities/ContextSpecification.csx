using NUnit.Framework;
using Moq;

namespace GII.Commons.Testing.NUnit
{
    [TestFixture]
    public abstract class ContextSpecification<SystemUnderTest>
    {
        protected SystemUnderTest sut;

        [SetUp]
        public virtual void setup()
        {
            this.establish_context();
            this.sut = this.create_sut();
            this.after_the_sut_has_been_created();
            this.because();
        }

        [TearDown]
        public virtual void teardown() => this.after_each_specification();

        protected abstract SystemUnderTest create_sut();

        protected abstract void because();

        protected abstract void establish_context();

        protected virtual void after_the_sut_has_been_created()
        {
        }

        protected virtual void after_each_specification()
        {
        }

        protected virtual Mock<InterfaceType> DoMock<InterfaceType>() where InterfaceType : class => new Moq.Mock<InterfaceType>();

        protected virtual Mock<InterfaceType> DoStub<InterfaceType>() where InterfaceType : class => new Moq.Mock<InterfaceType>();

        protected virtual Mock<InterfaceType> Wrapper<InterfaceType>(InterfaceType mockObject)
            where InterfaceType : class
        {
            return Moq.Mock.Get(mockObject);
        }
    }
}