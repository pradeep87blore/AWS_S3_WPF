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
        

        public static string CreateBucket(string bucketName, bool publicAccessAllowed = false)
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

                    bool bBucketCreatedOrExists = false;
                    try
                    {
                        PutBucketResponse putBucketResponse = s3Client.PutBucket(putBucketRequest);
                        bBucketCreatedOrExists = true;
                    }


                    catch (AmazonS3Exception e)
                    {
                        Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object",
                            e.Message);

                        if (e.ErrorCode == "BucketAlreadyOwnedByYou")
                            bBucketCreatedOrExists = true; // We already created this bucket and own it. Hence, we can proceed
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object",
                            e.Message);
                    }

                    if (bBucketCreatedOrExists == false)
                    {
                        // Error in creating the bucket. Return
                        return null;
                    }

                    // TODO: See how to add the policy
                    //if (publicAccessAllowed == true)
                    //{
                    //    //PutBucketPolicyRequest buckpetPolicyRequest = new PutBucketPolicyRequest()
                    //    //{
                    //    //    BucketName = bucketName,
                            

                    //    //};

                    //    string Policy =
                    //        "{\"Version\": \"2012-10-17\",\"Statement\": [    {        \"Effect\": \"Allow\",        \"Action\": \"s3:*\",        \"Resource\": \"*\", \"Principal\": \"*\"    }]}";
                    //    var putBucketPolicyResponse = s3Client.PutBucketPolicy(bucketName, Policy);
                    //}

                    // Enable versioning by default: 
                    // TODO: Later, make this configurable
                    BucketPolicies.EnableVersioning(bucketName, true);

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
