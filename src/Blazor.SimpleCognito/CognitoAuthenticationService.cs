using System;
using System.Threading.Tasks;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;
using Blazored.LocalStorage;

namespace Blazor.SimpleCognito
{
    public interface ICognitoAuthenticationService {

        CognitoAWSCredentials Credentials { get; }
        Task<bool> isAuthenticated();
    }

    public class CognitoAuthenticationService : ICognitoAuthenticationService {

        private ILocalStorageService localStorage;

        public CognitoAuthenticationService(ILocalStorageService localStorage, CognitoAWSCredentials credentials)
        {
            this.localStorage = localStorage;
            Credentials = credentials;
        }

        public CognitoAWSCredentials Credentials { get; private set; }

        public async Task<bool> isAuthenticated()
        {
            string id_token = await localStorage.GetItemAsStringAsync("id_token");
            
            if(String.IsNullOrEmpty(id_token)){
                return false;
            }

            try {
                Credentials.AddLogin(CognitoConfig.COGNITO_IDP, id_token);
                var credential = await Credentials.GetCredentialsAsync();
                Console.WriteLine("user authenticated ....");
                Console.WriteLine("accesskey: " + credential.AccessKey);
                return true;
            } catch (NotAuthorizedException ex) {
                Console.WriteLine(ex);
            }
            return false;
        }
    }
}