namespace Library.Data.Common
{
    public static class DataConstants
    {
        // ApplicationUser constants:
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 20;

        public const string UserNameDisplayName = "Username";

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;

        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;

        // Fields input error messages:
        public const string RequiredFieldErrorMsg = "This field is required.";
        public const string StringLengthErrorMsg = "This field should be between {2} and {1} characters long.";
        public const string LoginFailed = "Login failed! Please try again.";
        public const string PasswordConfirmationErrorMsg = "Confirmation does not match with your password.";

        // Book constants:
        public const int TitleMinLength = 10;
        public const int TitleMaxLength = 50;

        public const int AuthorMinLength = 5;
        public const int AuthorMaxLength = 50;

        public const int DescriptionMinLength = 5;
        public const int DescriptionMaxLength = 5000;

        public const int ImageUrlMaxLength = 255;

        public const string RatingMinValue = "0.0";
        public const string RatingMaxValue = "10.0";

        // Category constants:
        public const int CategoryNameMinLength = 5;
        public const int CategoryNameMaxLength = 50;

        public const string CategoryInvalid = "This category does not exist.";

        // Names of actions and controllers:
        public const string IndexAction = "Index";
        public const string AllAction = "All";
        public const string HomeContr = "Home";
        public const string BooksContr = "Books";
    }
}
