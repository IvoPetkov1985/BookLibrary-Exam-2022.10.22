namespace Library.Data.Common
{
    public static class DataConstants
    {
        // Category constants.
        public const int CategoryNameMinLength = 5;
        public const int CategoryNameMaxLength = 50;

        public const string CategoryErrorMsg = "Invalid category";

        // Book constants.
        public const int BookTitleMinLength = 10;
        public const int BookTitleMaxLength = 50;

        public const int BookAuthorMinLength = 5;
        public const int BookAuthorMaxLength = 50;

        public const int BookDescriptionMinLength = 5;
        public const int BookDescriptionMaxLength = 5000;

        public const string BookRatingMinValue = "0.0";
        public const string BookRatingMaxValue = "10.0";

        public const string BookInputErrorMsg = "Field {0} should be between {2} and {1} charcters long";

        // ApplicationUser constants.
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 20;

        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;

        public const string UsernameDisplay = "Username";
    }
}
