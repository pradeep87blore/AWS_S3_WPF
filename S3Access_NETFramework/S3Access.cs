using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;

namespace S3Access_NETFramework
{
    public class S3Access
    {

        // Create the specified bucket. If it fails, return an empty string, else return the URL to the bucket
        public string CreateBucket(string bucketName, bool publicAccessAllowed = false)
        {
            return BucketCreator.CreateBucket(bucketName, publicAccessAllowed);
        }
        // Upload the file to the specified bucket and return the URL to the same
        public bool UploadFile(string sFilePath, string bucketName)
        {
            return ObjectUploader.WriteAnObject(sFilePath, bucketName);
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

        public bool EnableBucketVersioning(string bucketName, bool bEnableVersioning)
        {
            return true;
        }


        // Return value, a list of tuples of fileName, fileUrl
        public List<Tuple<string, string>> ListAllFilesInBucket(string bucketName)
        {
            // If we have the permissions to access the specified bucket, fetch all the files from it and return the list

            //using (client = new AmazonS3Client(bucketRegion))
            //{
            //    Console.WriteLine("Listing objects stored in a bucket");
            //    //ListingObjectsAsync().Wait();
            //}

            return null;
        }

        public List<string> GetAllBuckets()
        {
            // Find all the buckets of the current user, assuming there are sufficient permissions available

            var bucketList = BucketInfoFetcher.GetBucketList();

            Console.WriteLine("Listing the bucket info of the current user");

            List<string> bucketListInfo = new List<string>();
            foreach (var bucketInfo in bucketList)
            {
                Console.WriteLine(bucketInfo);
                bucketListInfo.Add(bucketInfo.ToString());

            }

            return bucketListInfo;
        }
    }
}
