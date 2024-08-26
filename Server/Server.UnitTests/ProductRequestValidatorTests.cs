using Server.Models;
using Server.Validators;

namespace Server.UnitTests
{
    public class ProductRequestValidatorTests
    {
        [Fact]
        public void Success()
        {
            var validator = new ProductRequestValidator();
            var request = new ProductRequest
            {
                Code = "TestCode",
                Name = "TestName",
                Price = 20.5
            };

            var result = validator.Validate(request);
            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

        [Theory]
        [ClassData(typeof(EmptyStrings))]
        [InlineData("A")]

        public void IncorrectCodeProperty(string code)
        {
            var validator = new ProductRequestValidator ();
            var request = new ProductRequest
            {
                Code = code,
                Name = "TestName",
                Price = 20.5
            };

            var result = validator.Validate(request);
            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Theory]
        [ClassData(typeof(EmptyStrings))]
        [InlineData("A")]
        [InlineData("A ")]
        [InlineData("AB")]

        public void IncorrectNameProperty(string name)
        {
            var validator = new ProductRequestValidator();
            var request = new ProductRequest
            {
                Code = "TestCode",
                Name = name,
                Price = 20.5
            };

            var result = validator.Validate(request);
            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
