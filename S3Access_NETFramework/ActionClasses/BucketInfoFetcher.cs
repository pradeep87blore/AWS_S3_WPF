using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;

namespace S3Access_NETFramework
{
    public class BucketInfoFetcher
    {
        private static IAmazonS3 s3Client;
        public static List<BucketInfo> GetBucketList()
        {
            if (s3Client == null)
                s3Client = S3ClientProvider.GetS3Client();

            List<BucketInfo> bucketList = new List<BucketInfo>();
            var bucketRsp = s3Client.ListBuckets();

            if (bucketRsp != null)
            {
                foreach (var bucket in bucketRsp.Buckets)
                {
                    var bucketRegion = s3Client.GetBucketLocation(bucket.BucketName);
                    BucketInfo bucketInfo = new BucketInfo(bucket.BucketName, bucketRegion.Location.Value, 
                        bucketRsp.Owner.DisplayName);

                    bucketList.Add(bucketInfo);
                }
            }

            return bucketList;
        }
    }
}
