﻿// <copyright file="SerializeDataContractTest.cs" company="IPNetwork">
// Copyright (c) IPNetwork. All rights reserved.
// </copyright>

using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Net.TestSerialization.NetFramework
{
    [TestClass]
    public class SerializeDataContractTest
    {
        [TestMethod]
        public void Test_Serialize_DataContract()
        {
            var ipnetwork = IPNetwork.Parse("10.0.0.1/8");

            string result = DataContractSerializeHelper.Serialize(ipnetwork);

            string expected = $"<IPNetwork xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:x=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"http://schemas.datacontract.org/2004/07/System.Net\">{Environment.NewLine}  <IPNetwork i:type=\"x:string\" xmlns=\"\">10.0.0.0/8</IPNetwork>{Environment.NewLine}</IPNetwork>";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_Deserialize_DataContract()
        {
            var ipnetwork = IPNetwork.Parse("10.0.0.1/8");
            string serialized = DataContractSerializeHelper.Serialize(ipnetwork);

            var result = DataContractSerializeHelper.Deserialize<IPNetwork>(serialized);

            Assert.AreEqual(ipnetwork, result);
        }

        [TestMethod]
        public void Test_Empty_Constructor()
        {
            var ipnetwork = new IPNetwork();
            Assert.AreEqual("0.0.0.0/0", ipnetwork.ToString());
        }
    }
}