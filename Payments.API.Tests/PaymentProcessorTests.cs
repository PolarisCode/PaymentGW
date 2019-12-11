using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Payments.API.Contracts;
using Payments.API.Encryption;
using Payments.API.Exceptions;
using Payments.API.Models;
using Payments.API.Persistence;
using Payments.API.Processors;

namespace Payments.API.Tests
{
    [TestClass]
    public class PaymentProcessorTests
    {
        private readonly string _externalId = "123";
        private readonly decimal _amount = 100;
        private readonly string _cardNumber = "1111222233334444";
        private readonly string _maskerCardNumber = "**** **** **** 4444";
        private readonly int _expiryMonth = 6;
        private readonly int _expiryYear = 2020;
        private readonly string _currencyCode = "EUR";
        private readonly int _cvv = 245;
        private readonly string _billingId = "111";
        private readonly string _errorDesc = string.Empty;
        private readonly string _encryptedCardNumber = "encryptedValue";

        Mock<IBillingAdapter> billingAdapter;
        Mock<IPaymentValidator> paymentValidator;
        Mock<IPaymentRepository> paymentRepository;
        Mock<IEncryptor> encryptor;

        PaymentRequest request;

        [TestInitialize]
        public void Initialize()
        {
            billingAdapter = new Mock<IBillingAdapter>();
            paymentValidator = new Mock<IPaymentValidator>();
            paymentRepository = new Mock<IPaymentRepository>();
            encryptor = new Mock<IEncryptor>();

            request = new PaymentRequest()
            {
                ExternalID = _externalId,
                Amount = _amount,
                CardNumber = _cardNumber,
                ExpiryYear = _expiryYear,
                ExpiryMonth = _expiryMonth,
                CurrencyCode = _currencyCode,
                Cvv = _cvv
            };
        }

        [TestMethod]
        public void ProcessAsync_RequestValid_Success()
        {
            // Arrange
            var encryptedCardNumber = "encryptedValue";

            encryptor.Setup(x => x.Encrypt(_cardNumber)).Returns(encryptedCardNumber);

            PaymentProcessor processor = new PaymentProcessor(billingAdapter.Object, paymentValidator.Object,
                paymentRepository.Object, encryptor.Object);

            var response = new PaymentResponse()
            {
                BillingTransactionID = _billingId,
                ErrorDescription = _errorDesc,
                Success = true
            };

            paymentValidator.Setup(x => x.ValidateAsync(request)).ReturnsAsync(true);
            billingAdapter.Setup(x => x.SendRequestAsync(request)).ReturnsAsync(response);

            paymentRepository.Setup(x => x.SavePaymentRecordAsync(
                It.Is<PaymentRecord>(
                    p => p.Amount == _amount &&
                    p.BillingID == _billingId &&
                    p.BillingSuccess == true &&
                    p.CardExpirationMonth == _expiryMonth &&
                    p.CardExpirationYear == _expiryYear &&
                    p.CardNumber == encryptedCardNumber &&
                    p.CurrencyCode == _currencyCode &&
                    p.CVV == _cvv
                    )))
                    .Returns(Task.CompletedTask);

            // Act
            var paymentResponse = processor.ProcessAsync(request).Result;

            // Assert
            paymentValidator.Verify(x => x.ValidateAsync(request), Times.Once);
            billingAdapter.Verify(x => x.SendRequestAsync(request), Times.Once);
            paymentRepository.Verify(x => x.SavePaymentRecordAsync(It.IsAny<PaymentRecord>()), Times.Once);

            Assert.AreEqual(paymentResponse, response);
        }

        [TestMethod]
        public void ProcessAsync_ValidationException_Failed()
        {
            // Arrange
            encryptor.Setup(x => x.Decrypt(_cardNumber)).Returns(_encryptedCardNumber);

            PaymentProcessor processor = new PaymentProcessor(billingAdapter.Object, paymentValidator.Object,
                paymentRepository.Object, encryptor.Object);

            paymentValidator.Setup(x => x.ValidateAsync(request)).Throws(new CurrencyNotFoundException("Currency EUR not found"));

            // Act ==> Assert
            try
            {
                var result = processor.ProcessAsync(request).Result;
            }
            catch (AggregateException ex)
            {
                Assert.AreEqual(typeof(CurrencyNotFoundException), ex.InnerException.GetType());
            }
        }

        [TestMethod]
        public void ProcessAsync_NoBillingValue_ReturnNull()
        {
            // Arrange
            PaymentProcessor processor = new PaymentProcessor(billingAdapter.Object, paymentValidator.Object,
                paymentRepository.Object, encryptor.Object);

            paymentValidator.Setup(x => x.ValidateAsync(request)).ReturnsAsync(true);
            billingAdapter.Setup(x => x.SendRequestAsync(request)).Returns(Task.FromResult<PaymentResponse>(null));

            // Act
            var paymentResponse = processor.ProcessAsync(request).Result;

            // Assert
            paymentValidator.Verify(x => x.ValidateAsync(request), Times.Once);
            billingAdapter.Verify(x => x.SendRequestAsync(request), Times.Once);

            Assert.IsNull(paymentResponse);
        }

        [TestMethod]
        public void ReceivePaymentAsync_RequestValid_Success()
        {
            // Arrange
            encryptor.Setup(x => x.Decrypt(_encryptedCardNumber)).Returns(_cardNumber);

            PaymentProcessor processor = new PaymentProcessor(billingAdapter.Object, paymentValidator.Object,
                paymentRepository.Object, encryptor.Object);

            paymentRepository.Setup(x => x.GetPaymentRecordAsync(_externalId)).ReturnsAsync(new PaymentRecord()
            {
                Amount = _amount,
                BillingID = _billingId,
                BillingSuccess = true,
                CardExpirationMonth = _expiryMonth,
                CardExpirationYear = _expiryYear,
                CardNumber = _encryptedCardNumber,
                CurrencyCode = _currencyCode,
                CVV = _cvv
            });

            // Act
            var paymentDetails = processor.ReceivePaymentAsync(_externalId).Result;

            // Assert
            paymentRepository.Verify(x => x.GetPaymentRecordAsync(_externalId), Times.Once);

            encryptor.Verify(x => x.Decrypt(_encryptedCardNumber), Times.Once);

            Assert.AreEqual(_billingId, paymentDetails.BillingTransactionID);
            Assert.AreEqual(null, paymentDetails.ErrorDescription);
            Assert.AreEqual(_expiryYear.ToString(), paymentDetails.ExpirtyYear);
            Assert.AreEqual(_expiryMonth.ToString(), paymentDetails.ExpiryMonth);
            Assert.AreEqual(_maskerCardNumber, paymentDetails.MaskedCardNumber);
            Assert.AreEqual(true, paymentDetails.Success);
        }

        [TestMethod]
        public void ReceivePaymentAsync_ExternalIdNotFound_NullReturned()
        {
            // Arrange
            PaymentProcessor processor = new PaymentProcessor(billingAdapter.Object, paymentValidator.Object,
                paymentRepository.Object, encryptor.Object);

            paymentRepository.Setup(x => x.GetPaymentRecordAsync("123")).Returns(Task.FromResult<PaymentRecord>(null));

            // Act
            var paymentDetails = processor.ReceivePaymentAsync(_externalId).Result;

            // Assert
            paymentRepository.Verify(x => x.GetPaymentRecordAsync("123"), Times.Once);

            Assert.IsNull(paymentDetails);
        }
    }
}
