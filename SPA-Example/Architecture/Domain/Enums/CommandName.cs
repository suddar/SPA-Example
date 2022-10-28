namespace SPA_Example.Architecture.Domain.Enums
{
    public static class CommandNames
    {
        #region User
        public const string CreateUser = "CreateUser";
        public const string GetUserById = "GetUserById";
        public const string UpdateUser = "UpdateUser";
        public const string DeleteUser = "DeleteUser";

        public const string UserLogin = "UserLogin";
        public const string UserRegister = "UserRegister";
        #endregion

        #region Topic
        public const string CreateTopic = "CreateTopic";
        public const string GetTopicById = "GetTopicById";
        public const string GetTopics = "GetTopics";
        public const string UpdateTopic = "UpdateTopic";
        public const string DeleteTopic = "DeleteTopic";
        #endregion

        #region Course
        public const string CreateCourse = "CreateCourse";
        public const string GetCourseById = "GetCourseById";
        public const string GetCourses = "GetCourses";
        public const string UpdateCourse = "UpdateCourse";
        public const string DeleteCourse = "DeleteCourse";
        #endregion
    }
}
