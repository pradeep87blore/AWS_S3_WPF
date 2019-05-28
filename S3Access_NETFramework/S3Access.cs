using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace S3Access_NETFramework
{
    public class S3Access
    {
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private static IAmazonS3 client;

        // Create the specified bucket. If it fails, return an empty string, else return the URL to the bucket
        public string CreateBucket(string bucketName)
        {
            S3Access_NETFramework.CreateBucket.CreateBucketAsync(bucketName).Wait();
            return string.Empty;
        }
        // Upload the file to the specified bucket and return the URL to the same
        public string UploadFile(string sFilePath, string bucknetName)
        {

            return string.Empty;
        }

        // Check if any file with this name exists on the bucket
        public bool DoesFileExist(string sFilePath, string bucketName)
        {

            return false;
        }

        public bool DoesFileExist(string sFileS3URL)
        {

            return false;
        }

        // Return value, a list of tuples of fileName, fileUrl
        public List<Tuple<string, string>> ListAllFilesInBucket(string bucketName)
        {
            // If we have the permissions to access the specified bucket, fetch all the files from it and return the list

            using (client = new AmazonS3Client(bucketRegion))
            {
                Console.WriteLine("Listing objects stored in a bucket");
                //ListingObjectsAsync().Wait();
            }

            return null;
        }

        public List<string> GetAllBuckets(string userId)
        {
            // Find all the buckets of this user, assuming there are sufficient permissions available

            return null;
        }
    }
}
