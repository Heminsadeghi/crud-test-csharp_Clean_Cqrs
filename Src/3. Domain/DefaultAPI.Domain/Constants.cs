using System;

namespace DefaultAPI.Domain
{
    public class Constants
    {
        public const int SaltSize = 16;
        public const int HashSize = 20;
        public const string DefaultPassword = "123mudar";

       
        public const string UrlToHangFire = "https://{url}:9000/hangfire/servers";
        public const string UrlToRabbitMQ = "https://{url}:15672";
        public const string UrlToKissLog = "https://kisslog.net/Dashboard/{KissLog.ApplicationId}/defaultapi";

        public const string SaveLog = @"insert into Log(Class,Method,Message_Error,Update_time,Object) values('{0}','{1}','{2}','{3}','{4}')";

        public const string ExceptionRequestAPI = "ExceptionRequestAPI";
        public const string ExceptionExcel = "ExceptionExcel";

        public const string NoAuthorization = "NoAuthorization";
        public const string ErrorInUpdate = "ErrorInUpdate";
        public const string ErrorInAdd = "ErrorInAdd";
        public const string ErrorInDeleteLogic = "ErrorInDeleteLogic";
        public const string ErrorInDeletePhysical = "ErrorInDeletePhysical";
        public const string ErrorInResearch = "ErrorInResearch";
        public const string ErrorInGetAll = "ErrorInGetAll";
        public const string ErrorInGetId = "ErrorInGetId";
        public const string ErrorInGetDdl = "ErrorInGetDdl";
        public const string ErrorInLogin = "ErrorInLogin";
        public const string ErrorInChangePassword = "ErrorInChangePassword";
        public const string ErrorInResetPassword = "ErrorInResetPassword";
        public const string ErrorInActiveRecord = "ErrorInActiveRecord";
        public const string ErrorInBackup = "ErrorInBackup";
        public const string ErrorInAddCity = "ErrorInAddCity";
        public const string ErrorInRefreshToken = "ErrorInRefreshToken";
        public const string ErrorInProcedure = "ErrorInProcedure";

        public const string UrlToGetFireBase = "UrlToGetFireBase";
        public const string ServerApiKey = "ServerApiKey";
        public const string SenderId = "SenderId";


        public const string quote = "\"";
        public const string EmailIsExists = "Email Is Exists";

        public const string CustomerIsExists = "Customer Is Exists";
        public const string CustomerNotIsExists = "Customer Not Is Exists";


        

    }
}
