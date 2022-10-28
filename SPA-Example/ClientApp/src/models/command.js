export class Command {
    name;
    requestData;
}

export const CommandNames = {
    //#region topic
    CreateTopic: "CreateTopic",
    GetTopicById: "GetTopicById",
    GetTopics: "GetTopics",
    UpdateTopic: "UpdateTopic",
    DeleteTopic: "DeleteTopic",
    //#endregion

    //#region course
    CreateCourse: "CreateCourse",
    GetCourseById: "GetCourseById",
    GetCourses: 'GetCourses',
    UpdateCourse: "UpdateCourse",
    DeleteCourse: "DeleteCourse",
    //#endregion

    //#region user
    UserLogin: "UserLogin",
    UserRegister: "UserRegister",
    //#endregion
}
