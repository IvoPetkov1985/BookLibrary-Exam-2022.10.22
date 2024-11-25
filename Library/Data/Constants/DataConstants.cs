namespace Library.Data.Constants
{
    public static class DataConstants
    {
        // ApplicationUser constants:
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 20;
        public const string UserNameDisplay = "Username";

        public const int UserEmailMinLength = 10;
        public const int UserEmailMaxLength = 60;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;

        public const string LoginErrorMessage = "Invalid Login, please try again!";

        // Category constants:
        public const int CategoryNameMinLength = 5;
        public const int CategoryNameMaxLength = 50;

        public const string InvalidCategoryMessage = "This category does not exist.";

        // Book constants:
        public const int BookTitleMinLength = 10;
        public const int BookTitleMaxLength = 50;

        public const int BookAuthorNameMinLength = 5;
        public const int BookAuthorNameMaxLength = 50;

        public const int BookDescriptionMinLength = 5;
        public const int BookDescriptionMaxLength = 5000;

        public const int BookImageUrlMaxLength = 500;

        public const string BookRatingMinValue = "0.0";
        public const string BookRatingMaxValue = "10.0";

        public const string InputLengthErrorMessage = "{0} should be between {2} and {1} symbols long.";

        // Actions and controllers names:
        public const string BookContrName = "Books";
        public const string AllActionName = "All";
        public const string HomeContrName = "Home";
        public const string IndexActionName = "Index";
    }
}
