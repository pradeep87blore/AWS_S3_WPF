using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;

namespace S3Access_NETFramework
{
    internal class S3ClientProvider
    {
        static IAmazonS3 client;

        // https://docs.aws.amazon.com/sdk-for-net/v3/developer-guide/net-dg-config-creds.html#sdk-store
        private const string PROFILE_NAME = "S3AccessProfile";
        private static bool GetCredentials(out AWSCredentials awsCredentials)
        {
            var chain = new CredentialProfileStoreChain();
            if (chain.TryGetAWSCredentials(PROFILE_NAME, out awsCredentials))
            {
                return true;
            }

            return false; // No matching profile found
        }

        public static IAmazonS3 GetS3Client()
        {
            if (client == null)
            {
                AWSCredentials awsCredentials = null;

                if (GetCredentials(out awsCredentials))
                {
                    client = new AmazonS3Client(awsCredentials, RegionEndpoint.USWest2);
                }
            }

            return client;
        }
    }
}
