using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace S3Access_NETFramework
{
    public class CredentialFetcher
    {
        public static BasicAWSCredentials GetCredentials()
        {
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials("accessKey", 
                "secretkey");

            return awsCredentials;
        }
    }
}
