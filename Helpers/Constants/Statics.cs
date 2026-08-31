namespace Helpers.Constants
{
    public static class Statics
    {
        public static  class Dates
        {
            public static string StandardFormat = "dd.MM.yyyy";
        }

        public static class Notifications
        {
            public static string WelcomeToEManagement = "Welcome to eManagement";

            public static class UserMessages
            {
                public static string EmailAlreadyExists = "Email {0} already exist.";
                public static string EmailDoesNotExist = "User with email '{0}' does not exist.";
                public static string IncorrectPassword = "Incorrect password.";
                public static string EmailAndPasswordRequired = "Email and password are required.";
                public static string SuccessfulSignIn = "Successful sign in.";
            }

            public static class TaskMessages
            {
                public static string TaskStatusUpdated = "Task status updated successfuly.";
            }

            public static class AbsenceMessages
            {
                public static string AbsenceStatusUpdated = "Absence status updated successfuly.";
            }

            public static class Common
            {
                public static string Added = "{0} added successfuly.";
                public static string Updated = "{0} updated successfuly.";
                public static string Deleted = "{0} deleted successfuly.";
                public static string NotFound = "{0} not found";
                public static string InternalServerError = "An internal server error occured.";
                public static string NothindToUpdate = "Nothing to update.";
                public static string NoDataProvided = "No data provided.";
                public static string SomethingWentWrong = "Somethign went wrong";
                public static string AlreadyExist = "{0} already exist.";
            }

        }
    }
}
