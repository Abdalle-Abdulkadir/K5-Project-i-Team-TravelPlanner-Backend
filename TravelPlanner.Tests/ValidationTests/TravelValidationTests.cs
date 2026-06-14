namespace TravelPlanner.Tests.ValidationTests
{
    public class TravelRequestTests
    {
        [Fact]
        public void Budget_Must_Be_Greater_Than_1000_SEK()
        {
            // Given
            int budget = 500;

            // When
            bool isValid = budget > 1000;

            // Then
            Assert.False(isValid);
        }

        [Fact]
        public void Days_Must_Be_Greater_Than_Zero()
        {
            // Given
            int days = 0;

            // When
            bool isValid = days > 0;

            // Then
            Assert.False(isValid);
        }

        [Fact]
        public void StartDate_Must_Be_Tomorrow_Or_Later()
        {
            // Given
            DateTime startDate = DateTime.Today;

            // When
            bool isValid = startDate > DateTime.Today;

            // Then
            Assert.False(isValid);
        }
    }

}
