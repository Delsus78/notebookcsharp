using Logic;
using System;
using Xunit;

namespace TestLogic
{
    public class TestPedagogicalElement
    {
        [Fact]
        public void TestCoef()
        {
            Assert.Throws<Exception>(() =>
            {
                float valeur = -3;
                PedagogicalElement p = new PedagogicalElement() { Coef = valeur, Name = "Jean" };
                
            });
        }
        [Fact]
        public void TestName()
        {
            Assert.Throws<Exception>(() =>
            {
                string valeur = "";
                PedagogicalElement p = new PedagogicalElement() { Coef = 1,Name =  valeur };
            });
        }

        [Fact]
        public void TestEqual()
        {
                PedagogicalElement instance1 = new PedagogicalElement() { Name = "JeSuisUnPedagogicalElement", Coef = 1 };
                PedagogicalElement instance2 = new PedagogicalElement() { Name = "JeSuisUnPedagogicalElement", Coef = 1 };

                bool actual = instance1.Equals(instance2);

                Assert.True(actual);
        }
    }
}
