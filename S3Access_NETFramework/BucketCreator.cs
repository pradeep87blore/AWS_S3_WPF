using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace S3Access_NETFramework
{
    class BucketCreator
    {
        //private const string bucketName = "*** bucket name ***";
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private static IAmazonS3 s3Client;
        

        public static string CreateBucket(string bucketName)
        {
            try
            {
                //var awsCredentials = CredentialFetcher.GetCredentials();

                if (s3Client == null)
                    s3Client = S3ClientProvider.GetS3Client();

                //if (!(await AmazonS3Util.DoesS3BucketExistAsync(s3Client, bucketName)))
                {
                    var putBucketRequest = new PutBucketRequest
                    {
                        BucketName = bucketName,
                        UseClientRegion = false,
                        BucketRegion = S3Region.USW2
                    };

                    PutBucketResponse putBucketResponse = s3Client.PutBucket(putBucketRequest);
                    
                }
                
                // Retrieve the bucket location (which AZ the bucket is in)
                string bucketLocation = FindBucketLocation(s3Client, bucketName);

                Console.WriteLine(bucketLocation);

                return bucketLocation;
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

            return null;
        }
        
        static string FindBucketLocation(IAmazonS3 client, string bucketName)
        {
            string bucketLocation;
            var request = new GetBucketLocationRequest()
            {
                BucketName = bucketName
            };
            GetBucketLocationResponse response = client.GetBucketLocation(request);
            bucketLocation = response.Location.ToString();
            return bucketLocation;
        }
    }
}
