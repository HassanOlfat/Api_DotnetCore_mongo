using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_mongo.data
{
    public class AddressInfo
    {

        public ObjectId _id { get; set; }

        public string Pelak { get; set; }


        public string Address { get; set; }


    }



}