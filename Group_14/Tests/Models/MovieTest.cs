using Xunit;
using System.ComponentModel.DataAnnotations;
using Group_14.CoreLayer.Entities;
using System.Collections.Generic;

namespace Group_14.Tests.Models
{
    public class MovieTests
    {
        [Fact]
        public void Movie_ShouldRequireTitle()
        {
            // Arrange
            var movie = new MovieSeries { Genre = "Sci-Fi" }; // Thiếu Title

            // Act
            var validationResults = ValidateModel(movie);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Title"));
        }

        private List<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
