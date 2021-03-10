using System;
using System.Collections.Generic;
using System.Text;
using Logic;
using Xunit;

namespace TestLogic
{
    public class TestExam
    {

        [Fact]
        public void TestCoef()
        {
            Assert.Throws<Exception>(() =>
            {
                float valeur = -3;
                Exam instante = new Exam() { Coef = valeur };

            });
        }

        [Fact]
        public void TestNote()
        {
            Assert.Throws<Exception>(() =>
            {
                float valeur = -3;
                Exam instante = new Exam() { Score = valeur };
            });
        }

        [Fact]
        public void TestModule()
        {
            Assert.Throws<Exception>(() =>
            {
                Exam instante = new Exam() { Module = null };
            });
        }

        [Fact]
        public void TestisAbsent()
        {
            Exam instante = new Exam();
            instante.IsAbsent = true;
            Assert.Equal(0, instante.Score);
        }

        [Fact]
        public void TestEqual()
        {
            Module m1 = new Module() { Coef = 1, Name = "JeSuisLeModule" };

            Exam instance1 = new Exam() { Score = 10, Coef = 1, Module = m1, IsAbsent = false, Teacher = "Coucou", DateExam = DateTime.Now };
            Exam instance2 = new Exam() { Score = 10, Coef = 1, Module = m1, IsAbsent = false, Teacher = "Coucou", DateExam = DateTime.Now };

            bool actual = instance1.Equals(instance2);

            Assert.True(actual);
        }
    }
}
