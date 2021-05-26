using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Blazor.SimpleCognito
{
    public static class CognitoConfig {

        public static Amazon.RegionEndpoint REGION = null;
        public static string USER_POOL_ID = "";
        public static string CLIENT_ID = "";
        public static string IDENTITY_POOL_ID = "";
        public static string COGNITO_IDP = "";
        public static string URL_LOGIN = "";
        public static string URL_LOGOUT = "";

        public static void build(WebAssemblyHostConfiguration configuration)
        {
            REGION = Amazon.RegionEndpoint.GetBySystemName(configuration["AWS:Region"]);
            USER_POOL_ID = configuration["AWS:UserPoolId"];
            CLIENT_ID = configuration["AWS:ClientId"];
            IDENTITY_POOL_ID = configuration["AWS:IdentityPoolId"];
            COGNITO_IDP = configuration["AWS:CognitoIdp"];
            URL_LOGIN = configuration["AWS:UrlLogin"];
            URL_LOGOUT = configuration["AWS:UrlLogout"];
        }
    }
}