using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Access_NETFramework
{
    // This class shall be used to pass around the bucket info
    public class BucketInfo
    {
        public string BucketName = "";
        public string BucketRegion = "";
        public string BucketOwner = "";

        public BucketInfo(string bName, string bRegion = null, string bOwner = null)
        {
            BucketName = bName;
            BucketRegion = bRegion;
            BucketOwner = bOwner;
        }

        public override string ToString()
        {
            return string.Format("Bucket Name: {0}, Bucket Region: {1}, Bucket Owner: {2}",
                BucketName, BucketRegion, BucketOwner);
        }
    }
}
