using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Access_NETFramework
{
    class UploadObject
    {        
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.EUWest1;

        private static IAmazonS3 client;       

        public static bool WritingAnObject(string filePath, string bucketName)
        {
            try
            {
                var fileInfo = filePath.Split('\\');

                if (client == null)
                    client = new AmazonS3Client("AccessKey", "SecretKey", RegionEndpoint.USWest2);

                string keyName = fileInfo[fileInfo.Length - 1];
                // 1. Put object-specify only key name for the new object.
                var request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };
                
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    request.InputStream = stream;

                    // Put object
                    PutObjectResponse response = client.PutObject(request);

                    if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                        return true;
                }
                
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine(
                        "Error encountered ***. Message:'{0}' when writing an object"
                        , e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object"
                    , e.Message);
            }

            return false;
        }
    }
}
