﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stellar;
using System;
using System.Text;

namespace csharp_stellar_base.Tests
{
    [TestClass]
    public class OperationTests
    {
        [TestMethod]
        public void ChangeTrustOperation()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");
            var assetCode = "EUR";
            var asset = new Asset(assetCode, source);

            long limit = 100;

            ChangeTrustOperation operation = new ChangeTrustOperation.Builder(asset, limit)
                .SetSourceAccount(source)
                .Build();

            Assert.AreEqual(source.Address, operation.SourceAccount.Address);
            Assert.AreEqual(assetCode, operation.Asset.Code);
            Assert.AreEqual(asset.Issuer.Address, operation.Asset.Issuer.Address);
            Assert.AreEqual(asset.Type, operation.Asset.Type);
            Assert.AreEqual(limit, operation.Limit);
            Assert.AreEqual("AAAAAQAAAAC7JAuE3XvquOnbsgv2SRztjuk4RoBVefQ0rlrFMMQvfAAAAAYAAAABRVVSAAAAAAC7JAuE3XvquOnbsgv2SRztjuk4RoBVefQ0rlrFMMQvfAAAAAAAAABk",
                    operation.ToXdrBase64());

            Stellar.Generated.Operation xdr = operation.ToXDR();
            ChangeTrustOperation parsedOperation = Stellar.ChangeTrustOperation.FromXDR(xdr);

            Assert.AreEqual(source.Address, parsedOperation.SourceAccount.Address);
            Assert.AreEqual("EUR", parsedOperation.Asset.Code);
            Assert.AreEqual(source.Address, parsedOperation.Asset.Issuer.Address);
            Assert.AreEqual(limit, parsedOperation.Limit);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "asset cannot be null.")]
        public void ChangeTrustOperationNullAsset()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");

            long limit = 100;

            ChangeTrustOperation operation = new ChangeTrustOperation.Builder(null, limit)
                .SetSourceAccount(source)
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "limit must be non-negative.")]
        public void ChangeTrustOperationNegativeLimit()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");
            var assetCode = "EUR";
            var asset = new Asset(assetCode, source);

            ChangeTrustOperation operation = new ChangeTrustOperation.Builder(asset, -1)
                .SetSourceAccount(source)
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "sourceAccount cannot be null.")]
        public void ChangeTrustOperationNullSource()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");
            var assetCode = "EUR";
            var asset = new Asset(assetCode, source);

            long limit = 100;

            ChangeTrustOperation operation = new ChangeTrustOperation.Builder(asset, limit)
                .SetSourceAccount(null)
                .Build();
        }

        [TestMethod]
        public void CreateAccountOperation()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");
            // GDW6AUTBXTOC7FIKUO5BOO3OGLK4SF7ZPOBLMQHMZDI45J2Z6VXRB5NR
            KeyPair destination = KeyPair.FromSeed("SDHZGHURAYXKU2KMVHPOXI6JG2Q4BSQUQCEOY72O3QQTCLR2T455PMII");
            var balance = 1000;

            CreateAccountOperation operation = new CreateAccountOperation.Builder(destination, balance)
                .SetSourceAccount(source)
                .Build();

            Assert.AreEqual(source.Address, operation.SourceAccount.Address);
            Assert.AreEqual(destination.Address, operation.Destination.Address);
            Assert.AreEqual(balance, operation.StartingBalance);
            Assert.AreEqual("AAAAAQAAAAC7JAuE3XvquOnbsgv2SRztjuk4RoBVefQ0rlrFMMQvfAAAAAAAAAAA7eBSYbzcL5UKo7oXO24y1ckX+XuCtkDsyNHOp1n1bxAAAAAAAAAD6A==",
                    operation.ToXdrBase64());

            Stellar.Generated.Operation xdr = operation.ToXDR();
            CreateAccountOperation parsedOperation = Stellar.CreateAccountOperation.FromXDR(xdr);

            Assert.AreEqual(source.Address, parsedOperation.SourceAccount.Address);
            Assert.AreEqual(destination.Address, parsedOperation.Destination.Address);
            Assert.AreEqual(1000, parsedOperation.StartingBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "destination cannot be null.")]
        public void CreateAccountOperationNullDestination()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");
            var balance = 1000;

            CreateAccountOperation operation = new CreateAccountOperation.Builder(null, balance)
                .SetSourceAccount(source)
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "startingBalance must be non-negative.")]
        public void CreateAccountOperationNegativeStartingBalance()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");
            // GDW6AUTBXTOC7FIKUO5BOO3OGLK4SF7ZPOBLMQHMZDI45J2Z6VXRB5NR
            KeyPair destination = KeyPair.FromSeed("SDHZGHURAYXKU2KMVHPOXI6JG2Q4BSQUQCEOY72O3QQTCLR2T455PMII");

            CreateAccountOperation operation = new CreateAccountOperation.Builder(destination, -1)
                .SetSourceAccount(source)
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "sourceAccount cannot be null.")]
        public void CreateAccountOperationNullSource()
        {
            // GDW6AUTBXTOC7FIKUO5BOO3OGLK4SF7ZPOBLMQHMZDI45J2Z6VXRB5NR
            KeyPair destination = KeyPair.FromSeed("SDHZGHURAYXKU2KMVHPOXI6JG2Q4BSQUQCEOY72O3QQTCLR2T455PMII");
            var balance = 1000;

            CreateAccountOperation operation = new CreateAccountOperation.Builder(destination, balance)
                .SetSourceAccount(null)
                .Build();
        }

        [TestMethod]
        public void PaymentOperation()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");
            // GDW6AUTBXTOC7FIKUO5BOO3OGLK4SF7ZPOBLMQHMZDI45J2Z6VXRB5NR
            KeyPair destination = KeyPair.FromSeed("SDHZGHURAYXKU2KMVHPOXI6JG2Q4BSQUQCEOY72O3QQTCLR2T455PMII");

            Asset asset = new Stellar.Asset();
            long amount = 1000;

            PaymentOperation operation = new PaymentOperation.Builder(destination, asset, amount)
                .SetSourceAccount(source)
                .Build();

            Assert.AreEqual(source.Address, operation.SourceAccount.Address);
            Assert.AreEqual(destination.Address, operation.Destination.Address);
            Assert.AreEqual(asset.Type, operation.Asset.Type);
            Assert.AreEqual(amount, operation.Amount);
            Assert.AreEqual(
                    "AAAAAQAAAAC7JAuE3XvquOnbsgv2SRztjuk4RoBVefQ0rlrFMMQvfAAAAAEAAAAA7eBSYbzcL5UKo7oXO24y1ckX+XuCtkDsyNHOp1n1bxAAAAAAAAAAAAAAA+g=",
                    operation.ToXdrBase64());

            Stellar.Generated.Operation xdr = operation.ToXDR();
            PaymentOperation parsedOperation = Stellar.PaymentOperation.FromXDR(xdr);

            Assert.AreEqual(source.Address, parsedOperation.SourceAccount.Address);
            Assert.AreEqual(destination.Address, parsedOperation.Destination.Address);
            Assert.AreEqual(asset.Type, parsedOperation.Asset.Type);
            Assert.AreEqual(amount, parsedOperation.Amount);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "destination cannot be null.")]
        public void PaymentOperationNullDestination()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");

            Asset asset = new Stellar.Asset();
            long amount = 1000;

            PaymentOperation operation = new PaymentOperation.Builder(null, asset, amount)
                .SetSourceAccount(source)
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "asset cannot be null.")]
        public void PaymentOperationNullAsset()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");
            // GDW6AUTBXTOC7FIKUO5BOO3OGLK4SF7ZPOBLMQHMZDI45J2Z6VXRB5NR
            KeyPair destination = KeyPair.FromSeed("SDHZGHURAYXKU2KMVHPOXI6JG2Q4BSQUQCEOY72O3QQTCLR2T455PMII");
            
            long amount = 1000;

            PaymentOperation operation = new PaymentOperation.Builder(destination, null, amount)
                .SetSourceAccount(source)
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "amount must be non-negative.")]
        public void PaymentOperationNegativeAmount()
        {
            // GC5SIC4E3V56VOHJ3OZAX5SJDTWY52JYI2AFK6PUGSXFVRJQYQXXZBZF
            KeyPair source = KeyPair.FromSeed("SC4CGETADVYTCR5HEAVZRB3DZQY5Y4J7RFNJTRA6ESMHIPEZUSTE2QDK");
            // GDW6AUTBXTOC7FIKUO5BOO3OGLK4SF7ZPOBLMQHMZDI45J2Z6VXRB5NR
            KeyPair destination = KeyPair.FromSeed("SDHZGHURAYXKU2KMVHPOXI6JG2Q4BSQUQCEOY72O3QQTCLR2T455PMII");

            Asset asset = new Stellar.Asset();

            PaymentOperation operation = new PaymentOperation.Builder(destination, asset, -1)
                .SetSourceAccount(source)
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "sourceAccount cannot be null.")]
        public void PaymentOperationNullSource()
        {
            // GDW6AUTBXTOC7FIKUO5BOO3OGLK4SF7ZPOBLMQHMZDI45J2Z6VXRB5NR
            KeyPair destination = KeyPair.FromSeed("SDHZGHURAYXKU2KMVHPOXI6JG2Q4BSQUQCEOY72O3QQTCLR2T455PMII");

            Asset asset = new Stellar.Asset();
            long amount = 1000;

            PaymentOperation operation = new PaymentOperation.Builder(destination, asset, amount)
                .SetSourceAccount(null)
                .Build();
        }
    }
}
