using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace S3Access_NETFramework
{
    // This class shall be used to store the bucket policies that we apply to any newly created bucket
    public class BucketPolicies
    {
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private static IAmazonS3 s3Client;

        public static bool EnableVersioning(string bucketName, bool bEnableVersioning)
        {
            try
            {
                if (s3Client == null)
                {
                    s3Client = S3ClientProvider.GetS3Client();
                }

                PutBucketVersioningRequest verRequest = new PutBucketVersioningRequest()
                {
                    BucketName = bucketName,
                    VersioningConfig = new S3BucketVersioningConfig()
                    {
                        Status = VersionStatus.Enabled
                    }
                };
                var rsp = s3Client.PutBucketVersioning(verRequest);
                if (rsp.HttpStatusCode != HttpStatusCode.OK)
                    return false;

                return true;
            }
            catch (AmazonS3Exception s3Ex)
            {
                Console.WriteLine(s3Ex);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Error in setting the versioning of {0} bucket to {1}", bucketName, bEnableVersioning);
            return false;
        }
    }
}
