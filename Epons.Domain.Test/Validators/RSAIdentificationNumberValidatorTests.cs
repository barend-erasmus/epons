using Epons.Domain.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Epons.Domain.Test.Validators
{
    [TestClass]
    public class RSAIdentificationNumberValidatorTests
    {
        private readonly string _validMaleIdentificationNumber = "9605235100085";
        private readonly string _validFemaleIdentificationNumber = "0405233100081";
        private readonly string _invalidShortIdentificationNumber = "123";
        private readonly string _invalidLongIdentificationNumber = "12345678912345";
        private readonly string _invalidMaleIdentificationNumber = "9605235100089";

        [TestMethod, TestCategory("UnitTest")]
        public void IsValid_GivenValidMaleIdentificationNumber_ReturnsTrue()
        {
            bool result = new RSAIdentificationNumberValidator().IsValid(_validMaleIdentificationNumber);

            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void IsValid_GivenInvalidShortIdentificationNumber_ReturnsFalse()
        {
            bool result = new RSAIdentificationNumberValidator().IsValid(_invalidShortIdentificationNumber);

            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void IsValid_GivenInvalidLongIdentificationNumber_ReturnsFalse()
        {
            bool result = new RSAIdentificationNumberValidator().IsValid(_invalidLongIdentificationNumber);

            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void IsValid_GivenInvalidMaleIdentificationNumber_ReturnsFalse()
        {
            bool result = new RSAIdentificationNumberValidator().IsValid(_invalidMaleIdentificationNumber);

            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void DateOfBirth_GivenValidFemaleIdentificationNumber_ReturnsDateOfBirth()
        {
            DateTime result = new RSAIdentificationNumberValidator().DateOfBirth(_validFemaleIdentificationNumber);

            Assert.IsNotNull(result);
            Assert.AreEqual(2004, result.Year);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void DateOfBirth_GivenValidMaleIdentificationNumber_ReturnsDateOfBirth()
        {
            DateTime result = new RSAIdentificationNumberValidator().DateOfBirth(_validMaleIdentificationNumber);

            Assert.IsNotNull(result);
            Assert.AreEqual(1996, result.Year);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentException))]
        public void DateOfBirth_GivenInvalidMaleIdentificationNumber_ThrowsException()
        {
            DateTime result = new RSAIdentificationNumberValidator().DateOfBirth(_invalidMaleIdentificationNumber);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void IsMale_GivenValidFemaleIdentificationNumber_ReturnFalse()
        {
            bool result = new RSAIdentificationNumberValidator().IsMale(_validFemaleIdentificationNumber);

            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void IsMale_GivenValidMaleIdentificationNumber_ReturnsTrue()
        {
            bool result = new RSAIdentificationNumberValidator().IsMale(_validMaleIdentificationNumber);

            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentException))]
        public void IsMale_GivenInvalidMaleIdentificationNumber_ThrowsException()
        {
            bool result = new RSAIdentificationNumberValidator().IsMale(_invalidMaleIdentificationNumber);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void IsFemale_GivenValidFemaleIdentificationNumber_ReturnTrue()
        {
            bool result = new RSAIdentificationNumberValidator().IsFemale(_validFemaleIdentificationNumber);

            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void IsFemale_GivenValidMaleIdentificationNumber_ReturnsFalse()
        {
            bool result = new RSAIdentificationNumberValidator().IsFemale(_validMaleIdentificationNumber);

            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("UnitTest")]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFemale_GivenInvalidMaleIdentificationNumber_ThrowsException()
        {
            bool result = new RSAIdentificationNumberValidator().IsFemale(_invalidMaleIdentificationNumber);
        }


    }
}
